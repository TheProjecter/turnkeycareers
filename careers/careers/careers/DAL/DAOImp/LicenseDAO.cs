using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using careers.MODEL;

/// <summary>
/// Summary description for AccountDAO
/// </summary>
public class LicenseDAO : DAO_License_Interface
{
    private modelDataContext ctx;
    public LicenseDAO()
	{
        ctx = new modelDataContext();//ModelFactory.getModelInstance();
	}

    public bool isFound(string userName)
    {
        try
        {
            var obj = (from p in ctx.Licenses
                       where p.userName == @userName
                       select p).Single();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public LicenseDTO find(string userName)
    {
        var obj = (from p in ctx.Licenses
                   where p.userName == @userName
                   select p).Single();

        LicenseDTO acc = new LicenseDTO();
        acc.userName = obj.userName;
        acc.type = obj.type;
        return acc;
    }


    public List<LicenseDTO> findAll()
    {
        var objs = (from p in ctx.Licenses 
                   select p);
        LicenseDTO acc = null;
        List<LicenseDTO> Licenses = new List<LicenseDTO>();
        foreach(License obj in objs)
        {
            acc = new LicenseDTO();
            acc.userName = obj.userName;
            acc.type = obj.type;

            Licenses.Add(acc);
        }
        return Licenses;
    }

    public bool presist(LicenseDTO entityDTO)
    {
        try
        {
            License obj = new License();
            obj.userName = entityDTO.userName;
            obj.type = entityDTO.type;

            ctx.Licenses.InsertOnSubmit(obj);
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
   
    public bool merge(LicenseDTO entityDTO)
    {
        try
         {
        var obj = (from p in ctx.Licenses
                   where p.userName == @entityDTO.userName
                   select p).Single();

        License accObj = (License)obj;

        /*Update*/
        accObj.userName = entityDTO.userName;
        accObj.type = entityDTO.type;

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

    public bool remove(LicenseDTO entity)
    {
        return this.removeByUserId(entity.userName);
    }

    public bool removeByUserId(string userName)
    {
        try
        {
            var obj = (from p in ctx.Licenses
                       where p.userName == @userName
                       select p).Single();

             License accObj = (License)obj;

            ctx.Licenses.DeleteOnSubmit(accObj);
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

}