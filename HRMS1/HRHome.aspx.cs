using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace HRMS1
{
    public partial class HRHome : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("approve") || e.CommandName.Equals("reject"))
            {
                if (int.TryParse(e.CommandArgument.ToString(), out int rowIndex))
                {
                    // Retrieve the row
                    GridViewRow row = GridView1.Rows[rowIndex];
                    // Get the email value from the cell (index 0 assuming it's the first column)
                    string email = row.Cells[0].Text;// Adjust index if needed
                    string date = row.Cells[1].Text;

                    if (e.CommandName.Equals("approve"))
                    {
                       
                        string q = $"exec fetch_pending_leave '{email}'";
                        SqlCommand cmd = new SqlCommand(q, conn);
                        SqlDataReader rdr = cmd.ExecuteReader();
                        rdr.Read();
                        string leave_type = rdr["leave_typ"].ToString();
                        int rqstd_leave = int.Parse(rdr["no_of_rqstd_leave"].ToString());
                        int pl = int.Parse(rdr["pl"].ToString());
                        int sl = int.Parse(rdr["sl"].ToString());
                        int cl = int.Parse(rdr["cl"].ToString());

                        if (leave_type.Equals("PL"))
                        {
                            int remaingleave = pl - rqstd_leave;
                            string qpl = $"update leave set pl={remaingleave},leave_status='approve' where email='{email}' and From_date='{date}'";
                            SqlCommand cmd2 = new SqlCommand(qpl, conn);
                            cmd2.ExecuteNonQuery();
                        }
                        else if (leave_type.Equals("SL"))
                        {
                            int remaingleave = sl - rqstd_leave;
                            string qsl = $"update leave set sl={remaingleave},leave_status='approve' where email='{email}'and From_date='{date}";
                            SqlCommand cmd2 = new SqlCommand(qsl, conn);
                            cmd2.ExecuteNonQuery();
                        }
                        else if (leave_type.Equals("CL"))
                        {
                            int remaingleave = cl - rqstd_leave;
                            string qcl = $"update leave set cl={remaingleave},leave_status='approve' where email='{email}'and From_date='{date}";
                            SqlCommand cmd2 = new SqlCommand(qcl, conn);
                            cmd2.ExecuteNonQuery();
                        }
                        MailMessage mail = new MailMessage();
                        mail.From = new MailAddress("mpoke1928@gmail.com");
                        mail.To.Add(email);
                        mail.Subject = "Your Leave approved";
                        mail.Body = $"Hi {email},\nLeave type : {leave_type}\n{rqstd_leave} days leave is approve. ,\nH\nregards,\nHR dept";
                        SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                        smtp.Port = 587;
                        smtp.Credentials = new NetworkCredential("mpoke1928@gmail.com", "dhfx widi jvps itnr");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                        Response.Write("<script>alert('Leave Approved!!')</script>");
                    }
                    else if (e.CommandName.Equals("reject"))
                    {
                        string qcl = $"update leave set leave_status='reject' where email='{email}'and From_date='{date}'";
                        SqlCommand cmd2 = new SqlCommand(qcl, conn);
                        cmd2.ExecuteNonQuery();
                        Response.Write("<script>alert('Leave rejected!!')</script>");
                    }
                }
                else
                {
                    Label2.Text = "Invalid row index.";
                }
            }
            else
            {
                Label2.Text = "Might be some error. Command: " + e.CommandName;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow selectedRow = GridView1.SelectedRow;
        }
    }
}