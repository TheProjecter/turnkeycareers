<%@ Page Title="" Language="C#" MasterPageFile="~/CareersMain.Master" AutoEventWireup="true" CodeBehind="InboxMessage.aspx.cs" Inherits="DAL.Inbox.InboxMessage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <div>
        <h1>User Inbox</h1>
        <asp:Repeater ID="rpt" runat="server" onitemcommand="rpt_ItemCommand">
            <HeaderTemplate>
                
                <table style="background-color:#C5C5C5; border-color:White">
                    <tr>
                        <td style="width:100px"></td>
                        <td style="width:100px">Username</td>
                        <td style="width:100px">Vacancy Number</td>
                        <td style="width:100px">Status</td>
                    </tr>                
                </table>
            </HeaderTemplate>
            <ItemTemplate>
            <div style="background-color:rgb(181,230,29); margin:3px; ">
                <table>
                    <tr>
                        <td style="width:100px">
                            <asp:LinkButton ID="lbShow" CommandName="username" CommandArgument=<%# Eval("vacancyNumber")%> runat="server">Show</asp:LinkButton>
                        </td>
                        <td style="width:100px">
                            <asp:Label ID="username" runat="server" Text=<%# Eval("username")%>></asp:Label>
                        </td>                
                        <td style="width:100px">
                            <asp:Label ID="vacancyNumber" runat="server" Text=<%# Eval("vacancyNumber")%>></asp:Label>
                        </td>
                        <td style="width:100px">
                            <asp:Label ID="status" runat="server" Text=<%# Eval("status")%>></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
                
            </ItemTemplate>
                        
            <SeparatorTemplate>
            </SeparatorTemplate>

        </asp:Repeater>
    </div>


</asp:Content>
