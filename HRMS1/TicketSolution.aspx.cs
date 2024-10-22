using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS1
{
    public partial class TicketSolution : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();

            if (!IsPostBack)
            {
                // Get the TicketID from the query string
                string ticketId = Request.QueryString["TicketID"];
                lblTicketID.Text = ticketId;
            }

        }

        protected void btnSubmitSolution_Click(object sender, EventArgs e)
        {
          
            string ticketId = lblTicketID.Text;

            fileUpload.SaveAs(Server.MapPath("TktImgs/") + Path.GetFileName(fileUpload.FileName));
            string attachment = "TktImgs/" + Path.GetFileName(fileUpload.FileName);

          
            SubmitSolution(ticketId, attachment);

            
            Response.Write("<script>alert('Soln uploaded Successfully...');</script>");
            

        }

        private void SubmitSolution(string ticketId, string attachment)
        {
            string em = Session["name"].ToString();
            string query = $"exec updateStatus '{em}', '{ticketId}', 'Closed' ,'{attachment}'";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
        }
    }
}