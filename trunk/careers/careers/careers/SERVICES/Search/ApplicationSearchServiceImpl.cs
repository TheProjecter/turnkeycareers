
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
        
    }
}
