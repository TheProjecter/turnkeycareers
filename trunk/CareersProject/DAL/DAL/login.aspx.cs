using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace DAL
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_LoginError(object sender, EventArgs e)
        {

            // Determine why the user could not login...
            Login1.FailureText = "Your login attempt was not successful. Please try again.";

            // Does there exist a User account for this user?
            MembershipUser usrInfo = Membership.GetUser(Login1.UserName);
            if (usrInfo != null)
            {
                // Is this user locked out?
                if (usrInfo.IsLockedOut)
                {
                    Login1.FailureText = "Your account has been locked out because of too many invalid login attempts. Please contact the administrator to have your account unlocked.";
                }
                else if (!usrInfo.IsApproved)
                {
                    Login1.FailureText = "Your account has not yet been approved. You cannot login until an administrator has approved your account.";
                }
            }

        }
    }

    public partial class LogOnUserAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        
    }
}