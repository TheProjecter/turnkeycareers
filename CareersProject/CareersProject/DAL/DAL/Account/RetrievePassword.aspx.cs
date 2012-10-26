using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DAL
{
    public partial class RetrievePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void PasswordRecovery1_SendMailError(object sender, SendMailErrorEventArgs e)
        {
            Server.Transfer("../Error.aspx"); // Change to error page
        }

        protected void PasswordRecovery1_SendMailError(object sender, EventArgs e)
        {
            Server.Transfer("../Error.aspx"); // Change to error page
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../login.aspx");
        }
    }
}