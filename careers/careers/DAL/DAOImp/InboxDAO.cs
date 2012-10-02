using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using model;

/// <summary>
/// Summary description for  InboxDAO
/// </summary>
public class InboxDAO : DAO_Inbox_Interface
{
    private ModelDataContext ctx;
    public InboxDAO()
	{
        ctx =  new ModelDataContext();//ModelFactory.getModelInstance();
	}



    public bool isFound(string userName, int messageId)
    {

        try
        {
            var obj = (from p in ctx.Inboxes
                       where p.userName == @userName && p.messageId ==  @messageId
                       select p).Single();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public InboxDTO find(string userName, int messageId)
    {
        var obj = (from p in ctx.Inboxes
                   where p.userName == @userName && p.messageId == @messageId
                   select p).Single();

        InboxDTO add = new InboxDTO();
        add.userName = obj.userName;
        add.messageId = obj.messageId;
        add.date = obj.date;
        add.unread = obj.unread;
        add.message = obj.message;

        return add;
    }

    public bool removeByUserId(string userName, int messageId)
    {
        try
        {
            var obj = (from p in ctx.Inboxes
                       where p.userName == @userName && p.messageId == @messageId
                       select p).Single();

            model.Inbox accObj = (Inbox)obj;

            ctx.Inboxes.DeleteOnSubmit(accObj);
            ctx.SubmitChanges();
            return true;

        }
        catch (Exception)
        {
            return false;
        }
    }

    public List<InboxDTO> findAll()
    {
        var objs = (from p in ctx.Inboxes
                    select p);
        InboxDTO add = null;
        List<InboxDTO> addList = new List<InboxDTO>();
        foreach (Inbox obj in objs)
        {
            add = new InboxDTO();
            add.userName = obj.userName;
            add.messageId = obj.messageId;
            add.date = obj.date;
            add.unread = obj.unread;
            add.message = obj.message;

            addList.Add(add);
        }
        return addList;
    }

    public bool presist(InboxDTO entity)
    {
        try
        {
            model.Inbox obj = new Inbox();
            obj.userName = entity.userName;
            obj.messageId = entity.messageId;
            obj.date = entity.date;
            obj.unread = entity.unread;
            obj.message = entity.message;

            ctx.Inboxes.InsertOnSubmit(obj);
            ctx.SubmitChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool merge(InboxDTO entity)
    {
        try
        {
            var addObj = (from p in ctx.Inboxes
                       where p.userName == @entity.userName && p.messageId == @entity.messageId
                       select p).Single();

            model.Inbox obj = (Inbox)addObj;

            /*Update*/
            //obj.userName = entity.userName;
            //obj.messageId = entity.messageId;
            obj.date = entity.date;
            obj.unread = entity.unread;
            obj.message = entity.message;

            ctx.SubmitChanges();
            return true;
        }
        catch (Exception e)
        {
            model.Log log = new Log();
            log.message = "Inbox Merge: " + " ["+entity.userName+" , "+entity.messageId+"] " + e.Message;
            ctx.Logs.InsertOnSubmit(log);
            ctx.SubmitChanges();

            return false;
        }
    }

    public bool remove(InboxDTO entity)
    {
        return this.removeByUserId(entity.userName,entity.messageId);
    }
}