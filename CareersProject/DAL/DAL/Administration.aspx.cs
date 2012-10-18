using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace DAL
{
    public partial class Administration : System.Web.UI.Page
    {
        MembershipService service = new MembershipService();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Membership.DeleteUser(txtUserName.Text);
            btnDelUser.Enabled = false;
            txtStatus.Text = txtUserName.Text + " succesfully deleted!";
            txtUserName.Text = "";
            txtStatus.Enabled = true;
            txtUserName.Enabled = true;
            btnDelUser.Enabled = false;
            btnResetPassword.Enabled = false;
            btnValidUser.Enabled = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DAO_Account_Interface user_ctx = new AccountDAO();
            if (user_ctx.isFound(txtUserName.Text))
            {
                btnValidUser.Enabled = false;
                btnDelUser.Enabled = true;
                btnResetPassword.Enabled = true;
                txtStatus.Text = "";
                txtUserName.Enabled = false;

                if (service.isAccountBlocked(txtUserName.Text) )
                    btnUnblock.Enabled = true;
                else
                    btnUnblock.Enabled = false;
                
            }
            else
            {
                btnValidUser.Enabled = true;
                btnResetPassword.Enabled = false;
                btnDelUser.Enabled = false;
                btnResetPassword.Enabled = false;
                txtStatus.Text = "Invalid User Name Entered!";
                txtUserName.Enabled = true;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            
            txtNewPassword.Text = service.setUserPassword(txtUserName.Text);
            btnValidUser.Enabled = true;
            btnDelUser.Enabled = false;
            btnResetPassword.Enabled = false;
            txtUserName.Enabled = true;
        }

        protected void Button3_Click1(object sender, EventArgs e)
        {
            txt.Text = service.unblockAccount(txtUserName.Text);
            btnUnblock.Enabled = false;
            btnValidUser.Enabled = true;
            btnDelUser.Enabled = false;
            btnResetPassword.Enabled = false;
            txtUserName.Enabled = true;
        }
    }
}