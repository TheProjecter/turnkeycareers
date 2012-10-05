using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using careers.MODEL;

/// <summary>
/// Summary description for  addressDAO
/// </summary>
public class AddressDAO : DAO_Address_Interface
{
    private modelDataContext ctx;
    public AddressDAO()
	{
        ctx = new modelDataContext();//ModelFactory.getModelInstance();
	}



    public bool isFound(string userName, string addressType)
    {

        
            int cnt = (from p in ctx.Addresses
                       where p.userName == @userName && p.addressType ==  @addressType
                       select p).Count();
            if (cnt == 1)
                return true;
            else
                return false;
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
            ctx.deleteAddress(userName, addressType);

        }
        catch (Exception)
        {

        }
        return this.isFound(userName,addressType);
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
        try{

            ctx.insertAddress(entity.userName, entity.addressType, entity.unitNumber, entity.street, entity.suburb, entity.town, entity.province, entity.country);
        }
        catch (Exception)
        {
        }
        return this.isFound(entity.userName,entity.addressType);
     
    }


    public void merge(AddressDTO entity)
    {
         ctx.updateAddress(entity.userName, entity.addressType, entity.unitNumber, entity.street, entity.suburb, entity.town, entity.province, entity.country);
        
    }

    public bool remove(AddressDTO entity)
    {
        return this.removeByUserId(entity.userName,entity.addressType);
    }


    bool DAO_Interface<AddressDTO>.merge(AddressDTO entity)
    {
        throw new NotImplementedException();
    }
}