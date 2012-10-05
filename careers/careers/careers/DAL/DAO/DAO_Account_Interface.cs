using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DAO_Ext_Interface
/// </summary>
public interface DAO_Account_Interface : DAO_Interface<AccountDTO>
{
    bool isFound(string userName);
    AccountDTO find(string userName);
    bool removeByUserId(string username);
}