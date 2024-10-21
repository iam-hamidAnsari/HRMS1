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
    public partial class IntraChatrTrainer : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string fromEmail = Session["name"].ToString();
            string connString = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(connString);
            conn.Open();
            if (!IsPostBack)
            {

                string query = "exec fetchAllEmails";
                SqlDataAdapter ada = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                ada.Fill(dt);
                DropDownList1.DataSource = dt;
                DropDownList1.DataTextField = "email";
                DropDownList1.DataValueField = "email";
                DropDownList1.DataBind();
                DisplayPreviousMessages();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string fromEmail = Session["name"].ToString();
            string toEmail = DropDownList1.SelectedValue;
            string message = TextBox2.Text;


            string query = $"exec SendMsg '{fromEmail}','{toEmail}','{message}'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            DisplayPreviousMessages();
        }

        private void DisplayPreviousMessages()
        {

            string fromEmail = Session["name"].ToString();
            string toEmail = DropDownList1.SelectedValue;

            string query = $"fetchMsg '{fromEmail}','{toEmail}'";
            SqlDataAdapter ada = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }
    }
}