using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS1
{
    public partial class Resignations : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(connectionString);
            conn.Open();
            if (!IsPostBack)
            {

                BindGrid();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string fromDate = txtFromDate.Text, toDate = txtToDate.Text;
          
    

            string query = $"exec GetEmpResignationsByDate '{fromDate}', '{toDate}'";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvResignation.DataSource = dt;
            gvResignation.DataBind();
        }
        public void BindGrid()
        {

            string query = $"exec GetAllEmpResignations";
            SqlDataAdapter sda = new SqlDataAdapter(query,conn);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            gvResignation.DataSource = dt;
            gvResignation.DataBind();
        }

        protected void gvResignation_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Approve" || e.CommandName == "Reject")
            {
                string email = e.CommandArgument.ToString();
                string newStatus = e.CommandName == "Approve" ? "Approved" : "Rejected";


                UpdateStatus(email, newStatus);

                Response.Write($"<script>alert('Application is {newStatus}')</script>");


                BindGrid();
            }

        }




        private void UpdateStatus(string email, string status)
        {
           
            string query = $"exec  UpdateEmpResignationStatus '{email}','{status}'";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.ExecuteNonQuery();
            string e = email;
            string s = status;
            SendEmail(e, s);
        }


        private void SendEmail(string e, string s)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("dts123.ds@gmail.com");
                mail.To.Add(e);
                mail.Subject = $"Your Resignation is {s}";
                mail.Body = $"Your resignation is {s}.";
                mail.IsBodyHtml = true;


                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("dts123.ds@gmail.com", "fyuy spab cyol eoes"),
                    EnableSsl = true
                };


                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                Response.Write("Error sending email: " + ex.Message);
            }
        }


    }
}