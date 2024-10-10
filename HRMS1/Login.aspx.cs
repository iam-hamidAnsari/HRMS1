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
    public partial class Login : System.Web.UI.Page
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
            string email=TextBox4.Text, password=TextBox5.Text;
            string q = $"exec Login '{email}','{password}'";
            SqlCommand cmd = new SqlCommand(q,conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    if (rdr["email"].Equals(email) && rdr["pass"].Equals(password) && rdr["urole"].Equals("HR"))
                    {
                        Session["name"] = email;
                        Response.Redirect("HRHome.aspx");
                    }
                    else if (rdr["email"].Equals(email) && rdr["pass"].Equals(password) && rdr["urole"].Equals("EMP"))
                    {
                        Session["name"] = email;
                        Response.Redirect("EmpHome.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid Cradentials..')</script>");

                    }

                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Cradentials..')</script>");

            }
        }
    }
}