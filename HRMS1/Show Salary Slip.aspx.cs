using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS1
{
    public partial class Show_Salary_Slip : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Retrieve the PDF byte array from the session
            if (Session["SalarySlipPDF"] != null)
            {
                byte[] pdfBytes = (byte[])Session["SalarySlipPDF"];

                // Clear the response
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", pdfBytes.Length.ToString());
                Response.BinaryWrite(pdfBytes);
                Response.Flush();
                Response.End();
            }
            else
            {
                Response.Write("Salary Slip PDF is not available.");
            }
        }
    }
}