using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace DAL
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.IsAuthenticated && !string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                    // This is an unauthorized, authenticated request...
                    Response.Redirect("~/UnauthorisedAcess.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Membership.ValidateUser("griddy", "777Tron777."))
            {
                
                Label1.Text =  "ok";
            }
            else
                Label1.Text = "auth failed";

        }
    }
}