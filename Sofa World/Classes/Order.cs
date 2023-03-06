using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_World.Classes
{
    public class Order
    {
        public int id { get; set; }

        public string order_date { get; set; }

        public string delivery_date { get; set; }
        public string point_of_issue { get; set; }

        public int id_client { get; set; }
        public string receive_code { get; set; }

        public string order_status { get; set; }

        
        public Order(int id, string order_date, string delivery_date, string point_of_issue, int id_client, string receive_code, string order_status)
        {
            this.id = id;
            this.order_date = order_date;
            this.delivery_date = delivery_date;
            this.point_of_issue = point_of_issue;
            this.id_client = id_client;
            this.receive_code = receive_code;
            this.order_status = order_status;
        }
    }
}
