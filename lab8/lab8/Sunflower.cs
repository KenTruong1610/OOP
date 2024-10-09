using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    public class Sunflower : Product
    {
        public Sunflower()
        {
            Name = "Hoa hướng dương";
            Cost = 20;
            Value = 40;
            Duration = 10;  // thời gian chăm bón là 10 giây
            Fertilizer = 7;
            Water = 5;
        }

        public override void Seed()
        {
            Start = Environment.TickCount / 1000;
            Console.WriteLine($"Gieo hạt hoa hướng dương. Thời gian chăm bón là 10 giây.");
        }

        public override void Harvest()
        {
            if (IsReadyForHarvest())
            {
                Console.WriteLine("Thu hoạch hoa hướng dương");
                int totalCost = Cost + (NumFertilizer * Fertilizer) + (NumWater * Water);
                int profit = Value - totalCost;
                Console.WriteLine($"Thu hoạch {Name}, lãi {profit}");
            }
            else
            {
                Console.WriteLine("Hoa hướng dương chưa sẵn sàng thu hoạch.");
            }
        }
    }
}
