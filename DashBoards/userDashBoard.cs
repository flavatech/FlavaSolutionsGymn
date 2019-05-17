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
    public partial class userDashBoard : Form
    {

        public userDashBoard()
        {
            InitializeComponent();
        }
        //Set a public static method to specify whether the form is  purchase or sales
        public static string transactionType;


        private void AddStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaddStaff Form = new SaddStaff();
            Form.Show();
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
                        if (n.Name == "SaddUser")
                        {
                            n.BringToFront();
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        SaddUser aForm = new SaddUser();
                        aForm.Name = "SaddUser";
                        aForm.Show();
                    }
                }
                catch
                {
                }
            }
        }

        private void AddInstructorToolStripMenuItem_Click(object sender, EventArgs e)
        {

            bool found = false;
            try
            {
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    //Checks if the window is already open, and brings it to the front if it is
                    Form n = Application.OpenForms[i];
                    if (n.Name == "SaddStaff")
                    {
                        n.BringToFront();
                        found = true;
                    }
                }
                if (!found)
                {
                    SaddStaff aForm = new SaddStaff();
                    aForm.Name = "SaddUser";
                    aForm.Show();
                }
            }
            catch
            {
            }

        }

        private void UserDashBoard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form Login = new Login();
            Login.Show();
            this.Hide();
        }

        private void UserDashBoard_Load(object sender, EventArgs e)
        {
            lblLoggegIn.Text = Login.loggedIn;
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

        private void VewMembersToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
        }
    }
}

