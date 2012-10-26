<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Disability.aspx.cs" Inherits="careers.PRESENTATION.Disability.Disability" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="disabilityForm" runat="server">
        <div>
        <asp:Repeater ID="rptDisability" runat="server" 
            onitemcommand="rptDisability_ItemCommand">
            <ItemTemplate>
                <asp:LinkButton Text=<%# Eval("disabilityType")%> ID="lbDisability" 
                                CommandName="disabilityType" CommandArgument=<%# Eval("disabilityType")%> runat="server" PostBackUrl="~/PRESENTATION/Disability/Disability.aspx"></asp:LinkButton>
            </ItemTemplate>
            <SeparatorTemplate>
                <br />
            </SeparatorTemplate>

        </asp:Repeater>
        <br />
        <asp:LinkButton ID="lbtnNew" runat="server" onclick="lbtnNew_Click" 
            PostBackUrl="~/PRESENTATION/Disability/Disability.aspx" >New Address</asp:LinkButton>
    </div>
    <hr />
    <div>
        <asp:HiddenField ID="hfUsername" runat="server" />
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbDisabilityType" runat="server" Text="Disability Type: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDisabilityType" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbDisabilityTypeError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbDescription" runat="server" Text="Description: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbDescriptionError" runat="server" Text=""></asp:Label>
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
