﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Manager/Manager.master" AutoEventWireup="true" CodeBehind="ViewShortlisted.aspx.cs" Inherits="DAL.Account.Manager.ViewShortlisted" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AccountContent" runat="server">
    <asp:HiddenField ID="hfVacancyNumber" runat="server" />
    <div>
        <asp:Repeater ID="rptShortlistedSelect" runat="server">
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

</asp:Content>
