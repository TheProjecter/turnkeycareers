using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using model;

/// <summary>
/// Summary description for  DisabilityDAO
/// </summary>
public class DisabilityDAO : DAO_Disability_Interface
{
    private ModelDataContext ctx;
    public DisabilityDAO()
	{
        ctx =  new ModelDataContext();//ModelFactory.getModelInstance();
	}



    public bool isFound(string userName, string disabilityType)
    {

        try
        {
            var obj = (from p in ctx.Disabilities
                       where p.userName == @userName && p.disabilityType ==  @disabilityType
                       select p).Single();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public DisabilityDTO find(string userName, string disabilityType)
    {
        var obj = (from p in ctx.Disabilities
                   where p.userName == @userName && p.disabilityType == @disabilityType
                   select p).Single();

        DisabilityDTO add = new DisabilityDTO();
        add.userName = obj.userName;
        add.disabilityType = obj.disabilityType;
        add.description = obj.description;

        return add;
    }

    public bool removeByUserId(string userName, string disabilityType)
    {
        try
        {
            var obj = (from p in ctx.Disabilities
                       where p.userName == @userName && p.disabilityType == @disabilityType
                       select p).Single();

            model.Disability accObj = (Disability)obj;

            ctx.Disabilities.DeleteOnSubmit(accObj);
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

    public List<DisabilityDTO> findAll()
    {
        var objs = (from p in ctx.Disabilities
                    select p);
        DisabilityDTO add = null;
        List<DisabilityDTO> addList = new List<DisabilityDTO>();
        foreach (Disability obj in objs)
        {
            add = new DisabilityDTO();
            add.userName = obj.userName;
            add.disabilityType = obj.disabilityType;
            add.description = obj.description;

            addList.Add(add);
        }
        return addList;
    }

    public bool presist(DisabilityDTO entity)
    {
        try
        {
            model.Disability obj = new Disability();
            obj.userName = entity.userName;
            obj.disabilityType = entity.disabilityType;
            obj.description = entity.description;

            ctx.Disabilities.InsertOnSubmit(obj);
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

    public bool merge(DisabilityDTO entity)
    {
        try
        {
            var addObj = (from p in ctx.Disabilities
                       where p.userName == @entity.userName && p.disabilityType == @entity.disabilityType
                       select p).Single();

            model.Disability obj = (Disability)addObj;

            /*Update*/
            obj.userName = entity.userName;
            obj.disabilityType = entity.disabilityType;
            obj.description = entity.description;

            ctx.SubmitChanges();
            return true;
        }
        catch (Exception e)
        {
            model.Log log = new Log();
            log.message = "Disability Merge: " + " ["+entity.userName+" , "+entity.disabilityType+"] " + e.Message;
            ctx.SubmitChanges();

            ctx.Dispose();
            ctx = new ModelDataContext();
            return false;
        }
    }

    public bool remove(DisabilityDTO entity)
    {
        return this.removeByUserId(entity.userName,entity.disabilityType);
    }
}