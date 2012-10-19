using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace careers.PRESENTATION.BasicEdu
{
    public interface IBasicEduView
    {
        void setRepeater(List<BasicEduDTO> list);
        String getUsername();
        String getSchool();
        String getTown();
        String getProvince();
        String getCountry();
        Int32 getLevelCompleted();
        void setUsername(String username);
        void setSchool(String school);
        void setTown(String language);
        void setProvince(String province);
        void setCountry(String country);
        void setLevelCompleted(Int32 levelCompleted);

        String getSchoolError();
        String getTownError();
        String getProvinceError();
        String getCountryError();
        String getLevelCompletedError();
        void setSchoolError(String school);
        void setTownError(String language);
        void setProvinceError(String province);
        void setCountryError(String country);
        void setLevelCompletedError(String levelCompleted);
        void setNewLinkVisable(bool isVisable);

        void setUpdateView();
        void setNewView();
        void showFeedback(String feedback);
        void hideFeedback();
        void pageReload();
    }
}
