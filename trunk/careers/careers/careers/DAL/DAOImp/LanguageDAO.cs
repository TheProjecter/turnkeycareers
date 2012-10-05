using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using careers.MODEL;

/// <summary>
/// Summary description for  HigherEducationDAO
/// </summary>
public class LanguageDAO : DAO_Language_Interface
{
    private modelDataContext ctx;
    public LanguageDAO()
	{
        ctx = new modelDataContext();//ModelFactory.getModelInstance();
	}



    public bool isFound(string userName, string languageName)
    {

        int cnt = (from p in ctx.Languages
                   where p.userName == @userName && p.languageName == @languageName
                   select p).Count();
        if (cnt == 1)
            return true;
        else
            return false;
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
            ctx.deleteLanguage(userName, languageName);

        }
        catch (Exception)
        {

        }
        return this.isFound(userName, languageName);
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

            ctx.insertLanguage(entity.userName, entity.languageName, entity.reads, entity.write, entity.speak);
        }
        catch (Exception)
        {
        }
        return this.isFound(entity.userName, entity.languageName);
    }

    public void merge(LanguageDTO entity)
    {
        ctx.updateLanguage(entity.userName, entity.languageName, entity.reads, entity.write, entity.speak);
    }

    public bool remove(LanguageDTO entity)
    {
        return this.removeByUserId(entity.userName,entity.languageName);
    }


    bool DAO_Interface<LanguageDTO>.merge(LanguageDTO entity)
    {
        throw new NotImplementedException();
    }
}