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
    public partial class PurchasesAndSales : Form
    {
        public PurchasesAndSales()
        {
            InitializeComponent();
        }

        //subscriptionsBLL p = new subscriptionsBLL();
        //subscriptionsDAL sDAL = new subscriptionsDAL();
        DeaCusDAL dcDAL = new DeaCusDAL();
        subscriptionsDAL pDAL= new subscriptionsDAL();

        private void SelectRole_Load(object sender, EventArgs e)
        {
            //get the transactiontype value from the user dashboard
            string type = adminDashBoard.transactionType;

            //Set the value on lbllblPurchasesAndSales
            lblPurchasesAndSales.Text = type;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //Get all the values from the form


        }

        private void BtnClear_Click(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {

        }

        private void TbSearch_TextChanged(object sender, EventArgs e)
        {
            //get the keyword fro the textbox
            string keywords = tbSearch.Text;
            if (keywords == "")
            {
             //Clear all the textBoxes
                Clear();
               return;
             }
            DeaCusBLL dc = dcDAL.SearchDealerCustomerForTransaction(keywords);

            //Set the value the textboxes

            tbName.Text = dc.name;
            tbEmail.Text = dc.emailAddress;
            tbContact.Text = dc.contact;
            tbAddress.Text = dc.address;
        }
          private void Clear()
        {
            var name = tbName;
            var email = tbEmail;
            var contact = tbContact;
            var address = tbAddress;
            var productName = tbProductName;
            var inventory = tbInventory;
            var price = tbPrice;
            var quantity = tbQuantity;

            name.Clear();
            email.Clear();
            contact.Clear();
            address.Clear();
            productName.Clear();
            inventory.Clear();
            price.Text= "";
            quantity.Text="";
        }

        private void TbProductSearch_TextChanged(object sender, EventArgs e)
        {
            //get the keyword fro the textbox
            string keywords = tbProductSearch.Text;
            if (keywords == "")
            {
                //Clear all the textBoxes
                Clear();
                return;

            }
            subscriptionsBLL p = pDAL.GetProductsForTransaction(keywords);
            //Set the value on textboxes based on pObject
            tbProductName.Text = p.name;
            tbInventory.Text = p.quantity.ToString();
            tbPrice.Text = p.price.ToString();

        }
    }
}
