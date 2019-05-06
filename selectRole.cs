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
    public partial class selectRole : Form
    {
        public selectRole()
        {
            InitializeComponent();
        }
        private FlavaSolutionsGymnEntities ros;

        private void SelectRole_Load(object sender, EventArgs e)
        {

        }

        private void BtnGo_Click(object sender, EventArgs e)
        {
           var SelRole = cbRole.SelectedIndex;
          {
                {
                    if (SelRole == 1)
                        {
                          AddStaff Form = new AddStaff();
                          this.Hide();
                          Form.Show();
                        }
                        else if (SelRole == 2)
                        {
                            addUser Form = new addUser();
                            this.Close();
                            Form.Show();
                        }
                        else if (SelRole == 0)
                        {
                            addUser Form = new addUser();

                            this.Hide();
                            Form.Show();
                        }
                        else
                        {
                            this.Show();
                        }

                    }
                }
            }


        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
