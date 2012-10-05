using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using careers.MODEL;

/// <summary>
/// Summary description for AccountDAO
/// </summary>
public class BasicEduDAO : DAO_BasicEdu_Interface
{
    private modelDataContext ctx;
    public BasicEduDAO()
	{
        ctx = new modelDataContext();//ModelFactory.getModelInstance();
	}

    public bool isFound(string userName)
    {

        int cnt = (from p in ctx.BasicEdus
                   where p.userName == @userName 
                   select p).Count();
        if (cnt == 1)
            return true;
        else
            return false;
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

            ctx.insertBasicEdu(entityDTO.userName, entityDTO.school, entityDTO.town, entityDTO.province,
                entityDTO.country, entityDTO.levelCompleted);
        }
        catch (Exception)
        {
        }
        return this.isFound(entityDTO.userName);
    }
   
    public void merge(BasicEduDTO entityDTO)
    {
        ctx.updateBasicEdu(entityDTO.userName, entityDTO.school, entityDTO.town, entityDTO.province,
                entityDTO.country, entityDTO.levelCompleted);
    }

    public bool remove(BasicEduDTO entity)
    {
        return this.removeByUserId(entity.userName);
    }

    public bool removeByUserId(string userName)
    {

         try
        {
            ctx.deleteBasicEdu(userName);

        }
        catch (Exception)
        {

        }
        return this.isFound(userName);
        }


    bool DAO_Interface<BasicEduDTO>.merge(BasicEduDTO entity)
    {
        throw new NotImplementedException();
    }
}



