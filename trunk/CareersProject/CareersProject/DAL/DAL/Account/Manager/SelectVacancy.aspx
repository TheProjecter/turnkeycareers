<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Manager/Manager.master" AutoEventWireup="true" CodeBehind="SelectVacancy.aspx.cs" Inherits="DAL.Account.Manager.SelectVacancy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AccountContent" runat="server">

    <div>
        <asp:Repeater ID="rptShortlistedSelect" runat="server" 
            onitemcommand="rptShortlistedSelect_ItemCommand">
            <HeaderTemplate>
                
                <table>
                    <tr>
                        <td style="width:100px">Username</td>
                        <td style="width:100px">Firstname</td>
                        <td style="width:100px">Lastname</td>
                    </tr>                
                </table>
            </HeaderTemplate>
            <ItemTemplate>
            <div style="background-color:Gray; margin:3px; ">
                <table>
                    <tr>
                        <td style="width:100px">
                            <asp:LinkButton ID="LinkButton1" CommandArgument=<%# Eval("vacancyNumber")%> runat="server">Select</asp:LinkButton>
                        </td>         
                        <td style="width:100px">
                            <asp:Label ID="lbUsername" runat="server" Text=<%# Eval("vacancyNumber")%>></asp:Label>
                        </td>                
                        <td style="width:100px">
                            <asp:Label ID="lbFirstname" runat="server" Text=<%# Eval("Title")%>></asp:Label>
                        </td>
                        <td style="width:100px">
                            <asp:Label ID="lbSurname" runat="server" Text=<%# Eval("manager")%>></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
                
            </ItemTemplate>
                        
            <SeparatorTemplate>
            </SeparatorTemplate>

        </asp:Repeater>
    </div>
    <asp:Label ID="lbFeedback" runat="server" Text=""></asp:Label>
</asp:Content>
