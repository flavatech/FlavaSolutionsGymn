using FlavaGymn.BlogicLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlavaGymn.DAL
{
    class transactionDetailDAL
    {
        //Create connection string
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        #region INSERT METHOD FOR TRANSACTION DETAIL
        public bool Insert_TransactionDetail(transactionDetailBLL td)
        {
            //Create a bool and set the value to false
            bool isSuccess = false;
           SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {

                string sql = "INSERT into dbo.transactionDetail(subscriptionid, price, quantity, total, dealer_cust_id, addedDate, addedBy) Values(@subscriptionid, @price, @quantity, @total, @dealer_cust_id, @addedDate, @addedBy)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@subscriptionid",td.subscriptionid);
                cmd.Parameters.AddWithValue("@price", td.price);
                cmd.Parameters.AddWithValue("@quantity", td.quantity);
                cmd.Parameters.AddWithValue("@total", td.total);
                cmd.Parameters.AddWithValue("@dealer_cust_id", td.dealer_cust_id);
                cmd.Parameters.AddWithValue("@addedDate", td.addedDate);
                cmd.Parameters.AddWithValue("@addedBy", td.addedBy);
                //open database connection
                conn.Open();

                //execute the query
                int rows = cmd.ExecuteNonQuery();
                //id the query is execute successfully then the value will not be null, else it will be null
                if (rows>0)

                {// Queryable executed successfully
                    isSuccess = true;
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
