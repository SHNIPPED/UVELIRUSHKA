using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_World.Classes
{
    public class Categories
    {
        public int id { get; set; }

        public string name { get; set; }

        public Categories (int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
