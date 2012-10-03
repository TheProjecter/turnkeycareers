using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using model;

/// <summary>
/// Summary description for  addressDAO
/// </summary>
public class AddressDAO : DAO_Address_Interface
{
    private ModelDataContext ctx;
    public AddressDAO()
	{
        ctx =  new ModelDataContext();//ModelFactory.getModelInstance();
	}



    public bool isFound(string userName, string addressType)
    {

        try
        {
            var obj = (from p in ctx.Addresses
                       where p.userName == @userName && p.addressType ==  @addressType
                       select p).Single();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public AddressDTO find(string userName, string addressType)
    {
        var obj = (from p in ctx.Addresses
                   where p.userName == @userName && p.addressType == @addressType
                   select p).Single();

        AddressDTO add = new AddressDTO();
        add.userName = obj.userName;
        add.addressType = obj.addressType;
        add.unitNumber = obj.unitNumber;
        add.street = obj.street;
        add.suburb = obj.suburb;
        add.town = obj.town;
        add.province = obj.province;
        add.country = obj.country;
        return add;
    }

    public bool removeByUserId(string userName, string addressType)
    {
        try
        {
            var obj = (from p in ctx.Addresses
                       where p.userName == @userName && p.addressType == @addressType
                       select p).Single();

            Address accObj = (Address)obj;

            ctx.Addresses.DeleteOnSubmit(accObj);
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

    public List<AddressDTO> findAll()
    {
        var objs = (from p in ctx.Addresses
                    select p);
        AddressDTO add = null;
        List<AddressDTO> addList = new List<AddressDTO>();
        foreach (Address obj in objs)
        {
            add = new AddressDTO();
            add.userName = obj.userName;
            add.addressType = obj.addressType;
            add.unitNumber = obj.unitNumber;
            add.street = obj.street;
            add.suburb = obj.suburb;
            add.town = obj.town;
            add.province = obj.province;
            add.country = obj.country;

            addList.Add(add);
        }
        return addList;
    }

    public bool presist(AddressDTO entity)
    {
        try
        {
            model.Address obj = new Address();
            obj.userName = entity.userName;
            obj.addressType = entity.addressType;
            obj.unitNumber = entity.unitNumber;
            obj.street = entity.street;
            obj.suburb = entity.suburb;
            obj.town = entity.town;
            obj.province = entity.province;
            obj.country = entity.country;

            ctx.Addresses.InsertOnSubmit(obj);
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

    public bool merge(AddressDTO entity)
    {
        try
        {
            var addObj = (from p in ctx.Addresses
                       where p.userName == @entity.userName && p.addressType == @entity.addressType
                       select p).Single();

            model.Address obj = (Address)addObj;

            /*Update*/
            obj.userName = entity.userName;
            obj.addressType = entity.addressType;
            obj.unitNumber = entity.unitNumber;
            obj.street = entity.street;
            obj.suburb = entity.suburb;
            obj.town = entity.town;
            obj.province = entity.province;
            obj.country = entity.country;

            ctx.SubmitChanges();
            return true;
        }
        catch (Exception e)
        {
            model.Log log = new Log();
            log.message = "Address Merge: " + " ["+entity.userName+" , "+entity.addressType+"] " + e.Message;

            ctx.Dispose();
            ctx = new ModelDataContext();
            ctx.SubmitChanges();

            return false;
        }
    }

    public bool remove(AddressDTO entity)
    {
        return this.removeByUserId(entity.userName,entity.addressType);
    }
}