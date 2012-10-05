using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using careers.MODEL;

/// <summary>
/// Summary description for  ContactInfoDAO
/// </summary>
public class ContactInfoDAO : DAO_ContactInfo_Interface
{
    private modelDataContext ctx;
    public ContactInfoDAO()
	{
        ctx = new modelDataContext();//ModelFactory.getModelInstance();
	}



    public bool isFound(string userName, string contactType)
    {


        int cnt = (from p in ctx.ContactInfos
                   where p.userName == @userName && p.contactType == @contactType
                   select p).Count();
        if (cnt == 1)
            return true;
        else
            return false;
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
            ctx.deleteContactInfo(userName, contactType);

        }
        catch (Exception)
        {

        }
        return this.isFound(userName, contactType);
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

            ctx.insertContactInfo(entity.userName, entity.contactType, entity.data);
        }
        catch (Exception)
        {
        }
        return this.isFound(entity.userName, entity.contactType);
    }

    public void merge(ContactInfoDTO entity)
    {
        ctx.updateContactInfo(entity.userName, entity.contactType, entity.data);
    }

    public bool remove(ContactInfoDTO entity)
    {
        return this.removeByUserId(entity.userName,entity.contactType);
    }


    bool DAO_Interface<ContactInfoDTO>.merge(ContactInfoDTO entity)
    {
        throw new NotImplementedException();
    }
}