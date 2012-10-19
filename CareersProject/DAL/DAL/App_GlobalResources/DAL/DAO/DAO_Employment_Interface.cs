using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DAO_Ext_Interface
/// </summary>
public interface DAO_Employment_Interface : DAO_Interface<EmploymentDTO>
{
    bool isFound(string userName, DateTime startDate);
    EmploymentDTO find(string userName, DateTime startDate);
    bool removeByUserId(string userName, DateTime startDate);
}