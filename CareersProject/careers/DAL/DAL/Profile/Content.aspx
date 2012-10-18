<%@ Page Title="" Language="C#" MasterPageFile="~/Profile/Profile.master" AutoEventWireup="true" CodeBehind="Content.aspx.cs" Inherits="DAL.Profile.Content" %>
<asp:Content ID="Content1" ContentPlaceHolderID="profileContent" runat="server">

    <div>
        <asp:Repeater ID="rptContact" runat="server" 
            onitemcommand="rptContact_ItemCommand">
            <ItemTemplate>
                <asp:LinkButton Text=<%# Eval("contactType")%> ID="lbContact" 
                                CommandName="contactType" CommandArgument=<%# Eval("contactType")%> runat="server" PostBackUrl="~/Profile/Content.aspx"></asp:LinkButton>
            </ItemTemplate>
            <SeparatorTemplate>
                <br />
            </SeparatorTemplate>

        </asp:Repeater>
        <br />
        <asp:LinkButton ID="lbtnNew" runat="server" onclick="lbtnNew_Click" 
            PostBackUrl="~/Profile/Content.aspx" >New Address</asp:LinkButton>
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

</asp:Content>
