
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
    public class ApplicationSearchServiceImpl : ApplicationSearchService
    {
        public List<ApplicationDTO> getApplicationByUsername(String username)
        {
            List<ApplicationDTO> applicationDtoList = new List<ApplicationDTO>();
            ApplicationDAO applicationDao = new ApplicationDAO();
            List<ApplicationDTO> applicationList = applicationDao.findAll();

            foreach(ApplicationDTO applicationDto in applicationList)
            {
                if (applicationDto.userName.Equals(username))
                {
                    applicationDtoList.Add(applicationDto);
                }
            }
            return applicationDtoList;
        }

        public List<ApplicationDTO> getApplicationByVacancyNumber(String vacancyNumber)
        {
            List<ApplicationDTO> applicationDtoList = new List<ApplicationDTO>(); ;
            ApplicationDAO applicationDao = new ApplicationDAO();
            List<ApplicationDTO> applicationList = applicationDao.findAll();

            foreach (ApplicationDTO applicationDto in applicationList)
            {
                if (applicationDto.vacancyNumber.Equals(vacancyNumber))
                {
                    applicationDtoList.Add(applicationDto);
                }
            }
            return applicationDtoList;
        }

        public List<ApplicationDTO> getApplicationByStatus(String status)
        {
            List<ApplicationDTO> applicationDtoList = new List<ApplicationDTO>();
            ApplicationDAO applicationDao = new ApplicationDAO();
            List<ApplicationDTO> applicationList = applicationDao.findAll();

            foreach (ApplicationDTO applicationDto in applicationList)
            {
                if (applicationDto.status.Equals(status))
                {
                    applicationDtoList.Add(applicationDto);
                }
            }
            return applicationDtoList;
        }

        public List<ApplicationDTO> getApplicationByStatus(String vacancyNumber, String status)
        {   
            List<ApplicationDTO> applicationDtoList = new List<ApplicationDTO>();
            ApplicationDAO applicationDao = new ApplicationDAO();
            List<ApplicationDTO> applicationList = getApplicationByVacancyNumber(vacancyNumber);

            foreach (ApplicationDTO applicationDto in applicationList)
            {
                if (applicationDto.status.Equals(status))
                {
                    applicationDtoList.Add(applicationDto);
                }
            }
            return applicationDtoList;
        }
        
        public void selectAsShortlisted(string username, string vacancyNumber)
        {
            ApplicationDAO dao = new ApplicationDAO();
            ApplicationDTO applicationDto = dao.find(username, vacancyNumber);

            applicationDto.status = ApplicationStatus.SHORTLISTED.ToString();
            dao.merge(applicationDto);
        }

        public void selectAsRegreted(string username, string vacancyNumber)
        {
            ApplicationDAO dao = new ApplicationDAO();
            ApplicationDTO applicationDto = dao.find(username, vacancyNumber);

            applicationDto.status = ApplicationStatus.REGRETTED.ToString();
            dao.merge(applicationDto);
        }

        public void selectAsInterview(string username, string vacancyNumber)
        {
            ApplicationDAO dao = new ApplicationDAO();
            ApplicationDTO applicationDto = dao.find(username, vacancyNumber);

            applicationDto.status = ApplicationStatus.INTERVIEW.ToString();
            dao.merge(applicationDto);
        }

        public void selectAsApplied(string username, string vacancyNumber)
        {
            ApplicationDAO dao = new ApplicationDAO();
            ApplicationDTO applicationDto = dao.find(username, vacancyNumber);

            applicationDto.status = ApplicationStatus.APPLIED.ToString();
            dao.merge(applicationDto);
        }

        public List<ApplicationDTO> getApplicationsShortlisted(string vacancyNumber)
        {
            List<ApplicationDTO> applicationDtoList = new List<ApplicationDTO>();
            ApplicationDAO applicationDao = new ApplicationDAO();
            List<ApplicationDTO> applicationList = getApplicationByVacancyNumber(vacancyNumber);
            foreach (ApplicationDTO applicationDto in applicationList)
            {
                if(applicationDto.status.Equals(ApplicationStatus.SHORTLISTED.ToString()))
                {
                    applicationDtoList.Add(applicationDto);
                }
            }
            return applicationDtoList;
        }

        public List<ApplicationDTO> getApplicationsApplied(string vacancyNumber)
        {
            List<ApplicationDTO> applicationDtoList = new List<ApplicationDTO>();
            ApplicationDAO applicationDao = new ApplicationDAO();
            List<ApplicationDTO> applicationList = getApplicationByVacancyNumber(vacancyNumber);
            foreach (ApplicationDTO applicationDto in applicationList)
            {
                if (applicationDto.status.Equals(ApplicationStatus.APPLIED.ToString()))
                {
                    applicationDtoList.Add(applicationDto);
                }
            }
            return applicationDtoList;
        }

        public List<ApplicationDTO> getApplicationsAll(String vacancyNumber)
        {
            List<ApplicationDTO> applicationDtoList = new List<ApplicationDTO>();
            ApplicationDAO applicationDao = new ApplicationDAO();
            List<ApplicationDTO> applicationList = getApplicationByVacancyNumber(vacancyNumber);
            foreach (ApplicationDTO applicationDto in applicationList)
            {
                applicationDtoList.Add(applicationDto);
            }
            return applicationDtoList;
        }

        public List<ApplicationViewDTO> getApplicationViewDtoList(List<ApplicationDTO> applicationList)
        {
            List<ApplicationViewDTO> applicaitonViewList = new List<ApplicationViewDTO>();
            UserDAO dao = new UserDAO();
            ApplicationViewDTO appViewDto;

            foreach (ApplicationDTO app in applicationList)
            {
                UserDTO user = dao.find(app.userName);
                appViewDto =  new ApplicationViewDTO();
                appViewDto.fullname = user.fullName;
                appViewDto.surname = user.surname;
                appViewDto.username = user.userName;
                applicaitonViewList.Add(appViewDto);
            }
            return applicaitonViewList;
        }
        
        public List<ApplicationViewDTO> getApplicationViewDtoList(List<AccountDTO> applicationList)
        {
            List<ApplicationViewDTO> applicaitonViewList = new List<ApplicationViewDTO>();
            UserDAO dao = new UserDAO();
            ApplicationViewDTO appViewDto;

            foreach (AccountDTO app in applicationList)
            {
                UserDTO user = dao.find(app.userName);
                appViewDto = new ApplicationViewDTO();
                appViewDto.fullname = user.fullName;
                appViewDto.surname = user.surname;
                appViewDto.username = user.userName;
                applicaitonViewList.Add(appViewDto);
            }
            return applicaitonViewList;
        }


        public List<AccountDTO> removeAccountFormList(List<AccountDTO> applicationList, AccountDTO account)
        {
            List<AccountDTO> accountList = new List<AccountDTO>();

            foreach (AccountDTO accountDto in applicationList)
            {
                if (!accountDto.userName.Equals(account.userName))
                {
                    accountList.Add(accountDto);
                }
            }
            return accountList;
        }

        public void saveShortlisted(List<AccountDTO> accountList, String vacancyNumber)
        {
            ApplicationDAO dao = new ApplicationDAO();

            foreach (AccountDTO account in accountList)
            {
                ApplicationDTO application = dao.find(account.userName, vacancyNumber);
                application.status = ApplicationStatus.SHORTLISTED.ToString();
                dao.merge(application);
            }
        }


    }
}
