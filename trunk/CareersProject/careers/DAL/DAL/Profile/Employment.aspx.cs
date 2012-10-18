using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using careers.PRESENTATION.Employment;
using careers.Utilities;
using careers.Constants;

namespace DAL.Profile
{
    public partial class Employment : System.Web.UI.Page, IEmploymentView
    {
        IEmploymentPresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new EmploymentPresenter(this);
            //String username = (String)Session["username"];
            String username = "griddy";
            if (!IsPostBack)
            {
                presenter.loadPage(username);
                presenter.doErrorClear();
            }
        }

        public void setRepeater(List<EmploymentDTO> list)
        {
            rptEmployment.DataSource = list;
            rptEmployment.DataBind();
        }

        public string getUsername()
        {
            return hfUsername.Value;
        }

        public void setUsername(string username)
        {
            hfUsername.Value = username;
        }

        public void showFeedback(string feedback)
        {
            lbFeedback.Text = feedback;
            lbFeedback.Visible = true;
        }

        public void hideFeedback()
        {
            lbFeedback.Text = "";
            lbFeedback.Visible = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            presenter.doSave();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            presenter.doUpdate();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            presenter.doReset();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            presenter.doDelete();
        }

        protected void lbtnNew_Click(object sender, EventArgs e)
        {
            presenter.newView();
        }

        protected void rptEmployment_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            EmploymentDTO dto;
            EmploymentDAO dao = new EmploymentDAO();
            String element = e.CommandName.ToString();

            if (element.Equals("startDate"))
            {
                dto = dao.find(getUsername(), DateTime.Parse(e.CommandArgument.ToString()));
                presenter.setEmploymentDto(dto);
                presenter.updateView();
            }

        }

        public void setUpdateView()
        {
            txtStartDate.ReadOnly = true;
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            lbFeedback.Text = "";
        }

        public void setNewView()
        {
            presenter.doClear();
            presenter.doErrorClear();
            txtStartDate.ReadOnly = false;
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            lbFeedback.Text = "";
        }

        public void pageReload()
        {
            Response.Redirect("~/Profile/Employment.aspx");
        }

        public string getTown()
        {
            return txtTown.Text;
        }

        public string getProvince()
        {
            return txtProvince.Text;
        }

        public string getCountry()
        {
            return txtCountry.Text;
        }

        public string getIndustry()
        {
            return txtIndustry.Text;
        }

        public void setTown(string language)
        {
            txtTown.Text = language;
        }

        public void setProvince(string province)
        {
            txtProvince.Text = province;
        }

        public void setCountry(string country)
        {
            txtCountry.Text = country;
        }

        public void setIndustry(string industry)
        {
            txtIndustry.Text = industry;
        }

        public string getTownError()
        {
            return lbTownError.Text;
        }

        public string getProvinceError()
        {
            return lbProvinceError.Text;
        }

        public string getCountryError()
        {
            return lbCountryError.Text;
        }

        public string getIndustryError()
        {
            return lbIndustryError.Text;
        }

        public void setTownError(string language)
        {
            lbTownError.Text = language;
        }

        public void setProvinceError(string province)
        {
            lbProvinceError.Text = province;
        }

        public void setCountryError(string country)
        {
            lbCountryError.Text = country;
        }

        public void setIndustryError(string industry)
        {
            lbIndustryError.Text = industry;
        }

        public string getTitle()
        {
            return txtTitle.Text;
        }

        public string getCompany()
        {
            return txtCompany.Text;
        }

        public string getEducationType()
        {
            return txtEmpType.Text;
        }

        public string getCurrentEmployer()
        {
            return txtCurrentEmployer.Text;
        }

        public Double getGross()
        {
            if (ValidationUtility.IsDouble(txtGross.Text))
            {
                return Double.Parse(txtGross.Text);
            }
            return Constants.DEFAULT_DOUBLE;
        }

        public DateTime getStartDate()
        {
            if (ValidationUtility.IsDateTime(txtStartDate.Text))
            {
                return DateTime.Parse(txtStartDate.Text);
            }
            return Constants.DEFAULT_DATE_TIME;
        }

        public DateTime getEndDate()
        {
            if (ValidationUtility.IsDateTime(txtEndDate.Text))
            {
                return DateTime.Parse(txtEndDate.Text);
            }
            return Constants.DEFAULT_DATE_TIME;
        }

        public string getResponsibilities()
        {
            return txtResponsibilities.Text;
        }

        public void setTitle(string title)
        {
            txtTitle.Text = title;
        }

        public void setCompany(string institution)
        {
            txtCompany.Text = institution;
        }

        public void setEducationType(string educationType)
        {
            txtEmpType.Text = educationType;
        }

        public void setCurrentEmployer(string currentEmployer)
        {
            txtCurrentEmployer.Text = currentEmployer;
        }

        public void setGross(string gross)
        {
            txtGross.Text = gross;
        }

        public void setStartDate(string startDate)
        {
            txtStartDate.Text = startDate;
        }

        public void setEndDate(string endDate)
        {
            txtEndDate.Text = endDate;
        }

        public void setResponsibilities(string responsibilities)
        {
            txtResponsibilities.Text = responsibilities;
        }

        public string getTitleError()
        {
            return lbTitleError.Text;
        }

        public string getCompanyError()
        {
            return lbCompanyError.Text;
        }

        public string getEducationTypeError()
        {
            return lbEmpTypeError.Text;
        }

        public string getCurrentEmployerError()
        {
            return lbCurrentEmployerError.Text;
        }

        public string getGrossError()
        {
            return lbGrossError.Text;
        }

        public string getStartDateError()
        {
            return lbStartDateError.Text;
        }

        public string getEndDateError()
        {
            return lbEndDateError.Text;
        }

        public string getResponsibilitiesError()
        {
            return lbResponsibilitiesError.Text;
        }

        public void setTitleError(string title)
        {
            lbTitleError.Text = title;
        }

        public void setCompanyError(string institution)
        {
            lbCompanyError.Text = institution;
        }

        public void setEducationTypeError(string educationType)
        {
            lbEmpTypeError.Text = educationType;
        }

        public void setCurrentEmployerError(string currentEmployer)
        {
            lbCurrentEmployerError.Text = currentEmployer;
        }

        public void setGrossError(string gross)
        {
            lbGrossError.Text = gross;
        }

        public void setStartDateError(string startDate)
        {
            lbStartDateError.Text = startDate;
        }

        public void setEndDateError(string endDate)
        {
            lbEndDateError.Text = endDate;
        }

        public void setResponsibilitiesError(string responsibilities)
        {
            lbResponsibilitiesError.Text = responsibilities;
        }

    }
}