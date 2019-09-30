using System;
using System.Runtime.CompilerServices;

namespace BankEmulator.Models
{
    public class UserAccount : BaseAccount
    {

        public bool blocked = false;
        public UserAccount(int id, string userName) : base(id, userName)
        {
        }

        public virtual void BlockAccount(bool blocked)
        {
            this.blocked = blocked;
        }
    }
}