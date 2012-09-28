using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AddressDTO
/// </summary>
public class AddressDTO
{
    public string userName { set; get; }
    public string addressType { set; get; }
    public int unitNumber { set; get; }
    public string street { set; get; }
    public string suburb { set; get; }
    public string town { set; get; }
    public string province { set; get; }
    public string country { set; get; }

	public AddressDTO()
	{
	}
}