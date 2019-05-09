using FlavaGymn.BlogicLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlavaGymn.DAL
{
    class transactionDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        #region INSERT TRANSACTION METHOD

        public bool Insert_Transaction(transactionsBLL t, out int transactionID)
        {
            //create a boolean variable and set its default value false
            bool isSuccess = false;
            //set the out transaction
            transactionID = -1;

           SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "INSERT into dbo.transactions (type, dealer_cust_id, grandTotal, transactionDate, tax,discount,addedBy) Values(@type, @dealer_cust_id, @grandTotal, @transactionDate, @tax,discount, @addedBy)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@type", t.type);
                cmd.Parameters.AddWithValue("@dealer_cust_id", t.deal_cust_id);
                cmd.Parameters.AddWithValue("@grandTotal", t.grandTotal);
                cmd.Parameters.AddWithValue("@transactionDate", t.transactionDate);
                cmd.Parameters.AddWithValue("@tax", t.tax);
                cmd.Parameters.AddWithValue("@discount", t.discount);
                cmd.Parameters.AddWithValue("@addedBy", t.addedBy);
                //open database connection
                conn.Open();

                //execute the query
                object o = cmd.ExecuteScalar();
                //id the query is execute successfully then the value will not be null, elese it will be null
                if (o != null)
                {// Queryable executed successfully
                    transactionID = int.Parse(o.ToString());
                }
                else
                {
                    //failed to execute query
                    isSuccess = false;
                }

             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
        #endregion
    }
}
