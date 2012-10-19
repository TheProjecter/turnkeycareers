using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DAO_Ext_Interface
/// </summary>
public interface DAO_Address_Interface : DAO_Interface<AddressDTO>
{
    bool isFound(string userName, string addressType);
    AddressDTO find(string userName, string addressType);
    bool removeByUserId(string userName, string addressType);
}