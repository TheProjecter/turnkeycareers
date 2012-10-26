using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    AccountDAO accountDAO = new AccountDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (accountDAO.isFound("griddy"))
            Label1.Text = "YES";
        else
            Label1.Text = "NO";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        List<AccountDTO> accounts = new List<AccountDTO>();
        accounts = accountDAO.findAll();

        string str = "";
        foreach (AccountDTO acc in accounts)
        {
            str = str + " " + acc.userName;
        }

        Label1.Text = str;            
        
    }
}