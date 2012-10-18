using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DAO_Ext_Interface
/// </summary>
public interface DAO_Inbox_Interface : DAO_Interface<InboxDTO>
{
    bool isFound(string userName, string vacancyNumber);
    InboxDTO find(string userName, string vacancyNumber);
    bool removeByUserId(string userName, string vacancyNumber);
}