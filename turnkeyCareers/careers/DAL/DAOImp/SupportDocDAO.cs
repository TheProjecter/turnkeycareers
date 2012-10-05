using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using careers.MODEL;

/// <summary>
/// Summary description for  addressDAO
/// </summary>
public class SupportDocDAO : DAO_SupportDoc_Interface
{
    private modelDataContext ctx;
    public SupportDocDAO()
	{
        ctx = new modelDataContext();//ModelFactory.getModelInstance();
	}



    public bool isFound(string userName, string title)
    {

        try
        {
            var obj = (from p in ctx.supportDocs
                       where p.userName == @userName && p.title ==  @title
                       select p).Single();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public SupportDocDTO find(string userName, string title)
    {
        var obj = (from p in ctx.supportDocs
                   where p.userName == @userName && p.title == @title
                   select p).Single();

        SupportDocDTO add = new SupportDocDTO();
        add.userName = obj.userName;
        add.title = obj.title;
        add.description = obj.description;
        add.content = obj.content.ToArray();

        return add;
    }

    public bool removeByUserId(string userName, string title)
    {
        try
        {
            var obj = (from p in ctx.supportDocs
                       where p.userName == @userName && p.title == @title
                       select p).Single();

            supportDoc accObj = (supportDoc)obj;

            ctx.supportDocs.DeleteOnSubmit(accObj);
            ctx.SubmitChanges();
            return true;

        }
        catch (Exception)
        {
            ctx.Dispose();
            ctx = new modelDataContext();
            return false;
        }
    }

    public List<SupportDocDTO> findAll()
    {
        var objs = (from p in ctx.supportDocs
                    select p);
        SupportDocDTO add = null;
        List<SupportDocDTO> addList = new List<SupportDocDTO>();
        foreach (supportDoc obj in objs)
        {
            add = new SupportDocDTO();
            add.userName = obj.userName;
            add.title = obj.title;
            add.description = obj.description;
            add.content = obj.content.ToArray();//Converts Binary data to an Array of bytes

            addList.Add(add);
        }
        return addList;
    }

    public bool presist(SupportDocDTO entity)
    {
        try
        {
             supportDoc obj = new supportDoc();
            obj.userName = entity.userName;
            obj.title = entity.title;
            obj.description = entity.description;
            obj.content = new System.Data.Linq.Binary(entity.content);//Array of bytes to Linq.Binary

            ctx.supportDocs.InsertOnSubmit(obj);
            ctx.SubmitChanges();
            return true;
        }
        catch (Exception)
        {
            ctx.Dispose();
            ctx = new modelDataContext();
            return false;
        }
    }

    public bool merge(SupportDocDTO entity)
    {
        try
        {
            var addObj = (from p in ctx.supportDocs
                       where p.userName == @entity.userName && p.title == @entity.title
                       select p).Single();

             supportDoc obj = (supportDoc)addObj;

            /*Update*/
            obj.userName = entity.userName;
            obj.title = entity.title;
            obj.description = entity.description;
            obj.content = new System.Data.Linq.Binary(entity.content);//Array of bytes to Linq.Binary

            ctx.SubmitChanges();
            return true;
        }
        catch (Exception e)
        {
             Log log = new Log();
            log.message = "supportDoc Merge: " + " ["+entity.userName+" , "+entity.title+"] " + e.Message;
            ctx.SubmitChanges();

            ctx.Dispose();
            ctx = new modelDataContext();
            return false;
        }
    }

    public bool remove(SupportDocDTO entity)
    {
        return this.removeByUserId(entity.userName,entity.title);
    }
}