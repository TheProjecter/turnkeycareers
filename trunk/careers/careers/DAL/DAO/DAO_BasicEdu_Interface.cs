using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DAO_Ext_Interface
/// </summary>
public interface DAO_BasicEdu_Interface : DAO_Interface<BasicEduDTO>
{
    bool isFound(string userName);
    BasicEduDTO find(string userName);
    bool removeByUserId(string username);
}