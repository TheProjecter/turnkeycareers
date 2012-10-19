<%@ Page Title="" Language="C#" MasterPageFile="~/CareersMain.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="DAL.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">


        <asp:Login ID="Login1" runat="server" CreateUserText="Need an account?" 
            CreateUserUrl="~/Account/CreateUserAccount.aspx" DestinationPageUrl="~/Home/Default.aspx" 
            onloginerror="Login1_LoginError" 
            PasswordRecoveryText="Forgot your password?" 
            PasswordRecoveryUrl="~/Account/RetrievePassword.aspx">
        </asp:Login>

</asp:Content>
