using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class SalesOrders
    {
        public int order_id { get; set; }
        public int customer_id { get; set; }
        public int order_status { get; set; }
        public DateTime order_date { get; set; }
        public DateTime required_date { get; set; }
        public DateTime shipped_date { get; set; }
        public int store_id { get; set; }
        public int staff_id { get; set; }
    }
}