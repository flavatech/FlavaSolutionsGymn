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
    public partial class addUser : Form
    {
       public addUser()
        {
            InitializeComponent();
        }
       userBLL u = new userBLL();
       userDAL d = new userDAL();
        private void Signup_Load(object sender, EventArgs e)
        {
            DataTable dt = d.SelectM();
            dgvAdduser.DataSource = dt;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        { //Get the username of the logged in User
            string loggedUser = Login.loggedIn;

            //get the user details from UI
            u.firstName = tbFirstName.Text;
            u.lastName = tbLastName.Text;
            u.emailAddress = tbEmail.Text;
            u.gender = cbGender.Text;
            u.address = tbAddress.Text;
            u.phoneNumber = tbTelephone.Text;
            u.activity = cbActivity.Text;
            u.username = tbUsername.Text;
            u.password = tbPassword.Text;
            u.userType = cbUserType.Text;
            u.dateCreated = DateTime.Now;
            u.dateOfBirth = dpDOB.Value;
            //Get the username of the logged in User for adding to the added by field of the database
            string logggedUser = Login.loggedIn;
            userBLL usr = d.GetIDFromUsername(logggedUser);
            u.addedBy = usr.id;
            u.subscription = cbSubscription.Text;
            u.status = cbSubscriptionStatus.Text;

            //Auto generate Password
            int lengthOfPassword = 9;
            string valid = "abcdefghijklmnozABCDEFGHIJKLMNOZ1234567890&%$#@!";
            StringBuilder strB = new StringBuilder(100);
            Random random = new Random();
            while (0 < lengthOfPassword--)
            {
                strB.Append(valid[random.Next(valid.Length)]);
            }
            u.password = strB.ToString();

            //Insert data into database
            bool success = d.Insert(u);

            if (success == true)
            {
                MessageBox.Show("User Successfully Created");
            }
            else
            {
                MessageBox.Show("Failed to add user");
            }
            Clear();
            //refresh the datagrid view
            DataTable dt = d.SelectM();
            dgvAdduser.DataSource = dt;

        }
           private void BtnCancel_Click(object sender, EventArgs e)
        {
            Clear();
            Close();

        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        //Create a Global method for Clear
        private void Clear()
        {
            //Use Var to  enable use of user friendly names in clear command below.
            var FirstName = tbFirstName;
            var LastName = tbLastName;
            var EmailAddress = tbEmail;
            var Gender = cbGender;
            var Telephone = tbTelephone;
            var Activity = cbActivity;
            var UserName = tbUsername;
            var password = tbPassword;
            var userType = cbUserType;
            var Address = tbAddress;
            var DateOfBirth = dpDOB;
            //dateCreated
            //added by
            var Subscription = cbSubscription;
            var status = cbSubscriptionStatus;

            FirstName.Clear();
            LastName.Clear();
            EmailAddress.Clear();
            Gender.Text = "";
            Telephone.Clear();
            Activity.Text = "";
            UserName.Clear();
            password.Clear();
            userType.Text = "";
            Address.Clear();
            DateOfBirth.ResetText();
            //date Created
            Subscription.Text = "";
            status.Text = "";
            FirstName.Focus();

        }

        private void DgvAdduser_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //get the index of the particular row
            
            int rowIndex = e.RowIndex;
            tbaddUserId.Text = dgvAdduser.Rows[rowIndex].Cells[0].Value.ToString();
            cbUserType.Text = dgvAdduser.Rows[rowIndex].Cells[1].Value.ToString(); ;
            tbFirstName.Text = dgvAdduser.Rows[rowIndex].Cells[2].Value.ToString();
            tbLastName.Text = dgvAdduser.Rows[rowIndex].Cells[3].Value.ToString();
            tbEmail.Text = dgvAdduser.Rows[rowIndex].Cells[4].Value.ToString();
            cbGender.Text = dgvAdduser.Rows[rowIndex].Cells[5].Value.ToString();
            tbTelephone.Text = dgvAdduser.Rows[rowIndex].Cells[6].Value.ToString();
            cbActivity.Text = dgvAdduser.Rows[rowIndex].Cells[7].Value.ToString();
            tbUsername.Text = dgvAdduser.Rows[rowIndex].Cells[8].Value.ToString();
            tbPassword.Text = dgvAdduser.Rows[rowIndex].Cells[9].Value.ToString();

            tbAddress.Text = dgvAdduser.Rows[rowIndex].Cells[10].Value.ToString();
            dpDOB.Text = dgvAdduser.Rows[rowIndex].Cells[11].Value.ToString();
            //dateCreated12
            //addedby13
            cbSubscription.Text = dgvAdduser.Rows[rowIndex].Cells[12].Value.ToString();
            cbSubscriptionStatus.Text = dgvAdduser.Rows[rowIndex].Cells[13].Value.ToString();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            // Get the Values From User Interface

            u.id = Convert.ToInt32(tbaddUserId.Text);
            u.firstName = tbFirstName.Text;
            u.lastName = tbLastName.Text;
            u.emailAddress = tbEmail.Text;
            u.gender = cbGender.Text;
            u.address = tbAddress.Text;
            u.phoneNumber = tbTelephone.Text;
            u.activity = cbActivity.Text;
            u.username = tbUsername.Text;
            u.password = tbPassword.Text;
            u.userType = cbUserType.Text;
            u.dateCreated = DateTime.Now;
            u.dateOfBirth = dpDOB.Value;
            //Get the username of the logged in User for adding to the added by field of the database
            string logggedUser = Login.loggedIn;
            userBLL usr = d.GetIDFromUsername(logggedUser);
            u.addedBy = usr.id;
            u.subscription = cbSubscription.Text;
            u.status = cbSubscriptionStatus.Text;

            //Update data in database
            bool success = d.Update(u);
            //if data is not updated successfully change value to true else false
            if (success == true)
            {
                MessageBox.Show("User Successfully updated");
                Clear();
            }
            else
            {
                MessageBox.Show("Failed to update User");
            }
            //Referesh DataGrid View
            DataTable dt = d.SelectM();
            dgvAdduser.DataSource = dt;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            //Getting the user from the form
            u.id = Convert.ToInt32(tbaddUserId.Text);
            bool success = d.Delete(u);

            // if the data is delete the value of success is true else false
            if (success == true)
            {
                MessageBox.Show("User deleted Successfully");
            }
            else
            {
                MessageBox.Show("Failed to delete user");
            }
            //Referesh DataGrid View
            DataTable dt = d.SelectM();
            dgvAdduser.DataSource = dt;
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
                DataTable dt = d.SearchM(keywords);
                dgvAdduser.DataSource = dt;
            }
            else
            {
                //Show all users in database
                DataTable dt = d.SelectM();
                dgvAdduser.DataSource = dt;
            }
        }
    }
    }

