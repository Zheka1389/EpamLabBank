using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankEmulator.Models
{
    public abstract class BaseAccount
    {
        public readonly int id;
        public readonly string userName;
        public double Credit;
        public double Debit;

        public  BaseAccount(int id, string userName, string password)
        {
            this.id = id;
            this.userName = userName;
            
        }

        // simple account can't have Credit> Debit
        public void Put(double moneyToDebit)
        {
            this.Debit += moneyToDebit;
        }

        public void Withdraw(double moneyToCredit)
        {
            this.Credit += moneyToCredit;
        }       
    }
}
