using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;

namespace nersary_managment.Report
{
    public partial class Payment_wise_order_master : System.Web.UI.Page
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
            cmd.CommandText = "select * from Payment";
            dr = cmd.ExecuteReader();
            DropDownList1.DataSource = dr;
            DropDownList1.DataValueField = "pay_id";
            DropDownList1.DataTextField = "pay_id";
            DropDownList1.DataBind();
            dr.Close();
        }
        protected void btnshow_Click(object sender, EventArgs e)
        {

            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "select ord_id,ord_date,Payment.pay_id,grand_total from Order_master,Payment where Order_master.cust_id=Payment.pay_id and Order_master.pay_id="+DropDownList1.SelectedValue;
            dr = cmd.ExecuteReader();

            PlaceHolder1.Controls.Add(new LiteralControl("<table border='2px' id='bill' class='table'><tr><th>Id </th><th>Name</th><th> Payment ID</th><th>Total</th></tr>"));
            while (dr.Read())
            {
                PlaceHolder1.Controls.Add(new LiteralControl("<tr>"));
                PlaceHolder1.Controls.Add(new LiteralControl("<td>" + dr[0] + "</td>"));
                PlaceHolder1.Controls.Add(new LiteralControl("<td>" + dr[1] + "</td>"));
                PlaceHolder1.Controls.Add(new LiteralControl("<td>" + dr[2] + "</td>"));
                PlaceHolder1.Controls.Add(new LiteralControl("<td>" + dr[3] + "</td>"));

                PlaceHolder1.Controls.Add(new LiteralControl("</tr>"));
            }
            PlaceHolder1.Controls.Add(new LiteralControl("</table>"));
            dr.Close();
        }
    }
}