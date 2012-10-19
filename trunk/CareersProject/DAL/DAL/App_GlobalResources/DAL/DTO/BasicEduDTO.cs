using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BasicEduDTO
/// </summary>
public class BasicEduDTO
{
    public string userName { set; get; }
    public string school { set; get; }
    public string town { set; get; }
    public string province { set; get; }
    public string country { set; get; }
    public int levelCompleted { set; get; }

	public BasicEduDTO()
	{
	}
}