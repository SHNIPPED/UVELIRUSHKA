using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_World.Classes
{
    public class OrderProduct
    {
        public int id { get; set; }

        public int orderID { get; set; }
        public string product_article { get; set; }
        public string amount { get; set; }
        public int id_client { get; set; }

        public OrderProduct(int id, int orderID, string product_article, string amount , int id_client)
        {
            this.id = id;
            this.orderID = orderID;
            this.product_article = product_article;
            this.amount = amount;
            this.id_client = id_client;
        }
    }
}
