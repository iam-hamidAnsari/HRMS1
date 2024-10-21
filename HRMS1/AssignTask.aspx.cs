using Org.BouncyCastle.Tls;
using System;
using System.Collections;
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
    public partial class AssignTask : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            { 
                getemail();
            }
            
        }

        public void getemail()
        {
            string q = "exec fetchEmails";
            SqlDataAdapter ada = new SqlDataAdapter(q,conn);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            if (dt.Rows.Count > 0 )
            {
                CheckBoxList1.DataSource = dt;
                CheckBoxList1.DataTextField = "email";
                CheckBoxList1.DataValueField = "email";
                CheckBoxList1.DataBind();
            }
            
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            FileUpload1.SaveAs(Server.MapPath("UploadedDocuments/") + Path.GetFileName(FileUpload1.FileName));
            string attachfile = "UploadedDocuments/" + Path.GetFileName(FileUpload1.FileName);
            string date = DateTime.Today.ToString("yyyy-MM-dd");
            //storing values in list 
            List<string> selectedemails = new List<string>();
            foreach (ListItem item in CheckBoxList1.Items) //itrating it 
            {
                if (item.Selected)
                { 
                    selectedemails.Add(item.Value);//fetching values
                }
            }

            if (selectedemails.Count > 0)
            {
                foreach (var email in selectedemails)
                {
                    string q = $"exec Assign_task '{TextBox1.Text}','{attachfile}','{email}','{date}'";
                    SqlCommand cmd = new SqlCommand(q, conn);
                    cmd.ExecuteNonQuery();
                }
                Response.Write("<script>alert('Task Assigned SuccessFully..')</script>");
            }
        }
    }
}