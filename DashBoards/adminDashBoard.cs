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
            {
                bool found = false;
                try
                {
                    for (int i = 0; i < Application.OpenForms.Count; i++)
                    {
                        //Checks if the window is already open, and brings it to the front if it is
                        Form n = Application.OpenForms[i];
                        if (n.Name == "AddStaff")
                        {
                            n.BringToFront();
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        AddStaff aForm = new AddStaff();
                        aForm.Name = "AddStaff";
                        aForm.Show();
                    }
                }
                catch
                {
                }
            }
        }

        private void AddMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                bool found = false;
                try
                {
                    for (int i = 0; i < Application.OpenForms.Count; i++)
                    {
                        //Checks if the window is already open, and brings it to the front if it is
                        Form n = Application.OpenForms[i];
                        if (n.Name == "addUser")
                        {
                            n.BringToFront();
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        addUser aForm = new addUser();
                        aForm.Name = "addUser";
                        aForm.Show();
                    }
                }
                catch
                {
                }
            }
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

            {
                bool found = false;
                try
                {
                    for (int i = 0; i < Application.OpenForms.Count; i++)
                    {
                        //Checks if the window is already open, and brings it to the front if it is
                        Form n = Application.OpenForms[i];
                        if (n.Name == "Subscriptions")
                        {
                            n.BringToFront();
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        Subscriptions aForm = new Subscriptions();
                        aForm.Name = "Subscriptions";
                        aForm.Show();
                    }
                }
                catch
                {
                }
            }
        }



        private void CustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                bool found = false;
                try
                {
                    for (int i = 0; i < Application.OpenForms.Count; i++)
                    {
                        //Checks if the window is already open, and brings it to the front if it is
                        Form n = Application.OpenForms[i];
                        if (n.Name == "Customers")
                        {
                            n.BringToFront();
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        Customers aForm = new Customers();
                        aForm.Name = "Customers";
                        aForm.Show();
                    }
                }
                catch
                {
                }
            }
        }



        private void InventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

            {
                bool found = false;
                try
                {
                    for (int i = 0; i < Application.OpenForms.Count; i++)
                    {
                        //Checks if the window is already open, and brings it to the front if it is
                        Form n = Application.OpenForms[i];
                        if (n.Name == "Inventory")
                        {
                            n.BringToFront();
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        Inventory aForm = new Inventory();
                        aForm.Name = "Inventory";
                        aForm.Show();
                    }
                }
                catch
                {
                }
            }
        }

        private void PurchaseToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            {
                bool found = false;
                try
                {
                    for (int i = 0; i < Application.OpenForms.Count; i++)
                    {
                        //Checks if the window is already open, and brings it to the front if it is
                        Form n = Application.OpenForms[i];
                        if (n.Name == "PurchasesAndSales")
                        {
                            n.BringToFront();
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        transactionType = "Purchases";
                        PurchasesAndSales Purchases = new PurchasesAndSales();
                        Purchases.Name = "PurchasesAndSales";
                        Purchases.Show();
                    }
                }
                catch
                {
                }
            }

           // transactionType = "Purchases";
           // PurchasesAndSales Purchases = new PurchasesAndSales();

          //  Purchases.Show();
        }


        private void SalesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            {
                bool found = false;
                try
                {
                    for (int i = 0; i < Application.OpenForms.Count; i++)
                    {
                        //Checks if the window is already open, and brings it to the front if it is
                        Form n = Application.OpenForms[i];
                        if (n.Name == "PurchasesAndSales")
                        {
                            n.BringToFront();
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        transactionType = "Sales";
                        PurchasesAndSales Sales = new PurchasesAndSales();
                        Sales.Name = "PurchasesAndSales";
                        Sales.Show();
                    }
                }
                catch
                {
                }
            }


            //transactionType = "Sales";
           // PurchasesAndSales Sales = new PurchasesAndSales();

           // Sales.Show();
        }



        private void TransactionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                bool found = false;
                try
                {
                    for (int i = 0; i < Application.OpenForms.Count; i++)
                    {
                        //Checks if the window is already open, and brings it to the front if it is
                        Form n = Application.OpenForms[i];
                        if (n.Name == "Transactions")
                        {
                            n.BringToFront();
                            found = true;
                        }
                    }
                    if (!found)
                    {

                        Transactions Form = new Transactions();
                        Form.Name = "Transactions";
                        Form.Show();
                    }
                }
                catch
                {
                }
            }

        }




        private void CategoriesToolStripMenuItem1_Click(object sender, EventArgs e)
        {


            {
                bool found = false;
                try
                {
                    for (int i = 0; i < Application.OpenForms.Count; i++)
                    {
                        //Checks if the window is already open, and brings it to the front if it is
                        Form n = Application.OpenForms[i];
                        if (n.Name == "Categories")
                        {
                            n.BringToFront();
                            found = true;
                        }
                    }
                    if (!found)
                    {

                        Categories Form = new Categories();
                        Form.Name = "Categories";
                        Form.Show();
                    }
                }
                catch
                {
                }
            }
        }

        private void ViewStaffStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StaffReport Form = new StaffReport();
            Form.Show();
        }

        private void ProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
