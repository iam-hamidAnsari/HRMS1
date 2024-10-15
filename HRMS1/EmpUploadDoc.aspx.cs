using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS1
{
    public partial class EmpUploadDoc : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cd = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cd);
            conn.Open();
            string email = Session["name"].ToString();
            string query = $"exec fetch_doc'{email}'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                string addharPath = rdr["addhar_card"] != DBNull.Value ? rdr["addhar_card"].ToString() : null;
                string panPath = rdr["pan_card"] != DBNull.Value ? rdr["pan_card"].ToString() : null;
                string sscMarksheetPath = rdr["ssc_marksheet"] != DBNull.Value ? rdr["ssc_marksheet"].ToString() : null;
                string hscMarksheetPath = rdr["hsc_marksheet"] != DBNull.Value ? rdr["hsc_marksheet"].ToString() : null;
                string graduationPath = rdr["graduation_certificate"] != DBNull.Value ? rdr["graduation_certificate"].ToString() : null;

                AddDocumentToPanel(addharPath);
                AddDocumentToPanel(panPath);
                AddDocumentToPanel(sscMarksheetPath);
                AddDocumentToPanel(hscMarksheetPath);
                AddDocumentToPanel(graduationPath);
            }
            else
            {
                lblMessage.Text = "No documents found for the specified email.";
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                // Retrieve email from session (assuming it is already stored in session)
                string email = Session["name"].ToString();

                // Define folder path where files will be saved on the server
                string folderPath = Server.MapPath("~/UploadedDocuments/");

                // Save the uploaded file to the server
                string fileName = FileUpload1.FileName;
                string savePath = $"{folderPath}{fileName}";  // Using string interpolation for file path
                FileUpload1.SaveAs(savePath);

                // Initialize document variables (file paths)
                string addharPath = null, panPath = null, sscMarksheetPath = null, hscMarksheetPath = null, graduationCertificatePath = null;

                SqlCommand cmd;
                // Determine which document is being uploaded based on the dropdown list
                if (ddlDocuments.SelectedValue.Equals("Addhar Card"))
                {
                    addharPath = $"/UploadedDocuments/{fileName}";
                    string q = $"update users set addhar_card='{addharPath}' where email='{email}'";  // Enclosed email in single quotes
                    cmd = new SqlCommand(q, conn);
                    cmd.ExecuteNonQuery();
                }
                else if (ddlDocuments.SelectedValue.Equals("Pan card"))
                {
                    panPath = $"/UploadedDocuments/{fileName}";
                    string pq = $"update users set pan_card='{panPath}' where email='{email}'";  // Enclosed email in single quotes
                    cmd = new SqlCommand(pq, conn);
                    cmd.ExecuteNonQuery();
                }
                else if (ddlDocuments.SelectedValue.Equals("Ssc markshet"))
                {
                    sscMarksheetPath = $"/UploadedDocuments/{fileName}";
                    string sscq = $"update users set ssc_marksheet='{sscMarksheetPath}' where email='{email}'";  // Enclosed email in single quotes
                    cmd = new SqlCommand(sscq, conn);
                    cmd.ExecuteNonQuery();
                }
                else if (ddlDocuments.SelectedValue.Equals("Hsc marksheet"))
                {
                    hscMarksheetPath = $"/UploadedDocuments/{fileName}";
                    string hscq = $"update users set hsc_marksheet='{hscMarksheetPath}' where email='{email}'";  // Enclosed email in single quotes
                    cmd = new SqlCommand(hscq, conn);
                    cmd.ExecuteNonQuery();
                }
                else if (ddlDocuments.SelectedValue.Equals("Graduation Certificate"))
                {
                    graduationCertificatePath = $"/UploadedDocuments/{fileName}";
                    string gcq = $"update users set graduation_Certificate='{graduationCertificatePath}' where email='{email}'";  // Enclosed email in single quotes
                    cmd = new SqlCommand(gcq, conn);
                    cmd.ExecuteNonQuery();
                }
                lblMessage.Text = $"File '{fileName}' uploaded successfully!";
            }
            else
            {
                lblMessage.Text = "Please select a file to upload.";
            }
        }


        private void AddDocumentToPanel(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                // Create a new panel for each document
                Panel documentPanel = new Panel();
                documentPanel.Attributes["style"] = "margin-bottom: 10px;";

                // Check if the file is an image or another document
                if (filePath.EndsWith(".jpg") || filePath.EndsWith(".png") || filePath.EndsWith(".jpeg"))
                {
                    Image img = new Image();
                    img.ImageUrl = filePath; // Use the relative URL
                    img.Width = Unit.Pixel(300);
                    documentPanel.Controls.Add(img);
                }
                else
                {
                    // Create a link for non-image files
                    Literal ltlLink = new Literal();
                    ltlLink.Text = $"<a href='{filePath}' target='_blank'>View Document</a>";
                    documentPanel.Controls.Add(ltlLink);
                }

                // Add the document panel to the main panel
                pnlDocuments.Controls.Add(documentPanel);
            }
        }
    }
}
