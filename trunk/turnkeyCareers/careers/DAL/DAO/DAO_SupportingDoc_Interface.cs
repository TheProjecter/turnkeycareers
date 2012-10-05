using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DAO_Ext_Interface
/// </summary>
public interface DAO_SupportDoc_Interface : DAO_Interface<SupportDocDTO>
{
    bool isFound(string userName, string title);
    SupportDocDTO find(string userName, string title);
    bool removeByUserId(string userName, string title);
}