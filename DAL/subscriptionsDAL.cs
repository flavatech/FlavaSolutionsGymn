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
    class subscriptionsDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        #region Select Data from Database

        public DataTable Select()
        {
            //Method to connect to database
            SqlConnection conn = new SqlConnection(myconnstrng);
            //This is used to hold data from the database
            DataTable dt = new DataTable();

            try
            {
                //Query to get the data from the database
                String sql = "SELECT * FROM dbo.subscriptions";
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

        #region Insert Data into subscriptions database

        public bool Insert(subscriptionsBLL p)
        {
            bool isSucccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "INSERT into dbo.subscriptions (name, category, description, price, quantity,dateAdded,addedBy) Values(@name, @category, @description, @price, @quantity,@dateAdded,@addedBy)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", p.name);
                cmd.Parameters.AddWithValue("@category", p.category);
                cmd.Parameters.AddWithValue("@description", p.description);
                cmd.Parameters.AddWithValue("@price", p.price);
                cmd.Parameters.AddWithValue("@quantity", p.quantity);
                cmd.Parameters.AddWithValue("@dateAdded", p.dateAddeded);
                cmd.Parameters.AddWithValue("@addedBy", p.addedBy);

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

        #region Update Data in subscriptions database
        public bool Update(subscriptionsBLL p)
        {
            bool isSucccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "UPDATE dbo.subscriptions SET name=@name,category=@category,description=@description,price=@price,quantity=@quantity,dateAdded=@dateAdded,addedBy=@addedBy WHERE id = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", p.name);
                cmd.Parameters.AddWithValue("@category", p.category);
                cmd.Parameters.AddWithValue("@description", p.description);
                cmd.Parameters.AddWithValue("@price", p.price);
                cmd.Parameters.AddWithValue("@quantity", p.quantity);
                cmd.Parameters.AddWithValue("@dateAdded", p.dateAddeded);
                cmd.Parameters.AddWithValue("@addedBy", p.addedBy);
                cmd.Parameters.AddWithValue("@id", p.id);

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

        #region Delete Data from Database
        public bool Delete(subscriptionsBLL p)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql = "DELETE FROM dbo.subscriptions WHERE id = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", p.id);
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
            #endregion
        }

        #region Search FROM DATABASE
        public DataTable Search(string keyword)
        {
            //Method to connect to database
            SqlConnection conn = new SqlConnection(myconnstrng);
            //This is used to hold data from the database
            DataTable dt = new DataTable();
            try
            {
                //Query to get the data from the database
                String sql = "SELECT * FROM dbo.subscriptions WHERE  id LIKE '%" + keyword + "%' OR name LIKE '%" + keyword + "%' OR description Like '%" + keyword + "%'OR category LIKE '%" + keyword + "%'";
                //String sql = "SELECT*FROM dbo.users WHERE  id LIKE '%" + keyword + "%' OR firstName LIKE '%" + keyword + "%' OR lastName Like '%" + keyword + "%'OR username LIKE '%" + keyword + "%'";
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


        #region METHOD TO SEARCH FOR PRODUCT IN TRANSACTION MODULE
        public subscriptionsBLL GetProductsForTransaction(string keyword)
        {
            //Create an object for DeaCust Class
            subscriptionsBLL pc = new subscriptionsBLL();
            //Method to connect to database
            SqlConnection conn = new SqlConnection(myconnstrng);
            //This is used to hold data from the database
            DataTable dt = new DataTable();
            try
            {   //Query to get the data from the database
                String sql = "SELECT name, price, quantity FROM dbo.subscriptions WHERE id LIKE '%" + keyword + "%' OR name LIKE '%" + keyword + "%'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //Open database connection
                conn.Open();
                //fill data in the datatable
                adapter.Fill(dt);
                if (dt.Rows.Count>0)
                {
                    pc.name = dt.Rows[0]["name"].ToString();
                    pc.price = decimal.Parse(dt.Rows[0]["price"].ToString());
                    pc.quantity = decimal.Parse(dt.Rows[0]["quantity"].ToString());
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
            return pc;

            #endregion

        }
    }
}



