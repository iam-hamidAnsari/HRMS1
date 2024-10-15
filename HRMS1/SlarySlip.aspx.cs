using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS1
{
    public partial class SlarySlip : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDownloadSalarySlip_Click(object sender, EventArgs e)
        {
            if (Session["SalarySlipPDF"] != null)
            {
                byte[] pdfBytes = (byte[])Session["SalarySlipPDF"];

                // Clear the response and set content type for download
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=Salary Slip.pdf");
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