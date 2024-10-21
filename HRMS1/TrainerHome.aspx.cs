using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS1
{
    public partial class TrainerHome : System.Web.UI.Page
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
            string from_dt=TextBox1.Text, to_dt=TextBox2.Text;
            string q = $"exec top3Candidates '{from_dt}','{to_dt}'";
            SqlDataAdapter ada = new SqlDataAdapter(q,conn);
            DataSet ds = new DataSet();
            ada.Fill(ds);
            DataList1.DataSource = ds;
            DataList1.DataBind();
           
        }
    }
}