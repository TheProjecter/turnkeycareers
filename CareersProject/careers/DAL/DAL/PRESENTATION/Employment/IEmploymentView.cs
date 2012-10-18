using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace careers.PRESENTATION.Employment
{
    public interface IEmploymentView
    {
        void setRepeater(List<EmploymentDTO> employmentList);
        String getUsername();
        String getTitle();
        String getCompany();
        String getIndustry();
        String getTown();
        String getProvince();
        String getCountry();
        String getEducationType();
        String getCurrentEmployer();
        double getGross();
        DateTime getStartDate();
        DateTime getEndDate();
        String getResponsibilities();
        void setUsername(String username);
        void setTitle(String title);
        void setCompany(String institution);
        void setIndustry(String industry);
        void setTown(String language);
        void setProvince(String province);
        void setCountry(String country);
        void setEducationType(String educationType);
        void setCurrentEmployer(String currentEmployer);
        void setGross(String gross);
        void setStartDate(String startDate);
        void setEndDate(String endDate);
        void setResponsibilities(String responsibilities);

        String getTitleError();
        String getCompanyError();
        String getIndustryError();
        String getTownError();
        String getProvinceError();
        String getCountryError();
        String getEducationTypeError();
        String getCurrentEmployerError();
        String getGrossError();
        String getStartDateError();
        String getEndDateError();
        String getResponsibilitiesError();
        void setTitleError(String title);
        void setCompanyError(String institution);
        void setIndustryError(String industry);
        void setTownError(String language);
        void setProvinceError(String province);
        void setCountryError(String country);
        void setEducationTypeError(String educationType);
        void setCurrentEmployerError(String currentEmployer);
        void setGrossError(String gross);
        void setStartDateError(String startDate);
        void setEndDateError(String endDate);
        void setResponsibilitiesError(String responsibilities);

        void setUpdateView();
        void setNewView();
        void showFeedback(String feedback);
        void hideFeedback();
        void pageReload();
    }
}
