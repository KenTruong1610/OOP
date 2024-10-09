using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab_9
{
    class Program
    {
        static void Main()
        {
            Player player;

            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            // Kiểm tra xem có tệp lưu trước đó không
            if (File.Exists("playerData.dat"))
            {
                player = Player.LoadPlayer("playerData.dat");
            }
            else
            {
                player = new Player("Tùng", 100); // Tạo người chơi mới nếu không có tệp lưu
            }

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- Game Nông Nghiệp ---");
                Console.WriteLine($"Người chơi: {player.UserName}, Điểm thưởng hiện tại: {player.Reward}");
                Console.WriteLine("1. Mua sản phẩm");
                Console.WriteLine("2. Tưới nước cho sản phẩm");
                Console.WriteLine("3. Bón phân cho sản phẩm");
                Console.WriteLine("4. Thu hoạch sản phẩm");
                Console.WriteLine("5. Lưu trò chơi");
                Console.WriteLine("6. Thoát");
                Console.Write("Chọn hành động: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Chọn sản phẩm để mua:");
                        Console.WriteLine("1. Lúa mì (10 điểm)");
                        Console.WriteLine("2. Cà chua (15 điểm)");
                        Console.WriteLine("3. Hoa hướng dương (20 điểm)");
                        string productChoice = Console.ReadLine();

                        Product product = null;

                        switch (productChoice)
                        {
                            case "1":
                                product = new Wheat();
                                break;
                            case "2":
                                product = new Tomato();
                                break;
                            case "3":
                                product = new Sunflower();
                                break;
                            default:
                                Console.WriteLine("Lựa chọn không hợp lệ.");
                                break;
                        }

                        if (product != null && player.Reward >= product.Cost)
                        {
                            player.Products.Add(product);
                            product.Seed();
                            Console.WriteLine($"Đã mua {product.Name}. Điểm thưởng hiện tại: {player.Reward}");
                        }
                        else if (product != null)
                        {
                            Console.WriteLine("Không đủ điểm thưởng để mua sản phẩm.");
                        }
                        break;

                    case "2":
                        if (player.Products.Count > 0)
                        {
                            Console.WriteLine("Chọn sản phẩm để tưới nước:");
                            for (int i = 0; i < player.Products.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {player.Products[i].Name}");
                            }
                            int waterChoice = int.Parse(Console.ReadLine()) - 1;

                            if (waterChoice >= 0 && waterChoice < player.Products.Count)
                            {
                                player.WaterProduct(player.Products[waterChoice]);
                            }
                            else
                            {
                                Console.WriteLine("Lựa chọn không hợp lệ.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Không có sản phẩm nào.");
                        }
                        break;

                    case "3":
                        if (player.Products.Count > 0)
                        {
                            Console.WriteLine("Chọn sản phẩm để bón phân:");
                            for (int i = 0; i < player.Products.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {player.Products[i].Name}");
                            }
                            int feedChoice = int.Parse(Console.ReadLine()) - 1;

                            if (feedChoice >= 0 && feedChoice < player.Products.Count)
                            {
                                player.FeedProduct(player.Products[feedChoice]);
                            }
                            else
                            {
                                Console.WriteLine("Lựa chọn không hợp lệ.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Không có sản phẩm nào.");
                        }
                        break;

                    case "4":
                        if (player.Products.Count > 0)
                        {
                            Console.WriteLine("Chọn sản phẩm để thu hoạch:");
                            for (int i = 0; i < player.Products.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {player.Products[i].Name}");
                            }
                            int harvestChoice = int.Parse(Console.ReadLine()) - 1;

                            if (harvestChoice >= 0 && harvestChoice < player.Products.Count)
                            {
                                player.HarvestProduct(player.Products[harvestChoice]);
                            }
                            else
                            {
                                Console.WriteLine("Lựa chọn không hợp lệ.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Không có sản phẩm nào.");
                        }
                        break;

                    case "5":
                        player.SavePlayer("playerData.dat");
                        player.SavePlayerToText("playerData.txt");
                        break;

                    case "6":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        break;
                }
            }
        }
    }
}
