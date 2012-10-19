using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DAO_Ext_Interface
/// </summary>
public interface DAO_BasicEduSubject_Interface : DAO_Interface<BasicEduSubjectDTO>
{
    bool isFound(string userName, string subjectName);
    BasicEduSubjectDTO find(string userName, string subjectName);
    bool removeByUserId(string userName, string subjectName);
}