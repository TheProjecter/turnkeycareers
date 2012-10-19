using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace careers.PRESENTATION.ContactInformation
{
    public partial class Contact : System.Web.UI.Page, IContactInformationView
    {
        IContactInformationPresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new ContactInformationPresenter(this);
            //String username = (String)Session["username"];
            String username = "griddy";
            if (!IsPostBack)
            {
                presenter.loadPage(username);
                presenter.doErrorClear();
            }
        }

        public void setRepeater(List<ContactInfoDTO> contactList)
        {
            rptContact.DataSource = contactList;
            rptContact.DataBind();
        }

        public string getUsername()
        {
            return hfUsername.Value;
        }

        public void setUsername(string username)
        {
            hfUsername.Value = username;
        }

        public string getContactType()
        {
            return txtContactType.Text;
        }

        public void setContactType(string addressType)
        {
            txtContactType.Text = addressType;
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

        protected void rptContact_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            ContactInfoDTO contactDto;
            ContactInfoDAO contactDao = new ContactInfoDAO();
            String element = e.CommandName.ToString();

            if (element.Equals("contactType"))
            {
                contactDto = contactDao.find(getUsername(), e.CommandArgument.ToString());
                presenter.setContactDto(contactDto);
                presenter.updateView();
            }

        }

        public void setUpdateView()
        {
            txtContactType.ReadOnly = true;
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            lbFeedback.Text = "";
        }

        public void setNewView()
        {
            presenter.doClear();
            presenter.doErrorClear();
            txtContactType.ReadOnly = false;
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            lbFeedback.Text = "";
        }

        public void pageReload()
        {
            Response.Redirect("~/PRESENTATION/ContactInformation/Contact.aspx");
        }
        
        public string getData()
        {
            return txtData.Text;
        }

        public void setData(string data)
        {
            txtData.Text = data;
        }

        public void clearFields()
        {
            txtContactType.Text = "";
            txtData.Text = "";
        }

        public void giveFeedback(string feedback)
        {
            lbFeedback.Text = feedback;
        }

        public string getContactTypeError()
        {
            return lbContactTypeError.Text;
        }

        public void setContactTypeError(string contactType)
        {
            lbContactTypeError.Text = contactType;
        }

        public string getDataError()
        {
            return lbDataError.Text;
        }

        public void setDataError(string data)
        {
            lbDataError.Text = data;
        }
    }
}