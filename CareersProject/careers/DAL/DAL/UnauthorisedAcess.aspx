<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnauthorisedAcess.aspx.cs" Inherits="DAL.UnauthorisedAcess" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Unauthorized Access</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h2>Unauthorized Access</h2>
 <p>
 You have attempted to access a page that you are not authorized to view.
 </p>
 <p>
 If you have any questions, please contact the site administrator.
 </p>
        <br />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Home" />
    </div>
    </form>
</body>
</html>
