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
        /*
        public DataTable Select()
        {
            //Method to connect to database
            SqlConnection conn = new SqlConnection(myconnstrng);
            //This is used to hold data from the database
            DataTable dt = new DataTable();
            DataTable dtsi = new DataTable();
            try
            {
                //Query to get the data from the dtabase
                String sql = "SELECT * FROM dbo.users";
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
        } */
        #endregion
        #region SELECT STAFF ONLY(FOR SADDSTAFF INTERFACE)

        public DataTable SelectS()
        {
            //Method to connect to database
            SqlConnection conn = new SqlConnection(myconnstrng);
            //This is used to hold data from the database
            DataTable dt = new DataTable();
            try
            {
                //Query to get the data from the dtabase
                String sql = ("SELECT id AS[User ID], userType AS[User Type], firstName AS[First Name], lastName AS[Last Name], emailAddress AS[Email Address], gender AS Gender, phoneNumber AS[Telephone #], activity AS Activity, userName AS Username,  password AS Password, address AS Address, dateOfBirth AS [Date of Birth], subscription AS Subscription, status AS Status, dateCreated AS [Date Created], addedBy AS [Added By] FROM  users WHERE(userType = 'Staff')");
                //String sql = ("SELECT * FROM users WHERE(userType LIKE 'Staff')");
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

        #region SELECT STAFF AND INSTRUCTORS ONLY(FOR ADDSTAFF INTERFACE)

        public DataTable SelectSI()
        {
            //Method to connect to database
            SqlConnection conn = new SqlConnection(myconnstrng);
            //This is used to hold data from the database
            DataTable dtsi = new DataTable();
            try
            {
                //Query to get the data from the dtabase
                String sql = ("SELECT id AS[User ID], userType AS[User Type], firstName AS[First Name], lastName AS[Last Name], emailAddress AS[Email Address], gender AS Gender, phoneNumber AS[Telephone #], activity AS Activity, userName AS Username,  password AS Password, address AS Address, dateOfBirth AS [Date of Birth], subscription AS Subscription, status AS Status, dateCreated AS [Date Created], addedBy AS [Added By] FROM  users WHERE(userType LIKE 'Staff') OR (userType LIKE 'Instructor')");
                //String sql = ("SELECT * FROM users WHERE(userType LIKE 'Staff')");
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //Open database connection
                conn.Open();
                //fill data in the datatable
                adapter.Fill(dtsi);
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
            return dtsi;
        }
        #endregion

        #region Select Members Only from database

        public DataTable SelectM()
        {
            //Method to connect to database
            SqlConnection conn = new SqlConnection(myconnstrng);
            //This is used to hold data from the database
            DataTable dt = new DataTable();
            try
            {
                //Query to get the data from the dtabase
                String sql = ("SELECT id AS[User ID], userType AS[User Type], firstName AS[First Name], lastName AS[Last Name], emailAddress AS[Email Address], gender AS Gender, phoneNumber AS[Telephone #], activity AS Activity, userName AS Username,  password AS Password, address AS Address, dateOfBirth AS [Date of Birth], subscription AS Subscription, status AS Status, dateCreated AS [Date Created], addedBy AS [Added By] FROM  users WHERE (userType = 'Member')");

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
                string sql = "INSERT into dbo.users(firstName,lastName,emailAddress,gender,phoneNumber,activity,userName,password,userType,address,dateOfBirth,dateCreated,addedBy,subscription, status) Values(@firstName,@lastName,@emailAddress,@gender,@phoneNumber,@activity,@userName,@password,@userType,@address,@dateOfBirth,@dateCreated,@addedBy,@subscription, @status)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@firstName", u.firstName);
                cmd.Parameters.AddWithValue("@lastName", u.lastName);
                cmd.Parameters.AddWithValue("@emailAddress", u.emailAddress);
                cmd.Parameters.AddWithValue("@gender", u.gender);
                cmd.Parameters.AddWithValue("@phoneNumber", u.phoneNumber);
                cmd.Parameters.AddWithValue("@activity", u.activity);
                cmd.Parameters.AddWithValue("@userName", u.username);
                cmd.Parameters.AddWithValue("@password", u.password);
                cmd.Parameters.AddWithValue("@userType", u.userType);
                cmd.Parameters.AddWithValue("@address", u.address);
                cmd.Parameters.AddWithValue("@dateOfBirth", u.dateOfBirth);
                cmd.Parameters.AddWithValue("@dateCreated", u.dateCreated);
                cmd.Parameters.AddWithValue("@addedBy", u.addedBy);
                cmd.Parameters.AddWithValue("@subscription", u.subscription);
                cmd.Parameters.AddWithValue("@status", u.status);

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
                string sql = "UPDATE dbo.users SET firstName=@firstName,lastName=@lastName,emailAddress=@emailAddress,gender=@gender,phoneNumber=@phoneNumber,activity=@activity,userName=@userName,password=@password,userType=@userType,address=@address,dateOfBirth=@dateOfBirth,dateCreated=@dateCreated,addedBy=@addedBy,subscription=@subscription, status=@status  WHERE id = @id ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@firstName", u.firstName);
                cmd.Parameters.AddWithValue("@lastName", u.lastName);
                cmd.Parameters.AddWithValue("@emailAddress", u.emailAddress);
                cmd.Parameters.AddWithValue("@gender", u.gender);
                cmd.Parameters.AddWithValue("@phoneNumber", u.phoneNumber);
                cmd.Parameters.AddWithValue("@activity", u.activity);
                cmd.Parameters.AddWithValue("@userName", u.username);
                cmd.Parameters.AddWithValue("@password", u.password);
                cmd.Parameters.AddWithValue("@userType", u.userType);
                cmd.Parameters.AddWithValue("@address", u.address);
                cmd.Parameters.AddWithValue("@dateOfBirth", u.dateOfBirth);
                cmd.Parameters.AddWithValue("@dateCreated", u.dateCreated);
                cmd.Parameters.AddWithValue("@addedBy", u.addedBy);
                cmd.Parameters.AddWithValue("@subscription", u.subscription);
                cmd.Parameters.AddWithValue("@status", u.status);
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
        #region Search FROM DATABASE
        public DataTable Search(string keyword)
        {
            //Method to connect to database
            SqlConnection conn = new SqlConnection(myconnstrng);
            //This is used to hold data from the database
            DataTable dtsi = new DataTable();
            try
            {

                //Query to get the data from the dtabase
                String sql= "SELECT id AS[User ID], userType AS[User Type], firstName AS[First Name], lastName AS[Last Name], emailAddress AS[Email Address], gender AS Gender, phoneNumber AS[Telephone #], activity AS Activity, userName AS Username,  password AS Password, address AS Address, dateOfBirth AS [Date of Birth], subscription AS Subscription, status AS Status, dateCreated AS [Date Created], addedBy AS [Added By] FROM  users WHERE (UserType = 'Staff' OR UserType ='Instructor') AND id LIKE '%" + keyword + "%' OR firstName LIKE '%" + keyword + "%' OR lastName Like '%" + keyword + "%'OR username LIKE '%" + keyword + "%'";
                //String sql = "SELECT*FROM dbo.users WHERE  id LIKE '%" + keyword + "%' OR firstName LIKE '%" + keyword + "%' OR lastName Like '%" + keyword + "%'OR username LIKE '%" + keyword + "%'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //Open database connection
                conn.Open();
                //fill data in the datatable
                adapter.Fill(dtsi);
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
            return dtsi;
        }
        #endregion

        #region Search DATABASE for members Only
        public DataTable SearchM(string keyword)
        {
            //Method to connect to database
            SqlConnection conn = new SqlConnection(myconnstrng);
            //This is used to hold data from the database
            DataTable dtM = new DataTable();
            try
            {

                //Query to get the data from the dtabase
                String sql = "SELECT id AS[User ID], userType AS[User Type], firstName AS[First Name], lastName AS[Last Name], emailAddress AS[Email Address], gender AS Gender, phoneNumber AS[Telephone #], activity AS Activity, userName AS Username,  password AS Password, address AS Address, dateOfBirth AS [Date of Birth], subscription AS Subscription, status AS Status, dateCreated AS [Date Created], addedBy AS [Added By] FROM  users WHERE (UserType = 'Member') AND id LIKE '%" + keyword + "%' OR firstName LIKE '%" + keyword + "%' OR lastName Like '%" + keyword + "%'OR username LIKE '%" + keyword + "%'";
                //String sql = "SELECT*FROM dbo.users WHERE  id LIKE '%" + keyword + "%' OR firstName LIKE '%" + keyword + "%' OR lastName Like '%" + keyword + "%'OR username LIKE '%" + keyword + "%'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //Open database connection
                conn.Open();
                //fill data in the datatable
                adapter.Fill(dtM);
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
            return dtM;
        }
        #endregion
        #region
        public userBLL GetIDFromUsername (string username)
        {
            userBLL u = new userBLL();
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
            string sql = "SELECT id FROM dbo.users WHERE username = '"+username+"'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                conn.Open();

                adapter.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    u.id = int.Parse(dt.Rows[0]["id"].ToString());
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
            return u;

            #endregion

        }
    }
}
