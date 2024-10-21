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
    public partial class EmpMyTkt : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();

            if (!IsPostBack)
            {
                LoadTickets("RaisedForMe");
            }
        }


        private void LoadTickets(string filter)
        {
            string em = Session["name"].ToString();
            string query;

            if (filter == "RaisedByMe")
            {
                // Show tickets raised by the user
                query = $"exec fetchTicketRaisedByMe '{em}' ";
            }
            else
            {
                // Show tickets raised for the user
                query = $"exec fetchTicketRaisedForMe '{em}' ";
            }


            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            da.Fill(dt);
            gvTickets.DataSource = dt;
            gvTickets.DataBind();
        }

        protected void gvTickets_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "CloseTicket")
            {
                // Get the index of the clicked row
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = gvTickets.Rows[index];

                // Retrieve the TicketID from the selected row
                string ticketId = selectedRow.Cells[0].Text; // Assuming TicketID is in the first column

                // Redirect to the Solution page, passing the TicketID in the query string
                Response.Redirect("TicketSolution.aspx?TicketID=" + ticketId);
            }
        }

        protected void ddlTicketFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFilter = ddlTicketFilter.SelectedValue;
            LoadTickets(selectedFilter);
        }

        protected void gvTickets_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTickets.PageIndex = e.NewPageIndex; // Set the new page index
            string selectedFilter = ddlTicketFilter.SelectedValue;
            LoadTickets(selectedFilter); // Rebind the data to the GridView
        }
    }
}