using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    public class Tomato : Product
    {
        public Tomato()
        {
            Name = "Cà chua";
            Cost = 15;
            Value = 30;
            Duration = 5;  // thời gian chăm bón là 5 giây
            Fertilizer = 4;
            Water = 2;
        }

        public override void Seed()
        {
            Start = Environment.TickCount / 1000;
            Console.WriteLine($"Gieo hạt cà chua. thời gian chăm bón là 5 giây");
        }

        public override void Harvest()
        {
            if (IsReadyForHarvest())
            {
                Console.WriteLine("Thu hoạch cà chua");
                int totalCost = Cost + (NumFertilizer * Fertilizer) + (NumWater * Water);
                int profit = Value - totalCost;
                Console.WriteLine($"Thu hoạch {Name}, lãi {profit}");
            }
            else
            {
                Console.WriteLine("Cà chua chưa sẵn sàng thu hoạch.");
            }
        }
    }
}
