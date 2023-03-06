using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_World.Classes
{
    public class Product
    {
        public int id { get; set; }
        public string article { get; set; }
        public string name { get; set; }
        public string measure_unit { get; set; }
        public string price { get; set; }
        public string max_discount { get; set; }
        public string manufacturer { get; set; }
        public string supplier { get; set; }
        public string category_id { get; set; }
        public string discount { get; set; }
        public string amount_on_warehouse { get; set; }
        public string description { get; set; }
        public string img_src { get; set; }

        public Product(int id, string article, string name, string measure_unit, string price, string max_discount, string manufacturer, string supplier, string category_id, string discount, string amount_on_warehouse, string description, string img_src)
        {
            this.id = id;
            this.article = article;
            this.name = name;
            this.measure_unit = measure_unit;
            this.price = price;
            this.max_discount = max_discount;
            this.manufacturer = manufacturer;
            this.supplier = supplier;
            this.category_id = category_id;
            this.discount = discount;
            this.amount_on_warehouse = amount_on_warehouse;
            this.description = description;
            this.img_src = img_src;
        }
    }
}
