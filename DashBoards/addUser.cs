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
        private FlavaSolutionsGymnEntities cinstructors;
       userBLL u = new userBLL();
       userDAL d = new userDAL();
       public object gender { get; private set; }

        private void Signup_Load(object sender, EventArgs e)
        {
            cinstructors = new FlavaSolutionsGymnEntities();
        }

        protected void btnCustomChar_Click(object sender, EventArgs e)
            {

            }

         private void BtnAdd_Click(object sender, EventArgs e)
        {

        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            u.firstName = tbFirstName.Text;
            u.lastName = tbLastName.Text;
            u.address = tbAddress.Text;
            u.activity = cbActivity.Text;
            u.dateOfBirth = dpDOB.Value;
            u.gender = cbGender.Text;
            u.emailAddress = tbEmail.Text;
            u.username = tbUsername.Text;
            u.phoneNumber = tbTelephone.Text;
            u.userType = cbUserType.Text;
            u.dateCreated = DateTime.Now;
            u.addedBy = 1;

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
            var UserName = tbUsername;
            var Address = tbAddress;
            var Activity = cbActivity;
            var Telephone = tbTelephone;
            var EmailAddress = tbEmail;
            var DateOfBirth = dpDOB;
            var Gender = cbGender;

            var Subscription = cbSubscription;

            FirstName.Clear();
            LastName.Clear();
            UserName.Clear();
            Address.Clear();
            Activity.Text = "";
            Telephone.Clear();
            EmailAddress.Clear();
            DateOfBirth.ResetText();
            Gender.Text = "";
            Subscription.Text = "";
            //Instructor.Text = "";
            FirstName.Focus();

        }
      }
    }

