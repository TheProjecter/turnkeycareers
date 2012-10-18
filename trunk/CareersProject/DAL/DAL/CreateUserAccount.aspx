<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateUserAccount.aspx.cs" Inherits="DAL.CreateUserAccount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    
        <br />
        <br />
        <asp:MultiView ID="accMultiPage" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
            <!--Page 1 -->
                <h1>Personal Information</h1>
                <br />
                <asp:Label ID="Label1" runat="server" Text="Fullname"></asp:Label>

                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator ID="UserNameRequired0" runat="server" 
                    ControlToValidate="txtName" ErrorMessage="Name is required." 
                    ToolTip="User Name is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Surname"></asp:Label>
                <asp:TextBox ID="txtSurname" runat="server"></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator ID="UserNameRequired1" runat="server" 
                    ControlToValidate="txtSurname" ErrorMessage="surname is required." 
                    ToolTip="User Name is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="Label3" runat="server" Text="Nickname"></asp:Label>
                <asp:TextBox ID="txtNickname" runat="server"></asp:TextBox>

                &nbsp;<asp:RequiredFieldValidator ID="UserNameRequired2" runat="server" 
                    ControlToValidate="txtNickname" ErrorMessage="Nickname is required." 
                    ToolTip="User Name is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>

                <br />
                <asp:Label ID="Label4" runat="server" Text="ID"></asp:Label>
                <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator ID="UserNameRequired3" runat="server" 
                    ControlToValidate="txtID" ErrorMessage="ID is required." 
                    ToolTip="User Name is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="Label7" runat="server" Text="ID Type"></asp:Label>
                <asp:RadioButtonList ID="RadioIdType" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True">South African ID</asp:ListItem>
                    <asp:ListItem>Passport</asp:ListItem>
                </asp:RadioButtonList>
                <br />
                <asp:Label ID="Label5" runat="server" Text="Gender"></asp:Label>
                <asp:RadioButtonList ID="RadioGender" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True">Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:RadioButtonList>
                <asp:Label ID="Label6" runat="server" Text="Race"></asp:Label>
                <asp:RadioButtonList ID="RadioRace" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True">Black</asp:ListItem>
                    <asp:ListItem>Bown</asp:ListItem>
                    <asp:ListItem>Indian</asp:ListItem>
                    <asp:ListItem>White</asp:ListItem>
                    <asp:ListItem>Asian</asp:ListItem>
                </asp:RadioButtonList>
                <br />
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Next" />
                <br />

            </asp:View>
            <asp:View ID="View2" runat="server">
                <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" 
                    AutoGeneratePassword="True" 
                    CompleteSuccessText="Your account has been created! Your password has been e-mailed to you." 
                    ContinueDestinationPageUrl="~/login.aspx" LoginCreatedUser="False" 
                    oncreateduser="CreateUserWizard1_CreatedUser" 
                    onsendmailerror="CreateUserWizard1_SendMailError">
                    <MailDefinition BodyFileName="~/App_GlobalResources/Security/EmailTemplates/createAccount.html" 
                        From="TurnKeyCareers@gmail.com" IsBodyHtml="True" Subject="New Account Created">
                    </MailDefinition>
                    <WizardSteps>
                  
                        <asp:CreateUserWizardStep runat="server">
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <td align="center" colspan="2">
                                            Sign Up for Your New Account</td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                                ControlToValidate="UserName" ErrorMessage="User Name is required." 
                                                ToolTip="User Name is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="EmailRequired" runat="server" 
                                                ControlToValidate="Email" ErrorMessage="E-mail is required." 
                                                ToolTip="E-mail is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">Security Question:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Question" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" 
                                                ControlToValidate="Question" ErrorMessage="Security question is required." 
                                                ToolTip="Security question is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Security Answer:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" 
                                                ControlToValidate="Answer" ErrorMessage="Security answer is required." 
                                                ToolTip="Security answer is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                        
                                    <tr>
                                        <td align="center" colspan="2" style="color:Red;">
                                            <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <CustomNavigationTemplate>
                                <table border="0" cellspacing="5" style="width:100%;height:100%;">
                                    <tr align="right">
                                        <td align="right" colspan="0">
                                            <asp:Button ID="StepNextButton" runat="server" CommandName="MoveNext" 
                                                Text="Create User" ValidationGroup="CreateUserWizard1" />
                                        </td>
                                    </tr>
                                </table>
                            </CustomNavigationTemplate>
                        </asp:CreateUserWizardStep>
                        <asp:CompleteWizardStep runat="server" />
                    </WizardSteps>
                    <FinishNavigationTemplate>
                        <asp:Button ID="FinishPreviousButton" runat="server" CausesValidation="False" 
                            CommandName="MovePrevious" Text="Previous" />
                        <asp:Button ID="FinishButton" runat="server" CommandName="MoveComplete" 
                            Text="Finish" />
                    </FinishNavigationTemplate>
                    <StartNavigationTemplate>
                        <asp:Button ID="StartNextButton" runat="server" CommandName="MoveNext" 
                    Text="Next" />
                    </StartNavigationTemplate>
                    <StepNavigationTemplate>
                        <asp:Button ID="StepPreviousButton" runat="server" CausesValidation="False" 
                            CommandName="MovePrevious" Text="Previous" />
                        <asp:Button ID="StepNextButton0" runat="server" CommandName="MoveNext" 
                            Text="Next" />
                    </StepNavigationTemplate>
                </asp:CreateUserWizard>
            </asp:View>
        </asp:MultiView>
    
    </div>
    </form>
</body>
</html>
