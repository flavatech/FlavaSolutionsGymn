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
    class categoriesDAL
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
                //Query to get the data from the dtabase
                String sql = "SELECT * FROM dbo.categories";
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
        #region Insert  Categories 

        public bool Insert(categoriesBLL c)
        {
            bool isSucccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "INSERT into dbo.categories(title, description,dateAdded,addedBy) Values(@title, @description,@dateAdded,@addedBy)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@title", c.title);
                cmd.Parameters.AddWithValue("@description", c.description);
                cmd.Parameters.AddWithValue("@dateAdded", c.dateAdded);
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
        #region Update Data in categories database
        public bool Update(categoriesBLL c)
        {
            bool isSucccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "UPDATE dbo.categories SET title=@title,description=@description,dateAdded=@dateAdded,addedBy=@addedBy WHERE id = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@title", c.title);
                cmd.Parameters.AddWithValue("@description", c.description);
                cmd.Parameters.AddWithValue("@dateAdded", c.dateAdded);
                cmd.Parameters.AddWithValue("@addedBy", c.addedBy);
                cmd.Parameters.AddWithValue("@id", c.id);

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
        #region Delete Data from Categories Database
        public bool Delete(categoriesBLL c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql = "DELETE FROM dbo.categories WHERE id = @id";
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
            #endregion
        }
#region Search Categories DATABASE
            public DataTable Search(string keyword)
            {
                //Method to connect to database
                SqlConnection conn = new SqlConnection(myconnstrng);
                //This is used to hold data from the database
                DataTable dt = new DataTable();
                try
                {
                    //Query to get the data from the database
                    String sql = "SELECT* FROM dbo.categories WHERE  id LIKE '%" + keyword + "%' OR title LIKE '%" + keyword + "%'";
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
         }
    }


