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
    public partial class AddEvent : System.Web.UI.Page
    {
        //private static List<EventInfo> events = new List<EventInfo>();
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ToString();
            conn = new SqlConnection(cs);
            conn.Open();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Collecting user inputs directly without validation
            DateTime eventDate = DateTime.Parse(TextBox1.Text); // Assumes valid input
            string eventName = TextBox2.Text;
            string eventType = DropDownList1.SelectedValue;
          

            string q = $"exec add_event '{TextBox1.Text}','{eventType}','{eventName}'";
            SqlCommand cmd = new SqlCommand(q,conn);
            cmd.ExecuteNonQuery();

            // Store event
            //events.Add(new EventInfo { Date = eventDate, Name = eventName, Type = eventType });

            // Clear input fields
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
        }

        protected void Calendar2_DayRender(object sender, DayRenderEventArgs e)
        {
            string q = "SELECT date FROM events";  // Assuming event_date is your column

            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                // Convert the string (VARCHAR) date to DateTime in C#
                DateTime eventDate;
                string eventDateString = rdr["date"].ToString();

                // Attempt to parse the VARCHAR date string into a DateTime object
                if (DateTime.TryParse(eventDateString, out eventDate))
                {
                    // Compare the parsed eventDate with the calendar date
                    if (eventDate.Date == e.Day.Date)
                    {
                        // Highlight the date if it matches
                        e.Cell.BackColor = System.Drawing.Color.Fuchsia;
                    }
                }
            }

        }

        //public class EventInfo
        //{
        //    public DateTime Date { get; set; }
        //    public string Name { get; set; }
        //    public string Type { get; set; }
        //}
    }
}