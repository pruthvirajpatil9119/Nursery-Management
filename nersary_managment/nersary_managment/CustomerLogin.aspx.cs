using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace nersary_managment
{
    public partial class CustomerLogin : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection();
            cn.ConnectionString = "Data Source=PRUTHVIRAJ-PATI\\SQLEXPRESS;Initial Catalog=nursery_management;Integrated Security=True";
            cn.Open();
        }

        protected void btn_log_Click(object sender, EventArgs e)
        {
            
            cmd = new SqlCommand("select * from Customer_master where cust_email='" + txt_email.Text + "' and cust_password='" + txt_pass.Text + "'", cn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Session.Add("cid", dr[0]);
                Session.Add("cnm", dr[1]);

                MessageBox.Show("login sucessful");
                Response.Redirect("~/search/Customer_Dashboard.aspx");
            }
            else
            {
                MessageBox.Show("login failed");
                txt_email.Text = "";
                txt_pass.Text = "";
            }
        }

       
    }
}