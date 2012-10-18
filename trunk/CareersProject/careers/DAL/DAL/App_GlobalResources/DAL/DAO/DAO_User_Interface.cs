using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DAO_Ext_Interface
/// </summary>
public interface DAO_User_Interface : DAO_Interface<UserDTO>
{
    bool isFound(string userName);
    UserDTO find(string userName);
    bool removeByUserId(string userName);
}