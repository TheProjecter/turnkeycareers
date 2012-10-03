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
            if (!context.isFound("skippy"))
                Label1.Text = "Not found";
            else
                Label1.Text = "Found";
            acc.userName = null;
            acc.password = "nissan";
            acc.accountType = "admin";
            acc.status = "active";
       
            context.presist(acc);
        

            acc.userName = "piet";
          
            if( !   context.presist(acc) )
                Label2.Text = "Error";
            else
                Label2.Text = "OK";

            //if(context.isFound("skippy"))
            //    text = "found";
            //else
            //TextBox1.Text = "not found";
        }
    }
}