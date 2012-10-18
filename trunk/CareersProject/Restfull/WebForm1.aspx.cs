using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Restfull
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Membership.ValidateUser("griddy", "777Tron777."))
            {

                Label1.Text = "ok";
            }
            else
                Label1.Text = "auth failed";
        }
    }
}