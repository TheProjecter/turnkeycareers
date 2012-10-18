using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using careers.PRESENTATION.ContactInformation;

namespace careers.PRESENTATION.Profile
{
    public partial class DisabilityView : System.Web.UI.Page, IDisabilityView
    {
        DisabilityPresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new DisabilityPresenter(this);
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

        public void setDisabilityType(string disabilityType)
        {
            txtDisabilityType.Text = disabilityType;
        }

        public string getDescription()
        {
            return txtDescription.Text;
        }

        public void setDescription(string description)
        {
            txtDescription.Text = description;
        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            presenter.doCancle();
        }
        
        protected void btnSave_Click(object sender, EventArgs e)
        {
            presenter.doSave();
        }

    }
}