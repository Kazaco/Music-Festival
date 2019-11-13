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
    public partial class WebForm1 : System.Web.UI.Page
    {
        string connectionString = @"Server=localhost;Database=festival;Uid=root;Pwd=R4wIxp";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
                {
                    sqlCon.Open();
                    MySqlCommand sqlCmd = new MySqlCommand("NewUser", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("name", hfname.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("email", hfemail.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("password", hfpassword.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("city", hfcity.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("state", hfstate.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("phone", hfphone.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    Clear();

                    lblSuccess.Text = "Success!";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        void Clear()
        {
            hfname.Text = hfemail.Text = hfpassword.Text = hfcity.Text = hfstate.Text = hfphone.Text = "";
            lblSuccess.Text = lblError.Text = "";
        }
    }
}