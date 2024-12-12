using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace nersary_managment
{
    public partial class Payment : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;


        protected void Page_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection();
            cn.ConnectionString = "Data Source=PRUTHVIRAJ-PATI\\SQLEXPRESS;Initial Catalog=nursery_management;Integrated Security=True";
            cn.Open();
            txt_pay_id.Text = Convert.ToString(getnewid());
            getnewid();
            txt_pay_id.Text = Convert.ToString(getnewid());
            txt_pay_date.Text = System.DateTime.Now.ToString();
            TextBox1.Text = Session["cnm"].ToString();

            txt_pay_amt.Text = Session["grand"].ToString();
            idarray = new ArrayList();
            nmarray = new ArrayList();
            ratearray = new ArrayList();
            cntarray = new ArrayList();
            qtyarray = new ArrayList();
            //gstarray = new ArrayList();
            int i;
            idarray = (ArrayList)Session["idarray"];
            nmarray = (ArrayList)Session["nmarray"];
            ratearray = (ArrayList)Session["ratearray"];
            //gstarray = (ArrayList)Session["gstarray"];
            qtyarray = (ArrayList)Session["qtyarray"];
            cntarray = (ArrayList)Session["cntarray"];


          

        }
       
        public int getnewid()
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "select max (pay_id) from Payment";
            object x = cmd.ExecuteScalar();
            if (Convert.ToString(x) == "")
                return 1;
            else
                return (Convert.ToInt32(x) + 1);
        }
        ArrayList idarray;
        ArrayList nmarray;
        ArrayList qtyarray;
        ArrayList ratearray;
        ArrayList cntarray;
        protected void btn_save_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "insert into Payment values(" + txt_pay_id.Text + "," + Session["ordid"] + "," + txt_pay_amt.Text + ",'" + txt_pay_date.Text + "'," + txt.Text + ")";
            cmd.ExecuteNonQuery();
            MessageBox.Show("inserted secssesfuly");
            Response.Redirect("~/Invoice.aspx");
        }

    }
}