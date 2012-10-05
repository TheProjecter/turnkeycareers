using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using careers.MODEL;

/// <summary>
/// Summary description for  addressDAO
/// </summary>
public class UserDAO : DAO_User_Interface
{
    private modelDataContext ctx;
    public UserDAO()
	{
        ctx = new modelDataContext();//ModelFactory.getModelInstance();
	}



    public bool isFound(string userName, string id)
    {

        try
        {
            var obj = (from p in ctx.Users
                       where p.userName == @userName && p.id ==  @id
                       select p).Single();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public UserDTO find(string userName, string id)
    {
        var obj = (from p in ctx.Users
                   where p.userName == @userName && p.id == @id
                   select p).Single();

        UserDTO add = new UserDTO();
        add.userName = obj.userName;
        add.id = obj.id;
        add.fullName = obj.fullname;
        add.nickName = obj.nickName;
        add.gender = obj.gender;
        add.race = obj.race;
        add.disabled = obj.disabled;
        add.citizenship = obj.citizenship;
        add.idType = obj.idType;
        add.license = obj.license;
        add.basicEducation = obj.basicEducation;
        add.higherEducation = obj.higherEducaton;
        add.language = obj.language;
        add.residentialAddress = obj.residentialAddress;
        add.postalAddress = obj.postalAddress;
        add.employed = obj.employed;
        add.employmentHistory = obj.employmentHistory;

        return add;
    }

    public bool removeByUserId(string userName, string id)
    {
        try
        {
            var obj = (from p in ctx.Users
                       where p.userName == @userName && p.id == @id
                       select p).Single();

            User accObj = (User)obj;

            ctx.Users.DeleteOnSubmit(accObj);
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

    public List<UserDTO> findAll()
    {
        var objs = (from p in ctx.Users
                    select p);
        UserDTO add = null;
        List<UserDTO> addList = new List<UserDTO>();
        foreach (User obj in objs)
        {
            add = new UserDTO();
            add.userName = obj.userName;
            add.id = obj.id;
            add.fullName = obj.fullname;
            add.nickName = obj.nickName;
            add.gender = obj.gender;
            add.race = obj.race;
            add.disabled = obj.disabled;
            add.citizenship = obj.citizenship;
            add.idType = obj.idType;
            add.license = obj.license;
            add.basicEducation = obj.basicEducation;
            add.higherEducation = obj.higherEducaton;
            add.language = obj.language;
            add.residentialAddress = obj.residentialAddress;
            add.postalAddress = obj.postalAddress;
            add.employed = obj.employed;
            add.employmentHistory = obj.employmentHistory;

            addList.Add(add);
        }
        return addList;
    }

    public bool presist(UserDTO entity)
    {
        try
        {
             User obj = new User();
            obj.userName = entity.userName;
            obj.id = entity.id;
            obj.fullname = entity.fullName;
            obj.nickName = entity.nickName;
            obj.gender = entity.gender;
            obj.race = entity.race;
            obj.disabled = entity.disabled;
            obj.citizenship = entity.citizenship;
            obj.idType = entity.idType;
            obj.license = entity.license;
            obj.basicEducation = entity.basicEducation;
            obj.higherEducaton = entity.higherEducation;
            obj.language = entity.language;
            obj.residentialAddress = entity.residentialAddress;
            obj.postalAddress = entity.postalAddress;
            obj.employed = entity.employed;
            obj.employmentHistory = entity.employmentHistory;

            ctx.Users.InsertOnSubmit(obj);
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

    public bool merge(UserDTO entity)
    {
        try
        {
            var addObj = (from p in ctx.Users
                       where p.userName == @entity.userName && p.id == @entity.id
                       select p).Single();

             User obj = (User)addObj;

            /*Update*/
            obj.userName = entity.userName;
            obj.id = entity.id;
            obj.fullname = entity.fullName;
            obj.nickName = entity.nickName;
            obj.gender = entity.gender;
            obj.race = entity.race;
            obj.disabled = entity.disabled;
            obj.citizenship = entity.citizenship;
            obj.idType = entity.idType;
            obj.license = entity.license;
            obj.basicEducation = entity.basicEducation;
            obj.higherEducaton = entity.higherEducation;
            obj.language = entity.language;
            obj.residentialAddress = entity.residentialAddress;
            obj.postalAddress = entity.postalAddress;
            obj.employed = entity.employed;
            obj.employmentHistory = entity.employmentHistory;

            ctx.SubmitChanges();
            return true;
        }
        catch (Exception e)
        {
            Log log = new Log();
            log.message = "User Merge: " + " ["+entity.userName+" , "+entity.id+"] " + e.Message;
            ctx.SubmitChanges();

            ctx.Dispose();
            ctx = new modelDataContext();
            return false;
        }
    }

    public bool remove(UserDTO entity)
    {
        return this.removeByUserId(entity.userName,entity.id);
    }
}