using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB6
{
    public class Program
    {
        public static void PrintComputers(List<Computer> computers)
        {
            foreach (Computer computer in computers)
                Console.WriteLine(computer);            
        }
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Store store = new Store();
            store.computers.Add(new Computer("Com01", "Dell XPS 2020",
            "white", "Indonesia", "Dell", 25000000, 23,
            12, true));
            store.computers.Add(new Computer("Com02", "LG gram 2022",
            "black", "Vietnam", "LG", 27000000, 17,
            12, true));
            store.computers.Add(new Computer("Com03", "MSI katana 15",
            "black", "Taiwan", "MSI", 32000000, 15,
            15, true));
            store.computers.Add(new Computer("Com04", "Lenovo Legion 5",
            "sliver", "Taiwan", "Lenovo", 20000000, 7,
            15, true));
            store.computers.Add(new Computer("Com05", "Acer Predator",
            "Black", "Taiwan", "Acer", 29000000, 10,
            12, true));
            store.computers.Add(new Computer("Com06", "Surface Laptop", 
            "Silver", "USA", "Microsoft", 30000000, 8,
            12, true));
            store.computers.Add(new Computer("Com07", "MacBook Pro", 
            "Gray", "USA", "Apple", 50000000, 12,
            12, false));
            store.computers.Add(new Computer("Com08", "Asus ROG",
            "Red", "Taiwan", "Asus", 25000000, 18,
            12, true));
            store.computers.Add(new Computer("Com09", 
            "Razer Blade", "Black", "USA", "Razer", 35000000, 0, 
            12, true));
            store.computers.Add(new Computer("Com10", "Lenovo Loq", 
            "Black", "China", "Lenovo", 18000000, 20,
            12, true));

            Console.WriteLine(Computer.GetHeader());
            Console.WriteLine(new string('-', 120));
            PrintComputers(store.computers);

            // Tạo một khách hàng và thử đặt hàng
            Customer customer1 = new Customer("Việt Tùng", "238 Ly Thai To", "0191924382");
            try
            {
                Computer orderedComputer1 = customer1.order(store.computers[9]);
                // Đặt mua máy tính đầu tiên
                Console.WriteLine("Order Successful");
                Console.WriteLine(Computer.GetHeader());
                Console.WriteLine(new string('-', 120));
                Console.WriteLine(orderedComputer1);

            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Customer customer1 Order Failed: {ex.Message}");
            }

            //Kiểm tra hàng còn lại
            Console.WriteLine("\nDanh sách máy tính còn lại sau khi đặt hàng: ");
            PrintComputers(store.computers);


            Console.ReadKey();
        }
    }
}
