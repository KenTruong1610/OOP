using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    public class Account : ICloneable
    {
        private string accountNumber;
        private float balance;
        public string AccountNumber { get => accountNumber; set => accountNumber = value; }
        public float Balance { get => balance; set => balance = value; }
        public Account(string accountNumber, float balance)
        {
            this.accountNumber = accountNumber;
            this.balance = balance;
        }
        public object Clone()
        {
            return new Account(accountNumber, balance);
        }
        public bool Withdraw(float amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
                return true;
            }
            return false;
        }
        public bool Transfer(Account toAccount, float amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
                toAccount.Balance += amount;
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return $"So TK: {accountNumber} \nSo du: {balance} VND\n";
        }
    }
}

