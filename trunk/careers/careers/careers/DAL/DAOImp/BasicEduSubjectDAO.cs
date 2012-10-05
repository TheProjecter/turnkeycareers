using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using careers.MODEL;

/// <summary>
/// Summary description for  addressDAO
/// </summary>
public class BasicEduSubjectDAO : DAO_BasicEduSubject_Interface
{
    private modelDataContext ctx;
    public BasicEduSubjectDAO()
	{
        ctx = new modelDataContext();// new modelDataContext();//ModelFactory.getModelInstance();
	}



    public bool isFound(string userName, string subjectName)
    {

        int cnt = (from p in ctx.BasicEduSubjects
                   where p.userName == @userName && p.subjectName == @subjectName
                   select p).Count();
        if (cnt == 1)
            return true;
        else
            return false;
    }

    public BasicEduSubjectDTO find(string userName, string subjectName)
    {
        var obj = (from p in ctx.BasicEduSubjects
                   where p.userName == @userName && p.subjectName == @subjectName
                   select p).Single();

        BasicEduSubjectDTO add = new BasicEduSubjectDTO();
        add.userName = obj.userName;
        add.subjectName = obj.subjectName;
        add.subjectDescription = obj.subjectDescription;
        return add;
    }

    public bool removeByUserId(string userName, string subjectName)
    {
        try
        {
            ctx.deleteBasicEduSubject(userName, subjectName);

        }
        catch (Exception)
        {

        }
        return this.isFound(userName, subjectName);
    }

    public List<BasicEduSubjectDTO> findAll()
    {
        var objs = (from p in ctx.BasicEduSubjects
                    select p);
        BasicEduSubjectDTO add = null;
        List<BasicEduSubjectDTO> addList = new List<BasicEduSubjectDTO>();
        foreach (BasicEduSubject obj in objs)
        {
            add = new BasicEduSubjectDTO();
            add.userName = obj.userName;
            add.subjectName = obj.subjectName;
            add.subjectDescription = obj.subjectDescription;

            addList.Add(add);
        }
        return addList;
    }

    public bool presist(BasicEduSubjectDTO entity)
    {
        try
        {

            ctx.insertBasicEduSubject(entity.userName, entity.subjectName, entity.subjectDescription);
        }
        catch (Exception)
        {
        }
        return this.isFound(entity.userName,entity.subjectName);
    }

    public void merge(BasicEduSubjectDTO entity)
    {


        ctx.updateBasicEduSubject(entity.userName, entity.subjectName, entity.subjectDescription);
    
    }

    public bool remove(BasicEduSubjectDTO entity)
    {
        return this.removeByUserId(entity.userName,entity.subjectName);
    }


    bool DAO_Interface<BasicEduSubjectDTO>.merge(BasicEduSubjectDTO entity)
    {
        throw new NotImplementedException();
    }
}