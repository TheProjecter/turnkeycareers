using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Services.VacancyServices
{
    public class GenerateVacancyNumber: IGenerateVacancyNumber
    {
        DAO_Vacancy_Interface ctx = new VacancyDAO();

        public int generateVacancyNumber()
        {
            List < VacancyDTO > list = ctx.findAll();
            int cnt = list.Count;
            return ++cnt;
        }
    }
}