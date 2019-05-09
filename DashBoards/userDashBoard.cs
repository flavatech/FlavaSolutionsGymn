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

        private void AddStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaddStaff Form = new SaddStaff();
            Form.Show();
        }

        private void AddMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaddUser Form = new SaddUser();

            Form.Show();
        }

        private void AddInstructorToolStripMenuItem_Click(object sender, EventArgs e)
        {
          SaddStaff Form = new SaddStaff();
            Form.Show();
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
            Customers Form = new Customers();
            Form.Show();
        }
    }
}
