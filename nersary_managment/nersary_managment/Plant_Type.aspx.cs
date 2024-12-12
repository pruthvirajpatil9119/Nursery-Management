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
    public partial class Plant_Type : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        static int flag = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection();
            cn.ConnectionString = "Data Source=PRUTHVIRAJ-PATI\\SQLEXPRESS;Initial Catalog=nursery_management;Integrated Security=True";
            cn.Open();
            setgrid();
            txt_id.CssClass = "form-control";
            txt_nm.CssClass = "form-control";
            btn_delete.CssClass = "btn alazea-btn mt-15";
            btn_new.CssClass = "btn alazea-btn mt-15";
                btn_save.CssClass="btn alazea-btn mt-15";
                btn_update.CssClass = "btn alazea-btn mt-15";

        }
        public void cleartext()
        {
            txt_id.Text = " ";
            txt_nm.Text = " ";
        }
        public void enabledtext()
        {
            txt_id.Enabled = true;
            txt_nm.Enabled = true;
        }
        public void disabletext()
        {
            txt_id.Enabled = false;
            txt_nm.Enabled = false;
        }
        public void setgrid()
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "select * from Plant_Type";
            dr = cmd.ExecuteReader();
            GridView1.DataSource = dr;
            GridView1.DataBind();
            dr.Close();
        }
        public int getnewid()//id=+1
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "select max (type_id) from Plant_Type";
            object x = cmd.ExecuteScalar();
            if (Convert.ToString(x) == " ")
                return 1;
            else
                return (Convert.ToInt32(x) + 1);
        }

        protected void btn_new_Click(object sender, EventArgs e)
        {
            flag = 1;
            txt_id.Text = Convert.ToString(getnewid());
            getnewid();
            enabledtext();
            btn_save.Enabled = true;
            btn_new.Enabled = false;
            setgrid();
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "insert into Plant_Type values(" + txt_id.Text + ",'" + txt_nm.Text + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("inserted secssesfuly");
            }
            if (flag == 2)
            {
                cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "update Plant_Type set type_nm ='" + txt_nm.Text + "'where type_id=" + txt_id.Text + "";
                cmd.ExecuteNonQuery();
                MessageBox.Show("updated secssesfuly");
            }
            btn_save.Enabled = false;
            btn_new.Enabled = true;
            cleartext();
            disabletext();
            setgrid();
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "delete from Plant_Type where type_id=" + txt_id.Text;
            cmd.ExecuteNonQuery();
            MessageBox.Show("deleted secssesfuly");
            btn_new.Enabled = true;
            btn_delete.Enabled = false;
            btn_update.Enabled = false;
            cleartext();
            disabletext();
            setgrid();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_id.Text = GridView1.SelectedRow.Cells[1].Text;
            txt_nm.Text = GridView1.SelectedRow.Cells[2].Text;
            btn_new.Enabled = false;
            btn_save.Enabled = false;
            btn_update.Enabled = true;
            btn_delete.Enabled = true;
            setgrid();
        }

        protected void brn_update_Click(object sender, EventArgs e)
        {

            flag = 2;
            enabledtext();
            btn_save.Enabled = true;
            btn_update.Enabled = false;
            btn_delete.Enabled = false;
        }



    }
}