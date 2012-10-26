using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DAO_Ext_Interface
/// </summary>
public interface DAO_License_Interface : DAO_Interface<LicenseDTO>
{
    bool isFound(string userName,string type);
    LicenseDTO find(string userName, string type);
    bool removeByUserId(string username, string type);
}