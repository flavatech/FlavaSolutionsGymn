using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavaGymn.DashBoards.BlogicLayer
{
    class userBLL
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string activity { get; set; }
        public string address { get; set; }
        public DateTime dateCreated { get; set; }
        public int weightGoal { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string gender { get; set; }
        public string emailAddress { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string phoneNumber { get; set; }
        public int addedBy { get; set; }
        public string userType { get; set; }


    }
}
