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

            DateTime startDate = Calendar1.SelectedDate;
            DateTime endDate = Calendar2.SelectedDate;

            if (startDate != DateTime.MinValue && endDate != DateTime.MinValue && endDate >= startDate)
            {
                // Calculate the total number of days between the selected dates (including start and end date)
                totalLeaveDays = (endDate - startDate).Days + 1;

                // Display the total leave days in the label
                //Label2.Text = "Total Leave Days: " + totalLeaveDays;
                if (DropDownList1.SelectedValue.Equals("PL"))
                {
                    if (totalLeaveDays <= pl)
                    {
                        int remaingleave = pl - totalLeaveDays;
                        string qpl = $"update users set pl={remaingleave} where email='{Session["name"].ToString()}'";
                        SqlCommand cmd2 = new SqlCommand(qpl, conn);
                        cmd2.ExecuteNonQuery();

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
                        string qcl = $"update users set cl={remaingleave} where email='{Session["name"].ToString()}'";
                        SqlCommand cmd2 = new SqlCommand(qcl, conn);
                        cmd2.ExecuteNonQuery();

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
                        string qsl = $"update users set sl={remaingleave} where email='{Session["name"].ToString()}'";
                        SqlCommand cmd2 = new SqlCommand(qsl, conn);
                        cmd2.ExecuteNonQuery();

                    }
                    else
                    {
                        Response.Write($"<script>alert('you have only {sl} leaves left')</script> ");
                    }


                }

                string q = $"exec leave '{DropDownList1.SelectedValue.ToString()}','{Calendar1.SelectedDate}','{Calendar2.SelectedDate}','{totalLeaveDays}','{TextBox1.Text}','{Session["name"].ToString()}'";
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

        protected void Button3_Click(object sender, EventArgs e)
        {
            string q = $"select pl,sl,cl from users where urole='EMP' and email='{Session["name"].ToString()}'";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            Label2.Text = $"Total Paid leave : 12  Remaining Paid leaves : {rdr["pl"].ToString()} || Total Sick Leave :6  Remainig Sick leaves : {rdr["sl"].ToString()}\n|| Total Casual Leave :6 || Remainig Casual leaves : {rdr["cl"].ToString()}";

        }
    }
}