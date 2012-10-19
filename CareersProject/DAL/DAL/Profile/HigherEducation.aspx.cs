using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using careers.PRESENTATION.HigherEducation;

namespace DAL.Profile
{
    public partial class HigherEducation : System.Web.UI.Page, IHigherEducationView
    {
        IHigherEducationPresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new HigherEducationPresenter(this);
            //String username = (String)Session["username"];
            String username = "griddy";
            if (!IsPostBack)
            {
                presenter.loadPage(username);
                presenter.doErrorClear();
            }
        }

        public void setRepeater(List<HigherEducationDTO> addressList)
        {
            rptHigherEducation.DataSource = addressList;
            rptHigherEducation.DataBind();
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

        protected void rptHigherEducation_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HigherEducationDTO dto;
            HigherEducationDAO dao = new HigherEducationDAO();
            String element = e.CommandName.ToString();

            if (element.Equals("major"))
            {
                dto = dao.find(getUsername(), e.CommandArgument.ToString());
                presenter.setHigherEducationDto(dto);
                presenter.updateView();
            }

        }

        public void setUpdateView()
        {
            txtMajor.ReadOnly = true;
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            lbFeedback.Text = "";
        }

        public void setNewView()
        {
            presenter.doClear();
            presenter.doErrorClear();
            txtMajor.ReadOnly = false;
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            lbFeedback.Text = "";
        }

        public void pageReload()
        {
            Response.Redirect("~/Profile/HigherEducation.aspx");
        }

        public string getInstitution()
        {
            return txtInstitution.Text;
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

        public string getEducationType()
        {
            return txtEducationType.Text;
        }

        public string getMajor()
        {
            return txtMajor.Text;
        }

        public string getIndustry()
        {
            return txtIndustry.Text;
        }

        public string getLength()
        {
            return txtLength.Text;
        }

        public string getNqf()
        {
            return txtNqf.Text;
        }

        public void setInstitution(string institution)
        {
            txtInstitution.Text = institution;
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

        public void setEducationType(string educationType)
        {
            txtEducationType.Text = educationType;
        }

        public void setMajor(string major)
        {
            txtMajor.Text = major;
        }

        public void setIndustry(string industry)
        {
            txtIndustry.Text = industry;
        }

        public void setLength(string length)
        {
            txtLength.Text = length;
        }

        public void setNqf(string nqf)
        {
            txtNqf.Text = nqf;
        }


        public string getInstitutionError()
        {
            return lbInstitutionError.Text;
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

        public string getEducationTypeError()
        {
            return lbEducationTypeError.Text;
        }

        public string getMajorError()
        {
            return lbMajorError.Text;
        }

        public string getIndustryError()
        {
            return lbIndustryError.Text;
        }

        public string getLengthError()
        {
            return lbLengthError.Text;
        }

        public string getNqfError()
        {
            return lbNqfError.Text;
        }

        public void setInstitutionError(string institution)
        {
            lbInstitutionError.Text = institution;
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

        public void setEducationTypeError(string educationType)
        {
            lbEducationTypeError.Text = educationType;
        }

        public void setMajorError(string major)
        {
            lbMajorError.Text = major;
        }

        public void setIndustryError(string industry)
        {
            lbIndustryError.Text = industry;
        }

        public void setLengthError(string length)
        {
            lbLengthError.Text = length;
        }

        public void setNqfError(string nqf)
        {
            lbNqfError.Text = nqf;
        }
    }
}