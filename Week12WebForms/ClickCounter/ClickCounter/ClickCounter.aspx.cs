using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class ClickCounter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            label2.Text = "Welcome " + Session["Name"];
        }

        protected void button1_Click(object sender, EventArgs e)
        {
            Session["Click"] = (int)Session["Click"] + 1;
            Application["Click"] = (int)Application["Click"] + 1;
        }
    }
}