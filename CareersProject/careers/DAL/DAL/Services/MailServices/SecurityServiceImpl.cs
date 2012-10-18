/*******************************
Developer: WA Pretoruis
Student  : 205093280
*******************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    public interface SecurityServiceImpl
    {
        int sendMail(string destinationAddress, string msgBody);
        int forgotPassword(string userName, string message);
    }
