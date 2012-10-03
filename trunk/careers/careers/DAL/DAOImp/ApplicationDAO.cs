using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using model;

/// <summary>
/// Summary description for  addressDAO
/// </summary>
public class ApplicationDAO : DAO_Application_Interface
{
    private ModelDataContext ctx;
    public ApplicationDAO()
	{
        ctx =  new ModelDataContext();//ModelFactory.getModelInstance();
	}





    public bool isFound(string userName, string vacancyNumber)
    {
        try
        {
            var obj = (from p in ctx.Applications
                       where p.userName == @userName && p.vacancyNumber == @vacancyNumber
                       select p).Single();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public ApplicationDTO find(string userName, string vacancyNumber)
    {
        var obj = (from p in ctx.Applications
                   where p.userName == @userName && p.vacancyNumber == @vacancyNumber
                   select p).Single();

        ApplicationDTO add = new ApplicationDTO();
        add.userName = obj.userName;
        add.vacancyNumber = obj.vacancyNumber;
        add.status = obj.status;
        return add;
    }

    public bool removeByUserId(string userName, string vacancyNumber)
    {
        try
        {
            var obj = (from p in ctx.Applications
                       where p.userName == @userName && p.vacancyNumber == @vacancyNumber
                       select p).Single();

            Application accObj = (Application)obj;

            ctx.Applications.DeleteOnSubmit(accObj);
            ctx.SubmitChanges();
            return true;

        }
        catch (Exception)
        {
            ctx.Dispose();
            ctx = new ModelDataContext();
            return false;
        }
    }

    public List<ApplicationDTO> findAll()
    {
        var objs = (from p in ctx.Applications
                    select p);
        ApplicationDTO add = null;
        List<ApplicationDTO> addList = new List<ApplicationDTO>();
        foreach (Application obj in objs)
        {
            add = new ApplicationDTO();
            add.userName = obj.userName;
            add.vacancyNumber = obj.vacancyNumber;
            add.status = obj.status;

            addList.Add(add);
        }
        return addList;
    }

    public bool presist(ApplicationDTO entity)
    {
        try
        {
            model.Application obj = new Application();
            obj.userName = entity.userName;
            obj.vacancyNumber = entity.vacancyNumber;
            obj.status = entity.status;

            ctx.Applications.InsertOnSubmit(obj);
            ctx.SubmitChanges();
            return true;
        }
        catch (Exception)
        {
            ctx.Dispose();
            ctx = new ModelDataContext();
            return false;
        }
    }

    public bool merge(ApplicationDTO entity)
    {
        try
        {
            var addObj = (from p in ctx.Applications
                       where p.userName == @entity.userName && p.vacancyNumber == @entity.vacancyNumber
                       select p).Single();

            model.Application obj = (Application)addObj;

            /*Update*/
            obj.userName = entity.userName;
            obj.vacancyNumber = entity.vacancyNumber;
            obj.status = entity.status;

            ctx.SubmitChanges();
            return true;
        }
        catch (Exception e)
        {
            model.Log log = new Log();
            log.message = "Application Merge: " + " [" + entity.userName + " , " + entity.vacancyNumber + "] " + e.Message;

            ctx.Dispose();
            ctx = new ModelDataContext();
            ctx.SubmitChanges();

            return false;
        }
    }

    public bool remove(ApplicationDTO entity)
    {
        return this.removeByUserId(entity.userName, entity.vacancyNumber);
    }
}