using Lab_9;
using System;
using System.Xml.Linq;

[Serializable]
public class Tomato : Product
{
    public Tomato()
    {
        Name = "Cà chua";
        Cost = 15;
        Value = 30;
        Duration = 7;  // 7 giây để thu hoạch
        FertilizerCost = 3;
        WaterCost = 2;
        MaxFertilizer = 1;
        MaxWater = 2;
    }

    public override void Seed()
    {
        StartTime = Environment.TickCount / 1000;  // Lưu thời gian gieo
        Console.WriteLine($"Gieo hạt cà chua. Cần 7 giây để thu hoạch");
    }

    public override void Harvest()
    {
        if (IsReadyForHarvest())
        {
            Console.WriteLine("Thu hoạch cà chua");
            int totalCost = Cost + (NumFertilizer * FertilizerCost) + (NumWater * WaterCost);
            int profit = Value - totalCost;
            Console.WriteLine($"Thu hoạch {Name}, lãi {profit}");
        }
        else
        {
            Console.WriteLine("Cà chua chưa sẵn sàng thu hoạch.");
        }
    }
}

