using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace nersary_managment
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_login_Click1(object sender, EventArgs e)
        {
            if (txt_anm.Text == "admin" && txt_pass.Text == "12345")
            {

                MessageBox.Show("login successful");
                Response.Redirect("~/AdminDashBoard.aspx");
            }
            else
            {
                MessageBox.Show("Enter Correct Password");
            }

        }
    }
}