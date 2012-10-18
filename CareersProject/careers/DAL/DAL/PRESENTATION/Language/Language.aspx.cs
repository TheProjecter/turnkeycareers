using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using careers.PRESENTATION.Disability;

namespace careers.PRESENTATION.Language
{
    public partial class Language : System.Web.UI.Page, ILanguageView
    {
        ILanguagePresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new LanguagePresenter(this);
            //String username = (String)Session["username"];
            String username = "griddy";
            if (!IsPostBack)
            {
                presenter.loadPage(username);
                presenter.doErrorClear();
            }
        }

        public void setRepeater(List<LanguageDTO> addressList)
        {
            rptLanguage.DataSource = addressList;
            rptLanguage.DataBind();
        }

        public string getUsername()
        {
            return hfUsername.Value;
        }

        public void setUsername(string username)
        {
            hfUsername.Value = username;
        }

        public string getLanguage()
        {
            return txtLanguage.Text;
        }

        public void setLanguage(string addressType)
        {
            txtLanguage.Text = addressType;
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

        protected void rptLanguage_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            LanguageDTO dto;
            LanguageDAO dao = new LanguageDAO();
            String element = e.CommandName.ToString();

            if (element.Equals("languageName"))
            {
                dto = dao.find(getUsername(), e.CommandArgument.ToString());
                presenter.setLanguageDto(dto);
                presenter.updateView();
            }

        }

        public void setUpdateView()
        {
            txtLanguage.ReadOnly = true;
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            lbFeedback.Text = "";
        }

        public void setNewView()
        {
            presenter.doClear();
            presenter.doErrorClear();
            txtLanguage.ReadOnly = false;
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            lbFeedback.Text = "";
        }

        public void pageReload()
        {
            Response.Redirect("~/PRESENTATION/Language/Language.aspx");
        }


        public string getLanguageTypeError()
        {
            return lbLanguageError.Text;
        }

        public void setLanguageTypeError(string addressType)
        {
            lbLanguageError.Text = addressType;
        }


        public string getRead()
        {
            return txtRead.Text;
        }

        public string getWrite()
        {
            return txtWrite.Text;
        }

        public string getSpeak()
        {
            return txtSpeak.Text;
        }

        public void setRead(string read)
        {
            txtRead.Text = read;
        }

        public void setWrite(string write)
        {
            txtWrite.Text = write;
        }

        public void setSpeak(string speak)
        {
            txtSpeak.Text = speak;
        }

        public string getLanguageError()
        {
            return lbLanguageError.Text;
        }

        public string getReadError()
        {
            return lbReadError.Text;
        }

        public string getWriteError()
        {
            return lbWriteError.Text;
        }

        public string getSpeakError()
        {
            return lbSpeakError.Text;
        }

        public void setLanguageError(string language)
        {
            lbLanguageError.Text = language;
        }

        public void setReadError(string read)
        {
            lbReadError.Text = read;
        }

        public void setWriteError(string write)
        {
            lbWriteError.Text = write;
        }

        public void setSpeakError(string speak)
        {
            lbSpeakError.Text = speak;
        }
    }
}