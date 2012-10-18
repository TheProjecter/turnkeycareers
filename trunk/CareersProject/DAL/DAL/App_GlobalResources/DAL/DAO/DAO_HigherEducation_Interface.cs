using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DAO_Ext_Interface
/// </summary>
public interface DAO_HigherEducation_Interface : DAO_Interface<HigherEducationDTO>
{
    bool isFound(string userName, string major);
    HigherEducationDTO find(string userName, string major);
    bool removeByUserId(string userName, string major);
}