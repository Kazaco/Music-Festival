using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace God_Machine
{
	public partial class Scheduler : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

            //Get info from the user
            if(Session["UserId"] != null)
            {
                Greeting.Text = "Hello: " + Session["UserId"].ToString();

                //Get the users ID and put into a string
                string sessionId = (string)Session["UserId"];
                System.Diagnostics.Debug.WriteLine(sessionId);

            }
            else
            {
                Greeting.Text = "Session has not been created yet.";
            }

        }

        void ResultsforSearchOnEventsandFestival()
        {

        }
    }
}