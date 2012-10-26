using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Restfull
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Membership.ValidateUser("griddy", "777Tron777."))
            {

                Label1.Text = "ok";
            }
            else
                Label1.Text = "auth failed";
        }

        protected void btnEncrypt_Click(object sender, EventArgs e)
        {

            txtCode.Text = AESencryption.EncryptStringAES(txtClearText.Text, txtSecretString.Text);
        }

        protected void btnDecrypt_Click(object sender, EventArgs e)
        {
            txtClearText.Text = AESencryption.DecryptStringAES(txtCode.Text, txtSecretString.Text);
        }



    }
}