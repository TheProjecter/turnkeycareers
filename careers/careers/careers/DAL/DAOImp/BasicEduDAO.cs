using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using model;

/// <summary>
/// Summary description for AccountDAO
/// </summary>
public class BasicEduDAO : DAO_BasicEdu_Interface
{
    private ModelDataContext ctx;
    public BasicEduDAO()
	{
        ctx =  new ModelDataContext();//ModelFactory.getModelInstance();
	}

    public bool isFound(string userName)
    {
        try
        {
            var obj = (from p in ctx.BasicEdus
                       where p.userName == @userName
                       select p).Single();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public BasicEduDTO find(string userName)
    {
        var obj = (from p in ctx.BasicEdus
                   where p.userName == @userName
                   select p).Single();

        BasicEduDTO acc = new BasicEduDTO();
        acc.userName = obj.userName;
        acc.school = obj.school;
        acc.town = obj.town;
        acc.province = obj.province;
        acc.country = obj.country;
        acc.levelCompleted = obj.levelCompleted;
        return acc;
    }


    public List<BasicEduDTO> findAll()
    {
        var objs = (from p in ctx.BasicEdus 
                   select p);
        BasicEduDTO acc = null;
        List<BasicEduDTO> accounts = new List<BasicEduDTO>();
        foreach(BasicEdu obj in objs)
        {
            acc = new BasicEduDTO();
            acc.userName = obj.userName;
            acc.school = obj.school;
            acc.town = obj.town;
            acc.province = obj.province;
            acc.country = obj.country;
            acc.levelCompleted = obj.levelCompleted;

            accounts.Add(acc);
        }
        return accounts;
    }

    public bool presist(BasicEduDTO entityDTO)
    {
        try
        {
            model.BasicEdu obj = new BasicEdu();
            obj.userName = entityDTO.userName;
            obj.school = entityDTO.school;
            obj.town = entityDTO.town;
            obj.province = entityDTO.province;
            obj.country = entityDTO.country;
            obj.levelCompleted = entityDTO.levelCompleted;

            ctx.BasicEdus.InsertOnSubmit(obj);
            ctx.SubmitChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
   
    public bool merge(BasicEduDTO entityDTO)
    {
        try
         {
        var obj = (from p in ctx.BasicEdus
                   where p.userName == @entityDTO.userName
                   select p).Single();

        model.BasicEdu accObj = (BasicEdu)obj;

        /*Update*/
        accObj.userName = entityDTO.userName;
        accObj.school = entityDTO.school;
        accObj.town = entityDTO.town;
        accObj.province = entityDTO.province;
        accObj.country = entityDTO.country;
        accObj.levelCompleted = entityDTO.levelCompleted;

        ctx.SubmitChanges();
        return true;
          }
          catch (Exception)
          {
              return false;
          }
    }

    public bool remove(BasicEduDTO entity)
    {
        return this.removeByUserId(entity.userName);
    }

    public bool removeByUserId(string userName)
    {
        try
        {
            var obj = (from p in ctx.BasicEdus
                       where p.userName == @userName
                       select p).Single();

            model.BasicEdu accObj = (BasicEdu)obj;

            ctx.BasicEdus.DeleteOnSubmit(accObj);
            ctx.SubmitChanges();
            return true;

        }
        catch (Exception)
        {
            return false;
        }
    }

}