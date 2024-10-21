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

namespace HRMS1
{
    public partial class ForgetPass : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (IsPostBack)
            {
                ChangePassword.Visible = false;
            }
        }

        public string genrateOTP()
        { 
            Random rnd = new Random();
            return rnd.Next(1001,9999).ToString();
        }

        public void sendOTP(string email,string otp)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("mpoke1928@gmail.com");
            mail.To.Add(email);
            mail.Subject = "OTP verification";
            mail.Body = $"Hi User\nHere Is Your OTP : {otp}";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("mpoke1928@gmail.com", "dhfx widi jvps itnr"); // Add your email password here
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string em = TextBox1.Text, otp = genrateOTP();
            string q = $"exec AddOTP '{otp}','{em}'";
            SqlCommand cmd = new SqlCommand(q,conn);
            cmd.ExecuteNonQuery();

            sendOTP(em, otp);
            Button1.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string otp = TextBox2.Text, em = TextBox1.Text;
            string q = $"exec verifyOTP '{otp}','{em}'";
            SqlCommand cmd = new SqlCommand(q,conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                ChangePassword.Visible = true;
            }
            else
            {
                Response.Write("<script>alert('Invalid OTP!!')</script>");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string email=TextBox1.Text,newpass = TextBox3.Text;
            string q = $"exec updatePass '{email}','{newpass}'";
            SqlCommand cmd = new SqlCommand(q,conn);
            cmd.ExecuteNonQuery();
            Response.Write("<script>alert('Password UPdated SuccessFully!!'); window.location.href='Login.aspx'</script>");
        }
    }
}