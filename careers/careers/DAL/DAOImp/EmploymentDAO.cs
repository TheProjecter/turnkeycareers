using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using model;

/// <summary>
/// Summary description for  EmploymentDAO
/// </summary>
public class EmploymentDAO : DAO_Employment_Interface
{
    private ModelDataContext ctx;
    public EmploymentDAO()
	{
        ctx =  new ModelDataContext();//ModelFactory.getModelInstance();
	}



    public bool isFound(string userName, DateTime startDate)
    {

        try
        {
            var obj = (from p in ctx.Employments
                       where p.userName == @userName && p.startDate ==  @startDate
                       select p).Single();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
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
            var obj = (from p in ctx.Employments
                       where p.userName == @userName && p.startDate == @startDate
                       select p).Single();

            model.Employment accObj = (Employment)obj;

            ctx.Employments.DeleteOnSubmit(accObj);
            ctx.SubmitChanges();
            return true;

        }
        catch (Exception)
        {
            return false;
        }
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
            model.Employment obj = new Employment();
            obj.userName = entity.userName;
            obj.startDate = entity.startDate;
            obj.title = entity.title;
            obj.company = entity.company;
            obj.industry = entity.industry;
            obj.town = entity.town;
            obj.province = entity.province;
            obj.country = entity.country;
            obj.empType = entity.empType;
            obj.currentEmployer = entity.currentEmployer;
            obj.gross = Decimal.Parse(entity.gross.ToString() );
            obj.startDate = entity.startDate;
            obj.endDate = entity.endDate;
            obj.responsibilities = entity.responsibilities;

            ctx.Employments.InsertOnSubmit(obj);
            ctx.SubmitChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool merge(EmploymentDTO entity)
    {
        try
        {
            var addObj = (from p in ctx.Employments
                       where p.userName == @entity.userName && p.startDate == @entity.startDate
                       select p).Single();

            model.Employment obj = (Employment)addObj;

            /*Update*/
            //obj.userName = entity.userName;
            //obj.startDate = entity.startDate;
            obj.title = entity.title;
            obj.company = entity.company;
            obj.industry = entity.industry;
            obj.town = entity.town;
            obj.province = entity.province;
            obj.country = entity.country;
            obj.empType = entity.empType;
            obj.currentEmployer = entity.currentEmployer;
            obj.gross = Decimal.Parse(entity.gross.ToString());
            obj.startDate = entity.startDate;
            obj.endDate = entity.endDate;
            obj.responsibilities = entity.responsibilities;

            ctx.SubmitChanges();
            return true;
        }
        catch (Exception e)
        {
            model.Log log = new Log();
            log.message = "Employment Merge: " + " ["+entity.userName+" , "+entity.startDate+"] " + e.Message;
            ctx.Logs.InsertOnSubmit(log);
            ctx.SubmitChanges();

            return false;
        }
    }

    public bool remove(EmploymentDTO entity)
    {
        return this.removeByUserId(entity.userName,entity.startDate);
    }
}