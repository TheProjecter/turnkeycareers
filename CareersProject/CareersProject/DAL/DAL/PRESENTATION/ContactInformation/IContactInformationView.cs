using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace careers.PRESENTATION.ContactInformation
{
    public interface IContactInformationView
    {
        void setRepeater(List<ContactInfoDTO> addressList);
        String getUsername();
        void setUsername(String username);
        String getContactType();
        void setContactType(String contactType);
        String getData();
        void setData(String data);
        void clearFields();
        void giveFeedback(String feedback);

        String getContactTypeError();
        void setContactTypeError(String contactType);
        String getDataError();
        void setDataError(String data);

        void setUpdateView();
        void setNewView();
        void showFeedback(String feedback);
        void hideFeedback();
        void pageReload();
    }

}
