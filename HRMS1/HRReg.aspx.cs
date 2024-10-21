using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS1
{
    public partial class HRReg : System.Web.UI.Page
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
            string name = TextBox1.Text, email = TextBox2.Text, pass = TextBox3.Text,contact_no=TextBox4.Text,address=TextBox5.Text;
            FileUpload1.SaveAs(Server.MapPath("ProfilePhotos/") + Path.GetFileName(FileUpload1.FileName));
            string img = "profile_img/"+Path.GetFileName(FileUpload1.FileName);
            string q = $"exec CreateAcct '{name}','{email}','{pass}','{img}','{contact_no}','{address}'";
            SqlCommand cmd = new SqlCommand(q, conn);
            int row =cmd.ExecuteNonQuery();
            Response.Write("<script>alert('User registerd successfully..'); </script>");
            if (row > 0)
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("mpoke1928@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Welcome to Our Hr portal ";
                mail.Body = $"Hi {name},\n\n Your registration is successfull,\nHere is your credetials\nEmail:{email}\npassword: {pass}\nregards,\nHR dept";
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential("mpoke1928@gmail.com", "dhfx widi jvps itnr");
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            else
            {
                Response.Write("<script>alert('Add all details..'); </script>");
            }
        }
    }
}