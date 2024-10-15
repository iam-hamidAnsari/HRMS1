using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();

            string q = $"select pl,sl,cl from leave where email='{Session["name"].ToString()}'";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            lblpl.Text = $"Total Paid leave : 12 ||  Remaining Paid leaves : {rdr["pl"].ToString()} ";
            lblsl.Text= $"Total Sick Leave :6 || Remainig Sick leaves : {rdr["sl"].ToString()}\n";
            lblcl.Text=  $" Total Casual Leave :6  || Remainig Casual leaves : {rdr["cl"].ToString()}";
        }
    }
}