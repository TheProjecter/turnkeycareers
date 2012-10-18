using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using careers.PRESENTATION.Disability;

namespace DAL.Profile
{
    public partial class Disability : System.Web.UI.Page, IDisabilityView
    {
        IDisabilityPresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new DisabilityPresenter(this);
            //String username = (String)Session["username"];
            String username = "griddy";
            if (!IsPostBack)
            {
                presenter.loadPage(username);
                presenter.doErrorClear();
            }
        }

        public void setRepeater(List<DisabilityDTO> list)
        {
            rptDisability.DataSource = list;
            rptDisability.DataBind();
        }

        public string getUsername()
        {
            return hfUsername.Value;
        }

        public void setUsername(string username)
        {
            hfUsername.Value = username;
        }

        public string getDisabilityType()
        {
            return txtDisabilityType.Text;
        }

        public void setDisabilityType(string addressType)
        {
            txtDisabilityType.Text = addressType;
        }

        public string getDescription()
        {
            return txtDescription.Text;
        }

        public void setDescription(string description)
        {
            txtDescription.Text = description;
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

        protected void rptDisability_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            DisabilityDTO dto;
            DisabilityDAO dao = new DisabilityDAO();
            String element = e.CommandName.ToString();

            if (element.Equals("disabilityType"))
            {
                dto = dao.find(getUsername(), e.CommandArgument.ToString());
                presenter.setDisabilityDto(dto);
                presenter.updateView();
            }

        }

        public void setUpdateView()
        {
            txtDisabilityType.ReadOnly = true;
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            lbFeedback.Text = "";
        }

        public void setNewView()
        {
            presenter.doClear();
            presenter.doErrorClear();
            txtDisabilityType.ReadOnly = false;
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            lbFeedback.Text = "";
        }

        public void pageReload()
        {
            Response.Redirect("~/Profile/Disability.aspx");
        }


        public string getDisabilityTypeError()
        {
            return lbDisabilityTypeError.Text;
        }

        public void setDisabilityTypeError(string addressType)
        {
            lbDisabilityTypeError.Text = addressType;
        }

        public string getDescriptionError()
        {
            return lbDescriptionError.Text;
        }

        public void setDescriptionError(string description)
        {
            lbDescriptionError.Text = description;
        }


    }

}