using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AccountDTO
/// </summary>
public class AccountDTO
{
    public string userName { set; get; }
    public string password { set; get; }
    public string status { set; get; }
    public string accountType { set; get; }

	public AccountDTO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}