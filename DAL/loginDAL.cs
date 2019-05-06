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
    class loginDAL
    {
        //String to connect database
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        public bool loginCheck(loginBLL l)
        {
            //create a boolean variable and set its value to false and return it
            bool isSuccess = false;


            // Method to connect to database
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Query to check login of dtabase
                String sql = "SELECT * FROM dbo.users WHERE username=@username AND password=@password AND userType=@userType";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@username", l.userName);
                cmd.Parameters.AddWithValue("@password", l.password);
                cmd.Parameters.AddWithValue("@userType", l.userType);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //This is used to hold data from the database
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                //Checking number of rows in datatable
            if (dt.Rows.Count > 0)
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
                //Show error message for any messages that might occur
                MessageBox.Show(ex.Message);
                 }
            finally
                {
                //Close Connection
                conn.Close();
                }
            return isSuccess;
        }
     }
   }

