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
    public partial class adminDashBoard : Form
    {

        public adminDashBoard()
        {
            InitializeComponent();
        }
        //Set a public static method to specify whether the form is  purchase or sales
        public static string transactionType;

        private void AddStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStaff Form = new AddStaff();
            Form.Show();
        }

        private void AddMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addUser Form = new addUser();
            Form.Show();
        }

        private void AdminDashBoard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form Login = new Login();
            Login.Show();
            this.Hide();
        }

        private void AdminDashBoard_Load(object sender, EventArgs e)
        {
            lblLoggegInUser.Text = Login.loggedIn;
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            Form Login = new Login();
            Login.Show();
            this.Hide();
        }

        private void SubscriptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Subscriptions Form = new Subscriptions();
            Form.Show();

        }

        private void CategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Categories Form = new Categories();
            Form.Show();

        }

        private void CustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customers Form = new Customers();
            Form.Show();
        }

         private void PurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // set value on transactionType
            transactionType = "Purchase";
            PurchasesAndSales purchase = new PurchasesAndSales();
            purchase.Show();


        }

        private void PurchaseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // set value on transactionType
            transactionType = "Sales";
            PurchasesAndSales sales = new PurchasesAndSales();
            sales.Show();

        }
    }
}
