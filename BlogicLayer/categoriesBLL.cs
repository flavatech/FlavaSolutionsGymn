using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavaGymn.BlogicLayer
{
    class categoriesBLL
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime dateAdded { get; set; }
        public int addedBy { get; set; }

    }
}
