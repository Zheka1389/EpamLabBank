using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BankEmulator.DbContexts;
using BankEmulator.Models;

namespace BankEmulator.Services
{
    public class UserAccountService
    {
        private bool logged;

        private BankAccountsRepository repository;

        private UserAccount userAccount;

        public UserAccountService(BaseAccount user)
        {
            this.Login(user);
        }

        public UserAccount GetUserAccount()
        {
            if (this.logged)
            {
                return this.userAccount;
            }

            throw new Exception("Wrong user credentials!");
        }

        public void PutMoney(double money)
        {
            if (this.logged)
            {
                this.userAccount.Put(money);
                if (this.userAccount.Credit < this.userAccount.Debit && this.userAccount.blocked)
                {
                    // unblock account in this case
                    this.userAccount.BlockAccount(false);
                }
            }
            else
            {
                throw new Exception("Wrong user credentials!");
            }
        }

        public void WithdrawMoney(double money)
        {
            if (this.logged)
            {
                Type t = this.userAccount.GetType();

                if (t == typeof(GoldUserAccount))
                {
                    this.userAccount.Withdraw(money);
                }
                else if (!this.userAccount.blocked)
                {
                    this.userAccount.Withdraw(money);
                }

                if (this.userAccount.Credit > this.userAccount.Debit && !this.userAccount.blocked)
                {
                    // to solve problem with liskov
                    if (t != typeof(GoldUserAccount))
                    {
                        // unblock account in this case
                        this.userAccount.BlockAccount(true);
                    }
                }
            }
            else
            {
                throw new Exception("Wrong user credentials!");
            }
        }

        private void Login(BaseAccount user)
        {
            if (user.userName.Length != 0 && user.password.Length != 0)
            {
                this.logged = true;
                this.repository = new BankAccountsRepository();
                this.repository.CreateUser(userName,password);
                this.userAccount = this.repository.GetAccount(userName, password);
            }
            else
            {
                this.logged = false;
            }
        }
    }
}
