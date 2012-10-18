<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Language.aspx.cs" Inherits="careers.PRESENTATION.Language.Language" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="languageForm" runat="server">
    <div>
        <div>
        <asp:Repeater ID="rptLanguage" runat="server" 
            onitemcommand="rptLanguage_ItemCommand">
            <ItemTemplate>
                <asp:LinkButton Text=<%# Eval("languageName")%> ID="lbContact" 
                                CommandName="languageName" CommandArgument=<%# Eval("languageName")%> runat="server" PostBackUrl="~/PRESENTATION/Language/Language.aspx"></asp:LinkButton>
            </ItemTemplate>
            <SeparatorTemplate>
                <br />
            </SeparatorTemplate>

        </asp:Repeater>
        <br />
        <asp:LinkButton ID="lbtnNew" runat="server" onclick="lbtnNew_Click" 
            PostBackUrl="~/PRESENTATION/Language/Language.aspx" >New Address</asp:LinkButton>
    </div>
    <hr />
    <div>
        <asp:HiddenField ID="hfUsername" runat="server" />
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbLanguage" runat="server" Text="Language: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtLanguage" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbLanguageError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbRead" runat="server" Text="Read: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtRead" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbReadError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbWrite" runat="server" Text="Write: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtWrite" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbWriteError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbSpeak" runat="server" Text="Speak:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSpeak" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbSpeakError" runat="server" Text=""></asp:Label>
                </td>
            </tr>

        </table>
            <div>
                <asp:Button ID="btnUpdate" runat="server" Text="Update" 
                    onclick="btnUpdate_Click"  />
                <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" 
                     />
                <asp:Button ID="btnReset" runat="server" Text="Reset" 
                    onclick="btnReset_Click" 
                     />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" 
                    onclick="btnDelete_Click" 
                    />
            </div>
        <asp:Label ID="lbFeedback" runat="server" Text=""></asp:Label>

    </div>
    </div>
    </form>
</body>
</html>
