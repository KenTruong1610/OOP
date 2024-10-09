using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    public class Player
    {
        public string UserName { get; set; }
        public int Reward { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();

        public void BuyProduct(Product product)
        {
            if (Reward >= product.Cost)
            {
                Products.Add(product);
                product.Seed();
            }
            else
            {
                throw new InsufficientFundException("Không đủ tiền!");
            }
        }

        public void HarvestProduct(Product product)
        {
            product.Harvest();
            if (product.IsReadyForHarvest())
            {
                int profit = product.Value - product.Cost - ((product.NumFertilizer * product.Fertilizer) + (product.NumWater * product.Water));
                Reward += profit > 0 ? profit : 0;
            }
        }

        public void WaterProduct(Product product)
        {
            Console.WriteLine($"Tưới nước cho {product.Name}");
            product.ProvWater();
            if (Reward < 0)
            {
                Reward = 0;
                Console.WriteLine("Bạn không đủ điểm thưởng để tiếp tục tưới nước.");
            }
        }

        public void FeedProduct(Product product)
        {
            Console.WriteLine($"Bón phân cho {product.Name}");
            product.Feed();
            if (Reward < 0)
            {
                Reward = 0;
                Console.WriteLine("Bạn không đủ điểm thưởng để tiếp tục bón phân.");
            }
        }
    }

}
