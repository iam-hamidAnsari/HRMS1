using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace HRMS1
{
    public partial class EmpHome : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int cl = 6, sl = 6, pl = 12, totalLeaveDays;

            DateTime startDate = DateTime.Parse(Calendar1.Text);
            DateTime endDate = DateTime.Parse(Calendar2.Text);

            if (startDate != DateTime.MinValue && endDate != DateTime.MinValue && endDate >= startDate)
            {
                // Calculate the total number of days between the selected dates (including start and end date)
                totalLeaveDays = (endDate - startDate).Days + 1;
                //Session["rqstLeaveDays"] = totalLeaveDays;

                // Display the total leave days in the label
                //Label2.Text = "Total Leave Days: " + totalLeaveDays;
                if (DropDownList1.SelectedValue.Equals("PL"))
                {
                    if (totalLeaveDays <= pl)
                    {
                        int remaingleave = pl - totalLeaveDays;
                        

                    }
                    else
                    {
                        Response.Write($"<script>alert('you have only {pl} leaves left')</script> ");
                    }
                    

                }
                else if (DropDownList1.SelectedValue.Equals("CL"))
                {
                    if (totalLeaveDays <= cl)
                    {
                        int remaingleave = cl - totalLeaveDays;
                      

                    }
                    else
                    {
                        Response.Write($"<script>alert('you have only {cl} leaves left')</script> ");
                    }


                }
                else if (DropDownList1.SelectedValue.Equals("SL"))
                {
                    if (totalLeaveDays <= sl)
                    {
                        int remaingleave = sl - totalLeaveDays;

                    }
                    else
                    {
                        Response.Write($"<script>alert('you have only {sl} leaves left')</script> ");
                    }


                }

                string startDateString = startDate.ToString("yyyy-MM-dd");
                string endDateString = endDate.ToString("yyyy-MM-dd");
                string q = $"exec rqst_leave '{Session["name"].ToString()}','{DropDownList1.SelectedValue}','{startDateString}','{endDateString}','{totalLeaveDays}','{TextBox1.Text}'";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.ExecuteNonQuery();
                Response.Write($"<script>alert('Leave Applied Sucessfulyy..')</script> ");

            }
            else
            {
                // Display an error message if dates are invalid or not selected properly
                Response.Write($"<script>alert('Please select valid start and end dates.')</script> ");
            }

            
        }

        

        
    }
}