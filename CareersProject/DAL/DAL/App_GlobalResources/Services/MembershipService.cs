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


    public class MembershipService: System.Web.UI.Control
    {
        public string setUserPassword(string userName)
        {
            MembershipUser mu = Membership.Providers["CareersMembershipProviderAdmin"].GetUser(userName, false);
            string newPassword =  mu.ResetPassword();
            if (sendPwdRstMail(mu.Email, mu.UserName, newPassword)== 4 )
                return "Unable to send e-mail while off-line, please contact the administrator or retry.";
            else
                return "The user's password has been reset successfully and sent via e-mail.";
        }

        public string unblockAccount(string userName)
        {
            MembershipUser mu = Membership.Providers["CareersMembershipProviderAdmin"].GetUser(userName, false);
            bool flag = mu.UnlockUser();
            if (flag)
                return "Account unlocked.";
            else
                return "Unable to unlock Account.";
        }

        public bool isAccountBlocked(string userName)
        {
            MembershipUser mu = Membership.Providers["CareersMembershipProviderAdmin"].GetUser(userName, false);
            bool flag = mu.IsLockedOut;
            return flag;
        }

        public int sendMail(string destinationAddress, string msgBody)
        {
            int flag = 5;// E-mail successfully sent
            try
            {
                //-------------------------------
                MailMessage mail = new MailMessage();
                //from address
                mail.From = new System.Net.Mail.MailAddress("turnkeycareers@gmail.com"); //Dummy Address
                mail.To.Add(new MailAddress(destinationAddress));
                mail.IsBodyHtml = true;
                mail.Body = msgBody;
                SmtpClient smtp = new SmtpClient();

                smtp.Send(mail);
                //-------------------------------
            }
            catch (Exception)
            {
                flag = 4; //Unable to send E-mail - contact administrator
                return flag;
            }
            return flag;
        }

        private int sendPwdRstMail(string destinationAddress, string user, string password)
        {
            int flag = 5;// E-mail successfully sent
            try
            {
                ListDictionary replacements = new ListDictionary();
                replacements.Add("<%UserName%>", user);
                replacements.Add("<%Password%>", password);

                MailDefinition mailDef = new MailDefinition();
                mailDef.IsBodyHtml = true;

                //location of the mail template
                mailDef.BodyFileName = "~/App_GlobalResources/Security/EmailTemplates/resetAccountPasswordByAdmin.html";
                mailDef.Subject = "Account Password Reset By Administrator";
                mailDef.From = "turnkeycareers@gmail.com";
                mailDef.Priority = MailPriority.High;
 
                //-------------------------------
                MailMessage mail = mailDef.CreateMailMessage(destinationAddress, replacements,this);
                //from address
                mail.From = new System.Net.Mail.MailAddress("turnkeycareers@gmail.com"); //Dummy Address
                SmtpClient smtp = new SmtpClient();

                smtp.Send(mail);
                //-------------------------------
            }
            catch (Exception)
            {
                flag = 4; //Unable to send E-mail - contact administrator
                return flag;
            }
            finally
                {
                }
            return flag;
        }
    }
