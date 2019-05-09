using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavaGymn.BlogicLayer
{
    class transactionsBLL
    {
        public int id { get; set; }
        public string type { get; set; }
        public int deal_cust_id { get; set; }
        public decimal grandTotal { get; set; }
        public DateTime transactionDate { get; set; }
        public decimal tax { get; set; }
        public decimal discount { get; set; }
        public int addedBy { get; set; }




    }
}
