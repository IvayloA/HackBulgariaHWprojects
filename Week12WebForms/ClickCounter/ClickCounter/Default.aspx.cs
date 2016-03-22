using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Default : System.Web.UI.Page
    {
        protected string name;
        protected void Page_Load(object sender, EventArgs e)
        {
            Button1.Click += Button1_Click;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Session["Click"] = 0;
            Application["TotalClick"] = 0;
           Response.Redirect("ClickCounter.aspx");
        }

        protected void textBox1_TextChanged(object sender, EventArgs e)
        {
            name = textBox1.Text;
            Session["Name"] = name;
        }
    }
 
}