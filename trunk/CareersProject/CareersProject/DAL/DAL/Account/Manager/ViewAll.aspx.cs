using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using careers.SERVICES.Search;

namespace DAL.Account.Manager
{
    public partial class ViewAll : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String vacancyNumber = (String)Session["vacancyNumber"];
            setVacancyNumber(vacancyNumber);

            ApplicationSearchService search = new ApplicationSearchServiceImpl();
            List<ApplicationDTO> applicationList = search.getApplicationByVacancyNumber(getVacancyNumber());
            List<ApplicationViewDTO> appViewList = search.getApplicationViewDtoList(applicationList);

            rptShortlistedSelect.DataSource = appViewList;
            rptShortlistedSelect.DataBind();
        }

        private String getVacancyNumber()
        {
            return hfVacancyNumber.Value;
        }

        private void setVacancyNumber(String vacancyNumber)
        {
            hfVacancyNumber.Value = vacancyNumber;
        }

    }
}