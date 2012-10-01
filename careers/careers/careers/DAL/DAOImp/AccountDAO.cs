using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using model;

/// <summary>
/// Summary description for AccountDAO
/// </summary>
public class AccountDAO : DAO_Account_Interface
{
    private ModelDataContext ctx;
	public AccountDAO()
	{
        ctx =  new ModelDataContext();//ModelFactory.getModelInstance();
	}

    public bool isFound(string userName)
    {
        try
        {
            var obj = (from p in ctx.Accounts
                       where p.userName == @userName
                       select p).Single();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public AccountDTO find(string userName)
    {
        var obj = (from p in ctx.Accounts
                   where p.userName == @userName
                   select p).Single();

        AccountDTO acc = new AccountDTO();
        acc.userName = obj.userName;
        acc.password = obj.password;
        acc.status = obj.status;
        acc.accountType = obj.accountType;
        return acc;
    }


    public List<AccountDTO> findAll()
    {
        var objs = (from p in ctx.Accounts 
                   select p);
        AccountDTO acc = null;
        List<AccountDTO> accounts = new List<AccountDTO>();
        foreach(Account obj in objs)
        {
            acc = new AccountDTO();
            acc.userName = obj.userName;
            acc.password = obj.password;
            acc.status = obj.status;
            acc.accountType = obj.accountType;

            accounts.Add(acc);
        }
        return accounts;
    }

    public bool presist(AccountDTO entityDTO)
    {
        try
        {
            model.Account obj = new Account();
            obj.userName = entityDTO.userName;
            obj.password = entityDTO.password;
            obj.status = entityDTO.status;
            obj.accountType = entityDTO.accountType;

            ctx.Accounts.InsertOnSubmit(obj);
            ctx.SubmitChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
   
    public bool merge(AccountDTO entityDTO)
    {
        try
         {
        var obj = (from p in ctx.Accounts
                   where p.userName == @entityDTO.userName
                   select p).Single();

        model.Account accObj = (Account)obj;

        /*Update*/
        accObj.userName = entityDTO.userName;
        accObj.password = entityDTO.password;
        accObj.status = entityDTO.status;
        accObj.accountType = entityDTO.accountType;

        ctx.SubmitChanges();
        return true;
          }
          catch (Exception)
          {
              return false;
          }
    }

    public bool remove(AccountDTO entity)
    {
        return this.removeByUserId(entity.userName);
    }

    public bool removeByUserId(string userName)
    {
        try
        {
            var obj = (from p in ctx.Accounts
                       where p.userName == @userName
                       select p).Single();

            model.Account accObj = (Account)obj;

            ctx.Accounts.DeleteOnSubmit(accObj);
            ctx.SubmitChanges();
            return true;

        }
        catch (Exception)
        {
            return false;
        }
    }

}