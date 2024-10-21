using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace HRMS1
{
    public partial class Resign : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            string name = TextBoxName.Text;
            string designation = TextBoxDesignation.Text;
            string reason = TextBoxReason.Text;
            string Email = Session["name"].ToString();
            string dateOfLeaving = TextBoxDateOfLeaving.Text;




            string email = "dts123.ds@gmail.com";
            string fromEmail = email;
            string toEmail = "mpoke1928@gmail.com";
            string subject = "Resignation - " + name;
            string body = GenerateEmailBody(name, designation, reason, dateOfLeaving.ToString());

            try
            {
                
                string pdfPath = GeneratePDF(name, designation, reason, dateOfLeaving, body);
                SendEmail(fromEmail, toEmail, subject, body,pdfPath);
            

                Response.Write("<script>alert('Resignation email sent and PDF generated successfully.');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error occurred: " + ex.Message + "');</script>");
            }
        }

        private string GenerateEmailBody(string name, string designation, string reason, string dateOfLeaving)
        {
            return $@"
                <html>
                <body>
                    <p>Dear HR Manager,</p>
                    <p>I hope this message finds you well. I am writing to formally resign from my position as <strong>{designation}</strong> at <strong>Masstech Bussiness Solution</strong>, effective <strong>{dateOfLeaving}</strong>.</p>
                    <p>The reason for my resignation is <strong>{reason}</strong>. This decision was not made lightly, and I am grateful for the support and opportunities I have received during my time here.</p>
                    <p>I am committed to ensuring a smooth transition and will do everything possible to hand over my responsibilities effectively. Please let me know how I can assist during this process.</p>
                    <p>Thank you once again for all the guidance and opportunities. I wish the team and the company continued success in the future.</p>
                    <p>Best regards,<br />
                    <strong>{name}</strong><br />
                    </p>
                </body>
                </html>";
        }

        private void SendEmail(string fromEmail, string toEmail, string subject, string body, string pdfPath)
        {
            MailMessage mail = new MailMessage(fromEmail, toEmail, subject, body)
            {
                IsBodyHtml = true
            };

           
            Attachment attachment = new Attachment(pdfPath);
            mail.Attachments.Add(attachment);

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new System.Net.NetworkCredential(fromEmail, "fyuy spab cyol eoes"), // Replace with your credentials
                EnableSsl = true
            };

            smtpClient.Send(mail);
        }

        private string GeneratePDF(string name, string designation, string reason, string dateOfLeaving, string body)
        {
            Document pdfDoc = new Document();
            string formattedName = name.Replace(" ", "_");
            string pdfPath = Server.MapPath($"~/Resignation/{formattedName}.pdf");
            PdfWriter.GetInstance(pdfDoc, new FileStream(pdfPath, FileMode.Create));

            pdfDoc.Open();
            Paragraph title = new Paragraph("Resignation Letter\n\n")
            {
                Alignment = Element.ALIGN_CENTER
            };
            pdfDoc.Add(title);
            pdfDoc.Add(new Paragraph($"Name: {name}\n"));
            pdfDoc.Add(new Paragraph($"Designation: {designation}\n"));
            pdfDoc.Add(new Paragraph($"Reason: {reason}\n"));
            pdfDoc.Add(new Paragraph($"Date of Leaving: {dateOfLeaving.ToString()}\n"));
            string cleanBody = StripHtmlTags(GenerateEmailBody(name, designation, reason, dateOfLeaving.ToString()));
            pdfDoc.Add(new Paragraph(cleanBody));
            pdfDoc.Close();

            string pdfPath1 = $"Resignation\\{formattedName}.pdf";

            string query = $"resign '{Session["name"].ToString()}','{designation}','{reason}','{dateOfLeaving}','{pdfPath1}'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            return pdfPath;
        }

        private string StripHtmlTags(string input)
        {
            return System.Text.RegularExpressions.Regex.Replace(input, "<.*?>", string.Empty).Trim();
        }
    }
}