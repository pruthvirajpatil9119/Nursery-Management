using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace nersary_managment.Report
{
    public partial class rpt_Plant_type : System.Web.UI.Page
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
            cmd.CommandText = "select * from Plant_Type";
            dr = cmd.ExecuteReader();

            PlaceHolder1.Controls.Add(new LiteralControl("<table border='2px' id='bill' class='table'><tr><th>Id </th><th>Name</th></tr>"));
            while (dr.Read())
            {
                PlaceHolder1.Controls.Add(new LiteralControl("<tr>"));
                PlaceHolder1.Controls.Add(new LiteralControl("<td>" + dr[0] + "</td>"));
                PlaceHolder1.Controls.Add(new LiteralControl("<td>" + dr[1] + "</td>"));

                PlaceHolder1.Controls.Add(new LiteralControl("</tr>"));
            }
            PlaceHolder1.Controls.Add(new LiteralControl("</table>"));
            dr.Close();
        }
    }
}