using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankEmulator.Models;

namespace BankEmulator.DbContexts
{
    public class BankAccountsRepository
    {
        private List<UserAccount> usersAccountsSource = new List<UserAccount>();

        public BankAccountsRepository()
        {
            
            //this.InitRepository();
        }

        public UserAccount GetAccount(string userName, string password)
        {
            return usersAccountsSource.First();
        }

        public UserAccount CreateAccount(string userName, string password)
        {
            if(usersAccountsSource.Contains())
        }
        private void InitUser(int id, string userName)
        {
                var acc = new UserAccount(id, userName)
                {
                    Credit = 0,
                    Debit = 0
                };
                this.usersAccountsSource.Add(acc);
        }
    }
}
