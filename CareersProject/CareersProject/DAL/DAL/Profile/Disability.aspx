<%@ Page Title="" Language="C#" MasterPageFile="~/Profile/Profile.master" AutoEventWireup="true" CodeBehind="Disability.aspx.cs" Inherits="DAL.Profile.Disability" %>
<asp:Content ID="Content1" ContentPlaceHolderID="profileContent" runat="server">

        <div>
        <asp:Repeater ID="rptDisability" runat="server" 
            onitemcommand="rptDisability_ItemCommand">
            <ItemTemplate>
                <asp:LinkButton Text=<%# Eval("disabilityType")%> ID="lbDisability" 
                                CommandName="disabilityType" CommandArgument=<%# Eval("disabilityType")%> runat="server" PostBackUrl="~/Profile/Disability.aspx"></asp:LinkButton>
            </ItemTemplate>
            <SeparatorTemplate>
                <br />
            </SeparatorTemplate>

        </asp:Repeater>
        <br />
        <asp:LinkButton ID="lbtnNew" runat="server" onclick="lbtnNew_Click" 
            PostBackUrl="~/Profile/Disability.aspx" >New Address</asp:LinkButton>
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

</asp:Content>
