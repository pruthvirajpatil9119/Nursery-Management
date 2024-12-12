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
    public partial class Order_master : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            cn=new SqlConnection();
            cn.ConnectionString = "Data Source=PRUTHVIRAJ-PATI\\SQLEXPRESS;Initial Catalog=nursery_management;Integrated Security=True";
            cn.Open();
            txt_ord_id.Text = Convert.ToString(getnewid());
            getnewid();
            if (!IsPostBack)
                setdropdown();
        }
        public int getnewid()
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "select max (ord_id) from Order_master";
            object x = cmd.ExecuteScalar();
            if (Convert.ToString(x) == "")
                return 1;
            else
                return (Convert.ToInt32(x) + 1);
        }
        public void setdropdown()
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "select * from Payment";
            dr = cmd.ExecuteReader();
            DropDownList1.DataSource = dr;
            DropDownList1.DataValueField = "pay_id";
            DropDownList1.DataTextField = "pay_id";
            DropDownList1.DataBind();
            dr.Close();
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
         
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "insert into Order_master values(" + txt_ord_id.Text + ",'" + txt_ord_date.Text + "'," + DropDownList1.SelectedValue + "," + txt_grand_total.Text + ")";
            cmd.ExecuteNonQuery();
            MessageBox.Show("inserted secssesfuly");
        }


    }
}