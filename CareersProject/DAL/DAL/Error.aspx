﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="DAL.Error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Error Encountered</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h2>Error Encountered</h2>
 <p>
    The application has encountered an error.
 </p>
 <p>
 Please contact the site administrator.
 </p>
        <br />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Home" />
    </div>
    </form>
</body>
</html>
