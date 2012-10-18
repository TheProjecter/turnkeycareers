<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="DAL.LogOnUserAccount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <asp:Login ID="Login1" runat="server" CreateUserText="Need an account?" 
            CreateUserUrl="~/CreateUserAccount.aspx" DestinationPageUrl="~/Default.aspx" 
            onloginerror="Login1_LoginError" 
            PasswordRecoveryText="Forgot your password?" 
            PasswordRecoveryUrl="~/RetrievePassword.aspx">
        </asp:Login>
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
