using DocumentFormat.OpenXml.Bibliography;
using FlavaGymn.BlogicLayer;
using FlavaGymn.DAL;
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
    public partial class Inventory : Form
    {
        public Inventory()
        {
            InitializeComponent();
        }


        categoriesDAL cdal = new categoriesDAL();
        subscriptionsDAL sdal = new subscriptionsDAL();
        private void SelectRole_Load(object sender, EventArgs e)
        {

        }

       
        private void CmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            DataTable cdt = cdal.Select();

            cmbICategory.DataSource = cdt;
            cmbICategory.DisplayMember ="title";
            cmbICategory.ValueMember = "title";

            //Display the categories in the comboBox
            DataTable sdt = sdal.Select();
            dgvInventory.DataSource = sdt;
            //string category = cmbcategories.Text();
        }

        private void BntShowAll_Click(object sender, EventArgs e)
        {

        }
    }
}
