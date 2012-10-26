<%@ Page Title="" Language="C#" MasterPageFile="~/Profile/Profile.master" AutoEventWireup="true" CodeBehind="BasicEdu.aspx.cs" Inherits="DAL.Profile.BasicEdu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="profileContent" runat="server">

    <div>
        <asp:Repeater ID="rptBasicEdu" runat="server" 
            onitemcommand="rptBasicEdu_ItemCommand">
            <ItemTemplate>
                <asp:LinkButton Text=<%# Eval("school")%> ID="lbContact" 
                                CommandName="school" CommandArgument=<%# Eval("school")%> runat="server" PostBackUrl="~/Profile/BasicEdu.aspx"></asp:LinkButton>
            </ItemTemplate>
            <SeparatorTemplate>
                <br />
            </SeparatorTemplate>

        </asp:Repeater>
        <br />
        <asp:LinkButton ID="lbtnNew" runat="server" onclick="lbtnNew_Click" 
            PostBackUrl="~/Profile/BasicEdu.aspx" >New Address</asp:LinkButton>
    </div>
    <hr />
    <div>
        <asp:HiddenField ID="hfUsername" runat="server" />
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbSchool" runat="server" Text="School: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSchool" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbSchoolError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbTown" runat="server" Text="Town: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTown" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbTownError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbProvince" runat="server" Text="Province: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtProvince" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbProvinceError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbCountry" runat="server" Text="Country: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbCountryError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbLevelCompleted" runat="server" Text="Level Completed:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtLevelCompleted" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbLevelCompletedError" runat="server" Text=""></asp:Label>
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
