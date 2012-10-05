using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace careers.SERVICES.VacancyServices
{
    public class FindVacanciesBySite
    {

        public List<VacancyDTO> getVacanciesBySite(string site)
        {
            VacancyDAO vac_context = new VacancyDAO();
            List<VacancyDTO> slive = vac_context.findAll();

            List<VacancyDTO> v = new List<VacancyDTO>();
            VacancyDTO vacancy;
            var obj = slive;

            foreach (VacancyDTO objs in obj)
            {

                vacancy = new VacancyDTO();
                string objDept = objs.site.ToString();
                int i = objDept.CompareTo(site);

                if (i == 0)
                {
                    vacancy.vacancyNumber = objs.vacancyNumber;
                    vacancy.department = objs.department;
                    vacancy.manager = objs.manager;
                    v.Add(vacancy);

                }


            }
            return v;

        }
    }
}