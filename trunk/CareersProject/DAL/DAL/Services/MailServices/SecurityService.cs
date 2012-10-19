/*******************************
Developer: WA Pretoruis
Student  : 205093280
*******************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;

namespace careers.SERVICES
{
    public class mailService :SecurityServiceImpl
    {
        /*
         * Results:
         * 4 Unable to send E-mail - contact administrator
         * 5 E-mail successfully sent
         */
        public int sendMail(string destinationAddress, string msgBody)
        {
            int flag = 5;// E-mail successfully sent
            try
            {
                //-------------------------------
                MailMessage mail = new MailMessage();
                mail.From = new System.Net.Mail.MailAddress("mailgriddy@gmail.com");

                // The important part -- configuring the SMTP client
                SmtpClient smtp = new SmtpClient();
                smtp.Port = 587;   // [1] You can try with 465 also, I always used 587 and got success
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network; // [2] Added this
                smtp.UseDefaultCredentials = false; // [3] Changed this
                smtp.Credentials = new NetworkCredential(mail.From.ToString(), "Gforce232");  //Move to WebCOnfig
                smtp.Host = "smtp.gmail.com";

                //recipient address
                mail.To.Add(new MailAddress(destinationAddress));

                //Formatted mail body
                mail.IsBodyHtml = true;


                // "<HTML><TITLE>Password Reset</TITLE><BODY><p style='background-color:green;'><b>Password Reset</b></p>Your password is : ";
                // st = Server.HtmlEncode(st);

                mail.Body = msgBody;
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


        /*
         * 1 Successfull
         * 2 Invalid User
         * 3 E-mail Address not found
         * 4 Unable to send E-mail - contact administrator
         * 5 E-mail successfully sent
         */
        public int forgotPassword(string userName,string message)
        {
            string newPassword = System.Web.Security.Membership.GeneratePassword(8, 2);
            int flag = 2;//Invalid user

            AccountDAO acc_context = new AccountDAO();
            ContactInfoDAO con_context = new ContactInfoDAO();

            if (acc_context.isFound(userName))
            {
                if (con_context.isFound(userName, "e-mail"))
                {
                    ContactInfoDTO email = con_context.find(userName, "e-mail");
                    AccountDTO account = acc_context.find(userName);
                    account.password = newPassword;
                    acc_context.merge(account);

                    message.Replace("PASSWORD", newPassword);
                    flag = sendMail(email.data, message);
                    

                }
                else
                {
                    flag = 3; //Email Address not found
                }

            }
            return flag;    
    }

    public bool unlockAccount()
    {
        return true;
    }

    /*
- - resetPassword(username) AUTOMATED
- - unlockAccount(username) ADMIN
- - lockAccount(username) AUTOMATED
- - setUserRole(username)
- - requestAccountUnlock(username)
- - setAccountActive()
     * */

    }

}