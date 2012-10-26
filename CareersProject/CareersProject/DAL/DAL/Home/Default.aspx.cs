using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DAL
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userName = HttpContext.Current.User.Identity.Name;
            Label1.Text = userName;
            Session["username"] = userName;

            if (User.IsInRole("Administrator"))
                Response.Redirect("~/Administrator/Administration.aspx");
            if (User.IsInRole("Manager"))
                Response.Redirect("~/Account/Manager/ViewAll.aspx");
            if (User.IsInRole("Recriuter"))
                Response.Redirect("~/Account/Recruter/ViewAll.aspx");
            
        }
    }
}