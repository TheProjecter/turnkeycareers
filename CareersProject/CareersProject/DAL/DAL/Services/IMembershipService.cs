using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;
using System.Web.UI.WebControls;
using System.Collections.Specialized;


    public interface IMembershipService
    {
        string setUserPassword(string userName);

        string unblockAccount(string userName);

        bool isAccountBlocked(string userName);

        int sendMail(string destinationAddress, string msgBody);

    }
