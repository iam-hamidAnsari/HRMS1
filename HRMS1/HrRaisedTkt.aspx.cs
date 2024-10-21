using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS1
{
    public partial class HrRaisedTkt : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();

            if (!IsPostBack)
            {

            }
        }


        protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Fetch the selected role from the first dropdown
            string selectedRole = ddlRole.SelectedValue;

            if (!string.IsNullOrEmpty(selectedRole))
            {
                // If a valid role is selected, fetch and bind the emails
                BindEmailsByRole(selectedRole);
            }
            else
            {
                // If no role is selected, clear the email dropdown
                ddlRaisedTo.Items.Clear();
                ddlRaisedTo.Items.Insert(0, new ListItem("Select Email", ""));
            }
        }

        private void BindEmailsByRole(string role)
        {


            string query = $"exec fetchMailByRole {role}";
            SqlDataAdapter ada = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            ada.Fill(dt);


            ddlRaisedTo.DataSource = dt;
            ddlRaisedTo.DataTextField = "Email";  // Email to display in the dropdown
            ddlRaisedTo.DataValueField = "Email"; // Email to use as the value
            ddlRaisedTo.DataBind();




            // Insert a default item at the top of the dropdown
            ddlRaisedTo.Items.Insert(0, new ListItem("Select Email", ""));
        }


        protected void btnRaiseTicket_Click(object sender, EventArgs e)
        {
            string role = ddlRole.SelectedValue;
            string raisedToEmail = ddlRaisedTo.SelectedValue;
            string ticket = txtTicketName.Text;
            fileUpload.SaveAs(Server.MapPath("TktImgs/") + Path.GetFileName(fileUpload.FileName));
            string file = "TktImgs/" + Path.GetFileName(fileUpload.FileName);
            DateTime dateTime = DateTime.Now;
            string date = dateTime.ToString("dd/MM/yyyy");
            string raisedBy = Session["name"].ToString();
            string status = "Pending";
            string sol = "null";


            string query = $"exec insertTicket '{raisedBy}', '{raisedToEmail}', '{ticket}', '{file}', '{date}', '{status}', '{sol}'";
            SqlCommand cmd = new SqlCommand(query, conn);
            int row = cmd.ExecuteNonQuery();


            Response.Write($"<script>alert('Ticket raised by {role} to {raisedToEmail}. Ticket Name: {ticket}. File: {file}')</script>");

        }
    }
}