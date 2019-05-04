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
    public partial class addInstructor : Form
    {
        public addInstructor()
        {
            InitializeComponent();
        }
        private FlavaSolutionsGymnEntities cinstructors;
        private void AddInstructor_Load(object sender, EventArgs e)
        {
            cinstructors = new FlavaSolutionsGymnEntities();
        }
         private void BtnSave_Click(object sender, EventArgs e)
        {
        }
         private void BtnSave_Click_1(object sender, EventArgs e)
        {
        //Get all the variables from the form interface.  Store in variables for ease of use
            var FirstName = tbFirstName.Text;
            var LastName = tbLastName.Text;
            var UserName = tbUserName.Text;
            var Telephone = tbTelephone.Text;
            var EmailAddress = tbEmail.Text;
            var experinceInYears = tbExperience.Text;
            var DateOfBirth = dpDOB.Value;
            var Gender = cbGender.SelectedValue;
            var HiredDate = DateTime.Now;//dpHiredDate.Value;
            var Specialization = cbSpecialization.SelectedValue;
           // var userType = ;
            var DateCreated = DateTime.Now;
            var dateOfHire = DateTime.Now;

            var rand = new Random();
            //This is my random generation of a password. I am using the first letter of the given first name,
            //the last name and a random number generated between 1 and 100.
            //This password NEEDS TO BE ENCRYPTED!!!!
            var password = $"{FirstName[0]}{LastName}{rand.Next(0, 100)}";


            //Declare an object of the datatype that corresponds with the
            //table that you are about to store data in
            instructor record = new instructor();
            user record1 = new user();

            record.firstName = FirstName;
            record.lastName = LastName;
           // record.Address = Address;
            record1.userName = UserName;
            record1.phoneNumber = Telephone;
            record1.emailAddress = EmailAddress;
            //record.dateCreate = DateOfBirth;
            record.instructorGenderId = Convert.ToInt32(Gender);
           // record.DateOfHire = HiredDate;
            record.specializationId = Convert.ToInt32(Specialization);
            //record.DateCreated = DateCreated;


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
                cinstructors.SaveChanges();
                MessageBox.Show("New Member added Successfully");
                Clear();
               }
             }

        private void BtnCancel_Click(object sender, EventArgs e)
        {

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
            var UserName = tbUserName;
            var Telephone = tbTelephone;
            var EmailAddress = tbEmail;
            var DateOfBirth = dpDOB;
            var Gender = cbGender;
            var SpecializationId = cbSpecialization;
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
            SpecializationId.Text = "";
            Address.Clear();
            FirstName.Focus();

        }
        bool CheckEmail(string email)
        {
            var emailExists = cinstructors.users.Any(q => q.emailAddress.Trim() == email.Trim());
            return emailExists;
        }
        bool CheckUserName(string username)
        {
            var usernameExists = cinstructors.users.Any(q => q.emailAddress.Trim() == username.Trim());
            return usernameExists;
        }

        bool isFormInvalid()
        {
            return String.IsNullOrEmpty(tbEmail.Text) || String.IsNullOrEmpty(tbUserName.Text) || cbGender.SelectedItem == null;
        }

        private void FillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                //this.gendersTableAdapter.FillBy(this.flavaGymnDataSet3.Genders);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

    private void BtnClear_Click_1(object sender, EventArgs e)
        {
            Clear();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Clear();
            Close();
        }

    }
}







