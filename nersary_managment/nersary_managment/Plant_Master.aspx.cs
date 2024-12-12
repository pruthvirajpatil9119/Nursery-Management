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
    public partial class Plant_Master : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        static int flag = 0;
        static string fnm = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection();
            cn.ConnectionString = "Data Source=PRUTHVIRAJ-PATI\\SQLEXPRESS;Initial Catalog=nursery_management;Integrated Security=True";
            cn.Open();
            setgrid();
            txt_plant_height.CssClass = "form-control";

            txt_plant_id.CssClass = "form-control";
            txt_description.CssClass = "form-control";
          //  txt_photo.CssClass = "form-control";
            txt_plant_nm.CssClass = "form-control";
            txt_rate.CssClass = "form-control";
            txt_stock.CssClass = "form-control";
            btn_delete.CssClass = "btn alazea-btn mt-15";
            btn_new.CssClass = "btn alazea-btn mt-15";
                btn_save.CssClass="btn alazea-btn mt-15";
                btn_update.CssClass = "btn alazea-btn mt-15";
            if (!IsPostBack)
                setdropdown();
         
        }
        public void cleartext()
        {
            txt_plant_id.Text = "";
            txt_plant_nm.Text = "";
            //txt_type_id.Text = " ";
            txt_plant_height.Text = "";
            txt_description.Text= "";
            txt_rate.Text = "";
            txt_stock.Text = "";
          //  txt_photo.Text = " ";
        }
        public void enabledtext()
        {
            txt_plant_id.Enabled = true;
            txt_plant_nm.Enabled = true;
           // txt_type_id.Enabled = true;
            txt_plant_height.Enabled = true;
            txt_description.Enabled = true;
            txt_rate.Enabled = true;
            txt_stock.Enabled = true;
//txt_photo.Enabled = true;
        }
        public void disabletext()
        {
            txt_plant_id.Enabled = false;
            txt_plant_nm.Enabled = false;
            //txt_type_id.Enabled = false;
            txt_plant_height.Enabled = false;
            txt_description.Enabled = false;
            txt_rate.Enabled = false;
            txt_stock.Enabled = false;
          //  txt_photo.Enabled = false;
        }
        public void setgrid()
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "select * from Plant_Master";
            dr = cmd.ExecuteReader();
            GridView1.DataSource = dr;
            GridView1.DataBind();
            dr.Close();
        }
        public void setdropdown()
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "select * from Plant_Type";
            dr = cmd.ExecuteReader();
            DropDownList1.DataSource = dr;
            DropDownList1.DataValueField = "type_id";
            DropDownList1.DataTextField = "type_nm";
            DropDownList1.DataBind();
            dr.Close();
        }
        public int getnewid()//id=+1
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "select max (plant_id) from Plant_Master";
            object x = cmd.ExecuteScalar();
            if (Convert.ToString(x) == "")
                return 1;
            else
                return (Convert.ToInt32(x) + 1);
        }

        protected void btn_new_Click(object sender, EventArgs e)
        {
            flag = 1;
            txt_plant_id.Text = Convert.ToString(getnewid());
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
                cmd.CommandText = "insert into Plant_Master values("+ txt_plant_id.Text+ ",'"+txt_plant_nm.Text+"',"+ DropDownList1.SelectedValue+",'"+ txt_plant_height.Text +"','"+ txt_description.Text+"'," + txt_rate.Text + "," + txt_stock.Text + ",'" + fnm + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("inserted secssesfuly");
            }
            if (flag == 2)
            {
                cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "update Plant_Master set plant_nm ='" + txt_plant_nm.Text + "',type_id="+ DropDownList1.SelectedValue +",plant_height='" + txt_plant_height.Text + "',description='" + txt_description.Text + "',rate=" + txt_rate.Text + ",stock=" + txt_stock.Text + ",photo='" + fnm + "' where plant_id=" + txt_plant_id.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("updated secssesfuly");
            }
            btn_save.Enabled = false;
            btn_new.Enabled = true;
            cleartext();
            disabletext();
            setgrid();
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            flag = 2;
            enabledtext();
            btn_save.Enabled = true;
            btn_update.Enabled = false;
            btn_delete.Enabled = false;
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "delete from Plant_Master where plant_id=" + txt_plant_id.Text;
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
            txt_plant_id.Text = GridView1.SelectedRow.Cells[1].Text;
            txt_plant_nm.Text = GridView1.SelectedRow.Cells[2].Text;
           // txt_type_id.Text = GridView1.SelectedRow.Cells[3].Text;
            txt_plant_height.Text = GridView1.SelectedRow.Cells[4].Text;
            txt_description.Text = GridView1.SelectedRow.Cells[5].Text;
            txt_rate.Text = GridView1.SelectedRow.Cells[6].Text;
            txt_stock.Text = GridView1.SelectedRow.Cells[7].Text;
           // txt_photo.Text = GridView1.SelectedRow.Cells[8].Text;
            btn_new.Enabled = false;
            btn_save.Enabled = false;
            btn_update.Enabled = true;
            btn_delete.Enabled = true;
            setgrid();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile == true)
            {
                string path = Server.MapPath("~/upload/");
                fnm = FileUpload1.FileName;
                FileUpload1.SaveAs(path + FileUpload1.FileName);
                Image1.ImageUrl = "~/upload/" + FileUpload1.FileName;
            }
            else
            {
                MessageBox.Show("select photo");
            }
        }
        
    }
}