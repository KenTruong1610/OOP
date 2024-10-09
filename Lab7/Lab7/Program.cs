using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab7
{
    public class Program
    {
        static public void PrintAccount(List<Account> acc)
        {
            foreach (Account account in acc)
            {
                Console.WriteLine(account);
            }
        }
        public static void ShowMenu(ATM atm)
        {
            while (true)
            {
                PrintAccount(atm.Accounts);
                Console.WriteLine("Chọn hành động:");
                Console.WriteLine("1. Rút tiền");
                Console.WriteLine("2. Chuyển tiền");
                Console.WriteLine("3. Thoát\n");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Nhập số tài khoản:");
                        string accountNum = Console.ReadLine();
                        Account account = atm.Accounts.Find(a => a.AccountNumber == accountNum);
                        if (account != null)
                        {
                            Console.WriteLine("Nhập số tiền muốn rút:");
                            float amount = float.Parse(Console.ReadLine());
                            Console.WriteLine();
                            atm.WithDraw(account, amount);
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Tài khoản không tồn tại.");
                        }
                        Console.WriteLine("***Nhấn Enter để tiếp tục***");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "2":
                        Console.WriteLine("Nhập số tài khoản chuyển:");
                        string fromAccountNum = Console.ReadLine();
                        Account fromAccount = atm.Accounts.Find(a => a.AccountNumber == fromAccountNum);
                        if (fromAccount != null)
                        {
                            Console.WriteLine("Nhập số tài khoản nhận:");
                            string toAccountNum = Console.ReadLine();
                            Account toAccount = atm.Accounts.Find(a => a.AccountNumber == toAccountNum);
                            if (toAccount != null)
                            {
                                Console.WriteLine("Nhập số tiền muốn chuyển:");
                                float amount = float.Parse(Console.ReadLine());
                                Console.WriteLine();
                                atm.Transfer(fromAccount, toAccount, amount);
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine("Tài khoản nhận không tồn tại.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Tài khoản chuyển không tồn tại.");
                        }
                        Console.WriteLine("***Nhấn Enter để tiếp tục***");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Cảm ơn đã sử dụng");
                        Thread.Sleep(1300);
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Clear();
            ATM atm = new ATM();
            atm.TransactionCompleted += (message) => Console.WriteLine($"{message}");

            atm.addAccount(new Account("0101", 200000f));
            atm.addAccount(new Account("2220", 3000000f));
            atm.addAccount(new Account("6012", 500000f));

            ShowMenu(atm);

            Console.ReadKey();
        }
    }
}
