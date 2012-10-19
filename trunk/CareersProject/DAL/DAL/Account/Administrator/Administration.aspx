<%@ Page Title="" Language="C#" MasterPageFile="~/Profile/ProfileMain.Master" AutoEventWireup="true" CodeBehind="Administration.aspx.cs" Inherits="DAL.Profile.Administration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <div style="margin-left: 40px">
    
        <asp:Label ID="Label1" runat="server" Text="Enter username to administrate"></asp:Label>
        &nbsp;<asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        &nbsp;<asp:Label ID="txtStatus" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnValidUser" runat="server" onclick="Button2_Click" Text="Validate User" />
        &nbsp;<asp:Button ID="btnDelUser" runat="server" onclick="Button1_Click" 
            Text="Delete User" CausesValidation="False" Enabled="False" /> &nbsp;<asp:Button ID="btnResetPassword" runat="server" Enabled="False" 
            onclick="Button3_Click" Text="Reset Password" />&nbsp;<asp:Button ID="btnUnblock" runat="server" Enabled="False" 
            onclick="Button3_Click1" Text="Unblock Account" />
        <br />
        <br />
    
    </div>
    <asp:Label ID="txtNewPassword" runat="server"></asp:Label>
    <br />
    <asp:Label ID="txt" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;<br />
    <br />
&nbsp;<asp:Button ID="Button1" runat="server" onclick="Button1_Click1" 
        Text="Reset" />
    <br />

</asp:Content>
