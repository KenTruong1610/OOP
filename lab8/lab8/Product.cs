using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    public abstract class Product
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Value { get; set; }
        public int Start { get; set; } // Thời gian bắt đầu gieo trồng (giây)
        public int Duration { get; set; }  // Thời gian chăm bón (giây)
        public int Fertilizer { get; set; }
        public int Water { get; set; }
        public int NumFertilizer { get; set; }
        public int NumWater { get; set; }

        public bool IsReadyForHarvest()
        {
            int currentTime = Environment.TickCount / 1000;
            return (currentTime - Start) >= Duration;
        }

        public abstract void Seed();
        public abstract void Harvest();

        public void Feed()
        {
            NumFertilizer++;
            Console.WriteLine($"Đã bón phân cho {Name}. Tổng số lần bón phân: {NumFertilizer}");
        }

        public void ProvWater()
        {
            NumWater++;
            Console.WriteLine($"Đã tưới nước cho {Name}. Tổng số lần tưới: {NumWater}");
        }
    }

}
