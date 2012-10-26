<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Encoder.aspx.cs" Inherits="Restfull.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Secret String:"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="txtSecretString" runat="server" Text="Tp3WasHard"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnDecrypt" runat="server" onclick="btnDecrypt_Click" 
            Text="AES Decrypt" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <asp:Button ID="btnEncrypt" runat="server" onclick="btnEncrypt_Click" 
            Text="AES Encrypt" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
&nbsp;<asp:Label ID="Label2" runat="server" Text="Code"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtCode" runat="server" Width="315px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Text="Clear"></asp:Label>
        <asp:TextBox ID="txtClearText" runat="server" Width="315px"></asp:TextBox>
    
    </div>
    </form>
</body>
</html>
