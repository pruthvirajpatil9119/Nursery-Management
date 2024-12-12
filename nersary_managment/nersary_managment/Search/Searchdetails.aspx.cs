using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections;


namespace nersary_managment.Search
{
    public partial class Searchdetails : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr1;
        static int stock =30;
        static int rate;
        static int prodid;
        static int qty;
        static int cnt;
        static string prodnm;
        protected void Page_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection();
            cn.ConnectionString = "Data Source=PRUTHVIRAJ-PATI\\SQLEXPRESS;Initial Catalog=nursery_management;Integrated Security=True";
            cn.Open();



            string id = Request.QueryString["ID"];
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "select * from  Plant_Master where plant_id=" + id;
            dr1 = cmd.ExecuteReader();
            setqty();
            int cnt = 1;

            while (dr1.Read())
            {
                cnt++;
            }
            dr1.Close();


            cmd = new SqlCommand("select * from  Plant_Master where plant_id=" + id, cn);
            dr1 = cmd.ExecuteReader();
            int i;
            Literal l1;
            Image i1;
            HyperLink h1;
            PlaceHolder1.Controls.Add(new LiteralControl("<table class='table'>"));
            PlaceHolder1.Controls.Add(new LiteralControl("<tr>"));
            int j;
            for (i = 0; i < cnt; i++)
            {
                for (j = 0; j < 5; j++)
                {
                    if (dr1.Read())
                    {
                        PlaceHolder1.Controls.Add(new LiteralControl("<td>"));
                        l1 = new Literal();
                        i1 = new Image();
                        h1 = new System.Web.UI.WebControls.HyperLink();

                        i1.Height = 500;
                        i1.Width = 500;
                        i1.ImageUrl = "~/Upload/" + dr1.GetString(7);
                        l1.Text = "<br>";
                        PlaceHolder1.Controls.Add(i1);
                        PlaceHolder1.Controls.Add(new LiteralControl("</td><td width='600px' align=right>"));
                        PlaceHolder1.Controls.Add(l1);
                        PlaceHolder1.Controls.Add(h1);

                        PlaceHolder1.Controls.Add(new LiteralControl("<h1>" + dr1.GetString(1) + "</h1>"));
                        PlaceHolder1.Controls.Add(new LiteralControl("<h5>Plant Height:&nbsp;&nbsp;&nbsp;" + dr1[3] + ""));
                        PlaceHolder1.Controls.Add(new LiteralControl("<h5>Description:&nbsp;&nbsp;&nbsp;" + dr1[4] + ""));
                        PlaceHolder1.Controls.Add(new LiteralControl("<h5>Rate (Rs.):&nbsp;&nbsp;&nbsp;" + dr1[5] + ""));

                        rate = Convert.ToInt32(dr1[5].ToString());
                        prodid = Convert.ToInt32(dr1[0].ToString());
                        prodnm = dr1[1].ToString();

                        Session["prodid"] = prodid;
                        Session["prodnm"] = prodnm;
                        Session["rate"] = rate;

                        PlaceHolder1.Controls.Add(new LiteralControl("<br>"));
                        PlaceHolder1.Controls.Add(new LiteralControl("</td>"));
                    }

                }// ending j loop
                PlaceHolder1.Controls.Add(new LiteralControl("</tr>"));

            }//ending i loop

            PlaceHolder1.Controls.Add(new LiteralControl("</table>"));
            dr1.Close();
           
        }
        public void setqty()
        {
            
            for (int i = 1; i < stock; i++)
                DropDownList1.Items.Add(Convert.ToString(i));


        }
        static ArrayList idarray = new ArrayList();
        static ArrayList nmarray = new ArrayList();
        static ArrayList qtyarray = new ArrayList();
        static ArrayList ratearray = new ArrayList();
        static ArrayList cntarray = new ArrayList();

        protected void Button1_Click(object sender, EventArgs e)
        {
             cnt = cnt + 1;
                        idarray.Add(Session["prodid"]);
                        Session.Add("idarray", idarray);


                        nmarray.Add(Session["prodnm"]);
                        Session.Add("nmarray", nmarray);


                        ratearray.Add(Session["rate"]);
                        Session.Add("ratearray", ratearray);


                        Session.Add("qty",DropDownList1.SelectedValue);
                        qtyarray.Add(Session["qty"]);
                        Session.Add("qtyarray", qtyarray);

                        Session.Add("cnt", cnt);
                        cntarray.Add(Session["cnt"]);
                        Session.Add("cntarray", cntarray);
                        Response.Redirect("~/search/Showcart.aspx");
        }
    }
}