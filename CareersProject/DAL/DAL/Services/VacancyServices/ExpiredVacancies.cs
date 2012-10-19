using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace careers.SERVICES.VacancyServices
{
    public class ExpiredVacancies
    {

        public List<VacancyDTO> getAllExpiredVancancies()
        {

            VacancyDAO vac_context = new VacancyDAO();
            List<VacancyDTO> vlive = vac_context.findAll();

            List<VacancyDTO> v = new List<VacancyDTO>();
            VacancyDTO vacancy = new VacancyDTO();
            var obj = vlive;

            foreach (VacancyDTO objs in obj)
            {

                string endString = objs.endDate.ToShortDateString();
                string testString = DateTime.Now.ToShortDateString();
                int i = endString.CompareTo(testString);

                if (i < 0)
                {
                    vacancy.vacancyNumber = objs.vacancyNumber;
                    vacancy.endDate = objs.endDate;
                    vacancy.viewStatus = objs.viewStatus;
                    v.Add(vacancy);
                }

            }
            return v;

        }


    }
}