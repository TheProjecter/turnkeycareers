using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SupportDoc
/// </summary>
public class SupportDocDTO
{
    public string title { set; get; }
    public string userName { set; get; }
    public string description { set; get; }
    public byte[] content { set; get; }

	public SupportDocDTO()
	{
	}
}