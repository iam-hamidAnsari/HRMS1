using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;

namespace HRMS1
{
    public partial class GenrateSlip : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
        }


        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string month = ddlMonth.SelectedValue;
            int absentDays = int.Parse(txtAbsentDays.Text);
            string n = string.Empty;
            string c = string.Empty;

            // Calculate salary
            double baseSalary = 5000; // Example salary
            int totalDays = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            //int presentDays = totalDays - absentDays;
            double dailysalary = baseSalary / totalDays;
            double deductio = dailysalary*absentDays;
            double salary = baseSalary - deductio;


            // Getting name and contact no
            string q = $"exec fetchName '{email}'";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                n = reader["name"].ToString();
                c = reader["contct_no"].ToString();
            }



            // Generate PDF
            using (MemoryStream stream = new MemoryStream())
            {
                Document pdfDoc = new Document();
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();

                pdfDoc.Add(new Paragraph($"Name : {n}"));
                pdfDoc.Add(new Paragraph($"Salary Slip for: {email}"));
                pdfDoc.Add(new Paragraph($"Contact No: {c}"));
                pdfDoc.Add(new Paragraph($"Month: {month}"));
                pdfDoc.Add(new Paragraph($"Absent Days: {absentDays}"));
                pdfDoc.Add(new Paragraph($"Gross Salary: {baseSalary}"));
                pdfDoc.Add(new Paragraph($"Deducted amount: {deductio:F2}"));
                pdfDoc.Add(new Paragraph($"Your Finally Salary is: {salary:F2}"));
                pdfDoc.Close();

                SendEmailWithAttachment(email, stream.ToArray());// Get the generated PDF as a byte array
                byte[] pdfBytes = stream.ToArray();

                // Store the PDF byte array in the session
                Session["SalarySlipPDF"] = pdfBytes;
                Response.Write("<script>alert('Salary Slip Genrated SuccessFully..')</script>");
            }
        }

        private void SendEmailWithAttachment(string em, byte[] pdfContent)
        {
            try
            {
                MailMessage mail = new MailMessage("anishborse27@gmail.com", em);
                mail.Subject = "Your Salary Slip";
                mail.Body = "Please find attached your salary slip.";

                using (MemoryStream ms = new MemoryStream(pdfContent))
                {
                    mail.Attachments.Add(new Attachment(ms, "Salary_Slip.pdf", "application/pdf"));

                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                    smtpClient.Port = 587;
                    smtpClient.Credentials = new NetworkCredential("anishborse27@gmail.com", "zcxj ygtn xajm trrh");
                    smtpClient.EnableSsl = true;

                    smtpClient.Send(mail);
                }
            }
            catch (SmtpException smtpEx)
            {
                Console.WriteLine($"SMTP Error: {smtpEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

}