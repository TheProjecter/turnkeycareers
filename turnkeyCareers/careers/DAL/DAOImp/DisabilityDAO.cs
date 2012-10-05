using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using careers.MODEL;

/// <summary>
/// Summary description for  DisabilityDAO
/// </summary>
public class DisabilityDAO : DAO_Disability_Interface
{
    private modelDataContext ctx;
    public DisabilityDAO()
	{
        ctx = new modelDataContext();//ModelFactory.getModelInstance();
	}



    public bool isFound(string userName, string disabilityType)
    {

        int cnt = (from p in ctx.Disabilities
                   where p.userName == @userName && p.disabilityType == @disabilityType
                   select p).Count();
        if (cnt == 1)
            return true;
        else
            return false;
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
            ctx.deleteDisability(userName, disabilityType);
        }
        catch (Exception)
        {

        }
        return this.isFound(userName, disabilityType);
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

            ctx.insertDisability(entity.userName, entity.disabilityType, entity.description);
        }
        catch (Exception)
        {
        }
        return this.isFound(entity.userName, entity.disabilityType);
    }

    public void merge(DisabilityDTO entity)
    {
         ctx.updateDisability(entity.userName, entity.disabilityType, entity.description);
        
    }

    public bool remove(DisabilityDTO entity)
    {
        return this.removeByUserId(entity.userName,entity.disabilityType);
    }


    bool DAO_Interface<DisabilityDTO>.merge(DisabilityDTO entity)
    {
        throw new NotImplementedException();
    }
}