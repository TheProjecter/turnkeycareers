<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Manager/Manager.master" AutoEventWireup="true" CodeBehind="Shortlisted.aspx.cs" Inherits="DAL.Account.Manager.Shortlisted" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AccountContent" runat="server">
    <asp:HiddenField ID="hfUsername" runat="server" />
    <asp:HiddenField ID="hfVacancyNumber" runat="server" />

    <div>
        <asp:Repeater ID="rpt" runat="server" onitemcommand="rpt_ItemCommand">
            <HeaderTemplate>
                
                <table>
                    <tr>
                        <td style="width:100px" ></td>
                        <td style="width:100px">Username</td>
                        <td style="width:100px">Firstname</td>
                        <td style="width:100px">Lastname</td>
                    </tr>                
                </table>
            </HeaderTemplate>
            <ItemTemplate>
            <div style="background-color:#C5C5C5; margin:3px; ">
                <table>
                    <tr>
                        <td style="width:100px">
                            <asp:LinkButton ID="lbSelect" CommandName="username" CommandArgument=<%# Eval("username")%> runat="server">Remove</asp:LinkButton>
                        </td>
                        <td style="width:100px">
                            <asp:Label ID="lbUsername" runat="server" Text=<%# Eval("username")%>></asp:Label>
                        </td>                
                        <td style="width:100px">
                            <asp:Label ID="lbFirstname" runat="server" Text=<%# Eval("fullname")%>></asp:Label>
                        </td>
                        <td style="width:100px">
                            <asp:Label ID="lbSurname" runat="server" Text=<%# Eval("surname")%>></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            </ItemTemplate>
                        
            <SeparatorTemplate>
            </SeparatorTemplate>

        </asp:Repeater>
    </div>

    <hr />

    <div>
        <asp:Repeater ID="rptShortlistedSelect" onitemcommand="rptShortlistedSelect_ItemCommand" runat="server">
            <HeaderTemplate>
                
                <table>
                    <tr>
                        <td style="width:100px" ></td>
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
                            <asp:LinkButton ID="lbSelect" CommandName="username" CommandArgument=<%# Eval("username")%> runat="server">Add</asp:LinkButton>
                        </td>
                        <td style="width:100px">
                            <asp:Label ID="lbUsername" runat="server" Text=<%# Eval("username")%>></asp:Label>
                        </td>                
                        <td style="width:100px">
                            <asp:Label ID="lbFirstname" runat="server" Text=<%# Eval("fullname")%>></asp:Label>
                        </td>
                        <td style="width:100px">
                            <asp:Label ID="lbSurname" runat="server" Text=<%# Eval("surname")%>></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
                
            </ItemTemplate>
                        
            <SeparatorTemplate>
            </SeparatorTemplate>

        </asp:Repeater>
    </div>
    <asp:LinkButton ID="lbShortList" runat="server" onclick="lbShortList_Click">Save Shortlist</asp:LinkButton>


</asp:Content>
