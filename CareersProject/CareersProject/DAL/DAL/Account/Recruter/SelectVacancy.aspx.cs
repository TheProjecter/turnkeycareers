using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using careers.SERVICES.VacancyServices;

namespace DAL.Account.Recruter
{
    public partial class SelectVacancy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String recruiter = (String) Session["username"];

            FindVacanciesByRecruiter find = new FindVacanciesByRecruiter();
            List<VacancyDTO> vacancyList =  find.getVacanciesByRecruiter(recruiter);

            rptShortlistedSelect.DataSource = vacancyList;
            rptShortlistedSelect.DataBind();
        }

        protected void rptShortlistedSelect_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            String vacancyNumber = e.CommandArgument.ToString();
            Session["vacancyNumber"] = vacancyNumber;

            setFeedback("Vacancy '"+vacancyNumber+"' is now selected.");


        }

        private String getFeedback()
        {
            return lbFeedback.Text;
        }

        private void setFeedback(String feedback)
        {
            lbFeedback.Text = feedback;
        }

    }
}