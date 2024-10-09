using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    public class Wheat : Product
    {
        public Wheat()
        {
            Name = "Lúa mì";
            Cost = 10;
            Value = 20;
            Duration = 7;  // thời gian chăm bón là 7 giây
            Fertilizer = 2;
            Water = 1;
        }

        public override void Seed()
        {
            Start = Environment.TickCount / 1000;
            Console.WriteLine($"Gieo hạt lúa mì. Thời gian chăm bón là 7 giây");
        }

        public override void Harvest()
        {
            if (IsReadyForHarvest())
            {
                Console.WriteLine("Thu hoạch lúa mì");
                int totalCost = Cost + (NumFertilizer * Fertilizer) + (NumWater * Water);
                int profit = Value - totalCost;
                Console.WriteLine($"Thu hoạch {Name}, lãi {profit}");
            }
            else
            {
                Console.WriteLine("Lúa mì chưa sẵn sàng thu hoạch.");
            }
        }
    }
}
