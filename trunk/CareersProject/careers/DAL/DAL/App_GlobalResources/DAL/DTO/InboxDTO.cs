using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for InboxDTO
/// </summary>
public class InboxDTO
{
    public string userName { set; get; }
    public string vacancyNumber { set; get; }
    public DateTime date { set; get; }
    public string unread { set; get; }
    public string message { set; get; }
    public string status { set; get; }

	public InboxDTO()
	{
	}
}