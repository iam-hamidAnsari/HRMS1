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
using System.IO;

namespace HRMS1
{
    public partial class DcmntGenration : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {

                
                FileUpload1.SaveAs(Server.MapPath("GenratedDocuments/") + Path.GetFileName(FileUpload1.FileName));
                string docPath = "GenratedDocuments/" + Path.GetFileName(FileUpload1.FileName);
                
                string email = txtEmail.Text;
                string docname = TxtName.Text; 
                string body = $"Document '{TxtName.Text}'";

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("sayyedamir1000@gmail.com");
                mail.To.Add(email);
                mail.Subject = "New Document is genrated";
                mail.Body = body;
                mail.Attachments.Add(new Attachment("C:\\Users\\Ansari Hamid\\source\\repos\\HRMS1\\HRMS1\\" + docPath));

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("sayyedamir1000@gmail.com", "pcrn vvie qqou wqai");
                smtp.EnableSsl = true;
                smtp.Send(mail);

             
                string insertQuery = $"exec gen_doc '{email}','{docPath}','{docname}'";
                SqlCommand cmd = new SqlCommand(insertQuery,conn);
                cmd.ExecuteNonQuery();
            
                Response.Write("<script>alert('Email sent successfully!');</script>");
               
            }
            else
            {
                Response.Write("<script>alert('Please upload a file.');</script>");
            }
        }
    }
}