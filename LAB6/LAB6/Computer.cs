using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB6
{
    public class Computer : ICloneable
    {
        string id;
        string title;
        string color;
        string country;
        string company;
        uint price;
        public byte quantity;
        byte expired;
        bool OS_setup;

        public Computer(string id, string title, string color, string country,
          string company, uint price, byte quantity,
          byte expired, bool OS_setup)
        {
            this.id = id;
            this.title = title;
            this.color = color;
            this.country = country;
            this.company = company;
            this.price = price;
            this.quantity = quantity;
            this.expired = expired;
            this.OS_setup = OS_setup;
        }
        public static string GetHeader()
        {
            return string.Format("{0,-10} | {1,-15} | {2,-10} | {3,-10} | {4,-10} | {5,-8} | {6,-8} | {7,-8} | {8,-8}",
                                 "ID", "Title", "Color", "Country", "Company", "Price", "Qty", "Expired", "OS_Setup");
        }

        public override string ToString()
        {
            return string.Format("{0,-10} | {1,-15} | {2,-10} | {3,-10} | {4,-10} | {5,-8} | {6,-8} | {7,-8} | {8,-8}",
                                 id, title, color, country, company, price, quantity, expired, OS_setup);
        }
        public bool CheckStatus()
        {
            return quantity > 0;
        }

        public bool find(string kw)
        {
            return title.IndexOf(kw) >= 0 || country.Equals(kw);
        }
        public bool find(uint fr, uint to)
        {
            return price >= fr && quantity <= to;
        }


        public object Clone()
        {
            return new Computer(id, title, color, country, company,
                price, quantity, expired, OS_setup);
        }
    }
}
