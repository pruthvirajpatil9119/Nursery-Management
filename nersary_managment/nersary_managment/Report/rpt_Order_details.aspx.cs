using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace nersary_managment.Report
{
    public partial class rpt_Order_details : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection();
            cn.ConnectionString = "Data Source=PRUTHVIRAJ-PATI\\SQLEXPRESS;Initial Catalog=nursery_management;Integrated Security=True";
            cn.Open();

            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "select * from Order_details";
            dr = cmd.ExecuteReader();

            PlaceHolder1.Controls.Add(new LiteralControl("<table border='2px' id='bill' class='table'><tr><th>Id </th><th>ord_id</th> <th>plant_id</th><th>rate</th><th>qty</th><th>amt</th><th>GST</th><th>Total</th></tr>"));
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