using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace careers.SERVICES.VacancyServices
{
    public class FindVacanciesByRecruiter
    {
        public List<VacancyDTO> getVacanciesByRecruiter(string recruiter)
        {
            VacancyDAO vac_context = new VacancyDAO();
            List<VacancyDTO> rList = vac_context.findAll();

            List<VacancyDTO> v = new List<VacancyDTO>();
            VacancyDTO vacancy;
            var obj = rList;

            foreach (VacancyDTO objs in obj)
            {

                vacancy = new VacancyDTO();
                string objDept = objs.recruiter.ToString();

                int i = objDept.CompareTo(recruiter);

                if (i == 0)
                {
                    vacancy.vacancyNumber = objs.vacancyNumber;
                    vacancy.department = objs.department;
                    vacancy.recruiter = objs.recruiter;
                    v.Add(vacancy);

                }


            }
            return v;

        }
    }
}