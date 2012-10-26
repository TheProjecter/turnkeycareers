using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;


/// <summary>
/// Summary description for AccountDTO
/// </summary>
[DataContract]
public class AccountDTO
{
    [DataMember]
    public string userName { set; get; }
    [DataMember]
    public string password { set; get; }
    [DataMember]
    public string status { set; get; }
    [DataMember]
    public string accountType { set; get; }


	
}