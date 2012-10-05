using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using careers.MODEL;

namespace careers.SERVICES.VacancyServices
{
    public class LiveVacancies
    {
        
        public List<VacancyDTO> getAllLiveVancancies()
        {

                VacancyDAO vac_context = new VacancyDAO(); 
                List<VacancyDTO> vlive = vac_context.findAll();
         
                List<VacancyDTO> v = new List<VacancyDTO>();
                VacancyDTO vacancy;
                var obj = vlive;
                foreach (VacancyDTO objs in obj)
                {
                   
                    vacancy = new VacancyDTO();
                    string endString = objs.endDate.ToShortDateString();
                    string testString = DateTime.Now.ToShortDateString();
                    int i = endString.CompareTo(testString);

                    if (i > 0 )
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