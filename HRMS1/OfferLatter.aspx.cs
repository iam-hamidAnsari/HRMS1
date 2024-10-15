using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace HRMS1
{
    public partial class OfferLatter : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cd = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cd);
            conn.Open();

        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string email = txtEmail.Text;
            DateTime dateOfJoining = DateTime.Parse(txtDate.Text);
            string designation = txtDesignation.Text;
            string ad = string.Empty;

            // Getting Adress
            string q = $"exec fetchAdd '{email}'";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                ad = reader["address"].ToString();

            }

            // Generate PDF
            using (MemoryStream stream = new MemoryStream())
            {
                Document pdfDoc = new Document();
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();

                pdfDoc.Add(new Paragraph($"{name}"));
                pdfDoc.Add(new Paragraph($"{ad}"));
                pdfDoc.Add(new Paragraph($"\nSubject: Offer of Employment at Masstech"));
                pdfDoc.Add(new Paragraph($"\nDear {name}"));
                pdfDoc.Add(new Paragraph($"We are pleased to extend this formal offer of employment for the position of {designation} at Masstech." +
                    $" After careful evaluation, we are confident that your skills and qualifications will make a valuable contribution to our team."));
                pdfDoc.Add(new Paragraph("\nPosition Details :"));
                pdfDoc.Add(new Paragraph($"Designation: {designation}"));
                pdfDoc.Add(new Paragraph($"Date of Joining: {dateOfJoining.ToShortDateString()}"));
                pdfDoc.Add(new Paragraph("Work Location : Thane"));
                pdfDoc.Close();

                // Send Email
                SendEmailWithAttachment(email, stream.ToArray(), name);

                // Get the generated PDF as a byte array
                string folderPath = Server.MapPath("~/GeneratedPDFs/");

                // Ensure the folder exists
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Save the PDF to the folder
                string fileName = $"{name}_OfferLetter.pdf"; // Customize the file name if needed
                string filePath = Path.Combine(folderPath, fileName);

                string fpq = $"exec add_offer_letter '{filePath}','{email}'";
                SqlCommand cmd1 = new SqlCommand(fpq,conn);
                cmd1.ExecuteNonQuery();

                File.WriteAllBytes(filePath, stream.ToArray());
            }

            // Optional
            Response.Write("<script>alert('Offer letter generated and sent successfully!');</script>");
        }

        private void SendEmailWithAttachment(string email, byte[] pdfContent, string name)
        {
            try
            {
                MailMessage mail = new MailMessage("anishborse27@gmail.com", email);
                mail.Subject = "Offer of Employment";
                mail.Body = $"Dear '{name}'" +
                        "\n\nWe am pleased to extend an offer to join Masstech. We were impressed with your qualifications and believe you will be a great fit for our team." +
                        $"\nPlease find attached your offer letter." +
                        $"\n\nthanks & regards" +
                        $"Hr Department";

                using (MemoryStream ms = new MemoryStream(pdfContent))
                {
                    mail.Attachments.Add(new Attachment(ms, "Offer_Letter.pdf", "application/pdf"));

                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                    {
                        Port = 587,
                        Credentials = new NetworkCredential("anishborse27@gmail.com", "zcxj ygtn xajm trrh"),
                        EnableSsl = true
                    };

                    smtpClient.Send(mail);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }
    }
}