using FlavaGymn.DashBoards.BlogicLayer;
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
    class userDAL
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
                String sql = "SELECT* FROM dbo.user";
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
        #region Insert the data into the database
        public bool Insert(DashBoards.BlogicLayer.userBLL u)
        {
            bool isSucccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "INSERT into dbo.users(firstName,lastName,address,activity,dateOfBirth,gender,emailAddress,userName,password,phoneNumber,addedBy,userType) Values(@firstName,@lastName,@address,@activity,@dateOfBirth,@gender,@emailAddress,@userName,@password,@phoneNumber,@addedBy,@userType)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@firstName", u.firstName);
                cmd.Parameters.AddWithValue("@lastName", u.lastName);
                cmd.Parameters.AddWithValue("@address", u.address);
                cmd.Parameters.AddWithValue("@datCreated", u.dateCreated);
                cmd.Parameters.AddWithValue("@activity", u.weightGoal);
                cmd.Parameters.AddWithValue("@dateOfBirth", u.dateOfBirth);
                cmd.Parameters.AddWithValue("@gender", u.gender);
                cmd.Parameters.AddWithValue("@emailAddress", u.emailAddress);
                cmd.Parameters.AddWithValue("@userName", u.username);
                cmd.Parameters.AddWithValue("@password", u.password);
                cmd.Parameters.AddWithValue("@phoneNumber", u.phoneNumber);
                cmd.Parameters.AddWithValue("@addedBy", u.addedBy);
                cmd.Parameters.AddWithValue("@userType", u.userType);

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
        #region Update data in database
        public bool Update(userBLL u)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql = "UPDATE dbo.users SET firstName=@firstName,lastName=@lastName,address=@address,activity=@activity,dateCreated=@dateCreated,dateOfBirth=@dateOfBirth,gender=@gender,emailAddress=@emailAddress,userName=@userName,password=@password,phoneNumber=@phoneNumber,addedBy=@addedBy,userType=@userType  WHERE id = @id ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@firstName", u.firstName);
                cmd.Parameters.AddWithValue("@lastName", u.lastName);
                cmd.Parameters.AddWithValue("@datCreated", u.dateCreated);
                cmd.Parameters.AddWithValue("@weightGoal", u.weightGoal);
                cmd.Parameters.AddWithValue("@dateOfBirth", u.dateOfBirth);
                cmd.Parameters.AddWithValue("@gender", u.gender);
                cmd.Parameters.AddWithValue("@emailAddress", u.emailAddress);
                cmd.Parameters.AddWithValue("@userName", u.username);
                cmd.Parameters.AddWithValue("@password", u.password);
                cmd.Parameters.AddWithValue("@phoneNumber", u.phoneNumber);
                cmd.Parameters.AddWithValue("@addedBy", u.addedBy);
                cmd.Parameters.AddWithValue("@userType", u.userType);
                cmd.Parameters.AddWithValue("@id", u.id);

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
        #region Delete Data from Database
        public bool Delete(userBLL u)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql = "DELETE FROM dbo.users WHERE id = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", u.id);
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

    }
}
