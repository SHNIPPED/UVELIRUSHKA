using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_World.Classes
{
    public class Chech
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string price { get; set; }
        public string discount { get; set; }

        public Chech(int id,string name, string price, string discount)
        {
            this.id = id;
            Name = name;
            this.price = price;
            this.discount = discount;
        }
    }
}
