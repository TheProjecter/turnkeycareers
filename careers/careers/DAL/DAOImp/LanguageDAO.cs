using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using model;

/// <summary>
/// Summary description for  HigherEducationDAO
/// </summary>
public class LanguageDAO : DAO_Language_Interface
{
    private ModelDataContext ctx;
    public LanguageDAO()
	{
        ctx =  new ModelDataContext();//ModelFactory.getModelInstance();
	}



    public bool isFound(string userName, string languageName)
    {

        try
        {
            var obj = (from p in ctx.Languages
                       where p.userName == @userName && p.languageName ==  @languageName
                       select p).Single();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public LanguageDTO find(string userName, string languageName)
    {
        var obj = (from p in ctx.Languages
                   where p.userName == @userName && p.languageName == @languageName
                   select p).Single();

        LanguageDTO add = new LanguageDTO();
        add.userName = obj.userName;
        add.languageName = obj.languageName;
        add.reads = obj.reads;
        add.write = obj.write;
        add.speak = obj.speak;

        return add;
    }

    public bool removeByUserId(string userName, string languageName)
    {
        try
        {
            var obj = (from p in ctx.Languages
                       where p.userName == @userName && p.languageName == @languageName
                       select p).Single();

            model.Language accObj = (Language)obj;

            ctx.Languages.DeleteOnSubmit(accObj);
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

    public List<LanguageDTO> findAll()
    {
        var objs = (from p in ctx.Languages
                    select p);
        LanguageDTO add = null;
        List<LanguageDTO> addList = new List<LanguageDTO>();
        foreach (Language obj in objs)
        {
            add = new LanguageDTO();
            add.userName = obj.userName;
            add.languageName = obj.languageName;
            add.reads = obj.reads;
            add.write = obj.write;
            add.speak = obj.speak;

            addList.Add(add);
        }
        return addList;
    }

    public bool presist(LanguageDTO entity)
    {
        try
        {
            model.Language obj = new Language();
            obj.userName = entity.userName;
            obj.languageName = entity.languageName;
            obj.reads = entity.reads;
            obj.write = entity.write;
            obj.speak = entity.speak;

            ctx.Languages.InsertOnSubmit(obj);
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

    public bool merge(LanguageDTO entity)
    {
        try
        {
            var addObj = (from p in ctx.Languages
                       where p.userName == @entity.userName && p.languageName == @entity.languageName
                       select p).Single();

            model.Language obj = (Language)addObj;

            /*Update*/
            obj.userName = entity.userName;
            obj.languageName = entity.languageName;
            obj.reads = entity.reads;
            obj.write = entity.write;
            obj.speak = entity.speak;

            ctx.SubmitChanges();
            return true;
        }
        catch (Exception e)
        {
            model.Log log = new Log();
            log.message = "Language Merge: " + " ["+entity.userName+" , "+entity.languageName+"] " + e.Message;
            ctx.SubmitChanges();

            ctx.Dispose();
            ctx = new ModelDataContext();
            return false;
        }
    }

    public bool remove(LanguageDTO entity)
    {
        return this.removeByUserId(entity.userName,entity.languageName);
    }
}