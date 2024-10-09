using Lab_9;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
public class Player
{
    public string UserName { get; set; }
    public int InitialReward { get; set; } // Điểm thưởng ban đầu
    public int Reward { get; set; } // Điểm thưởng hiện tại
    public List<Product> Products { get; set; } = new List<Product>();

    public Player(string userName, int initialReward)
    {
        UserName = userName;
        InitialReward = initialReward;
        Reward = initialReward;
    }

    public void HarvestProduct(Product product)
    {
        if (product.IsReadyForHarvest())
        {
            product.Harvest();
            int profit = product.Value - (product.Cost + (product.NumFertilizer * product.FertilizerCost) + (product.NumWater * product.WaterCost));

            if (profit > 0)
            {
                Reward += profit;
                Console.WriteLine($"Bạn đã thu được {profit} điểm thưởng. Điểm thưởng hiện tại: {Reward}");
            }
            else
            {
                Console.WriteLine("Không có lãi từ vụ thu hoạch này.");
            }

            Products.Remove(product);
        }
        else
        {
            Console.WriteLine($"{product.Name} chưa sẵn sàng để thu hoạch.");
        }
    }

    public void WaterProduct(Product product)
    {
        if (Reward >= product.WaterCost)
        {
            product.Water();
            Console.WriteLine($"Đã tưới nước.");
        }
        else
        {
            Console.WriteLine("Không đủ điểm thưởng để tưới nước!");
        }
    }

    public void FeedProduct(Product product)
    {
        if (Reward >= product.FertilizerCost)
        {
            product.Feed();
            Console.WriteLine($"Đã bón phân.");
        }
        else
        {
            Console.WriteLine("Không đủ điểm thưởng để bón phân!");
        }
    }

    public void SavePlayer(string filePath)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(filePath, FileMode.Create))
        {
            formatter.Serialize(stream, this);
        }
        Console.WriteLine("Dữ liệu người chơi đã được lưu.");
    }

    public static Player LoadPlayer(string filePath)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(filePath, FileMode.Open))
        {
            Player player = (Player)formatter.Deserialize(stream);
            Console.WriteLine("Dữ liệu người chơi đã được tải.");
            return player;
        }
    }

    public void SavePlayerToText(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine($"Tên người chơi: {UserName}");
            writer.WriteLine($"Điểm thưởng ban đầu: {InitialReward}");
            writer.WriteLine($"Điểm thưởng hiện tại: {Reward}");
            writer.WriteLine("Danh sách sản phẩm:");
            foreach (var product in Products)
            {
                writer.WriteLine($"- Tên sản phẩm: {product.Name}");
                writer.WriteLine($"  Chi phí: {product.Cost}");
                writer.WriteLine($"  Giá trị: {product.Value}");
                writer.WriteLine($"  Số lần tưới nước: {product.NumWater}/{product.MaxWater}");
                writer.WriteLine($"  Số lần bón phân: {product.NumFertilizer}/{product.MaxFertilizer}");
            }
            Console.WriteLine($"Dữ liệu người chơi đã được lưu vào: {Path.GetFullPath(filePath)}");
        }
    }
}
