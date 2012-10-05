using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using careers.MODEL;

/// <summary>
/// Summary description for  HigherEducationDAO
/// </summary>
public class HigherEducationDAO : DAO_HigherEducation_Interface
{
    private modelDataContext ctx;
    public HigherEducationDAO()
	{
        ctx = new modelDataContext();//ModelFactory.getModelInstance();
	}



    public bool isFound(string userName, string major)
    {

        int cnt = (from p in ctx.HigherEducations
                   where p.userName == @userName && p.major == @major
                   select p).Count();
        if (cnt == 1)
            return true;
        else
            return false;
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
            ctx.deleteHigherEducation(userName, major);

        }
        catch (Exception)
        {

        }
        return this.isFound(userName, major);
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

            ctx.insertHigherEducation(
                entity.userName,
                entity.institution,
                entity.town,
                entity.province,
                entity.country,
                entity.educationType,
                entity.major,
                entity.industry,
                entity.length,
                entity.nqf);
        }
        catch (Exception)
        {
        }
        return this.isFound(entity.userName, entity.major);
    }

    public void merge(HigherEducationDTO entity)
    {
        ctx.updateHigherEducation(
                entity.userName,
                entity.institution,
                entity.town,
                entity.province,
                entity.country,
                entity.educationType,
                entity.major,
                entity.industry,
                entity.length,
                entity.nqf);
        
    }

    public bool remove(HigherEducationDTO entity)
    {
        return this.removeByUserId(entity.userName,entity.major);
    }


    bool DAO_Interface<HigherEducationDTO>.merge(HigherEducationDTO entity)
    {
        throw new NotImplementedException();
    }
}