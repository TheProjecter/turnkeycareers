using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using model;

/// <summary>
/// Summary description for AccountDAO
/// </summary>
public class VacancyDAO : DAO_Vacancy_Interface
{
    private ModelDataContext ctx;
    public VacancyDAO()
	{
        ctx =  new ModelDataContext();//ModelFactory.getModelInstance();
	}

    public bool isFound(string vacancyNumber)
    {
        try
        {
            var obj = (from p in ctx.Vacancies
                       where p.vacancyNumber == @vacancyNumber
                       select p).Single();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
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
            model.Vacancy obj = new Vacancy();
            obj.vacancyNumber = entityDTO.vacancyNumber;
            obj.viewStatus = entityDTO.viewStatus;
            obj.title = entityDTO.title;
            obj.description = entityDTO.description;
            obj.department = entityDTO.department;
            obj.site = entityDTO.site;
            obj.startDate = entityDTO.startDate;
            obj.endDate = entityDTO.endDate;
            obj.viewCount = entityDTO.viewCount;
            obj.status = entityDTO.status;
            obj.manager = entityDTO.manager;
            obj.recruiter = entityDTO.recruiter;

            ctx.Vacancies.InsertOnSubmit(obj);
            ctx.SubmitChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
   
    public bool merge(VacancyDTO entityDTO)
    {
        try
         {
        var objt = (from p in ctx.Vacancies
                   where p.vacancyNumber == @entityDTO.vacancyNumber
                   select p).Single();

        model.Vacancy obj = (Vacancy)objt;

        /*Update*/
        obj.vacancyNumber = entityDTO.vacancyNumber;
        obj.viewStatus = entityDTO.viewStatus;
        obj.title = entityDTO.title;
        obj.description = entityDTO.description;
        obj.department = entityDTO.department;
        obj.site = entityDTO.site;
        obj.startDate = entityDTO.startDate;
        obj.endDate = entityDTO.endDate;
        obj.viewCount = entityDTO.viewCount;
        obj.status = entityDTO.status;
        obj.manager = entityDTO.manager;
        obj.recruiter = entityDTO.recruiter;

        ctx.SubmitChanges();
        return true;
          }
          catch (Exception)
          {
              return false;
          }
    }

    public bool remove(VacancyDTO entity)
    {
        return this.removeByUserId(entity.vacancyNumber);
    }

    public bool removeByUserId(string vacancyNumber)
    {
        try
        {
            var obj = (from p in ctx.Vacancies
                       where p.vacancyNumber == @vacancyNumber
                       select p).Single();

            model.Vacancy accObj = (Vacancy)obj;

            ctx.Vacancies.DeleteOnSubmit(accObj);
            ctx.SubmitChanges();
            return true;

        }
        catch (Exception)
        {
            return false;
        }
    }

}