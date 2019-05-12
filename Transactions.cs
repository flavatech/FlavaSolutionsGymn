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
    public partial class Transactions : Form
    {
        public Transactions()
        {
            InitializeComponent();
        }


        transactionDAL tdal = new transactionDAL();
        private void SelectRole_Load(object sender, EventArgs e)
        {
            //Display all the transactions

            DataTable dt = tdal.DisplayAllTransactions();
            dgvTransactions.DataSource = dt;
        }

        private void CbTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get the value from the comboBox
            string type = cmbTransactionType.Text;
            DataTable dt = tdal.DisplayTransactionByType(type);


        }

        private void BntShowAll_Click(object sender, EventArgs e)
        {
            //Display all the transactions
            transactionDAL tdal = new transactionDAL();
            DataTable dt = tdal.DisplayAllTransactions();
            dgvTransactions.DataSource = dt;
        }
    }
}
