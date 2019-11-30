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
            if(!IsPostBack)
            {
                string sessionId = (string)Session["UserId"];
                System.Diagnostics.Debug.WriteLine(sessionId);
            }
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
                    sqlCmd.Parameters.AddWithValue("_email", EmailText.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("_password", PassText.Text.Trim());
                    var returnParameter = sqlCmd.Parameters.Add("@ReturnVal", MySqlDbType.String);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    sqlCmd.ExecuteNonQuery();

                    //System.Diagnostics.Debug.WriteLine(returnParameter.Value);

                    //Item is not in the database (NULL returned)
                    if( returnParameter.Value == DBNull.Value)
                    {
                        lblSuccess.Text = "";
                        EmailText.Text = PassText.Text = "";
                        lblError.Text = "Wrong email or password";
                    }
                    else
                    {
                        //Found a match, can cast value to string and compare
                        string result = (string)returnParameter.Value;

                        //Admin logging in
                        if (result == "admin@gmail.com")
                        {
                            lblSuccess.Text = "Success!";
                            lblError.Text = "";
                            Session["UserID"] = result;
                            Response.Redirect("Admin.aspx", false);
                        }
                        //Normal User
                        else
                        {
                            lblSuccess.Text = "Success!";
                            lblError.Text = "";
                            Session["UserID"] = result;
                            Response.Redirect("Scheduler.aspx", false);
                        }
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