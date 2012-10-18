using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Vacancy
/// </summary>
public class VacancyDTO
{
    public string vacancyNumber { set; get; }
    public string viewStatus { set; get; }
    public string title { set; get; }
    public string description { set; get; }
    public string department { set; get; }
    public string site { set; get; }
    public DateTime startDate { set; get; }
    public DateTime endDate { set; get; }
    public int viewCount { set; get; }
    public string status { set; get; }
    public string manager { set; get; }
    public string recruiter { set; get; }

	public VacancyDTO()
	{
	}
}