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
    public partial class Customer_master : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection();
            cn.ConnectionString = "Data Source=PRUTHVIRAJ-PATI\\SQLEXPRESS;Initial Catalog=nursery_management;Integrated Security=True";
            cn.Open();
            txt_cust_id.Text = Convert.ToString(getnewid());
            getnewid();
        }
        public int getnewid()
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "select max (cust_id) from Customer_master";
            object x = cmd.ExecuteScalar();
            if (Convert.ToString(x) == " ")
                return 1;
            else
                return (Convert.ToInt32(x) + 1);
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "insert into Customer_master values(" + txt_cust_id.Text + ",'" + txt_cust_nm.Text + "','" + txt_cust_addr.Text + "','" + txt_cust_email.Text + "','"+txt_cust_password.Text+"','"+txt_cust_mobile.Text+"')";
            cmd.ExecuteNonQuery();
            Response.Redirect("~/CustomerLogin.aspx");
          //  MessageBox.Show("inserted secssesfuly");
        }

    }
}