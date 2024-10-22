using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS1
{
    public partial class Tasks : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                fetchTask();
            }
        }

        public void fetchTask()
        {
            string q = $"exec fetch_task '{Session["name"].ToString()}'";
            SqlDataAdapter ada = new SqlDataAdapter(q, conn);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        public void sumbitTask(int id ,string path)
        {
            string q = $"exec sumbit_task {id},'{path}'";
            SqlCommand cmd = new SqlCommand(q,conn);
            cmd.ExecuteNonQuery();
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        { 
            if (e.CommandName.Equals("UploadSoln"))
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;

                Button uploadbtn = (Button)row.FindControl("Sumbitbtn");


                // Find the FileUpload control within the GridViewRow
                FileUpload fileUploadControl = (FileUpload)row.FindControl("FileUpload1");
                int id = int.Parse(e.CommandArgument.ToString());
                if (fileUploadControl.HasFile)
                {
                    fileUploadControl.SaveAs(Server.MapPath("UploadedDocuments") + Path.GetFileName(fileUploadControl.FileName));
                    string filepath = "UploadedDocuments" + Path.GetFileName(fileUploadControl.FileName);
                    sumbitTask(id, filepath);
                    Response.Write("<script>alert('Task Sumbitted!!')</script>");
                    
                }
                else
                {
                    Response.Write("<script>alert('Atach soln File first !!')</script>");
                }

            }


        }
    }
}