using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB6
{
    public class Store
    {
        public List<Computer> computers { get; }

        public Store()
        {
            computers = new List<Computer>();
        }
        public void add(Computer computer)
        {
            computers.Add(computer);
        }
        public void remove(Computer computer)
        {
            computers.Remove(computer);
        }
        public List<Computer> find(string kw)
        {
            List<Computer> result = new List<Computer>();
            foreach (Computer computer in computers)
                if (computer.find(kw))
                    result.Add(computer);
            return result;
        }
        public List<Computer> find(uint fr, uint to)
        {
            return null;
        }
    }
}
