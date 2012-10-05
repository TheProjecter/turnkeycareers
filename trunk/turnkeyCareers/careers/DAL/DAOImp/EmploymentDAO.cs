using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using careers.MODEL;

/// <summary>
/// Summary description for  EmploymentDAO
/// </summary>
public class EmploymentDAO : DAO_Employment_Interface
{
    private modelDataContext ctx;
    public EmploymentDAO()
	{
        ctx = new modelDataContext();//ModelFactory.getModelInstance();
	}



    public bool isFound(string userName, DateTime startDate)
    {

        int cnt = (from p in ctx.Employments
                   where p.userName == @userName && p.startDate == @startDate
                   select p).Count();
        if (cnt == 1)
            return true;
        else
            return false;
    }

    public EmploymentDTO find(string userName, DateTime startDate)
    {
        var obj = (from p in ctx.Employments
                   where p.userName == @userName && p.startDate == @startDate
                   select p).Single();

        EmploymentDTO add = new EmploymentDTO();
        add.userName = obj.userName;
        add.title = obj.title;
        add.company = obj.company;
        add.industry = obj.industry;
        add.town = obj.town;
        add.province = obj.province;
        add.country = obj.country;
        add.empType = obj.empType;
        add.currentEmployer = obj.currentEmployer;
        add.gross = Double.Parse(obj.gross.ToString() );
        add.startDate = obj.startDate;
        add.endDate = obj.endDate;
        add.responsibilities = obj.responsibilities;

        return add;
    }

    public bool removeByUserId(string userName, DateTime startDate)
    {
        try
        {
            ctx.deleteEmployment(userName, startDate);

        }
        catch (Exception)
        {

        }
        return this.isFound(userName, startDate);
    }

    public List<EmploymentDTO> findAll()
    {
        var objs = (from p in ctx.Employments
                    select p);
        EmploymentDTO add = null;
        List<EmploymentDTO> addList = new List<EmploymentDTO>();
        foreach (Employment obj in objs)
        {
            add = new EmploymentDTO();
            add.userName = obj.userName;
            add.startDate = obj.startDate;
            add.title = obj.title;
            add.company = obj.company;
            add.industry = obj.industry;
            add.town = obj.town;
            add.province = obj.province;
            add.country = obj.country;
            add.empType = obj.empType;
            add.currentEmployer = obj.currentEmployer;
            add.gross = Double.Parse(obj.gross.ToString());
            add.startDate = obj.startDate;
            add.endDate = obj.endDate;
            add.responsibilities = obj.responsibilities;

            addList.Add(add);
        }
        return addList;
    }

    public bool presist(EmploymentDTO entity)
    {
        try
        {

            ctx.insertEmployment(
                entity.userName, 
                entity.title,
                entity.company,
                entity.industry,
                entity.town,
                entity.province,
                entity.country,
                entity.empType,
                entity.currentEmployer,
                (Decimal)entity.gross,
                entity.startDate,
                entity.endDate,
                entity.responsibilities);
        }
        catch (Exception)
        {
        }
        return this.isFound(entity.userName, entity.startDate);
    }

    public void merge(EmploymentDTO entity)
    {
        ctx.updateEmployment(
              entity.userName,
              entity.title,
              entity.company,
              entity.industry,
              entity.town,
              entity.province,
              entity.country,
              entity.empType,
              entity.currentEmployer,
              (Decimal)entity.gross,
              entity.startDate,
              entity.endDate,
              entity.responsibilities);
    }

    public bool remove(EmploymentDTO entity)
    {
        return this.removeByUserId(entity.userName,entity.startDate);
    }


    bool DAO_Interface<EmploymentDTO>.merge(EmploymentDTO entity)
    {
        throw new NotImplementedException();
    }
}