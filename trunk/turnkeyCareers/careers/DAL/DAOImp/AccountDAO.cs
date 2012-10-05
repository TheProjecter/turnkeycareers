using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
using careers.MODEL;

/// <summary>
/// Summary description for AccountDAO
/// </summary>
public class AccountDAO : DAO_Account_Interface
{
    private modelDataContext ctx;
	public AccountDAO()
	{
        ctx = new modelDataContext();//ModelFactory.getModelInstance();
	}

    public bool isFound(string userName)
    {
 
            int cnt = (from p in ctx.Accounts
                       where p.userName == @userName
                       select p).Count();
            if (cnt == 1)
                return true;
            else
                return false;
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
            ctx.insertAccount(entityDTO.userName,
                                entityDTO.password,
                                entityDTO.status,
                                entityDTO.accountType);
        }
        catch (Exception)
        {
        }
        return this.isFound(entityDTO.userName);
    }
   
    public void merge(AccountDTO entityDTO)
    {
            ctx.updateAccount(entityDTO.userName,
                                entityDTO.password,
                                entityDTO.status,
                                entityDTO.accountType);

    }

    public bool remove(AccountDTO entity)
    {
        return this.removeByUserId(entity.userName);
    }

    public bool removeByUserId(string userName)
    {
        
        try
        {
            ctx.deleteAccount(userName);
            
        }
        catch (Exception)
        {
           
        }
        return this.isFound(userName);
        
    }



    bool DAO_Interface<AccountDTO>.merge(AccountDTO entity)
    {
        throw new NotImplementedException();
    }
}