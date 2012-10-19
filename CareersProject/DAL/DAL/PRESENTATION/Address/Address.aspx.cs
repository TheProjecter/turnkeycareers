using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using careers.Utilities;
using careers.SERVICES;

namespace careers.PRESENTATION.Address
{
    public partial class Address : System.Web.UI.Page, IAddressView
    {
        IAddressPresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new AddressPresenter(this);
            //String username = (String)Session["username"];
            String username = "griddy";
            if (!IsPostBack)
            {
                presenter.loadPage(username);
                presenter.doErrorClear();
            }
        }

        public void setRepeater(List<AddressDTO> addressList)
        {
            rptAddress.DataSource = addressList;
            rptAddress.DataBind();
        }

        public string getUsername()
        {
            return hfUsername.Value;
        }

        public void setUsername(string username)
        {
            hfUsername.Value = username;
        }

        public string getAddressType()
        {
            return txtAddressType.Text;
        }

        public void setAddressType(string addressType)
        {
            txtAddressType.Text = addressType;
        }

        public int getUnitNumber()
        {
            if (ValidationUtility.IsNumeric(txtUitNumber.Text))
            {
                return Int32.Parse(txtUitNumber.Text);
            }
            return -1;
        }

        public void setUnitNumber(int unitNumber)
        {
            if (unitNumber == -1)
            {
                txtUitNumber.Text = "";
            }
            else
            {
                txtUitNumber.Text = unitNumber.ToString();
            }
        }

        public string getStreet()
        {
            return txtStreetName.Text;
        }

        public void setStreet(string street)
        {
            txtStreetName.Text = street;
        }

        public string getSuburb()
        {
            return txtSuburb.Text;
        }

        public void setSuburb(string suburb)
        {
            txtSuburb.Text = suburb;
        }

        public string getTown()
        {
            return txtTown.Text;
        }

        public void setTown(string town)
        {
            txtTown.Text = town;
        }

        public string getProvince()
        {
            return txtProvince.Text;
        }

        public void setProvince(string province)
        {
            txtProvince.Text = province;
        }

        public string getCountry()
        {
            return txtCountry.Text;
        }

        public void setCountry(string country)
        {
            txtCountry.Text = country;
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

        protected void rptAddress_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            AddressDTO addressDto;
            AddressDAO addressDao = new AddressDAO();
            String element = e.CommandName.ToString();

            if (element.Equals("addressType"))
            {
                addressDto = addressDao.find(getUsername(), e.CommandArgument.ToString());
                presenter.setAddressDto(addressDto);
                presenter.updateView();
            }

        }

        public void setUpdateView()
        {
            txtAddressType.ReadOnly = true;
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            lbFeedback.Text = "";
        }

        public void setNewView()
        {
            presenter.doClear();
            presenter.doErrorClear();
            txtAddressType.ReadOnly = false;
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            lbFeedback.Text = "";
        }

        public void pageReload()
        {
            Response.Redirect("~/PRESENTATION/Address/Address.aspx");
        }


        public string getAddressTypeError()
        {
            return lbAddressTypeError.Text;
        }

        public void setAddressTypeError(string addressType)
        {
            lbAddressTypeError.Text = addressType;
        }

        public String getUnitNumberError()
        {
            return lbUitNumberError.Text;
        }

        public void setUnitNumberError(String unitNumber)
        {
            lbUitNumberError.Text = unitNumber;
        }

        public string getStreetError()
        {
            return lbStreetNameError.Text;
        }

        public void setStreetError(string street)
        {
            lbStreetNameError.Text = street;
        }

        public string getSuburbError()
        {
            return lbSuburbError.Text;
        }

        public void setSuburbError(string suburb)
        {
            lbSuburbError.Text = suburb;
        }

        public string getTownError()
        {
            return lbTownError.Text;
        }

        public void setTownError(string town)
        {
            lbTownError.Text = town;
        }

        public string getProvinceError()
        {
            return lbProvinceError.Text;
        }

        public void setProvinceError(string province)
        {
            lbProvinceError.Text = province;
        }

        public string getCountryError()
        {
            return lbCountryError.Text;
        }

        public void setCountryError(string country)
        {
            lbCountryError.Text = country;
        }

    }
}