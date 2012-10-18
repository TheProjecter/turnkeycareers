using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace careers.PRESENTATION.HigherEducation
{
    public interface IHigherEducationView
    {
        void setRepeater(List<HigherEducationDTO> list);
        String getUsername();
        String getInstitution();
        String getTown();
        String getProvince();
        String getCountry();
        String getEducationType();
        String getMajor();
        String getIndustry();
        String getLength();
        String getNqf();
        void setUsername(String username);
        void setInstitution(String institution);
        void setTown(String language);
        void setProvince(String province);
        void setCountry(String country);
        void setEducationType(String educationType);
        void setMajor(String major);
        void setIndustry(String industry);
        void setLength(String length);
        void setNqf(String nqf);
        
        String getInstitutionError();
        String getTownError();
        String getProvinceError();
        String getCountryError();
        String getEducationTypeError();
        String getMajorError();
        String getIndustryError();
        String getLengthError();
        String getNqfError();
        void setInstitutionError(String institution);
        void setTownError(String language);
        void setProvinceError(String province);
        void setCountryError(String country);
        void setEducationTypeError(String educationType);
        void setMajorError(String major);
        void setIndustryError(String industry);
        void setLengthError(String length);
        void setNqfError(String nqf);

        void setUpdateView();
        void setNewView();
        void showFeedback(String feedback);
        void hideFeedback();
        void pageReload();
    }
}