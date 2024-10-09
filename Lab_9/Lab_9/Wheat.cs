using Lab_9;
using System;
using System.Xml.Linq;

[Serializable]
public class Wheat : Product
{
    public Wheat()
    {
        Name = "Lúa mì";
        Cost = 10;
        Value = 20;
        Duration = 5;  // 5 giây để thu hoạch
        FertilizerCost = 2;
        WaterCost = 1;
        MaxFertilizer = 1;
        MaxWater = 2;
    }

    public override void Seed()
    {
        StartTime = Environment.TickCount / 1000;  // Lưu thời gian gieo
        Console.WriteLine($"Gieo hạt lúa mì. Cần 5 giây để thu hoạch");
    }

    public override void Harvest()
    {
        if (IsReadyForHarvest())
        {
            Console.WriteLine("Thu hoạch lúa mì");
            int totalCost = Cost + (NumFertilizer * FertilizerCost) + (NumWater * WaterCost);
            int profit = Value - totalCost;
            Console.WriteLine($"Thu hoạch {Name}, lãi {profit}");
        }
        else
        {
            Console.WriteLine("Lúa mì chưa sẵn sàng thu hoạch.");
        }
    }
}
