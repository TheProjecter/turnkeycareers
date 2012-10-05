using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace careers.SERVICES.VacancyServices
{
    public class VacancyStatus
    {
        public List<VacancyDTO> getVacanciesByStatus(string status)
        {
            VacancyDAO vac_context = new VacancyDAO();
            List<VacancyDTO> vStatus = vac_context.findAll();

            List<VacancyDTO> v = new List<VacancyDTO>();
            VacancyDTO vacancy;
            var obj = vStatus;

            foreach (VacancyDTO objs in obj)
            {

                vacancy = new VacancyDTO();
                string objDept = objs.status.ToString();

                int i = objDept.CompareTo(status);

                if (i == 0)
                {
                    vacancy.vacancyNumber = objs.vacancyNumber;
                    vacancy.department = objs.status;
                    vacancy.manager = objs.manager;
                    v.Add(vacancy);

                }


            }
            return v;

        }
    }
}