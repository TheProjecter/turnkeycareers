using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;

namespace careers.PRESENTATION.Address
{
    public interface IAddressView
    {
        void setRepeater(List<AddressDTO> addressList);
        String getUsername();
        void setUsername(String username);
        String getAddressType();
        void setAddressType(String addressType);
        int getUnitNumber();
        void setUnitNumber(int unitNumber);
        String getStreet();
        void setStreet(String street);
        String getSuburb();
        void setSuburb(String suburb);
        String getTown();
        void setTown(String town);
        String getProvince();
        void setProvince(String province);
        String getCountry();
        void setCountry(String country);

        String getAddressTypeError();
        void setAddressTypeError(String addressType);
        String getUnitNumberError();
        void setUnitNumberError(String unitNumber);
        String getStreetError();
        void setStreetError(String street);
        String getSuburbError();
        void setSuburbError(String suburb);
        String getTownError();
        void setTownError(String town);
        String getProvinceError();
        void setProvinceError(String province);
        String getCountryError();
        void setCountryError(String country);

        void setUpdateView();
        void setNewView();
        void showFeedback(String feedback);
        void hideFeedback();
        void pageReload();
    }

}
