using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;

namespace nersary_managment.Report
{
    public partial class Plant_Type_wise_Plant_Master : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection();
            cn.ConnectionString = "Data Source=PRUTHVIRAJ-PATI\\SQLEXPRESS;Initial Catalog=nursery_management;Integrated Security=True";
            cn.Open();
            if (!IsPostBack)
                setdropdown();
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
        protected void btnshow_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;



            cmd.CommandText = "Select plant_id,plant_nm,type_nm,plant_height,description,rate,stock,photo from Plant_Type,Plant_Master where Plant_Master.type_id=Plant_Type.type_id and  Plant_Master.type_id="+DropDownList1.SelectedValue;
            dr = cmd.ExecuteReader();

            PlaceHolder1.Controls.Add(new LiteralControl("<table border='2px' id='bill' class='table'><tr><th>Id </th><th>Name</th><th> Type </th><th> Height </th><th> description</th><th>rate</th><th>Stock</th><th>Photo</th></tr>"));
            while (dr.Read())
            {
                PlaceHolder1.Controls.Add(new LiteralControl("<tr>"));
                PlaceHolder1.Controls.Add(new LiteralControl("<td>" + dr[0] + "</td>"));
                PlaceHolder1.Controls.Add(new LiteralControl("<td>" + dr[1] + "</td>"));
                PlaceHolder1.Controls.Add(new LiteralControl("<td>" + dr[2] + "</td>"));
                PlaceHolder1.Controls.Add(new LiteralControl("<td>" + dr[3] + "</td>"));
                PlaceHolder1.Controls.Add(new LiteralControl("<td>" + dr[4] + "</td>"));
                PlaceHolder1.Controls.Add(new LiteralControl("<td>" + dr[5] + "</td>"));
                PlaceHolder1.Controls.Add(new LiteralControl("<td>" + dr[6] + "</td>"));
                PlaceHolder1.Controls.Add(new LiteralControl("<td>" + dr[7] + "</td>"));

                PlaceHolder1.Controls.Add(new LiteralControl("</tr>"));
            }
            PlaceHolder1.Controls.Add(new LiteralControl("</table>"));
            dr.Close();
        }
    }
}