<%@ Page Title="" Language="C#" MasterPageFile="~/CareersMain.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="DAL.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">


        <asp:Login ID="Login1" runat="server" CreateUserText="Need an account?" 
            CreateUserUrl="~/Account/CreateUserAccount.aspx" DestinationPageUrl="~/Home/Default.aspx" 
            onloginerror="Login1_LoginError" 
            PasswordRecoveryText="Forgot your password?" 
            PasswordRecoveryUrl="~/Account/RetrievePassword.aspx">
            <LayoutTemplate>
                <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                    <tr>
                        <td>
                            <table cellpadding="0">
                                <tr>
                                    <td align="center" colspan="2">
                                    <div class="title">
                                        Log In
                                        </div>
                                        </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                            ControlToValidate="UserName" ErrorMessage="User Name is required." 
                                            ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                            ControlToValidate="Password" ErrorMessage="Password is required." 
                                            ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="color:Red;">
                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" 
                                            ValidationGroup="Login1" />
                                    </td>
                                </tr>
                               
                            </table>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:Login>
                                <table>
                                <tr>    
                                        <td>
                                         <asp:HyperLink ID="CreateUserLink" runat="server" 
                                            NavigateUrl="~/Account/CreateUserAccount.aspx">Need an account?</asp:HyperLink>
                                        </td>
                                        <td>
                                        </td> 
                                        <td>   
                                        <asp:HyperLink ID="PasswordRecoveryLink" runat="server" 
                                            NavigateUrl="~/Account/RetrievePassword.aspx">Forgot your password?</asp:HyperLink>
                                        </td>
                                </tr>
                                </table>
                           

</asp:Content>
