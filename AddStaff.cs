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
    public partial class addStaff : Form
    {
        public addStaff()
        {
            InitializeComponent();
        }

        /*
    * Declare an object of the database Entity Model  global to the class to ensure that it is accessible
    * to the class.
    * This is the code used (private flavaGymnEntities1 cstaffgymn)
    */
        private FlavaSolutionsGymnEntities cstaffgymn;
        private void AddStaff_Load(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //Get all the variables from the form interface.  Store in variables for ease of use
            var FirstName = tbFirstName.Text;
            var LastName = tbLastName.Text;
            var UserName = tbUsername.Text;
            var Telephone = tbTelephone.Text;
            var EmailAddress = tbEmail.Text;
            var DateOfBirth = dpDOB.Value;
            var Gender = cbGender.SelectedValue;
            var HiredDate = DateTime.Now;//dpHiredDate.Value;
            var Salary = cbSalary.SelectedValue;
            var Address = tbAddress.Text;
            //var userType = cbUserType;
            var DateCreated = DateTime.Now;

            /*
			//For Staff
			[First_name
			[Last_name
			//Gender
			//Date Of Birth
			[Email
			[Phone_number
			[Hire_date
			[job_id
			[salary
			[address
			[staff_payments_id]
			[username]
			[password]
			Date Created
			*/

            var rand = new Random();
            //This is my random generation of a password. I am using the first letter of the given first name,
            //the last name and a random number generated between 1 and 100.
            //This password NEEDS TO BE ENCRYPTED!!!!
            var password = $"{FirstName[0]}{LastName}{rand.Next(0, 100)}";

            /* STart Here

            //Declare an object of the datatype that corresponds with the
            //table that you are about to store data in
            staff record = new staff();

            record.First_name = FirstName;
            record.Last_name = LastName;
            record.address = Address;
            record.username = UserName;
            record.password = password;
            record.Phone_number = Telephone;
            record.Email = EmailAddress;
            record. DateOfBirth = DateOfBirth;
            record.GenderId = Convert.ToInt32(Gender);
            record.Hire_date = HiredDate;
            record.salary = Convert.ToInt32(Salary);
            record.DateCreated = DateCreated;
            //ar userType = cbUserType;

            End here */

            //Validate minimum data is collected, as well as any other validation that you may want to enforce.
            if (isFormInvalid())
            {
                MessageBox.Show("Please validate all data before submission!");
            }
            //Do further validations to checck for username and email address
            else if (CheckEmail(EmailAddress) || CheckUserName(UserName))
            {
                MessageBox.Show("A user exists with this email/username!");
                this.Show();
            }
            else
            {
                //Add the record (or object) to the the table and save changes
               // cstaffgymn.members.Add(record);
                cstaffgymn.SaveChanges();
                MessageBox.Show("New Member added Successfully");
                Clear();
                /* Fields not added

                Subscription Status = Subscription_status_id
                Organization /branch code = Oraganization_type
                Member_progress_id
                Payment-info_id
                hardcode User_type-id
                Fee_payment_option_type
                 */

            }


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
            var Telephone = tbTelephone;
            var EmailAddress = tbEmail;
            var DateOfBirth = dpDOB;
            var Gender = cbGender;
            var HiredDate = dpHiredDate;
            var Salary = cbSalary;
            var Address = tbAddress;
            //var userType = cbUserType;
            //var DateCreated = DateTime.Now;

            FirstName.Clear();
            LastName.Clear();
            UserName.Clear();
            Telephone.Clear();
            EmailAddress.Clear();
            DateOfBirth.ResetText();
            Gender.Text = "";
            HiredDate.ResetText();
            Salary.Text = "";
            Address.Clear();
            FirstName.Focus();

        }
        bool CheckEmail(string email)
        {
            var emailExists = cstaffgymn.users.Any(q => q.emailAddress.Trim() == email.Trim());
            return emailExists;
        }
        bool CheckUserName(string username)
        {
            var usernameExists = cstaffgymn.users.Any(q => q.userName.Trim() == username.Trim());
            return usernameExists;
        }

        bool isFormInvalid()
        {
            return String.IsNullOrEmpty(tbEmail.Text) || String.IsNullOrEmpty(tbUsername.Text) || cbGender.SelectedItem == null;
        }

        private void FillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
              //  this.gendersTableAdapter.FillBy(this.flavaGymnDataSet3.Genders);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}



