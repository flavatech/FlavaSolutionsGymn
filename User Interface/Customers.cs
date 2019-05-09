using FlavaGymn.BlogicLayer;
using FlavaGymn.DAL;
using FlavaGymn.DashBoards.BlogicLayer;
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
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
        }

        customersBLL c = new customersBLL();
        customersDAL cudal = new customersDAL();
        userDAL uDal = new userDAL();

        private void SelectRole_Load(object sender, EventArgs e)
        {
            //Referesh DataGrid View
            DataTable dtc = cudal.Select();
            dgvCustomers.DataSource = dtc;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //Get all the values from the form

            c.type = cbType.Text;
            c.name = tbName.Text;
            c.emailAddress = tbEmail.Text;
            c.contact = tbContact.Text;
            c.address = tbAddress.Text;
            c.addedDate = DateTime.Now;
            //Get the username of the logged in User for adding to the added by field of the database
            string logggedUser = Login.loggedIn;
            userBLL usr = uDal.GetIDFromUsername(logggedUser);
            c.addedBy = usr.id;

            var type = c.type;
            var name = c.name;
            if (name == "")
            {
                String thename = String.Empty;
                MessageBox.Show("Please enter a name in the area provided");
            }
            else if (type == "")
            {
                String thecategory = String.Empty;
                MessageBox.Show("Please select a type");
            }
            else
            {
                //Update data in database
                bool success = cudal.Insert(c);
                //if data is not updated successfully change value to true else false
                if (success == true)
                {
                    MessageBox.Show("Customer Successfully added");
                    Clear();
                    //Referesh DataGrid View
                    DataTable dtc = cudal.Select();
                    dgvCustomers.DataSource = dtc;
                }
                else
                {
                    MessageBox.Show("Failed to add Customer");
                }

            }

        }
        private void DgvCustomers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            tbCustomerId.Text = dgvCustomers.Rows[rowIndex].Cells[0].Value.ToString();
            tbName.Text = dgvCustomers.Rows[rowIndex].Cells[1].Value.ToString();
            cbType.Text = dgvCustomers.Rows[rowIndex].Cells[2].Value.ToString();
            tbEmail.Text = dgvCustomers.Rows[rowIndex].Cells[3].Value.ToString();
            tbContact.Text = dgvCustomers.Rows[rowIndex].Cells[4].Value.ToString();
            tbAddress.Text = dgvCustomers.Rows[rowIndex].Cells[5].Value.ToString();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
           c.id = Convert.ToInt32(tbCustomerId.Text);
            c.type = cbType.Text;
            c.name = tbName.Text;
            c.emailAddress = tbEmail.Text;
            c.contact = tbContact.Text;
            c.address = tbAddress.Text;
            c.addedDate = DateTime.Now;
            //Get the username of the logged in User for adding to the added by field of the database
            string logggedUser = Login.loggedIn;
            userBLL usr = uDal.GetIDFromUsername(logggedUser);
            c.addedBy = usr.id;


            //Update data in database
            bool success = cudal.Update(c);
            //if data is not updated successfully change value to true else false
            if (success == true)
            {
                MessageBox.Show("Customer Successfully updated");
                Clear();
                //Referesh DataGrid View
                DataTable dtc = cudal.Select();
                dgvCustomers.DataSource = dtc;
            }
            else
            {
                MessageBox.Show("Failed to update Customer");
            }

        }

            private void BtnDelete_Click(object sender, EventArgs e)
        {
            //Getting the user from the form
            c.id = Convert.ToInt32(tbCustomerId.Text);
            bool success = cudal.Delete(c);

            // if the data is delete the value of success is true else false
            if (success == true)
            {
                MessageBox.Show("Customer deleted Successfully");
            }
            else
            {
                MessageBox.Show("Failed to delete Customer");
            }

            //Referesh DataGrid View
            DataTable dtc = cudal.Select();
            dgvCustomers.DataSource = dtc;
            Clear();
        }

        private void TbSearch_TextChanged(object sender, EventArgs e)
        {
            //Get the keywords from the search box
            string keywords = tbSearch.Text;

            //Check if the keyword has value
            if (keywords != null)
            {
                //Show user based on keyword
                DataTable dt = cudal.Search(keywords);
                dgvCustomers.DataSource = dt;
            }
            else
            {
                //Show all users in database
                DataTable dt = cudal.Select();
                dgvCustomers.DataSource = dt;
            }
        }
            private void BtnExit_Click(object sender, EventArgs e)
            {
                Close();
            }

            private void BtnClear_Click(object sender, EventArgs e)
            {
                Clear();

            }

          private void Clear()
            {
            var Id = tbCustomerId;
                var type = cbType;
                var name = tbName;
                var email = tbEmail;
                var contact = tbContact;
                var address = tbAddress;

                Id.Clear();
                type.Text = "";
                name.Clear();
                email.Clear();
                contact.Clear();
                address.Clear();

              }
          }
      }



