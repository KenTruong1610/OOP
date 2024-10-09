using lab8;
using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.InputEncoding = Encoding.Unicode;
        Console.OutputEncoding = Encoding.Unicode;
        Player player = new Player { UserName = "Player1", Reward = 100 };

        while (true)
        {
            Console.WriteLine($"\nNgười chơi: {player.UserName}, Điểm thưởng: {player.Reward}");
            Console.WriteLine("1. Mua sản phẩm");
            Console.WriteLine("2. Thu hoạch");
            Console.WriteLine("3. Tưới nước");
            Console.WriteLine("4. Bón phân");
            Console.WriteLine("5. Thoát");
            Console.Write("Chọn chức năng: ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Lựa chọn không hợp lệ!");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Chọn sản phẩm để mua:");
                    Console.WriteLine("1. Lúa mì (10 điểm)");
                    Console.WriteLine("2. Cà chua (15 điểm)");
                    Console.WriteLine("3. Hoa hướng dương (20 điểm)");
                    int productChoice = int.Parse(Console.ReadLine());

                    try
                    {
                        switch (productChoice)
                        {
                            case 1:
                                player.BuyProduct(new Wheat());
                                break;
                            case 2:
                                player.BuyProduct(new Tomato());
                                break;
                            case 3:
                                player.BuyProduct(new Sunflower());
                                break;
                            default:
                                Console.WriteLine("Sản phẩm không hợp lệ.");
                                break;
                        }
                    }
                    catch (InsufficientFundException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case 2:
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
                            if (player.Products[harvestChoice].IsReadyForHarvest())
                            {
                                player.Products.RemoveAt(harvestChoice);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Sản phẩm không hợp lệ.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Bạn chưa có sản phẩm nào để thu hoạch.");
                    }
                    break;

                case 3:
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
                            Console.WriteLine("Sản phẩm không hợp lệ.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Bạn chưa có sản phẩm nào để tưới nước.");
                    }
                    break;

                case 4:
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
                            Console.WriteLine("Sản phẩm không hợp lệ.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Bạn chưa có sản phẩm nào để bón phân.");
                    }
                    break;

                case 5:
                    Console.WriteLine("Tạm biệt!");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Lựa chọn không hợp lệ!");
                    break;
            }
        }
    }
}

