using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using model;

/// <summary>
/// Summary description for  addressDAO
/// </summary>
public class KeyWordDAO : DAO_KeyWord_Interface
{
    private ModelDataContext ctx;
    public KeyWordDAO()
	{
        ctx =  new ModelDataContext();//ModelFactory.getModelInstance();
	}





    public bool isFound(string word, string vacancyNumber)
    {
        try
        {
            var obj = (from p in ctx.KeyWords
                       where p.word == @word && p.vacancyNumber == @vacancyNumber
                       select p).Single();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public KeyWordDTO find(string word, string vacancyNumber)
    {
        var obj = (from p in ctx.KeyWords
                   where p.word == @word && p.vacancyNumber == @vacancyNumber
                   select p).Single();

        KeyWordDTO add = new KeyWordDTO();
        add.vacancyNumber = obj.vacancyNumber;
        add.word = obj.word;

        return add;
    }

    public bool removeByUserId(string word, string vacancyNumber)
    {
        try
        {
            var obj = (from p in ctx.KeyWords
                       where p.word == @word && p.vacancyNumber == @vacancyNumber
                       select p).Single();

            model.KeyWord accObj = (KeyWord)obj;

            ctx.KeyWords.DeleteOnSubmit(accObj);
            ctx.SubmitChanges();
            return true;

        }
        catch (Exception)
        {
            return false;
        }
    }

    public List<KeyWordDTO> findAll()
    {
        var objs = (from p in ctx.KeyWords
                    select p);
        KeyWordDTO add = null;
        List<KeyWordDTO> addList = new List<KeyWordDTO>();
        foreach (KeyWord obj in objs)
        {
            add = new KeyWordDTO();
            add.word = obj.word;
            add.vacancyNumber = obj.vacancyNumber;

            addList.Add(add);
        }
        return addList;
    }

    public bool presist(KeyWordDTO entity)
    {
        try
        {
            model.KeyWord obj = new KeyWord();
            obj.word = entity.word;
            obj.vacancyNumber = entity.vacancyNumber;

            ctx.KeyWords.InsertOnSubmit(obj);
            ctx.SubmitChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool merge(KeyWordDTO entity)
    {
        try
        {
            var addObj = (from p in ctx.KeyWords
                       where p.word == @entity.word && p.vacancyNumber == @entity.vacancyNumber
                       select p).Single();

            model.KeyWord obj = (KeyWord)addObj;

            /*Update*/
            obj.word = entity.word;
            obj.vacancyNumber = entity.vacancyNumber;

            ctx.SubmitChanges();
            return true;
        }
        catch (Exception e)
        {
            model.Log log = new Log();
            log.message = "KeyWord Merge: " + " [" + entity.word + " , " + entity.vacancyNumber + "] " + e.Message;
            ctx.Logs.InsertOnSubmit(log);
            ctx.SubmitChanges();

            return false;
        }
    }

    public bool remove(KeyWordDTO entity)
    {
        return this.removeByUserId(entity.word, entity.vacancyNumber);
    }
}