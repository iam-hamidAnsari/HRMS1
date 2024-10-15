using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS1
{
    public partial class CalenderLeave : System.Web.UI.Page
    {
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Text = "Approved: <span style='display:inline-block;width:15px;height:15px;background-color:green;border-radius:50%;'></span>";
            Label3.Text = "Reject: <span style='display:inline-block;width:15px;height:15px;background-color:red;border-radius:50%;'></span>";
            Label4.Text = "Pending: <span style='display:inline-block;width:15px;height:15px;background-color:yellow;border-radius:50%;'></span>";
            Label5.Text = "Holiday/Birthday <span style='display:inline-block;width:15px;height:15px;background-color:Fuchsia;border-radius:50%;'></span> ";

            if (!IsPostBack)
            {
                //string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
                //conn = new SqlConnection(cs);
                //conn.Open();
            }
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();

                // Check events first
                string q = "SELECT date,event_name FROM events"; // Assuming event_date is your column
                SqlCommand cmd1 = new SqlCommand(q, conn);
                SqlDataReader rdr = cmd1.ExecuteReader();

                while (rdr.Read())
                {
                    // Convert the string (VARCHAR) date to DateTime in C#
                    DateTime eventDate;
                    string eventDateString = rdr["date"].ToString();
                    string eventname = rdr["event_name"].ToString();

                    // Attempt to parse the VARCHAR date string into a DateTime object
                    if (DateTime.TryParse(eventDateString, out eventDate))
                    {
                        // Compare the parsed eventDate with the calendar date
                        if (eventDate.Date == e.Day.Date)
                        {
                            // Highlight the date if it matches
                            e.Cell.BackColor = System.Drawing.Color.Fuchsia;
                            System.Diagnostics.Debug.WriteLine($"Event date highlighted: {eventDate.ToShortDateString()}");
                            e.Cell.Controls.Add(new LiteralControl("<br/>" + eventname));
                        }
                    }
                }
                rdr.Close(); // Close the reader before the next command

                // Check leave status next
                string query = "SELECT leave_status FROM [leave] WHERE @CurrentDate BETWEEN From_date AND To_date AND email = @Email";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add parameters for current date and email
                    cmd.Parameters.AddWithValue("@CurrentDate", e.Day.Date);
                    cmd.Parameters.AddWithValue("@Email", Session["name"].ToString());

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string status = reader["leave_status"].ToString().ToLower(); // Fetch the leave status
                            System.Diagnostics.Debug.WriteLine($"Status for {e.Day.Date.ToShortDateString()}: {status}");

                            // Set the cell color based on the leave status
                            switch (status)
                            {
                                case "approve":
                                    e.Cell.BackColor = System.Drawing.Color.Green;
                                    break;
                                case "pending":
                                    e.Cell.BackColor = System.Drawing.Color.Yellow;
                                    break;
                                case "reject":
                                    e.Cell.BackColor = System.Drawing.Color.Red;
                                    break;
                            }
                        }
                    }
                }
            }
        }


    }
}