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
                string sql = "INSERT into dbo.subscriptions (name, category, description, price, quantity, dateAdded, addedBy) Values (@name, @category, @description, @price, @quantity, @dateAdded, @addedBy)";
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
                string sql = "UPDATE dbo.subscriptions SET name=@name, category=@category, description=@description, price=@price, quantity=@quantity, dateAdded=@dateAdded, addedBy=@addedBy WHERE id = @id";
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
                if (dt.Rows.Count > 0)
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
        #region METHOD TO GET PRODUCT ID BASED ON NAME
        public subscriptionsBLL GetSubscriptionIDFromName(string name)
        {
            //Create an object of Decust BLL
            subscriptionsBLL p = new subscriptionsBLL();

            //Method to connect to database
            SqlConnection conn = new SqlConnection(myconnstrng);
            //This is used to hold data from the database
            DataTable dt = new DataTable();

            try
            {
                //Get Id based on name
                string sql = "SELECT id FROM dbo.subscriptions WHERE name ='" + name + "'";
                //Create the data adapter to execute the query
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                conn.Open();

                //Pass values to datatable
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //pass the value from dt to DeaCusBLL dc
                    p.id = int.Parse(dt.Rows[0]["id"].ToString());
                    ;
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
            return p;
        }
        #endregion

        #region METHOD TO GET CURRENT CURRENT QTY BASED ON PID
        public decimal GetProductQty(int id)
        {
            //SQl Connection First
            SqlConnection conn = new SqlConnection(myconnstrng);
            //Create a Decimal Variable and set its default value to 0
            decimal quantity = 0;

            //Create Data Table to save the data from database temporarily
            DataTable dt = new DataTable();

            try
            {
                //Write WQL Query to Get Quantity from Database
                string sql = "SELECT quantity FROM dbo.subscriptions WHERE id = " + id;

                //Cerate A SqlCommand
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create a SQL Data Adapter to Execute the query
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //open DAtabase Connection
                conn.Open();

                //PAss the calue from Data Adapter to DataTable
                adapter.Fill(dt);

                //Lets check if the datatable has value or not
                if (dt.Rows.Count > 0)
                {
                    quantity = decimal.Parse(dt.Rows[0]["quantity"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Close Database Connection
                conn.Close();
            }

            return quantity;
        }
        #endregion
        #region METHOD TO UPDATE QUANTITY
        public bool UpdateQuantity(int id, decimal quantity)
        {
            //Create a Boolean Variable and Set its value to false
            bool success = false;

            //SQl Connection to Connect Database
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Write the SQL Query to Update Qty
                string sql = "UPDATE dbo.subscriptions SET quantity=@quantity WHERE id=@id";

                //Create SQL Command to Pass the quantity into db
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Passing the VAlue through parameters
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@id", id);

                //Open Database Connection
                conn.Open();

                //Create Int Variable and Check whether the query is executed Successfully or not
                int rows = cmd.ExecuteNonQuery();
                //Lets check if the query is executed Successfully or not
                if (rows > 0)
                {
                    //Query Executed Successfully
                    success = true;
                }
                else
                {
                    //Failed to Execute Query
                    success = false;
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

            return success;
        }
        #endregion
        #region METHOD TO INCREASE PRODUCT QUANTITY
        public bool IncreaseProduct(int id, decimal Increasequantity)
        {
            //Create a Boolean Variable and SEt its value to False
            bool success = false;

            //Create SQL Connection To Connect DAtabase
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Get the Current Qty From dAtabase based on id
                decimal currentquantity = GetProductQty(id);

                //Increase the Current Quantity by the qty purchased from Dealer
                decimal Newquantity = currentquantity + Increasequantity;

                //Update the Prudcty Quantity Now
                success = UpdateQuantity(id, Newquantity);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return success;
        }
        #endregion
        #region METHOD TO DECREASE PRODUCT
        public bool DecreaseProduct(int id, decimal quantity)
        {
            //Create Boolean Variable and SEt its Value to false
            bool success = false;

            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Get the Current product Quantity
                decimal currentquantity = GetProductQty(id);

                //Decrease the Product Quantity based on product sales
                decimal Newquantity = currentquantity - quantity;

                //Update Product in Database
                success = UpdateQuantity(id, Newquantity);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return success;
        }
        #endregion

        #region DESPLAY PRODUCTS BASED ON CATEGORIES
        public DataTable DisplayProductsByCategory(string category)
        {
            //Sql Connection First
            SqlConnection conn = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();

            try
            {
                //SQL Query to Display Product Based on CAtegory
                string sql = "SELECT * FROM dbo.subscriptions WHERE category='" + category + "'";

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Open Database Connection Here
                conn.Open();

                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }
        #endregion
    }
}





