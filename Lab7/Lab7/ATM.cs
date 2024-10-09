using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    public class ATM
    {
        private List<Account> accounts = new List<Account>();
        public List<Account> Accounts { get => accounts; set => accounts = value; }

        public delegate void TransactionHandler(string message);
        public event TransactionHandler TransactionCompleted;
        protected virtual void OnTransactionCompleted(string message)
        {
            if (TransactionCompleted != null)
            {
                TransactionCompleted(message);
            }
        }
        public ATM()
        {
            Accounts = accounts;
        }
        public void addAccount(Account account)
        {
            accounts.Add(account);
        }
        public void WithDraw(Account account, float amount)
        {
            if (account.Withdraw(amount))
            {
                Console.WriteLine($"{account.AccountNumber} rút {amount} VND...");
                Console.WriteLine("Rút tiền thành công.");
                OnTransactionCompleted("...Send Message...");
                OnTransactionCompleted($"Số tài khoản: {account.AccountNumber}");
                OnTransactionCompleted($"Đã rút {amount} VND.");
                OnTransactionCompleted($"Số dư: {account.Balance} VND");
            }
            else
            {
                Console.WriteLine($"{account.AccountNumber} rút {amount} VND...");
                Console.WriteLine("Số dư hiện tại không đủ !!!");
            }
        }
        public void Transfer(Account fromAccount, Account toAccount, float amount)
        {
            if (fromAccount.Transfer(toAccount, amount))
            {
                Console.WriteLine($"{fromAccount.AccountNumber} chuyển {amount} VND...");
                Console.WriteLine("Chuyển tiền thành công.");
                OnTransactionCompleted("...Send Message...");
                OnTransactionCompleted($"Số tài khoản: {fromAccount.AccountNumber}");
                OnTransactionCompleted($"Đã chuyển {amount} VND đến số tài khoản {toAccount.AccountNumber}.");
                OnTransactionCompleted($"Số dư: {fromAccount.Balance} VND");
            }
            else
            {
                Console.WriteLine($"{fromAccount.AccountNumber} chuyển {amount} VND...");
                Console.WriteLine("Số dư hiện tại không đủ !!!");
            }
        }
    }
}
