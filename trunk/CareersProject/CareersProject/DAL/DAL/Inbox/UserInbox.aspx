<%@ Page Title="" Language="C#" MasterPageFile="~/CareersMain.Master" AutoEventWireup="true" CodeBehind="UserInbox.aspx.cs" Inherits="DAL.Inbox.UserInbox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <div style="height:50px; width:100%">
        <h1>User Inbox</h1>
    </div>
    <asp:HiddenField ID="hfUsername" runat="server" />
    <asp:HiddenField ID="hfVacancyNumber" runat="server" />

    <div >
        <div style="background-color:#C5C5C5; float:left; width:190px; height:100%; padding:5px;">
            <h2>Messages</h2>
            
        <asp:Repeater ID="rptInbox" runat="server" 
            onitemcommand="rptInbox_ItemCommand">
            <ItemTemplate>
                <div style="background-color:RGB(120, 140,220); float:left; width:190px; margin-top:5px;">
                    <asp:Label ID="Label1" runat="server" Text="Status: "></asp:Label>
                    <asp:Label ID="lbStatus" runat="server" Text=<%# Eval("status")%>></asp:Label>
                    <asp:Label ID="lbDate" runat="server" Text=<%# Eval("date")%>></asp:Label>
                    <asp:LinkButton Text="Show Message" ID="lbContact" 
                                CommandName="status" CommandArgument=<%# Eval("status")%> runat="server"></asp:LinkButton>
                </div>
            </ItemTemplate>
            <SeparatorTemplate>
                <br />
            </SeparatorTemplate>

        </asp:Repeater>


        </div>
        <div style="position:relative; height:500px; margin-left:200px;">
            <asp:TextBox ID="txtMessage" runat="server" Height="98%" Width="98%" 
                TextMode="MultiLine" Font-Names="Arail" Font-Size="16pt"></asp:TextBox>



            
        </div>
    </div>


</asp:Content>
