using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserDTO
/// </summary>
public class UserDTO
{
    public string id { set; get; }
    public string userName { set; get; }
    public string fullName { set; get; }
    public string nickName { set; get; }
    public string surname { set; get; }
    public string gender { set; get; }
    public string race { set; get; }
    public bool disabled { set; get; }
    public bool citizenship { set; get; }
    public string idType { set; get; }
    public bool license { set; get; }
    public bool basicEducation { set; get; }
    public bool higherEducation { set; get; }
    public bool language { set; get; }
    public bool residentialAddress { set; get; }
    public bool postalAddress { set; get; }
    public bool employed { set; get; }
    public bool employmentHistory { set; get; }

	public UserDTO()
	{
	}
}