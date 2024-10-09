using System;

namespace Lab_9
{
    [Serializable]
    public abstract class Product
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Value { get; set; }
        public int Duration { get; set; } // Thời gian chăm sóc tính bằng giây
        public int FertilizerCost { get; set; }
        public int WaterCost { get; set; }
        public int StartTime { get; set; }
        public int NumFertilizer { get; set; }
        public int NumWater { get; set; }
        public int MaxFertilizer { get; set; }
        public int MaxWater { get; set; }

        public abstract void Seed();
        public abstract void Harvest();

        public void Water()
        {
            if (NumWater < MaxWater)
            {
                NumWater++;
                Console.WriteLine($"Tưới nước cho {Name}. Số lần tưới: {NumWater}/{MaxWater}");
            }
            else { Console.WriteLine("Quá số lần thực hiện"); }
        }

        public void Feed()
        {
            if (NumFertilizer < MaxFertilizer)
            {
                NumFertilizer++;
                Console.WriteLine($"Bón phân cho {Name}. Số lần bón phân: {NumFertilizer}/{MaxFertilizer}");
            }
            else
            {
                Console.WriteLine("Quá số lần thực hiện");
            }
        }

        public bool IsReadyForHarvest()
        {
            int currentTime = Environment.TickCount / 1000;  // Tính bằng giây
            return (currentTime - StartTime) >= Duration;
        }
    }
}
