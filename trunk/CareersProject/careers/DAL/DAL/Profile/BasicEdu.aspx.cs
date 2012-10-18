using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using careers.PRESENTATION.BasicEdu;
using careers.Utilities;
using careers.Constants;

namespace DAL.Profile
{

    public partial class BasicEdu : System.Web.UI.Page, IBasicEduView
    {
        IBasicEduPresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new BasicEduPresenter(this);
            //String username = (String)Session["username"];
            String username = "griddy";
            if (!IsPostBack)
            {
                presenter.loadPage(username);
                presenter.doErrorClear();
            }
        }

        public void setRepeater(List<BasicEduDTO> addressList)
        {
            rptBasicEdu.DataSource = addressList;
            rptBasicEdu.DataBind();
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

        protected void rptBasicEdu_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            BasicEduDTO dto;
            BasicEduDAO dao = new BasicEduDAO();
            String element = e.CommandName.ToString();

            if (element.Equals("school"))
            {
                dto = dao.find(getUsername());
                presenter.setBasicEduDto(dto);
                presenter.updateView();
            }

        }

        public void setUpdateView()
        {
            //txtMajor.ReadOnly = true;
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            lbFeedback.Text = "";
        }

        public void setNewView()
        {
            presenter.doClear();
            presenter.doErrorClear();
            //txtMajor.ReadOnly = false;
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            lbFeedback.Text = "";
        }

        public void pageReload()
        {
            Response.Redirect("~/Profile/BasicEdu.aspx");
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

        public string getSchool()
        {
            return txtSchool.Text;
        }

        public int getLevelCompleted()
        {
            if (ValidationUtility.IsNumeric(txtLevelCompleted.Text))
            {
                return Int32.Parse(txtLevelCompleted.Text);
            }
            return Constants.DEFAULT_INT;
        }

        public void setSchool(string school)
        {
            txtSchool.Text = school;
        }

        public void setLevelCompleted(int levelCompleted)
        {
            if (levelCompleted == Constants.DEFAULT_INT)
            {
                txtLevelCompleted.Text = "";
            }
            else
            {
                txtLevelCompleted.Text = levelCompleted.ToString();
            }
        }

        public string getSchoolError()
        {
            return lbSchoolError.Text;
        }

        public string getLevelCompletedError()
        {
            return lbLevelCompletedError.Text;
        }

        public void setSchoolError(string school)
        {
            lbSchoolError.Text = school;
        }

        public void setLevelCompletedError(string levelCompleted)
        {
            lbLevelCompletedError.Text = levelCompleted;
        }



        public void setNewLinkVisable(bool isVisable)
        {
            lbtnNew.Visible = isVisable;
        }
    }

}