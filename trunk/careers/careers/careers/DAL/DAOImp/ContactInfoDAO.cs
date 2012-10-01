using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using model;

/// <summary>
/// Summary description for  ContactInfoDAO
/// </summary>
public class ContactInfoDAO : DAO_ContactInfo_Interface
{
    private ModelDataContext ctx;
    public ContactInfoDAO()
	{
        ctx =  new ModelDataContext();//ModelFactory.getModelInstance();
	}



    public bool isFound(string userName, string contactType)
    {

        try
        {
            var obj = (from p in ctx.ContactInfos
                       where p.userName == @userName && p.contactType ==  @contactType
                       select p).Single();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public ContactInfoDTO find(string userName, string contactType)
    {
        var obj = (from p in ctx.ContactInfos
                   where p.userName == @userName && p.contactType == @contactType
                   select p).Single();

        ContactInfoDTO add = new ContactInfoDTO();
        add.userName = obj.userName;
        add.contactType = obj.contactType;
        add.data = obj.data;

        return add;
    }

    public bool removeByUserId(string userName, string contactType)
    {
        try
        {
            var obj = (from p in ctx.ContactInfos
                       where p.userName == @userName && p.contactType == @contactType
                       select p).Single();

            model.ContactInfo accObj = (ContactInfo)obj;

            ctx.ContactInfos.DeleteOnSubmit(accObj);
            ctx.SubmitChanges();
            return true;

        }
        catch (Exception)
        {
            return false;
        }
    }

    public List<ContactInfoDTO> findAll()
    {
        var objs = (from p in ctx.ContactInfos
                    select p);
        ContactInfoDTO add = null;
        List<ContactInfoDTO> addList = new List<ContactInfoDTO>();
        foreach (ContactInfo obj in objs)
        {
            add = new ContactInfoDTO();
            add.userName = obj.userName;
            add.contactType = obj.contactType;
            add.data = obj.data;

            addList.Add(add);
        }
        return addList;
    }

    public bool presist(ContactInfoDTO entity)
    {
        try
        {
            model.ContactInfo obj = new ContactInfo();
            obj.userName = entity.userName;
            obj.contactType = entity.contactType;
            obj.data = entity.data;

            ctx.ContactInfos.InsertOnSubmit(obj);
            ctx.SubmitChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool merge(ContactInfoDTO entity)
    {
        try
        {
            var addObj = (from p in ctx.ContactInfos
                       where p.userName == @entity.userName && p.contactType == @entity.contactType
                       select p).Single();

            model.ContactInfo obj = (ContactInfo)addObj;

            /*Update*/
            //obj.userName = entity.userName;
            //obj.contactType = entity.contactType;
            obj.data = entity.data;

            ctx.SubmitChanges();
            return true;
        }
        catch (Exception e)
        {
            model.Log log = new Log();
            log.message = "ContactInfo Merge: " + " ["+entity.userName+" , "+entity.contactType+"] " + e.Message;
            ctx.Logs.InsertOnSubmit(log);
            ctx.SubmitChanges();

            return false;
        }
    }

    public bool remove(ContactInfoDTO entity)
    {
        return this.removeByUserId(entity.userName,entity.contactType);
    }
}