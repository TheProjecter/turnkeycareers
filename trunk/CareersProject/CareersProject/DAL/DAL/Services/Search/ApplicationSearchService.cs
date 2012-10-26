
/* ********************************************************
 * Author: Hughan Kleintes 210036834
 * Date: 4 October 2012
 * ********************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace careers.SERVICES.Search
{
    public interface ApplicationSearchService
    {
        List<ApplicationDTO> getApplicationByUsername(String username);
        List<ApplicationDTO> getApplicationByVacancyNumber(String vacancyNumber);
        List<ApplicationDTO> getApplicationByStatus(String status);
        List<ApplicationDTO> getApplicationByStatus(String vacancyNumber, String status);

        void selectAsShortlisted(String username, String vacancyNumber);
        void selectAsRegreted(String username, String vacancyNumber);
        void selectAsInterview(String username, String vacancyNumber);
        void selectAsApplied(String username, String vacancyNumber);

        List<ApplicationDTO> getApplicationsAll(string vacancyNumber);
        List<ApplicationDTO> getApplicationsShortlisted(String vacancyNumber);
        List<ApplicationDTO> getApplicationsApplied(String vacancyNumber);
        List<ApplicationViewDTO> getApplicationViewDtoList(List<ApplicationDTO> applicationList);
        List<ApplicationViewDTO> getApplicationViewDtoList(List<AccountDTO> applicationList);
        List<AccountDTO> removeAccountFormList(List<AccountDTO> applicationList, AccountDTO account);

        void saveShortlisted(List<AccountDTO> accountList, String vacancyNumber);
    }
}
