using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

namespace God_Machine
{
    public partial class Register : System.Web.UI.Page
    {
        string connectionString = "datasource=music-festival.cxauddipatom.us-east-1.rds.amazonaws.com;port=3306;database=Music_Festival_Database;user=admin;password=godmachine;";
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if( !IsPostBack)
            {
                ShowRegisteredUsers();
                Clear();
            }
        }

        protected void Button_Submit(object sender, EventArgs e)
        {
            string sessionId = (string)Session["UserId"];
            System.Diagnostics.Debug.WriteLine(sessionId);

            try
            {
                using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
                {
                    sqlCon.Open();
                    MySqlCommand sqlCmd = new MySqlCommand("NewUser", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("_name", hfname.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("_email", hfemail.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("_password", hfpassword.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("_city", hfcity.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("_state", hfstate.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("_phone", hfphone.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    ShowRegisteredUsers();
                    Clear();
                }

                lblSuccess.Text = "Success!";
                lblError.Text = "";
            }
            catch (Exception ex)
            {
                lblSuccess.Text = "";
                lblError.Text = ex.Message;
            }
        }

        protected void Button_Update(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
                {
                    sqlCon.Open();
                    MySqlCommand sqlCmd = new MySqlCommand("UpdateUser", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("_name", hfname.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("_email", hfemail.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("_password", hfpassword.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("_city", hfcity.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("_state", hfstate.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("_phone", hfphone.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    ShowRegisteredUsers();
                    Clear();
                }

                lblSuccess.Text = "Updated User Info!";
                lblError.Text = "";
            }
            catch (Exception ex)
            {
                lblSuccess.Text = "";
                lblError.Text = ex.Message;
            }
        }

        protected void Button_Delete(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
                {
                    sqlCon.Open();
                    MySqlCommand sqlCmd = new MySqlCommand("DeleteUser", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("_email", hfemail.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    ShowRegisteredUsers();
                    Clear();
                }

                lblSuccess.Text = "Deleted User";
                lblError.Text = "";
            }
            catch (Exception ex)
            {
                lblSuccess.Text = "";
                lblError.Text = ex.Message;
            }
        }

        void Clear()
        {
            hfname.Text = hfemail.Text = hfpassword.Text = hfcity.Text = hfstate.Text = hfphone.Text = "";
            lblSuccess.Text = lblError.Text = "";
        }

        void ShowRegisteredUsers()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                sqlCon.Open();
                MySqlDataAdapter sqlData = new MySqlDataAdapter("ViewUsers", sqlCon);
                sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable tdDB = new DataTable();
                sqlData.Fill(tdDB);
                userGrid.DataSource = tdDB;
                userGrid.DataBind();
            }
        }
    }
}