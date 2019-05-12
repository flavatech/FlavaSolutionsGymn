using DGVPrinterHelper;
using FlavaGymn.BlogicLayer;
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
using System.Transactions;
using System.Windows.Forms;

namespace FlavaGymn
{
    public partial class PurchasesAndSales : Form
    {
        public PurchasesAndSales()
        {
            InitializeComponent();
        }


        DeaCusDAL dcDAL = new DeaCusDAL();
        subscriptionsDAL pDAL = new subscriptionsDAL();
        userDAL uDAL = new userDAL();
        transactionDAL tDAL = new transactionDAL();
        transactionDetailDAL tdDAL = new transactionDetailDAL();
        DataTable transactionDT = new DataTable();

        private void SelectRole_Load(object sender, EventArgs e)
        {
            //get the transactiontype value from the user dashboard
            string type = adminDashBoard.transactionType;

            //Set the value on lbllblPurchasesAndSales
            lblPurchasesAndSales.Text = type;

            //state columns for datatable
            transactionDT.Columns.Add("Item Name");
            transactionDT.Columns.Add("Price");
            transactionDT.Columns.Add("Quantity");
            transactionDT.Columns.Add("Total");

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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            //Get product name price and quantity that is been sold
            string productName = tbProductName.Text;
            decimal price = decimal.Parse(tbPrice.Text);
            decimal quantity = decimal.Parse(tbQuantity.Text);

            //formula for total
            decimal Total = price * quantity;

            //Show the subtotal in the text box
            decimal subTotal = decimal.Parse(tbSubtotal.Text);


            //Display subtotal in calculation grid
            subTotal = subTotal + Total;

            //Check if the product name is selected
            if (productName == "")
            {
                MessageBox.Show("Please select the product to proceed");
            }
            else
            {
                //Add the product to the datagrid
                transactionDT.Rows.Add(productName, price, quantity, Total);

                //show in datagrid view
                dgvPurchases.DataSource = transactionDT;
                //display the subtotal in the subtotal area
                tbSubtotal.Text = subTotal.ToString();
                //Clear DataGrid view
                Clear();
            }

        }

        private void TbDiscount_TextChanged(object sender, EventArgs e)
        {
            // Get value from discount tb
            string value = tbDiscount.Text;
            if (value == "")
            {
                MessageBox.Show("Please add discount");
            }
            else
            {
                //Get discount
                decimal subTotal = decimal.Parse(tbSubtotal.Text);
                decimal discount = decimal.Parse(tbDiscount.Text);


                //Calculate the total based on discount
                decimal grandTotal = ((100 - discount) / 100) * subTotal;
               // grandTotal = grandTotal + discount;

                //Show the Grand Total in text box
                tbGrandTotal.Text = grandTotal.ToString();

            }
        }

        private void TbVat_TextChanged(object sender, EventArgs e)
        {
            //check grandtotal
            string check = tbGrandTotal.Text;
            if (check == "")
            {
                //Display message
                MessageBox.Show("Please calculate the discount to set the grand total");
            }
            else
            {
                //Calculate Vat
                decimal previousGT = decimal.Parse(tbGrandTotal.Text);
                decimal vat = decimal.Parse(tbVat.Text);
                decimal grandTotalWithVAT = ((100 + vat) / 100) * previousGT;

                //display grand Total with VAT
                tbGrandTotal.Text = grandTotalWithVAT.ToString();

            }
        }

        private void TbAmountPaid_TextChanged(object sender, EventArgs e)
        {

            //Get the amount paid and grand Total
            decimal grandTotal = Math.Round(decimal.Parse(tbGrandTotal.Text), 2);
            decimal paidAmount = Math.Round(decimal.Parse(tbAmountPaid.Text), 2);

            decimal returnAmount = paidAmount - grandTotal;
            //display the change
            tbChange.Text = returnAmount.ToString();

        }
        private void BtnCalcSave_Click(object sender, EventArgs e)
        {
            try
            {
                //Get the values from PurchaseSales Form
                transactionsBLL transaction = new transactionsBLL();
                transaction.type = lblPurchasesAndSales.Text;

                //Get the id and name of dealer or customer
                string deaCustName = tbName.Text;
                DeaCusBLL dc = dcDAL.GetDeaCusIdFromName(deaCustName);
                transaction.deal_cust_id = dc.id;
                transaction.grandTotal = Math.Round(decimal.Parse(tbGrandTotal.Text), 2);
                transaction.transactionDate = DateTime.Now;
                transaction.tax = decimal.Parse(tbVat.Text);
                transaction.discount = decimal.Parse(tbDiscount.Text);

                //get the username of logged in user
                string username = Login.loggedIn;
                userBLL u = uDAL.GetIDFromUsername(username);
                transaction.addedBy = u.id;
                transaction.transactionDetails = transactionDT;

                //create a boolean and set value
                bool success = false;
                //Insert transaction in table
                using (TransactionScope scope = new TransactionScope())
                {
                    int transactionID = -1;

                    //create a bool value and insert transaction
                    bool w = tDAL.Insert_Transaction(transaction, out transactionID);
                    for (int i=0; i<transactionDT.Rows.Count;i++)
                    {

                        //Get all the details of the subscription
                        transactionDetailBLL transactionDetail = new transactionDetailBLL();
                        //convert subscription Name to id
                        string name = transactionDT.Rows[i][0].ToString();
                        subscriptionsBLL p = pDAL.GetSubscriptionIDFromName(name);

                        transactionDetail.subscriptionid = p.id;
                        transactionDetail.price = decimal.Parse(transactionDT.Rows[i][1].ToString());
                        transactionDetail.quantity = decimal.Parse(transactionDT.Rows[i][2].ToString());
                        transactionDetail.total = Math.Round(decimal.Parse(transactionDT.Rows[i][3].ToString()),2);
                        transactionDetail.dealer_cust_id = dc.id;
                        transactionDetail.addedDate = DateTime.Now;
                        transactionDetail.addedBy = u.id;

            //change quantity based on sales or purchases
            string transactionType = lblPurchasesAndSales.Text;
                        //Create a bool and check for type of transaction
                        bool x = false;
                        if (transactionType=="Purchase")
                        {
                            x = pDAL.IncreaseProduct(transactionDetail.subscriptionid, transactionDetail.quantity);
                        }
                        else if (transactionType=="Sales")
                        {
                            //Decrease the Product Quantity
                            x = pDAL.DecreaseProduct(transactionDetail.subscriptionid, transactionDetail.quantity);
                        }
                        //Insert transaction Details
                        bool y = tdDAL.Insert_TransactionDetail(transactionDetail);
                        success = w && x && y;
                    }
                    if (success == true)
                    {
                        scope.Complete();

            //Print Bill
            DGVPrinter printer = new DGVPrinter();

                        printer.Title = "\r\n\r\n\r\n Flava Solutions Gymn MGMT. LTD. \r\n\r\n";
                        printer.SubTitle = "Angels, Spanish Town \r\n Phone: 876-619-1097 - 99 \r\n\r\n";
                        printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                        printer.PageNumbers = true;
                        printer.PageNumberInHeader = false;
                        printer.PorportionalColumns = true;
                        printer.HeaderCellAlignment = StringAlignment.Near;
                        printer.Footer = "Discount: " + tbDiscount.Text + "% \r\n" + "VAT: " + tbVat.Text + "% \r\n" + "Grand Total: " + tbGrandTotal.Text + "\r\n\r\n" + "Thank you for doing business with us.";
                        printer.FooterSpacing = 15;
                        printer.PrintDataGridView(dgvPurchases);



                        MessageBox.Show("Transaction Completed Successfully");
                        //Clear datagrid view
                        dgvPurchases.DataSource = null;
                        dgvPurchases.Rows.Clear();
                        Clear1();
                    }
                    else
                    {

            //transaction Failed
            MessageBox.Show("Transaction Failed");
                    }

                }
            }
            finally
            {

            }
        }


    private void Clear1()
        {
            var id = tbProductSearch;
            var search = tbSearch;
            var name = tbName;
            var email = tbEmail;
            var contact = tbContact;
            var address = tbAddress;
            var productName = tbProductName;
            var inventory = tbInventory;
            var price = tbPrice;
            var quantity = tbQuantity;

            var subTotal = tbSubtotal;
            var discount = tbDiscount;
            var tax = tbVat;
            var grandtotal = tbGrandTotal;
            var paidamount = tbAmountPaid;
            var change = tbChange;


            id.Clear();
            search.Clear();
            name.Clear();
            email.Clear();
            contact.Clear();
            address.Clear();
            productName.Clear();
            inventory.Text = "0";
            price.Text = "0";
            quantity.Text = "0";
            subTotal.Text = "0";
            discount.Text = "0";
            tax.Text = "0";
            grandtotal.Text = "0";
            paidamount.Text = "0";
            change.Text = "0";
        }

        private void Clear()
        {
            var id = tbProductSearch;
            var name = tbName;
            var email = tbEmail;
            var contact = tbContact;
            var address = tbAddress;
            var productName = tbProductName;
            var inventory = tbInventory;
            var price = tbPrice;
            var quantity = tbQuantity;

            var subTotal = tbSubtotal;
            var discount = tbDiscount;
            var tax = tbVat;
            var grandtotal = tbGrandTotal;
            var paidamount = tbAmountPaid;
            var change = tbChange;


            id.Clear();
            //name.Clear();
            // email.Clear();
            //  contact.Clear();

            //  address.Clear();
            productName.Clear();
            inventory.Clear();
            price.Text = "";
            quantity.Text = "";
            //subTotal.Text = "";
            //discount.Text = "";
            //tax.Text = "0.00";
            //grandtotal.Text = "";
            // paidamount.Text = "";
            //change.Text = "";
        }
    }
}



