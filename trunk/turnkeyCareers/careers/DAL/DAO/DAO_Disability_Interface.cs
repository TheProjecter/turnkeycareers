using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DAO_Ext_Interface
/// </summary>
public interface DAO_Disability_Interface : DAO_Interface<DisabilityDTO>
{
    bool isFound(string userName, string disabilityType);
    DisabilityDTO find(string userName, string disabilityType);
    bool removeByUserId(string userName, string disabilityType);
}