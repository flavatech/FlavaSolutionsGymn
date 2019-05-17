using FlavaGymn.DAL;
using FlavaGymn.DashBoards.BlogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlavaGymn
{
    public partial class StaffReport : Form
    {
        public StaffReport()
        {
            InitializeComponent();
        }

        userBLL u = new userBLL();
        userDAL d = new userDAL();

        private void SelectRole_Load(object sender, EventArgs e)
        {

            DataTable dt = d.SelectSI();
            dgvStaffrep.DataSource = dt;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {

        }




    }
}
