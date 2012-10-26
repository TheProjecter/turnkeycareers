<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="careers.PRESENTATION.ContactInformation.Contact" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Repeater ID="rptContact" runat="server" 
            onitemcommand="rptContact_ItemCommand">
            <ItemTemplate>
                <asp:LinkButton Text=<%# Eval("contactType")%> ID="lbContact" 
                                CommandName="contactType" CommandArgument=<%# Eval("contactType")%> runat="server" PostBackUrl="~/PRESENTATION/ContactInformation/Contact.aspx"></asp:LinkButton>
            </ItemTemplate>
            <SeparatorTemplate>
                <br />
            </SeparatorTemplate>

        </asp:Repeater>
        <br />
        <asp:LinkButton ID="lbtnNew" runat="server" onclick="lbtnNew_Click" 
            PostBackUrl="~/PRESENTATION/ContactInformation/Contact.aspx" >New Address</asp:LinkButton>
    </div>
    <hr />
    <div>
        <asp:HiddenField ID="hfUsername" runat="server" />
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbContactType" runat="server" Text="Contact Type: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtContactType" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbContactTypeError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbData" runat="server" Text="Data: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtData" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbDataError" runat="server" Text=""></asp:Label>
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
    </form>
</body>
</html>
