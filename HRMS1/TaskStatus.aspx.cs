using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS1
{
    public partial class TaskStatus : System.Web.UI.Page
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
            if (DropDownList1.SelectedValue.Equals("completed"))
            {
                string q = $"exec fetch_cmpltd_task '{DropDownList1.SelectedValue}'";
                SqlDataAdapter ada = new SqlDataAdapter(q, conn);
                DataTable dt = new DataTable();
                ada.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            if (DropDownList1.SelectedValue.Equals("not completd"))
            {
                string q = $"exec fetch_cmpltd_task '{DropDownList1.SelectedValue}'";
                SqlDataAdapter ada = new SqlDataAdapter(q, conn);
                DataTable dt = new DataTable();
                ada.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        { 
            if (e.CommandName.Equals("UpdateScore"))
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer; //for finding row
                Button addScore = (Button)row.FindControl("addscore");
                TextBox getscore = (TextBox)row.FindControl("TextBox1");

                int id = int.Parse(e.CommandArgument.ToString());

                AddScore(id,double.Parse(getscore.Text));
                Response.Write("<script>alert('Score Added!!')</script>");
                GridView1.DataBind();

            }


        }

        public void AddScore(int id, double score)
        {
            string q = $"exec Add_Score {id},{score}";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();
        }
    }
}