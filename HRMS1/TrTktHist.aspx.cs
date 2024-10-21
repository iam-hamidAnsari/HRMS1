using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS1
{
    public partial class TrTktHist : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();

            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        // Get the selected time range from the dropdown
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            // Get the selected time frame from dropdown
            string selectedValue = ddlTimeRange.SelectedValue;

            // Replace with the actual logged-in user email
            string email = Session["name"].ToString();

            // Fetch tickets and bind to GridView
            DataTable dtTickets = GetTickets(selectedValue, email);
            gvTickets.DataSource = dtTickets;
            gvTickets.DataBind();
        }



        protected void gvTickets_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTickets.PageIndex = e.NewPageIndex; // Set the new page index
            BindGrid();   // Rebind the data to the GridView
        }

        private void BindGrid()
        {
            string selectedValue = ddlTimeRange.SelectedValue; // Get the selected time frame
            string email = Session["name"].ToString(); // Replace with the actual logged-in user email
            DataTable dtTickets = GetTickets(selectedValue, email); // Fetch tickets from your method
            gvTickets.DataSource = dtTickets; // Set the data source
            gvTickets.DataBind(); // Bind the data to the GridView
        }



        private DataTable GetTickets(string timeFrame, string email)
        {
            DataTable dt = new DataTable();
            string query = $"GetClosedTicketsByTimeFrame '{email}', '{timeFrame}'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }
    }
}