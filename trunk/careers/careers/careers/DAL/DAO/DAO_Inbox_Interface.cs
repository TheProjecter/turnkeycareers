using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DAO_Ext_Interface
/// </summary>
public interface DAO_Inbox_Interface : DAO_Interface<InboxDTO>
{
    bool isFound(string userName, int messgeId);
    InboxDTO find(string userName, int messgeId);
    bool removeByUserId(string userName, int messgeId);
}