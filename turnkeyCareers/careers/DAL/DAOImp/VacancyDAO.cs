using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using careers.MODEL;

/// <summary>
/// Summary description for AccountDAO
/// </summary>
public class VacancyDAO : DAO_Vacancy_Interface
{
    private modelDataContext ctx;
    public VacancyDAO()
	{
        ctx = new modelDataContext();//ModelFactory.getModelInstance();
	}

    public bool isFound(string vacancyNumber)
    {
        int cnt = (from p in ctx.Vacancies
                   where p.vacancyNumber == @vacancyNumber
                   select p).Count();
        if (cnt == 1)
            return true;
        else
            return false;
    }

    public VacancyDTO find(string vacancyNumber)
    {
        var obj = (from p in ctx.Vacancies
                   where p.vacancyNumber == @vacancyNumber
                   select p).Single();

        VacancyDTO acc = new VacancyDTO();
        acc.vacancyNumber = obj.vacancyNumber;
        acc.viewStatus = obj.viewStatus;
        acc.title = obj.title;
        acc.description = obj.description;
        acc.department = obj.department;
        acc.site = obj.site;
        acc.startDate = obj.startDate;
        acc.endDate = obj.endDate;
        acc.viewCount = obj.viewCount;
        acc.status = obj.status;
        acc.manager = obj.manager;
        acc.recruiter = obj.recruiter;

        return acc;
    }


    public List<VacancyDTO> findAll()
    {
        var objs = (from p in ctx.Vacancies 
                   select p);
        VacancyDTO acc = null;
        List<VacancyDTO> Vacancies = new List<VacancyDTO>();
        foreach(Vacancy obj in objs)
        {
            acc = new VacancyDTO();
            acc.vacancyNumber = obj.vacancyNumber;
            acc.viewStatus = obj.viewStatus;
            acc.title = obj.title;
            acc.description = obj.description;
            acc.department = obj.department;
            acc.site = obj.site;
            acc.startDate = obj.startDate;
            acc.endDate = obj.endDate;
            acc.viewCount = obj.viewCount;
            acc.status = obj.status;
            acc.manager = obj.manager;
            acc.recruiter = obj.recruiter;

            Vacancies.Add(acc);
        }
        return Vacancies;
    }

    public bool presist(VacancyDTO entityDTO)
    {
        try
        {

            ctx.insertVacancy(
                entityDTO.vacancyNumber,
                entityDTO.viewStatus,
                entityDTO.title,
                entityDTO.description,
                entityDTO.department,
                entityDTO.site,
                entityDTO.startDate,
                entityDTO.endDate,
                entityDTO.viewCount,
                entityDTO.status,
                entityDTO.manager,
                entityDTO.recruiter);
        }
        catch (Exception)
        {
        }
        return this.isFound(entityDTO.vacancyNumber);
    }
   
    public void merge(VacancyDTO entityDTO)
    {
        ctx.updateVacancy(
                 entityDTO.vacancyNumber,
                 entityDTO.viewStatus,
                 entityDTO.title,
                 entityDTO.description,
                 entityDTO.department,
                 entityDTO.site,
                 entityDTO.startDate,
                 entityDTO.endDate,
                 entityDTO.viewCount,
                 entityDTO.status,
                 entityDTO.manager,
                 entityDTO.recruiter);
    }

    public bool remove(VacancyDTO entity)
    {
        return this.removeByUserId(entity.vacancyNumber);
    }

    public bool removeByUserId(string vacancyNumber)
    {
        return this.removeByUserId(vacancyNumber);
    }



    bool DAO_Interface<VacancyDTO>.merge(VacancyDTO entity)
    {
        throw new NotImplementedException();
    }
}