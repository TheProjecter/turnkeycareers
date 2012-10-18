using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DAO_Ext_Interface
/// </summary>
public interface DAO_ContactInfo_Interface : DAO_Interface<ContactInfoDTO>
{
    bool isFound(string userName, string contactType);
    ContactInfoDTO find(string userName, string contactType);
    bool removeByUserId(string userName, string contactType);
}