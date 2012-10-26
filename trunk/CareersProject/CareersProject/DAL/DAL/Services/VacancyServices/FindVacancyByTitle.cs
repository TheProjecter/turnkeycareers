using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace careers.SERVICES.VacancyServices
{
    public class FindVacancyByTitle
    {
        public VacancyDTO getVacanciesByTitle(string vacNo)
        {
            VacancyDAO vac_context = new VacancyDAO();
            List<VacancyDTO> tlive = vac_context.findAll();

            List<VacancyDTO> v = new List<VacancyDTO>();
            VacancyDTO vacancy = new VacancyDTO();
            var obj = tlive;
           
            foreach (VacancyDTO objs in obj)
            {

                //vacancy = new VacancyDTO();
                string objDept = objs.vacancyNumber.ToString();
                int i = objDept.CompareTo(vacNo);

                if (i == 0)
                {
                    vacancy.title = objs.title;
                    vacancy.department = objs.department;
                    vacancy.manager = objs.manager;
                    

                }


            }
            return vacancy;

        }
    }
}