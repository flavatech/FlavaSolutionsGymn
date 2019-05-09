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
    public partial class Categories : Form
    {
        public Categories()
        {
            InitializeComponent();
        }

        categoriesBLL c = new categoriesBLL();
        categoriesDAL dal = new categoriesDAL();
        userDAL ucat = new userDAL();

        private void SelectRole_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            dgvCategories.DataSource = dt;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var title = tbTitle.Text;
            var description = tbDescription.Text;
            //Get all the values from the form
            c.title = tbTitle.Text;
            c.description = tbDescription.Text;
            c.dateAdded = DateTime.Now;

            //get ID of logged in user
            string loggedUser = Login.loggedIn;
            userBLL cuser = ucat.GetIDFromUsername(loggedUser);
            c.addedBy = cuser.id;


            /*Validate input at the application level*/

            if (title == "")
            {
                String thetitle = String.Empty;
                MessageBox.Show("The Title is required");
            }
            else if (description == "")
            {
                String thedescription = String.Empty;
                MessageBox.Show("The Description is required");
            }
            else
            {

                //Insert data into database
                bool success = dal.Insert(c);

                if (success == true)
                {
                    MessageBox.Show("New category Successfully Created");
                }
                else
                {
                    MessageBox.Show("Failed to add category");
                }
                Clear();
                //refresh the datagrid view
                DataTable dt = dal.Select();
                dgvCategories.DataSource = dt;

            }
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            //Get the Values From User Interface
            c.id = int.Parse(tbId.Text);
            c.title = tbTitle.Text;
            c.description = tbDescription.Text;
            c.dateAdded = DateTime.Now;
            //Get the username of the logged in User for adding to the added by field of the database
            string logggedUser = Login.loggedIn;
            userBLL usr = ucat.GetIDFromUsername(logggedUser);
            c.addedBy = usr.id;


            var title = c.title;
            var description = c.description;
            if (title == "")
            {
                String theusername = String.Empty;
                MessageBox.Show("Please select a record to update");
            }
            else if (description == "")
            {
                String thedescription = String.Empty;
                MessageBox.Show("Please enter a description");
            }
            else
            {
                //Update data in database
                bool success = dal.Update(c);
                //if data is not updated successfully change value to true else false
                if (success == true)
                {
                    MessageBox.Show("Category Successfully updated");
                    Clear();
                    //Referesh DataGrid View
                    DataTable dt = dal.Select();
                    dgvCategories.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Failed to update Category");
                }
            }
        }
            private void BtnDelete_Click(object sender, EventArgs e)
            {
                //Getting the user from the form
                c.id = Convert.ToInt32(tbId.Text);
                bool success = dal.Delete(c);

                // if the data is delete the value of success is true else false
                if (success == true)
                {
                    MessageBox.Show("Category deleted Successfully");
                }
                else
                {
                    MessageBox.Show("Failed to delete Category");
                }
                //Referesh DataGrid View
                DataTable dt = dal.Select();
                dgvCategories.DataSource = dt;
                Clear();

            }

            private void BtnClear_Click(object sender, EventArgs e)
            {
                Clear();
            }
            private void BtnExit_Click(object sender, EventArgs e)
            {
                Close();
            }

            private void Clear()
            {
                var Id = tbId;
                var title = tbTitle;
                var description = tbDescription;
                var search = tbSearch;

                Id.Clear();
                title.Clear();
                description.Clear();
                search.Clear();

            }

            private void DgvCategories_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
            {
                // find the row index o fthe row clicked on the datagrid view
                int rowIndex = e.RowIndex;
                tbId.Text = dgvCategories.Rows[rowIndex].Cells[0].Value.ToString();
                tbTitle.Text = dgvCategories.Rows[rowIndex].Cells[1].Value.ToString();
                tbDescription.Text = dgvCategories.Rows[rowIndex].Cells[2].Value.ToString(); ;

            }

            private void TbSearch_TextChanged(object sender, EventArgs e)
            {
                //Get the keywords from the search box
                string keywords = tbSearch.Text;

                //Check if the keyword has value
                if (keywords != null)
                {
                    //Show user based on keyword
                    DataTable dt = dal.Search(keywords);
                    dgvCategories.DataSource = dt;
                }
                else
                {
                    //Show all users in database
                    DataTable dt = dal.Select();
                    dgvCategories.DataSource = dt;
                }
            }
        }
    }



