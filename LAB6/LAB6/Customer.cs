using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB6
{
    public class Customer
    {
        private string name;
        private string address;
        private string phone;

        public Customer(string name, string address, string phone)
        {
            this.name = name;
            this.address = address;
            this.phone = phone;
        }
        public Computer order(Computer computer)
        {
            if (computer.CheckStatus())
            {
                Computer mycom = (Computer)computer.Clone();
                computer.quantity--; 
                //thay đổi thuộc tính 
                return mycom;
            }
            else
            {
                throw new InvalidOperationException("Computer is out of stock and cannot be ordered.");
            }
        }


    }
}
