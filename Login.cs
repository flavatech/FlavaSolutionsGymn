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

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            adminDashBoard btnLogin = new adminDashBoard();
            var username = tbUsername.Text;
            var password = tbPassword.Text;

            //Declare an object of the database Model
            var datactx = new FlavaSolutionsGymnEntities();

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
            else
            {
                //Lambda Expression to check if the username and password exists
                var userCount = datactx.users.Count(q => q.userName == username && q.password == password);
            if (userCount !=1)
                {
                    MessageBox.Show("Invalid Credentials");
                }
            else
                {
                    Hide();
                    btnLogin.Show();
                    MessageBox.Show($"Welcome {username}");
                }
            }
        }

        private void BtnSignup_Click(object sender, EventArgs e)
        {
            selectRole Form = new selectRole();

            Form.Show();
        }

        private void BtnNewuserForm_Click(object sender, EventArgs e)
        {
            adminDashBoard Form = new adminDashBoard();
            Form.Show();
        }
    }

}

