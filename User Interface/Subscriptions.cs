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
    public partial class Subscriptions : Form
    {
        public Subscriptions()
        {
            InitializeComponent();
        }
        subscriptionsBLL s = new subscriptionsBLL();
        subscriptionsDAL sdal = new subscriptionsDAL();
        categoriesDAL cdal = new categoriesDAL();
        userDAL udal = new userDAL();
        private void SelectRole_Load(object sender, EventArgs e)
        {
            //Create datatable to hold categories from the database
            DataTable categoriesDT = cdal.Select();
            //Specify datasource for category combobox
            cbCategory.DataSource = categoriesDT;
            //Show all users in database
            DataTable dt = sdal.Select();
            dgvSubscription.DataSource = dt;

            //Specify display member and value member for combobox
            cbCategory.DisplayMember = "title";
            cbCategory.ValueMember = "title";
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            //Get all the values from the form
            s.name = tbName.Text;
            s.category = cbCategory.Text;
            s.description = tbDescription.Text;
            s.price = decimal.Parse(tbPrice.Text);
            s.quantity = decimal.Parse(tbQuantity.Text);
            s.dateAddeded = DateTime.Now;
            //Get the username of the logged in User for adding to the added by field of the database
            string logggedUser = Login.loggedIn;
            userBLL usr = udal.GetIDFromUsername(logggedUser);
            s.addedBy = usr.id;

            var name = s.name;
            var category = s.category;
            var price = s.price;
            var quanttity = s.quantity;

            if (name == "")
            {
                String thename = String.Empty;
                MessageBox.Show("Please enter a name in the area provided");
            }
            else if (category == "")
            {
                String thecategory = String.Empty;
                MessageBox.Show("Please select a category");
            }
            else
            {
                //Update data in database
                bool success = sdal.Insert(s);
                //if data is not updated successfully change value to true else false
                if (success == true)
                {
                    MessageBox.Show("Subscription Successfully added");
                    Clear();
                    //Referesh DataGrid View
                    DataTable dt = sdal.Select();
                    dgvSubscription.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Failed to add Subscription");
                }

            }

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            s.id = Convert.ToInt32(tbSubscriptionId.Text);
            s.name = tbName.Text;
            s.category = cbCategory.Text;
            s.description = tbDescription.Text;
            s.price = decimal.Parse(tbPrice.Text);
            s.quantity = decimal.Parse(tbQuantity.Text);
            s.dateAddeded = DateTime.Now;
            //Get the username of the logged in User for adding to the added by field of the database
            string logggedUser = Login.loggedIn;
            userBLL usr = udal.GetIDFromUsername(logggedUser);
            s.addedBy = usr.id;
            //Update data in database
            bool success = sdal.Update(s);
            //if data is not updated successfully change value to true else false
            if (success == true)
            {
                MessageBox.Show("Subscription Successfully updated");
                Clear();
            }
            else
            {
                MessageBox.Show("Failed to update Subscription");
            }
            //Referesh DataGrid View
            DataTable dt = sdal.Select();
            dgvSubscription.DataSource = dt;

        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            //Getting the user from the form
            s.id = Convert.ToInt32(tbSubscriptionId.Text);
            bool success = sdal.Delete(s);

            // if the data is delete the value of success is true else false
            if (success == true)
            {
                MessageBox.Show("Subscription deleted Successfully");
            }
            else
            {
                MessageBox.Show("Failed to delete Subscription");
            }
            //Referesh DataGrid View
            DataTable dt = sdal.Select();
            dgvSubscription.DataSource = dt;
            Clear();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Clear();
            Close();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            var Id = tbSubscriptionId;
            var Name = tbName;
            var Categories = cbCategory;
            var Description = tbDescription;
            var Price = tbPrice;
            var Quantity = tbQuantity;
            var search = tbSearch;

            Id.Clear();
            Name.Clear();
            Categories.Text = "";
            Description.Clear();
            Price.Clear();
            Quantity.Clear();
            search.Clear();
           }

        private void DgvSubscription_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // get the index of the particular row
            int rowIndex = e.RowIndex;
            tbSubscriptionId.Text = dgvSubscription.Rows[rowIndex].Cells[0].Value.ToString();
            tbName.Text = dgvSubscription.Rows[rowIndex].Cells[1].Value.ToString(); ;
            cbCategory.Text = dgvSubscription.Rows[rowIndex].Cells[2].Value.ToString();
            tbDescription.Text = dgvSubscription.Rows[rowIndex].Cells[3].Value.ToString();
            tbPrice.Text = dgvSubscription.Rows[rowIndex].Cells[4].Value.ToString();
            tbQuantity.Text = dgvSubscription.Rows[rowIndex].Cells[5].Value.ToString();
        }

        private void TbSearch_TextChanged(object sender, EventArgs e)
        {
            //Get the keywords from the search box
            string keywords = tbSearch.Text;

            //Check if the keyword has value
            if (keywords != null)
            {
                //Show user based on keyword
                DataTable dt = sdal.Search(keywords);
                dgvSubscription.DataSource = dt;
            }
            else
            {
                //Show all users in database
                DataTable dt = sdal.Select();
                dgvSubscription.DataSource = dt;
            }
        }
    }
}
