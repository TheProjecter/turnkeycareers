<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInbox.aspx.cs" Inherits="careers.PRESENTATION.Inbox.User.UserInbox" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Repeater ID="rptUserInbox" runat="server">
            <ItemTemplate><asp:LinkButton ID="LinkButton1" runat="server">
                <div style="background-color:pink; margin-bottom:20px;">
                    <asp:Label ID="lbVacancyLiteral" runat="server" Text="Vacancy: "></asp:Label>
                    <asp:Label ID="lbTitle" runat="server" Text=<%# Eval("title")%>></asp:Label>
                    <br />
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lbStartDateLiteral" runat="server" Text="Start Date: "></asp:Label>
                                <asp:Label ID="lbStartDate" runat="server" Text=<%# Eval("startDate")%>></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbSatusLiteral" runat="server" Text="Status: "></asp:Label>
                                <asp:Label ID="lbSatus" runat="server" Text=<%# Eval("status")%>></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbEndDateLiteral" runat="server" Text="End Date: "></asp:Label>
                                <asp:Label ID="lbEndDate" runat="server" Text=<%# Eval("endDate")%>></asp:Label>
                            </td>
                        </tr>
                    </table>
                    </asp:LinkButton>
                </div>            
            </ItemTemplate>
            <SeparatorTemplate>
                <br />
            </SeparatorTemplate>

        </asp:Repeater>




    </div>
    </form>
</body>
</html>
