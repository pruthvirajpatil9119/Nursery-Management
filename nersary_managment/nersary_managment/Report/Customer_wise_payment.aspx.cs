using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;

namespace nersary_managment.Report
{
    public partial class Customer_wise_payment : System.Web.UI.Page
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
            cmd.CommandText = "select * from Customer_master";
            dr = cmd.ExecuteReader();
            DropDownList1.DataSource = dr;
            DropDownList1.DataValueField = "cust_id";
            DropDownList1.DataTextField = "cust_nm";
            DropDownList1.DataBind();
            dr.Close();
        }
        protected void btnshow_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;


            cmd.CommandText = "select pay_id,cust_nm,pay_amt,pay_date,card_no  from Payment,Customer_master,Order_master where Payment.ord_id=Order_master.ord_id and Order_master.cust_id=Customer_master.cust_id  and Payment.ord_id=" + DropDownList1.SelectedValue;
            dr = cmd.ExecuteReader();

            PlaceHolder1.Controls.Add(new LiteralControl("<table border='2px'  id='bill' class='table'><tr><th>Id </th><th>Name</th><th> Amount</th><th>Date</th><th>Card_no</th></tr>"));
            while (dr.Read())
            {
                PlaceHolder1.Controls.Add(new LiteralControl("<tr>"));
                PlaceHolder1.Controls.Add(new LiteralControl("<td>" + dr[0] + "</td>"));
                PlaceHolder1.Controls.Add(new LiteralControl("<td>" + dr[1] + "</td>"));
                PlaceHolder1.Controls.Add(new LiteralControl("<td>" + dr[2] + "</td>"));
                PlaceHolder1.Controls.Add(new LiteralControl("<td>" + dr[3] + "</td>"));
                PlaceHolder1.Controls.Add(new LiteralControl("<td>" + dr[4] + "</td>"));

                PlaceHolder1.Controls.Add(new LiteralControl("</tr>"));
            }
            PlaceHolder1.Controls.Add(new LiteralControl("</table>"));
            dr.Close();
        }
    }
}