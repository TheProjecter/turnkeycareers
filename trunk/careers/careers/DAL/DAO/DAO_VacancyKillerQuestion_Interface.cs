using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DAO_Ext_Interface
/// </summary>
public interface DAO_VacancyKillerQuestion_Interface : DAO_Interface<VacancyKillerQuestionDTO>
{
    bool isFound(string vacancyNumber, string question);
    VacancyKillerQuestionDTO find(string vacancyNumber, string question);
    bool removeByUserId(string vacancyNumber, string question);
}