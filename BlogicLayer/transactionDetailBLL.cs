using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavaGymn.BlogicLayer
{
    class transactionDetailBLL
    {
        public int id { get; set; }
        public int subscriptionid { get; set; }
        public decimal price { get; set; }
        public decimal quantity { get; set; }
        public decimal total { get; set; }
        public int dealer_cust_id { get; set; }
        public DateTime addedDate { get; set; }
        public int addedBy { get; set; }
        }
}
