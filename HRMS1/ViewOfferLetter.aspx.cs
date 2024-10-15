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
    public partial class ViewOfferLetter : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cd = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cd);
            conn.Open();

            string q = $"exec fetch_offer_letter '{Session["name"].ToString()}'";
            SqlCommand cmd = new SqlCommand(q,conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            string filePath = rdr["offer_letter"].ToString();

            
            
                

                if (filePath !=null)
                {
                    Response.ContentType = "application/pdf";
                    Response.AppendHeader("Content-Disposition", $"attachment; filename={Session["name"].ToString()}_Offer Letter");
                    Response.TransmitFile(filePath);
                    Response.End();
                }
                else
                {
                    // Handle case where file does not exist
                    Response.Write("<script>alert('PDF file not found.');</script>");
                }
            

        }
    }
}