using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using model;

/// <summary>
/// Summary description for  addressDAO
/// </summary>
public class BasicEduSubjectDAO : DAO_BasicEduSubject_Interface
{
    private ModelDataContext ctx;
    public BasicEduSubjectDAO()
	{
        ctx = ModelFactory.getModelInstance();
	}



    public bool isFound(string userName, string subjectName)
    {

        try
        {
            var obj = (from p in ctx.BasicEduSubjects
                       where p.userName == @userName && p.subjectName ==  @subjectName
                       select p).Single();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
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
            var obj = (from p in ctx.BasicEduSubjects
                       where p.userName == @userName && p.subjectName == @subjectName
                       select p).Single();

            BasicEduSubject accObj = (BasicEduSubject)obj;

            ctx.BasicEduSubjects.DeleteOnSubmit(accObj);
            ctx.SubmitChanges();
            return true;

        }
        catch (Exception)
        {
            return false;
        }
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
            model.BasicEduSubject obj = new BasicEduSubject();
            obj.userName = entity.userName;
            obj.subjectName = entity.subjectName;
            obj.subjectDescription = entity.subjectDescription;

            ctx.BasicEduSubjects.InsertOnSubmit(obj);
            ctx.SubmitChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool merge(BasicEduSubjectDTO entity)
    {
        try
        {
            var addObj = (from p in ctx.BasicEduSubjects
                       where p.userName == @entity.userName && p.subjectName == @entity.subjectName
                       select p).Single();

            model.BasicEduSubject obj = (BasicEduSubject)addObj;

            /*Update*/
            //obj.userName = entity.userName;
            //obj.subjectName = entity.subjectName;
            obj.subjectDescription = entity.subjectDescription;

            ctx.SubmitChanges();
            return true;
        }
        catch (Exception e)
        {
            model.Log log = new Log();
            log.message = "BasicEduSubject Merge: " + " ["+entity.userName+" , "+entity.subjectName+"] " + e.Message;
            ctx.Logs.InsertOnSubmit(log);
            ctx.SubmitChanges();

            return false;
        }
    }

    public bool remove(BasicEduSubjectDTO entity)
    {
        return this.removeByUserId(entity.userName,entity.subjectName);
    }
}