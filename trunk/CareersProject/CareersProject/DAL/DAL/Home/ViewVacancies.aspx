<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CareersMain.Master" CodeBehind="ViewVacancies.aspx.cs" Inherits="careers.ViewVacancies" %>

<asp:Content ID="body" ContentPlaceHolderID="Content" runat="server">
    <h1>View Vacancy</h1>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <ContentTemplate>
<asp:DropDownList runat="server" ID="dropDownList" 
        onselectedindexchanged="dropDownList_SelectedIndexChanged" AutoPostBack="true" >
    <asp:ListItem>All Vacancies</asp:ListItem>
    <asp:ListItem>Department</asp:ListItem>

</asp:DropDownList>
<br />
<asp:DropDownList runat="server" ID="deparments" Visible="false">
    <asp:ListItem>Information Services</asp:ListItem>
    <asp:ListItem>Finance</asp:ListItem>
    <asp:ListItem>Corporate Affairs</asp:ListItem>
    <asp:ListItem>Engineering</asp:ListItem>

</asp:DropDownList>
<br />
    <asp:Button ID="Button1" runat="server" Text="Search" onclick="Display" />
   
<br />
    <asp:Repeater ID="vacRepeater" runat="server" 
        onitemcommand="vacRepeater_ItemCommand">
        <%--  vacancy.vacancyNumber = objs.vacancyNumber;
                        vacancy.vacancyNumber = objs.title;
                        vacancy.vacancyNumber = objs.manager;
                        vacancy.endDate = objs.endDate;
                        vacancy.viewStatus = objs.description;--%>
         <ItemTemplate>
         <tr>
            <td class="repeater">
             <b>Vacancy No:</b>
            </td>
            <td>
                <%# DataBinder.Eval(Container.DataItem, "vacancyNumber") %>
            </td>
         </tr>
         <tr>
             <td class="repeater">
                <div><b>Title:</b></div>
            </td>
            <td>
              <div> <%# DataBinder.Eval(Container.DataItem, "title") %> </div>
            </td>
         </tr>
         <tr>
            <td class="repeater">
                <b> Manager:</b>
            </td>
             <td>
            <div><%# DataBinder.Eval(Container.DataItem, "manager") %> </div>
            </td>
         </tr>
         <tr>
            <td class="repeater">
              <b>End Date:</b>
            </td>
         <td>
               <div>  <%# DataBinder.Eval(Container.DataItem, "endDate") 
                  
                  %> </div>
         </td></tr>
         <%-- <div></div>
          <div></div>
          <div> </div>
          <div> 
           </div>--%>
           <tr>
                  <td>
                    <div>
                        <asp:LinkButton ID="LinkButton1" CommandName=<%# Eval("vacancyNumber")%> runat="server">Apply</asp:LinkButton>
                      <!--<asp:Button ID="btnApply" CommandName=<%# Eval("vacancyNumber")%> runat="server" Text="Apply" /> -->
                      </div>
                </td>
           </tr>
           <br></br>
                </ItemTemplate>
    </asp:Repeater>
     </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="dropDownList" 
                EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
