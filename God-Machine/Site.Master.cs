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
    public partial class SiteMaster : MasterPage
    {

        string connectionString = "datasource=music-festival.cxauddipatom.us-east-1.rds.amazonaws.com;port=3306;database=Music_Festival_Database;user=admin;password=godmachine;";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Click_SignIn(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
                {
                    sqlCon.Open();
                    MySqlCommand sqlCmd = new MySqlCommand("CheckLogin", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("email", EmailText.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("password", PassText.Text.Trim());
                    var returnParameter = sqlCmd.Parameters.Add("@ReturnVal", MySqlDbType.Int32);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    sqlCmd.ExecuteNonQuery();

                    //1 = found a match, 0 = no match (try again)
                    int result = (int) returnParameter.Value;

                    if( result == 1)
                    {
                        lblSuccess.Text = "Success!";
                        lblError.Text = "";
                        Session["UserID"] = EmailText.Text;
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        lblSuccess.Text = "";
                        EmailText.Text = PassText.Text = "";
                        lblError.Text = "Wrong email or password";
                    }
                }
            }
            catch (Exception ex)
            {
                lblSuccess.Text = "";
                lblError.Text = ex.Message;
            }
        }
    }
}