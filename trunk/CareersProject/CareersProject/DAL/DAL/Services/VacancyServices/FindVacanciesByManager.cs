using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace careers.SERVICES.VacancyServices
{
    public class FindVacanciesByManager
    {
        public List<VacancyDTO> getVacanciesByManager(string manager)
        {
            VacancyDAO vac_context = new VacancyDAO();
            List<VacancyDTO> mList = vac_context.findAll();

            List<VacancyDTO> v = new List<VacancyDTO>();
            VacancyDTO vacancy;
            var obj = mList;

            foreach (VacancyDTO objs in obj)
            {

                vacancy = new VacancyDTO();
                string objDept = objs.manager.ToString();
             
                int i = objDept.CompareTo(manager);

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