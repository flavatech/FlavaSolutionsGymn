using FlavaGymn.BlogicLayer;
using FlavaGymn.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlavaGymn
{
    public partial class PurchasesAndSales : Form
    {
        public PurchasesAndSales()
        {
            InitializeComponent();
        }

        subscriptionsBLL p = new subscriptionsBLL();
        subscriptionsDAL sDAL = new subscriptionsDAL();

        private void SelectRole_Load(object sender, EventArgs e)
        {

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //Get all the values from the form
           

        }

        private void BtnClear_Click(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
