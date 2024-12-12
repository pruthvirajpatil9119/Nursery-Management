using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections;

namespace nersary_managment
{
    public partial class Invoice : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;

        string ord_id, ord_date, grand_total, cust_nm, cust_addr, cust_email, cust_mobile;

        ArrayList ord_det_idlist = new ArrayList();
        ArrayList plant_nmlist = new ArrayList();
        ArrayList ratelist = new ArrayList();
        ArrayList qtylist = new ArrayList();
        ArrayList amtlist = new ArrayList();
        ArrayList GSTlist = new ArrayList();
        ArrayList Totallist = new ArrayList();
         ArrayList idarray = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection();
            cn.ConnectionString = "Data Source=PRUTHVIRAJ-PATI\\SQLEXPRESS;Initial Catalog=nursery_management;Integrated Security=True";
            cn.Open();

            cmd = new SqlCommand();
            cmd.Connection = cn;



            cmd.CommandText = "select plant_nm,Order_master.ord_id,ord_date,grand_total,ord_det_id,Order_details.rate,qty,amt,GST,Total,cust_nm,cust_addr,cust_email,cust_mobile,Payment.pay_id from Plant_Master,Order_master,Order_details,Payment,Customer_master where Plant_Master.plant_id=Order_details.plant_id and Order_master.ord_id=Order_details.ord_id and Payment.ord_id=Order_master.ord_id "+
" and order_master.cust_id=Customer_master.cust_id and Order_master.ord_id=" + Session["ordid"];
            dr = cmd.ExecuteReader();
           
//           select plant_nm,Order_master.ord_id,ord_date,grand_total,ord_det_id,Order_details.rate,qty,amt,GST,Total,cust_nm,cust_addr,cust_email,cust_mobile,Payment.pay_id from 
//Plant_Master,
//Order_master,
//Order_details,
//Payment,
//Customer_master 
//where Plant_Master.plant_id=Order_details.plant_id 
//and Order_master.ord_id=Order_details.ord_id 
//and Payment.cust_id=order_master.ord_id
//and Customer_master.cust_id =order_master.pay_id 
//and payment.cust_id=
          
          

           // PlaceHolder1.Controls.Add(new LiteralControl("<table border='2px' id='bill' class='table'><tr><th>Id </th><th>Name</th><th> Type </th><th> Height </th><th> description</th><th>rate</th><th>Stock</th><th>Photo</th><th>Name</th><th> Type </th><th> Height </th><th> description</th><th>rate</th><th>Stock</th><th>Photo</th></tr>"));
            while (dr.Read())
            {
                ord_id = dr[1].ToString();
                ord_date = dr[2].ToString();
                grand_total = dr[3].ToString();
                cust_nm = dr[10].ToString();
                cust_addr = dr[11].ToString();
                cust_email = dr[12].ToString();
                cust_mobile = dr[13].ToString();

                ord_det_idlist.Add(dr[4].ToString());
                ratelist.Add(dr[5].ToString());
                qtylist.Add(dr[6].ToString());
                amtlist.Add(dr[7].ToString());
                GSTlist.Add(dr[8].ToString());
                Totallist.Add(dr[9].ToString());
                plant_nmlist.Add(dr[0].ToString());


                //PlaceHolder1.Controls.Add(new LiteralControl("<tr>"));
                //PlaceHolder1.Controls.Add(new LiteralControl("<td>" + dr[0] + "</td>"));
                //PlaceHolder1.Controls.Add(new LiteralControl("<td>" + dr[1] + "</td>"));
                //PlaceHolder1.Controls.Add(new LiteralControl("<td>" + dr[2] + "</td>"));
                //PlaceHolder1.Controls.Add(new LiteralControl("<td>" + dr[3] + "</td>"));
                //PlaceHolder1.Controls.Add(new LiteralControl("<td>" + dr[4] + "</td>"));
                //PlaceHolder1.Controls.Add(new LiteralControl("<td>" + dr[5] + "</td>"));
                //PlaceHolder1.Controls.Add(new LiteralControl("<td>" + dr[6] + "</td>"));
                //PlaceHolder1.Controls.Add(new LiteralControl("<td>" + dr[7] + "</td>"));
                //PlaceHolder1.Controls.Add(new LiteralControl("<td>" + dr[8] + "</td>"));
                //PlaceHolder1.Controls.Add(new LiteralControl("<td>" + dr[9] + "</td>"));
                //PlaceHolder1.Controls.Add(new LiteralControl("<td>" + dr[10] + "</td>"));
                //PlaceHolder1.Controls.Add(new LiteralControl("<td>" + dr[11] + "</td>"));
                //PlaceHolder1.Controls.Add(new LiteralControl("<td>" + dr[12] + "</td>"));
                //PlaceHolder1.Controls.Add(new LiteralControl("<td>" + dr[13] + "</td>"));
                //PlaceHolder1.Controls.Add(new LiteralControl("<td>" + dr[14] + "</td>"));

                //PlaceHolder1.Controls.Add(new LiteralControl("</tr>"));
            }


            //PlaceHolder1.Controls.Add(new LiteralControl("<table border='2px' id='bill' class='table'><tr><th>ord Id </th><th>Date</th><th> Grand Total </th><th> name </th><th> address</th><th>email</th><th>mobile</th></tr>"));
            //PlaceHolder1.Controls.Add(new LiteralControl("<tr>"));


            //PlaceHolder1.Controls.Add(new LiteralControl("<td>" + ord_id+ "</td>"));
            //PlaceHolder1.Controls.Add(new LiteralControl("<td>" + ord_date + "</td>"));
            //PlaceHolder1.Controls.Add(new LiteralControl("<td>" + grand_total + "</td>"));
            //PlaceHolder1.Controls.Add(new LiteralControl("<td>" + cust_nm + "</td>"));
            //PlaceHolder1.Controls.Add(new LiteralControl("<td>" + cust_addr+ "</td>"));
            //PlaceHolder1.Controls.Add(new LiteralControl("<td>" + cust_email + "</td>"));
            //PlaceHolder1.Controls.Add(new LiteralControl("<td>" +cust_mobile+ "</td>"));
            //PlaceHolder1.Controls.Add(new LiteralControl("</tr>"));
            
            //PlaceHolder1.Controls.Add(new LiteralControl("</table>"));
            dr.Close();

            //PlaceHolder1.Controls.Add(new LiteralControl("<table border='2px' id='bill' class='table'><tr><th>ord_det_Id </th><th>Plant name</th><th>rate</th><th> qty </th><th> amt </th><th> GST</th><th>Total</th></tr>"));
               
            //  for (int i = 0; i <= ord_det_idlist.Count - 1; i++)
            //{
            //    PlaceHolder1.Controls.Add(new LiteralControl("<tr>"));
            //    PlaceHolder1.Controls.Add(new LiteralControl("<td>" + ord_det_idlist[i] + "</td>"));
            //    PlaceHolder1.Controls.Add(new LiteralControl("<td>" + plant_nmlist[i] + "</td>"));
            //    PlaceHolder1.Controls.Add(new LiteralControl("<td>" + ratelist[i] + "</td>"));
            //    PlaceHolder1.Controls.Add(new LiteralControl("<td>" + qtylist[i] + "</td>"));
            //    PlaceHolder1.Controls.Add(new LiteralControl("<td>" + amtlist[i] + "</td>"));
            //    PlaceHolder1.Controls.Add(new LiteralControl("<td>" + GSTlist[i]+ "</td>"));
            //    PlaceHolder1.Controls.Add(new LiteralControl("<td>" + Totallist[i] + "</td>"));
            //    PlaceHolder1.Controls.Add(new LiteralControl("</tr>"));

            //}
            //  PlaceHolder1.Controls.Add(new LiteralControl("<tr><td colspn=6>" + grand_total + "</td></tr>"));
            //  PlaceHolder1.Controls.Add(new LiteralControl("</table>"));
            //  dr.Close();



            
            PlaceHolder1.Controls.Add(new LiteralControl( "<table width=550px id='bill' align=center frame='box' id='bill'>"+
       "<tr>"+
            "<td colspan='5' align=center>"+
                "<img align='middle' height='100px' width='120px' src='lep.jpg' /> </tr>"+
       " <tr>"+
            "<td align='center' colspan='5'>"+
                "<strong>INVOICE</strong></td>"+
       " </tr>"+
       " <tr>"+
            "<td>"+
              "  &nbsp;</td>"+
           " <td>"+
              "  &nbsp;</td>"+
          "  <td>"+
            "    &nbsp;</td>"+
            "<td>"+
             "   &nbsp;</td>"+
           " <td>"+
           "     &nbsp;</td>"+
        "</tr>"+
      "  <tr>"+
          "  <td colspan='3'>"+
              "  <strong>Bill To :<br />"+
             "   Bill No :" + ord_id + "&nbsp;&nbsp;&nbsp;&nbsp; Bill Date : " + ord_date + "</strong><br />"  + cust_nm + 
              "  <br />"+
              "  " + cust_addr + "<br />" +
               " phone :" + cust_mobile + "<br />" +
                "Email :" + cust_email + "</td>" +
           " <td class='style1' colspan='2'>"+
             "   <strong>GoGreen<br />"+
              "  </strong>1023 Lakshtirth vasahat"+
              "  <br />"+
               " near rankala kolhapur"+
               " <br />"+
              "  phone:0231-41623<br />"+
              " Email:GoGreen@gmail.com</td>" +
       " </tr>"+
        "<tr>"+
           " <td>"+
              "  &nbsp;</td>"+
            "<td>"+
             "   &nbsp;</td>"+
           " <td>"+
            "    &nbsp;</td>"+
          "  <td>"+
           "     &nbsp;</td>"+
           " <td>"+
               " &nbsp;</td>"+
       " </tr>"+
        "<tr>"+
           " <td bgcolor='#00CC00'>"+
             "   Sr. no.</td>"+
          "  <td bgcolor='#00CC00'>"+
           "     Plant Name</td>"+
           " <td bgcolor='#00CC00'>"+
           "     Quantity</td>"+
          "  <td bgcolor='#00CC00'>"+
           "     Unit Prise</td>"+
            "  <td bgcolor='#00CC00'>" +
           "     GSTamt</td>" +
           " <td bgcolor='#00CC00'>"+
             "   Amount</td>"+
       " </tr>"+
       " <tr>"));

            for (int i = 0; i <= ord_det_idlist.Count - 1; i++)
            {
                PlaceHolder1.Controls.Add(new LiteralControl(" <td style='text-align: center'>" +
               "   " + ord_det_idlist[i] + "</td>" +
              "  <td style='text-align: center'>" +
              "     " + plant_nmlist[i] + "</td>" +
              "  <td style='text-align: center'>" +
              "      " + qtylist[i] + "</td>" +
              "  <td style='text-align: center'>" +
               "     " + amtlist[i] + "</td>" +
                 "  <td style='text-align: center'>" +
               "     " + (Convert.ToInt32(amtlist[i])*5)/100.0f + "</td>" +
              "  <td style='text-align: center'>" +
               "     " + Totallist[i] + "</td>" +
         "   </tr>"));
            }
            PlaceHolder1.Controls.Add(new LiteralControl("    <tr>" +
          "      <td style='text-align: center'>" +
                "    &nbsp;</td>" +
             "   <td>" +
                 "   &nbsp;</td>" +
              "  <td>" +
                "    &nbsp;</td>" +
                "<td>" +
                "    &nbsp;</td>" +
                "<td>" +
               "     &nbsp;</td>" +
          "  </tr>" +
           " <tr>" +
              "  <td colspan='3' rowspan='2' style='text-align: center'>" +
                "    Thank You For Your Order....</td>" +
              
          "  </tr>" +
           " <tr>" +
             "   <td>" +
                 "   Total Amount (Rs.)</td>" +
              "  <td>" +
                 "   " + grand_total + "</td>" +
          "  </tr>" +

            "  <tr>" +
              "  <td>" +
              "      &nbsp;</td>" +
               " <td>" +
              "      &nbsp;</td>" +
              "  <td>" +
              "      &nbsp;</td>" +
            "    <td>" +
              "      &nbsp;</td>" +
             "   <td>" +
             "       &nbsp;</td>" +
         "   </tr>" +
         "   <tr>" +
            "    <td style='text-align: center'>" +
               "     <img height='25px' width='25px' src='download%20(1).png' /></td>" +
               " <td colspan='2'>" +
               "     1023 Lakshtirth vasahat" +
               "     <br />" +
               "    near rankala kolhapur</td>" +
              "  <td colspan='2' rowspan='2' style='text-align: center'>" +
               "     <img  height='60px' width='160px'  src='images.png' /></td>" +
           " </tr>" +
          "  <tr>" +
            "    <td style='text-align: center'>" +
               "     <img  height='25px' width='25px' " +
                "        src='communication-email-icon-plex-iconset-cornmanthe-38.png' " +
                "       /></td>" +
               " <td colspan='2'>" +
                  "Gogreen@gmail.com</td>" +
           " </tr>" +
          "  <tr>" +
              "  <td style='text-align: center'>" +
              "      <img  height='25px' width='25px' src='download.png' /></td>" +
               " <td colspan='2'>" +
               "     0231-41623</td>" +
              "  <td colspan='2' style='text-align: center'>" +
               "     Signature</td>" +
           " </tr>" +
           " <tr>" +
              "  <td colspan='5' style='text-align: center'>" +
               "     <br />" +
             "   </td>" +
           " </tr>" ));
            PlaceHolder1.Controls.Add(new LiteralControl(" </table>"));
            dr.Close();
            



        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Search/alazea-gh-pages/index.html");
        }
    }
}