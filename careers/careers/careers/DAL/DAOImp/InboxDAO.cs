using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using careers.MODEL;

/// <summary>
/// Summary description for  InboxDAO
/// </summary>
public class InboxDAO : DAO_Inbox_Interface
{
    private modelDataContext ctx;
    public InboxDAO()
	{
        ctx = new modelDataContext();//ModelFactory.getModelInstance();
	}



    public bool isFound(string userName, int messageId)
    {

        int cnt = (from p in ctx.Inboxes
                   where p.userName == @userName && p.messageId == @messageId
                   select p).Count();
        if (cnt == 1)
            return true;
        else
            return false;
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
            ctx.deleteInbox(userName, messageId);

        }
        catch (Exception)
        {

        }
        return this.isFound(userName, messageId);
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

            ctx.insertInbox(entity.userName, entity.messageId, entity.date, entity.unread, entity.message);
        }
        catch (Exception)
        {
        }
        return this.isFound(entity.userName, entity.messageId);
    }

    public void merge(InboxDTO entity)
    {
        ctx.updateInbox(entity.userName, entity.messageId, entity.date, entity.unread, entity.message);
    }

    public bool remove(InboxDTO entity)
    {
        return this.removeByUserId(entity.userName,entity.messageId);
    }


    bool DAO_Interface<InboxDTO>.merge(InboxDTO entity)
    {
        throw new NotImplementedException();
    }
}