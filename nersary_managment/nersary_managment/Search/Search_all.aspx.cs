using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace nersary_managment.Search
{
    public partial class Search_all : System.Web.UI.Page
    {
        SqlCommand cmd;
        SqlConnection cn;
        SqlDataReader dr1;
        protected void Page_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection();
            cn.ConnectionString = "Data Source=PRUTHVIRAJ-PATI\\SQLEXPRESS;Initial Catalog=nursery_management;Integrated Security=True";
            cn.Open();



            cmd = new SqlCommand("SELECT * FROM Plant_Master", cn);
            dr1 = cmd.ExecuteReader();
            int cnt = 1;

            while (dr1.Read())
            {
                cnt++;
            }
            dr1.Close();
            cmd = new SqlCommand("SELECT * FROM Plant_Master", cn);
            dr1 = cmd.ExecuteReader();
            int i;
            Literal lit1, lit2, lit3, lit4, lit5;
            lit1 = new Literal();
            lit2 = new Literal();
            lit3 = new Literal();
            lit4 = new Literal();
            lit5 = new Literal();

            lit1.Text = "<table class='table'>";
            lit2.Text = "<tr>";
            lit3.Text = "<td>";
            lit4.Text = "</td>";
            lit5.Text = "</tr>";
            PlaceHolder1.Controls.Add(new LiteralControl("<table class='table'><br>"));
            PlaceHolder1.Controls.Add(new LiteralControl("<tr>"));
            int j;
            for (i = 0; i < cnt; i++)
            {
                for (j = 0; j < 5; j++)
                {
                    if (dr1.Read())
                    {
                        PlaceHolder1.Controls.Add(new LiteralControl("<td>"));
                        PlaceHolder1.Controls.Add(new LiteralControl("<a href=Searchdetails.aspx?ID=" + dr1[0].ToString() + "><img src='../upload/" + dr1[7].ToString() + "' height='200px' width='200px' style='border:2px solid red;border-radius:40px;' ></img></a><br>"));
                        PlaceHolder1.Controls.Add(new LiteralControl("<h3>" + dr1[1].ToString() + "</h3>"));
                        PlaceHolder1.Controls.Add(new LiteralControl("</a>"));
                        PlaceHolder1.Controls.Add(new LiteralControl("<font color=Green size=4>" + ("Rs.") + "</font>"));
                        PlaceHolder1.Controls.Add(new LiteralControl("<font color=Green size=4>" + dr1[5].ToString() + "/-</font>"));
                        PlaceHolder1.Controls.Add(new LiteralControl("</center></td>"));
                    }

                }
                PlaceHolder1.Controls.Add(new LiteralControl("</tr>"));

            }

            PlaceHolder1.Controls.Add(new LiteralControl("</table>"));
        }
    }
}