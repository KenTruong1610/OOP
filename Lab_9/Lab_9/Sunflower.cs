using Lab_9;
using System;
using System.Xml.Linq;

[Serializable]
public class Sunflower : Product
{
    public Sunflower()
    {
        Name = "Hoa hướng dương";
        Cost = 20;
        Value = 40;
        Duration = 10;  // 10 giây để thu hoạch
        FertilizerCost = 4;
        WaterCost = 3;
        MaxFertilizer = 1;
        MaxWater = 2;
    }

    public override void Seed()
    {
        StartTime = Environment.TickCount / 1000;  // Lưu thời gian gieo
        Console.WriteLine($"Gieo hạt hoa hướng dương. Cần 10 giây để thu hoạch");
    }

    public override void Harvest()
    {
        if (IsReadyForHarvest())
        {
            Console.WriteLine("Thu hoạch hoa hướng dương");
            int totalCost = Cost + (NumFertilizer * FertilizerCost) + (NumWater * WaterCost);
            int profit = Value - totalCost;
            Console.WriteLine($"Thu hoạch {Name}, lãi {profit}");
        }
        else
        {
            Console.WriteLine("Hoa hướng dương chưa sẵn sàng thu hoạch.");
        }
    }
}
