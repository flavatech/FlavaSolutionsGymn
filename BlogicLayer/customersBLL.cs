using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavaGymn.BlogicLayer
{
    class customersBLL
    {
        public int id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string emailAddress { get; set; }
        public string contact { get; set; }
        public string address { get; set; }
        public DateTime addedDate { get; set; }
        public int addedBy { get; set; }

    }
}
