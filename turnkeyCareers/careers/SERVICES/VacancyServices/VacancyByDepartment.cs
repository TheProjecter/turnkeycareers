using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace careers.SERVICES.VacancyServices
{
    public class VacancyByDepartment
    {

            public List<VacancyDTO> getVacanciesByDept(string department)
            {
                VacancyDAO vac_context = new VacancyDAO(); 
                List<VacancyDTO> vlive = vac_context.findAll();
         
                List<VacancyDTO> v = new List<VacancyDTO>();
                VacancyDTO vacancy;
                var obj = vlive;

                foreach (VacancyDTO objs in obj)
                {
                    
                    vacancy = new VacancyDTO();
                    string objDept = objs.department.ToString();

                    int i = objDept.CompareTo(department);

                    if (i == 0 )
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