using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using careers.SERVICES.Search;
using careers.SERVICES;
using careers.PRESENTATION.Inbox.User;

namespace DAL.Inbox
{
    public partial class UserInbox : System.Web.UI.Page, IUserView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String username = (String) Session["username"];
            String vacancyNumber = (String) Session["vacancyNumber"];

            setUsername(username);
            setVacancyNumber(vacancyNumber);

            InboxMessageSearchService seach = new InboxMessageSearchServiceImpl();
            List<InboxDTO> inboxList = seach.getUserInboxMessagesByVacancy(getUsername(), getVacancyNumber());

            rptInbox.DataSource = inboxList;
            rptInbox.DataBind();

            if (IsPostBack)
            {
            }
        }

        protected void rptInbox_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            String element = e.CommandName.ToString();

            if (element.Equals("status"))
            {
                String username = (String)Session["username"];
                String vacancyNumber = (String)Session["vacancyNumber"];

                InboxService inboxService = new InboxServiceImpl();
                String message =  inboxService.getInboxMessage(getUsername(), getVacancyNumber(), e.CommandArgument.ToString());
                
                setMessage(message);
            }

        }
        
        public string getUsername()
        {
            return hfUsername.Value;
        }

        public void setUsername(string username)
        {
            hfUsername.Value = username;
        }

        public string getVacancyNumber()
        {
            return hfVacancyNumber.Value;
        }

        public void setVacancyNumber(string vacancyNumber)
        {
            hfVacancyNumber.Value = vacancyNumber;
        }

        public string getMessage()
        {
            return txtMessage.Text;
        }

        public void setMessage(string message)
        {
            txtMessage.Text = message;
        }

    }
}