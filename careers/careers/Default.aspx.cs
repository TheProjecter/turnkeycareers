using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace careers
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
             AccountDAO context = new AccountDAO();
            AccountDTO acc = new AccountDTO();

            acc.userName = "skippy";
            acc.password = "nissan";
            acc.accountType = "admin";
            acc.status = "active";

            context.presist(acc);

            //if(context.isFound("skippy"))
            //    text = "found";
            //else
            //TextBox1.Text = "not found";
        }
    }
}