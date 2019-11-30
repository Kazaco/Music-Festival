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
    public partial class Scheduler : System.Web.UI.Page
    {
        string connectionString = "datasource=music-festival.cxauddipatom.us-east-1.rds.amazonaws.com;port=3306;database=Music_Festival_Database;user=admin;password=godmachine;";

        protected void Page_Load(object sender, EventArgs e)
        {

            //Get info from the user
            if (Session["UserId"] != null)
            {
                Greeting.Text = "Hello: " + Session["UserId"].ToString();

                //Get the users ID and put into a string
                string sessionId = (string)Session["UserId"];
                System.Diagnostics.Debug.WriteLine(sessionId);

                ResultsforSearchOnEventsandFestival();
                ViewMySchedule();


            }
            else
            {
                Greeting.Text = "Session has not been created yet.";
            }

        }

        void ResultsforSearchOnEventsandFestival()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                sqlCon.Open();
                MySqlDataAdapter sqlData = new MySqlDataAdapter("ViewFestivalJoinedEvents", sqlCon);
                sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable tdDB = new DataTable();
                sqlData.Fill(tdDB);
                schedGrid.DataSource = tdDB;
                schedGrid.PageSize = 8;
                schedGrid.AllowPaging = true;
                schedGrid.PagerSettings.Visible = false;
                schedGrid.DataBind();
            }
        }

        void ViewMySchedule()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                sqlCon.Open();
                MySqlCommand sqlCmd = new MySqlCommand("ViewMySchedule", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("_email", Session["UserId"].ToString());
                sqlCmd.ExecuteNonQuery();
                MySqlDataAdapter sqlData = new MySqlDataAdapter(sqlCmd);
                DataTable tdDB = new DataTable();
                sqlData.Fill(tdDB);
                myScheduleGrid.DataSource = tdDB;
                myScheduleGrid.DataBind();

            }
        }
    }
}