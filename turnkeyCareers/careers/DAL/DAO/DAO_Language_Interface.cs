using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DAO_Ext_Interface
/// </summary>
public interface DAO_Language_Interface : DAO_Interface<LanguageDTO>
{
    bool isFound(string userName, string language);
    LanguageDTO find(string userName, string language);
    bool removeByUserId(string userName, string language);
}