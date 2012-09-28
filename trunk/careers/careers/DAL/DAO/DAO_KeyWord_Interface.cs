using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DAO_Ext_Interface
/// </summary>
public interface DAO_KeyWord_Interface : DAO_Interface<KeyWordDTO>
{
    bool isFound(string vacancyNumber, string keyWord);
    KeyWordDTO find(string vacancyNumber, string keyWord);
    bool removeByUserId(string vacancyNumber, string keyWord);
}