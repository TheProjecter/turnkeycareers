using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using careers.SERVICES.Search;
using careers.SERVICES;

namespace DAL.Inbox
{
    public partial class InboxMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String username = (String)Session["username"];
            ApplicationSearchService appService = new ApplicationSearchServiceImpl();
            List<ApplicationDTO> applicationList = appService.getApplicationByUsername(username);

            rpt.DataSource = applicationList;
            rpt.DataBind();
        }

        protected void rpt_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            String element = e.CommandName.ToString();

            if (element.Equals("username"))
            {
                Session["vacancyNumber"] = e.CommandArgument.ToString();
                Response.Redirect("~/Inbox/UserInbox.aspx");
            }
        }


    }
}