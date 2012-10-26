using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using careers.SERVICES.Search;

namespace DAL.Account.Manager
{
    public partial class Shortlisted : System.Web.UI.Page
    {
        List<AccountDTO> selectedAccountDtoList;
        protected void Page_Load(object sender, EventArgs e)
        {
            String vacancyNumber = (String)Session["vacancyNumber"];
            String username = (String)Session["username"];

            setUsername(username);
            setVacancyNumber(vacancyNumber);

            if (Session["ShortlistedAccountDTOList"] == null)
            {
                selectedAccountDtoList = new List<AccountDTO>();
                Session["ShortlistedAccountDTOList"] = selectedAccountDtoList;
            }
            else
            {
                selectedAccountDtoList = (List<AccountDTO>)Session["ShortlistedAccountDTOList"];
            }


            ApplicationSearchService search = new ApplicationSearchServiceImpl();
            List<ApplicationDTO> applicationList = search.getApplicationsApplied(getVacancyNumber());
            List<ApplicationViewDTO> appViewList = search.getApplicationViewDtoList(applicationList);


            List<ApplicationViewDTO> appViewSelectedList = search.getApplicationViewDtoList(selectedAccountDtoList);

            rpt.DataSource = appViewSelectedList;
            rpt.DataBind();

            rptShortlistedSelect.DataSource = appViewList;
            rptShortlistedSelect.DataBind();

        }

        protected void rptShortlistedSelect_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            String element = e.CommandName.ToString();

            if (element.Equals("username"))
            {
                AccountDAO dao = new AccountDAO();
                AccountDTO account = dao.find(e.CommandArgument.ToString());

                selectedAccountDtoList = (List<AccountDTO>)Session["ShortlistedAccountDTOList"];
                selectedAccountDtoList.Add(account);
                reloadPage();

                //ApplicationSearchService searchService = new ApplicationSearchServiceImpl();
                //searchService.selectAsShortlisted(e.CommandArgument.ToString(), getVacancyNumber());
            }
        }

        protected void rpt_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            String element = e.CommandName.ToString();

            if (element.Equals("username"))
            {
                AccountDAO dao = new AccountDAO();
                AccountDTO account = dao.find(e.CommandArgument.ToString());

                selectedAccountDtoList = (List<AccountDTO>)Session["ShortlistedAccountDTOList"];
                selectedAccountDtoList.Remove(account);

                ApplicationSearchService search = new ApplicationSearchServiceImpl();
                List<AccountDTO> accountList = search.removeAccountFormList(selectedAccountDtoList, account);
                Session.Remove("ShortlistedAccountDTOList");
                Session["ShortlistedAccountDTOList"] = accountList;
                reloadPage();

                //ApplicationSearchService searchService = new ApplicationSearchServiceImpl();
                //searchService.selectAsApplied(e.CommandArgument.ToString(), getVacancyNumber());
            }
        }

        public String getUsername()
        {
            return hfUsername.Value;
        }

        public void setUsername(String username)
        {
            hfUsername.Value = username;
        }

        public String getVacancyNumber()
        {
            return hfVacancyNumber.Value;
        }

        public void setVacancyNumber(String vacancyNumber)
        {
            hfVacancyNumber.Value = vacancyNumber;
        }

        public void reloadPage()
        {
            Response.Redirect("~/Account/Manager/Shortlisted.aspx");
        }

        protected void lbShortList_Click(object sender, EventArgs e)
        {
            List<AccountDTO> accontList = (List<AccountDTO>)Session["ShortlistedAccountDTOList"];
            ApplicationSearchService search = new ApplicationSearchServiceImpl();
            search.saveShortlisted(accontList, getVacancyNumber());
        }

    }
}