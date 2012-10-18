using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace DAL
{
    public partial class CreateUserAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void CreateUserWizard1_SendMailError(object sender, SendMailErrorEventArgs e)
        {
            Server.Transfer("Default.aspx"); // Change to error page
        }

        protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
        {
            // Determine the currently logged on user's UserId
            //MembershipUser currentUser = Membership.GetUser();
            //Guid currentUserId = (Guid)currentUser.ProviderUserKey;

            //Create user in Account table
            DAO_Account_Interface acc_ctx = new AccountDAO();
            AccountDTO newAccount = new AccountDTO();

            newAccount.userName = CreateUserWizard1.UserName;
            newAccount.password = "n/a";
            newAccount.status = "active";
            newAccount.accountType = "user";
            acc_ctx.presist(newAccount);

            //Add User Email to COntact Info
            DAO_ContactInfo_Interface info_ctx = new ContactInfoDAO();
            ContactInfoDTO mail_info = new ContactInfoDTO();
            mail_info.userName = newAccount.userName;
            mail_info.contactType = "e-mail";
            mail_info.data = CreateUserWizard1.Email;
            info_ctx.presist(mail_info);

            //Add User information to User Table
            DAO_User_Interface user_ctx = new UserDAO();
            UserDTO user_info = new UserDTO();
            user_info.userName = newAccount.userName;
            user_info.id = txtID.Text;
            user_info.fullName = txtName.Text;
            user_info.surname = txtSurname.Text;
            user_info.nickName = txtNickname.Text;
            user_info.idType = RadioIdType.SelectedValue;
            user_info.race = RadioRace.SelectedValue;
            user_info.gender = RadioGender.SelectedValue;
            user_ctx.presist(user_info);
        }
  

        protected void Button1_Click(object sender, EventArgs e)
        {
            accMultiPage.SetActiveView(View2);
        }
    }
}