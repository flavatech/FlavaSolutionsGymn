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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            tbPassword.MaxLength = 20;
        }
        loginBLL l = new loginBLL();
        loginDAL d = new loginDAL();
        public static string loggedIn;

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            var username = tbUsername.Text.Trim();
            var password = tbPassword.Text.Trim();
            var userType = cbUserType.Text.Trim();

            l.userName = username;
            l.password = password;
            l.userType = userType;

            /*Validate input at the application level*/

            if (username == "")
            {
                String theusername = String.Empty;
                MessageBox.Show("The Users' Name is required");
            }
            else if (password == "")
            {
                String thepassword = String.Empty;
                MessageBox.Show("The Password is required");
            }
            else if (userType == "")
            {
                String theuserType = String.Empty;
                MessageBox.Show("The UserType is required");
            }
            else
            {
                bool success = d.loginCheck(l);
                //open respective dashboard based on user type
                if (success == true)
                {

                    loggedIn = username;
                    //Open the forms based on the usertype selected
                    switch (l.userType)
                    {
                        case "Admin":
                            {   adminDashBoard admin = new adminDashBoard();
                                admin.Show();
                                MessageBox.Show($"Welcome {username}");
                                this.Hide();
                            }
                            break;

                        case "Staff":
                            {
                                userDashBoard user = new userDashBoard();
                                user.Show();
                                MessageBox.Show($"Welcome {username}");
                                this.Hide();
                            }
                            break;
                            /*
                        default:
                            {
                                //Display Error message
                                MessageBox.Show("Please choose userType");
                            }
                            break;
                           */
                    }
                }
                else
                {
                    this.Show();
                    MessageBox.Show("Invalid Credentials. Please try again");
                }
            }
        }
        private void BtnSignup_Click(object sender, EventArgs e)
        {
            CreateAccount Form = new CreateAccount();
            Form.Show();
        }
        private void PbClose_Click(object sender, EventArgs e)
        {
            //Close the form
            this.Close();
        }


    }
}

