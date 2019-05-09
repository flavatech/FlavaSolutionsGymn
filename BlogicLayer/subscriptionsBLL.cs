using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavaGymn.BlogicLayer
{
    class subscriptionsBLL
    {
        //getters and Setters for products module
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public decimal quantity { get; set; }
        public string category { get; set; }
        public DateTime dateAddeded { get; set; }
        public int addedBy { get; set; }

    }
}
