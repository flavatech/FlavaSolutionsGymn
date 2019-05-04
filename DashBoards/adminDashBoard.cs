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
    public partial class adminDashBoard : Form
    {

        public adminDashBoard()
        {
            InitializeComponent();
        }

        private void AddStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addStaff Form = new addStaff();
            Form.Show();
        }

        private void AddMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addUser Form = new addUser();
            Form.Show();
        }

        private void AddInstructorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addInstructor Form = new addInstructor();
            Form.Show();
        }
    }
}
