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
    class customersDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        #region SELECT DATA FOR CUSTOMERS DATABASE

        public DataTable Select()
        {
            //Method to connect to database
            SqlConnection conn = new SqlConnection(myconnstrng);
            //This is used to hold data from the database
            DataTable dtc = new DataTable();

            try
            {
                //Query to get the data from the database
                String sql = "SELECT * FROM dbo.customers";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //Open database connection
                conn.Open();
                //fill data in the datatable
                adapter.Fill(dtc);
            }
            catch (Exception ex)
            {
                //Show error message for any messages that might occur
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Close Connection
                conn.Close();
            }
            return dtc;
        }
        #endregion
        #region INSERT THE DATA INTO CUSTOMERS THE DATABASE
        public bool Insert(customersBLL c)
        {
            bool isSucccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "INSERT into dbo.customers(type,name,emailAddress,contact,address,addedDate,addedBy) Values(@type,@name,@emailAddress,@contact,@address,@addedDate,@addedBy)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@type", c.type);
                cmd.Parameters.AddWithValue("@name", c.name);
                cmd.Parameters.AddWithValue("@emailAddress", c.emailAddress);
                cmd.Parameters.AddWithValue("@contact", c.contact);
                cmd.Parameters.AddWithValue("@address", c.address);
                cmd.Parameters.AddWithValue("@addedDate", c.addedDate);
                cmd.Parameters.AddWithValue("@addedBy", c.addedBy);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                //If the query is executed Successfully then the value to rows will be greater than zero else it will be less than zero.
                if (rows > 0)
                {
                    isSucccess = true;
                }
                else
                {
                    isSucccess = false;
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
            return isSucccess;
        }
        #endregion
        #region UPDATE THE DATA IN THE CUSTOMERS THE DATABASE
        public bool Update(customersBLL c)
        {
            //sql Connection for database connection
            SqlConnection conn = new SqlConnection(myconnstrng);
            //Create a bool variable and set the default to false
            bool isSucccess = false;
            try
            {
                string sql = "UPDATE dbo.customers SET type=@type,name=@name,emailAddress=@emailAddress,contact=@contact,address=@address,addedDate=@addedDate, addedBy=@addedBy WHERE id = @id";
                //SqlCommand to pass values
                SqlCommand cmd = new SqlCommand(sql, conn);
                // Pass the values through params
                cmd.Parameters.AddWithValue("@type", c.type);
                cmd.Parameters.AddWithValue("@name", c.name);
                cmd.Parameters.AddWithValue("@emailAddress", c.emailAddress);
                cmd.Parameters.AddWithValue("@contact", c.contact);
                cmd.Parameters.AddWithValue("@address", c.address);
                cmd.Parameters.AddWithValue("@addedDate", c.addedDate);
                cmd.Parameters.AddWithValue("@addedBy", c.addedBy);
                cmd.Parameters.AddWithValue("@id", c.id);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                //If the query is executed Successfully then the value to rows will be greater than zero else it will be less than zero.
                if (rows > 0)
                {
                    //Query executed successfully
                    isSucccess = true;
                }
                else
                {
                    isSucccess = false;
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
            return isSucccess;
        }
        #endregion
        #region DELETE DATA FROM THE CUSTOMERS DATABASE
        public bool Delete(customersBLL c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql = "DELETE FROM dbo.customers WHERE id = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", c.id);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
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
        #region SEARCH CUSTOMERS DATABASE
        public DataTable Search(string keyword)
        {
            //Method to connect to database
            SqlConnection conn = new SqlConnection(myconnstrng);
            //This is used to hold data from the database
            DataTable dt = new DataTable();
            try
            {

                //Query to get the data from the database
                String sql = "SELECT * FROM dbo.customers WHERE id LIKE '%" + keyword + "%' OR type LIKE '%" + keyword + "%' OR name Like '%" + keyword + "%'OR emailAddress LIKE '%" + keyword + "%'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //Open database connection
                conn.Open();
                //fill data in the datatable
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                //Show error message for any messages that might occur
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Close Connection
                conn.Close();
            }
            return dt;
        }
        #endregion
    }
}

