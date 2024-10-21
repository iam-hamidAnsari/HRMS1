using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS1
{
    public partial class ViewGenratedDocs : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            con = new SqlConnection(connectionString);
            con.Open();

            string email = Session["name"].ToString();
            if (!IsPostBack)
            {
                LoadDocumentData(email);
            }
        }

        private void LoadDocumentData(string email)
        {
            
            
            string query = $"exec fetch_gen_doc '{email}'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}