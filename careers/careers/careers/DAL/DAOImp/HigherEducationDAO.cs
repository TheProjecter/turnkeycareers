using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using model;

/// <summary>
/// Summary description for  HigherEducationDAO
/// </summary>
public class HigherEducationDAO : DAO_HigherEducation_Interface
{
    private ModelDataContext ctx;
    public HigherEducationDAO()
	{
        ctx =  new ModelDataContext();//ModelFactory.getModelInstance();
	}



    public bool isFound(string userName, string major)
    {

        try
        {
            var obj = (from p in ctx.HigherEducations
                       where p.userName == @userName && p.major ==  @major
                       select p).Single();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public HigherEducationDTO find(string userName, string major)
    {
        var obj = (from p in ctx.HigherEducations
                   where p.userName == @userName && p.major == @major
                   select p).Single();

        HigherEducationDTO add = new HigherEducationDTO();
        add.userName = obj.userName;
        add.institution = obj.institution;
        add.town = obj.town;
        add.province = obj.province;
        add.country = obj.country;
        add.educationType = obj.educationType;
        add.major = obj.major;
        add.industry = obj.industry;
        add.length = obj.length;
        add.nqf = obj.nqf;


        return add;
    }

    public bool removeByUserId(string userName, string major)
    {
        try
        {
            var obj = (from p in ctx.HigherEducations
                       where p.userName == @userName && p.major == @major
                       select p).Single();

            model.HigherEducation accObj = (HigherEducation)obj;

            ctx.HigherEducations.DeleteOnSubmit(accObj);
            ctx.SubmitChanges();
            return true;

        }
        catch (Exception)
        {
            return false;
        }
    }

    public List<HigherEducationDTO> findAll()
    {
        var objs = (from p in ctx.HigherEducations
                    select p);
        HigherEducationDTO add = null;
        List<HigherEducationDTO> addList = new List<HigherEducationDTO>();
        foreach (HigherEducation obj in objs)
        {
            add = new HigherEducationDTO();
            add.userName = obj.userName;
            add.institution = obj.institution;
            add.town = obj.town;
            add.province = obj.province;
            add.country = obj.country;
            add.educationType = obj.educationType;
            add.major = obj.major;
            add.industry = obj.industry;
            add.length = obj.length;
            add.nqf = obj.nqf;

            addList.Add(add);
        }
        return addList;
    }

    public bool presist(HigherEducationDTO entity)
    {
        try
        {
            model.HigherEducation obj = new HigherEducation();
            obj.userName = entity.userName;
            obj.major = entity.major;
            obj.institution = entity.institution;
            obj.town = entity.town;
            obj.province = entity.province;
            obj.country = entity.country;
            obj.educationType = entity.educationType;
            obj.major = entity.major;
            obj.industry = entity.industry;
            obj.length = entity.length;
            obj.nqf = entity.nqf;

            ctx.HigherEducations.InsertOnSubmit(obj);
            ctx.SubmitChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool merge(HigherEducationDTO entity)
    {
        try
        {
            var addObj = (from p in ctx.HigherEducations
                       where p.userName == @entity.userName && p.major == @entity.major
                       select p).Single();

            model.HigherEducation obj = (HigherEducation)addObj;

            /*Update*/
            //obj.userName = entity.userName;
            //obj.major = entity.major;
            obj.institution = entity.institution;
            obj.town = entity.town;
            obj.province = entity.province;
            obj.country = entity.country;
            obj.educationType = entity.educationType;
            obj.major = entity.major;
            obj.industry = entity.industry;
            obj.length = entity.length;
            obj.nqf = entity.nqf;

            ctx.SubmitChanges();
            return true;
        }
        catch (Exception e)
        {
            model.Log log = new Log();
            log.message = "HigherEducation Merge: " + " ["+entity.userName+" , "+entity.major+"] " + e.Message;
            ctx.Logs.InsertOnSubmit(log);
            ctx.SubmitChanges();

            return false;
        }
    }

    public bool remove(HigherEducationDTO entity)
    {
        return this.removeByUserId(entity.userName,entity.major);
    }
}