using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmploymentDTO
/// </summary>
public class EmploymentDTO
{
    public string userName { set; get; }
    public string title { set; get; }
    public string company { set; get; }
    public string industry { set; get; }
    public string town { set; get; }
    public string province { set; get; }
    public string country { set; get; }
    public string empType { set; get; }
    public string currentEmployer { set; get; }
    public double gross { set; get; }
    public DateTime startDate { set; get; }
    public DateTime endDate { set; get; }
    public string responsibilities { set; get; }

	public EmploymentDTO()
	{
	}
}