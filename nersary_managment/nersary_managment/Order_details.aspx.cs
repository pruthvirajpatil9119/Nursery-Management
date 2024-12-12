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
    public partial class Order_details : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            cn=new SqlConnection();
            cn.ConnectionString = "Data Source=PRUTHVIRAJ-PATI\\SQLEXPRESS;Initial Catalog=nursery_management;Integrated Security=True";
            cn.Open();
            txt_ord_det_id.Text = Convert.ToString(getnewid());
            getnewid();
        }
        public int getnewid()
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "select max (ord_det_id) from Order_details";
            object x = cmd.ExecuteScalar();
            if (Convert.ToString(x) == "")
                return 1;
            else
                return (Convert.ToInt32(x) + 1);
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "insert into Order_details values(" + txt_ord_det_id.Text + "," + txt_ord_id.Text + "," + txt_plant_id.Text + "," + txt_rate.Text + ","+txt_qty.Text+","+txt_amt.Text+","+txt_GST.Text+","+txt_Total.Text+")";
            cmd.ExecuteNonQuery();
            MessageBox.Show("inserted secssesfuly");
        }

    }
}