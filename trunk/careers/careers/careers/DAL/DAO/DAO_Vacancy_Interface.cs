using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DAO_Ext_Interface
/// </summary>
public interface DAO_Vacancy_Interface : DAO_Interface<VacancyDTO>
{
    bool isFound(string vacancyNumber);
    VacancyDTO find(string vacancyNumber);
    bool removeByUserId(string vacancyNumber);
}