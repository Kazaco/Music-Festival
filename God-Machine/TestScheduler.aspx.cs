using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Globalization;
using System.Configuration;
using Twilio;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace God_Machine
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string connectionString = "datasource=music-festival.cxauddipatom.us-east-1.rds.amazonaws.com;port=3306;database=Music_Festival_Database;user=admin;password=godmachine;";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
            else
            {
                string test = FestBox.Text;
                System.Diagnostics.Debug.WriteLine(test);

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
                schedGrid.DataBind();
            }
        }
        protected void ViewMySchedule()
        {
            try
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
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }
        protected void AddEvent(object sender, EventArgs e)
        {
            string sessionId = (string)Session["UserId"];
            System.Diagnostics.Debug.WriteLine(sessionId);

            Button btn = (Button)sender;
            GridViewRow getRow = (GridViewRow)btn.NamingContainer;
            int index = Convert.ToInt32(getRow.RowIndex);
            System.Diagnostics.Debug.WriteLine(index);

            string stage = schedGrid.Rows[index].Cells[7].Text;
            string date = schedGrid.Rows[index].Cells[8].Text;
            string time_begin = schedGrid.Rows[index].Cells[9].Text;
            string time_end = schedGrid.Rows[index].Cells[10].Text;

            date = DateTime.Parse(date).ToString("yyyy-MM-dd");

            //CHeck output
            System.Diagnostics.Debug.WriteLine(stage);
            System.Diagnostics.Debug.WriteLine(date);
            System.Diagnostics.Debug.WriteLine(time_begin);
            System.Diagnostics.Debug.WriteLine(time_end);

            try
            {
                using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
                {
                    sqlCon.Open();
                    MySqlCommand sqlCmd = new MySqlCommand("AddEventToUser", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("_email", Session["UserId"].ToString());
                    sqlCmd.Parameters.AddWithValue("_stage", stage);
                    sqlCmd.Parameters.AddWithValue("_time_begin", time_begin);
                    sqlCmd.Parameters.AddWithValue("_time_end", time_end);
                    sqlCmd.Parameters.AddWithValue("_date", date);
                    sqlCmd.ExecuteNonQuery();
                    ViewMySchedule();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        protected void RemoveEvent_Click(object sender, EventArgs e)
        {
            string sessionId = (string)Session["UserId"];
            System.Diagnostics.Debug.WriteLine(sessionId);

            Button btn = (Button)sender;
            GridViewRow getRow = (GridViewRow)btn.NamingContainer;
            int index = Convert.ToInt32(getRow.RowIndex);
            System.Diagnostics.Debug.WriteLine(index);

            string stage = myScheduleGrid.Rows[index].Cells[3].Text;
            string date = myScheduleGrid.Rows[index].Cells[6].Text;
            string time_begin = myScheduleGrid.Rows[index].Cells[4].Text;
            string time_end = myScheduleGrid.Rows[index].Cells[5].Text;

            date = DateTime.Parse(date).ToString("yyyy-MM-dd");

            //CHeck output
            System.Diagnostics.Debug.WriteLine(stage);
            System.Diagnostics.Debug.WriteLine(date);
            System.Diagnostics.Debug.WriteLine(time_begin);
            System.Diagnostics.Debug.WriteLine(time_end);

            try
            {
                using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
                {
                    sqlCon.Open();
                    MySqlCommand sqlCmd = new MySqlCommand("RemoveEventFromUser", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("_email", Session["UserId"].ToString());
                    sqlCmd.Parameters.AddWithValue("_stage", stage);
                    sqlCmd.Parameters.AddWithValue("_time_begin", time_begin);
                    sqlCmd.Parameters.AddWithValue("_time_end", time_end);
                    sqlCmd.Parameters.AddWithValue("_date", date);
                    sqlCmd.ExecuteNonQuery();
                    ViewMySchedule();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(FestBox.Text.Trim());
            System.Diagnostics.Debug.WriteLine(YearBox.Text.Trim());
            System.Diagnostics.Debug.WriteLine(StateBox.Text.Trim());
            System.Diagnostics.Debug.WriteLine(BandBox.Text.Trim());
            try
            {
                using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
                {
                    sqlCon.Open();
                    MySqlCommand sqlCmd = new MySqlCommand("Search", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("_festival", FestBox.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("_year", YearBox.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("_state", StateBox.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("_band", BandBox.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    MySqlDataAdapter sqlData = new MySqlDataAdapter(sqlCmd);
                    DataTable tdDB = new DataTable();
                    schedGrid.DataSource = tdDB;
                    sqlData.Fill(tdDB);
                    schedGrid.DataBind();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        protected void SendMessage_OnClick(object sender, EventArgs e)
        {

            string sessionId = (string)Session["UserId"];
            System.Diagnostics.Debug.WriteLine(sessionId);

            try
            {
                using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
                {
                    sqlCon.Open();
                    MySqlCommand sqlCmd = new MySqlCommand("GetPhone", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("_email", sessionId);
                    var phone = sqlCmd.Parameters.Add("@ReturnVal", MySqlDbType.String);
                    phone.Direction = ParameterDirection.ReturnValue;
                    sqlCmd.ExecuteNonQuery();
                    System.Diagnostics.Debug.WriteLine(phone.Value);
                    string phoneNumber = (string)phone.Value;

                    string festival = myScheduleGrid.Rows[0].Cells[1].Text;
                    string stage = myScheduleGrid.Rows[0].Cells[3].Text;
                    string time_begin = myScheduleGrid.Rows[0].Cells[4].Text;
                    string time_end = myScheduleGrid.Rows[0].Cells[5].Text;
                    string date = myScheduleGrid.Rows[0].Cells[6].Text;
                    string band = myScheduleGrid.Rows[0].Cells[7].Text;

                    string send = festival + " " + stage + " " + time_begin + " " + time_end + " " + date + " " + band;

                    System.Diagnostics.Debug.WriteLine(festival);
                    System.Diagnostics.Debug.WriteLine(stage);
                    System.Diagnostics.Debug.WriteLine(time_begin);
                    System.Diagnostics.Debug.WriteLine(time_end);
                    System.Diagnostics.Debug.WriteLine(date);
                    System.Diagnostics.Debug.WriteLine(band);

                    string ACCOUNT_SID = "ACa579a7f0cc6b5d91c6ebb3c13f784589";
                    string AUTH_TOKEN = "5659abddf1ac7bca0cf690e776b43832";

                    TwilioClient.Init(ACCOUNT_SID, AUTH_TOKEN);

                    var message = MessageResource.Create(
                       body: send,
                       from: new Twilio.Types.PhoneNumber("+12028318403"),
                       to: new Twilio.Types.PhoneNumber("+1" + phoneNumber)
                    );

                    System.Diagnostics.Debug.WriteLine(message.Sid);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

    }
}