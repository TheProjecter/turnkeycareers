
/* ********************************************************
 * Author: Hughan Kleintes 210036834
 * Date: 4 October 2012
 * ********************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using careers.SERVICES.Search;

namespace careers.SERVICES
{
    public class UserServiceImpl: UserService
    {
        ApplicationSearchService applicationSearchService;

        public UserServiceImpl()
        {
            applicationSearchService = new ApplicationSearchServiceImpl();
        }

        public List<ApplicationDTO> getShortListedCandidates(String vacancyNumber)
        {
            return applicationSearchService.getApplicationByStatus(vacancyNumber, ApplicationStatus.SHORTLISTED.ToString());
        }

        public void changeUserApplicationStatus(String username, String vacancyNumber, ApplicationStatus appStatus)
        {   //Literals needs to be put in an internationalization format.
            switch (appStatus)
            {
                case ApplicationStatus.APPLIED:
                    changeApplicationStatus(username, vacancyNumber, "APPLIED");
                    break;
                case ApplicationStatus.REGRETTED:
                    changeApplicationStatus(username, vacancyNumber, "REGRETTED");
                    break;
                case ApplicationStatus.SHORTLISTED:
                    changeApplicationStatus(username, vacancyNumber, "SHORTLISTED");
                    break;
                case ApplicationStatus.INTERVIEW:
                    changeApplicationStatus(username, vacancyNumber, "INTERVIEW");
                    break;
            }
        }

        private void changeApplicationStatus(String username, String vacancyNumber, String status)
        {
            ApplicationDAO applicationDao = new ApplicationDAO();
            ApplicationDTO applicationDto = applicationDao.find(username, vacancyNumber);

            if (applicationDto != null)
            {
                applicationDto.status = status;
                applicationDao.merge(applicationDto);
            }
        }

    }
}
