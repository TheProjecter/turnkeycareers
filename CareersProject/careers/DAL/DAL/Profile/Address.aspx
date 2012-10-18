<%@ Page Title="" Language="C#" MasterPageFile="~/Profile/Profile.master" AutoEventWireup="true" CodeBehind="Address.aspx.cs" Inherits="DAL.Profile.Address" %>
<asp:Content ID="Content1" ContentPlaceHolderID="profileContent" runat="server">
<div>
    <div>
        <asp:Repeater ID="rptAddress" runat="server" 
            onitemcommand="rptAddress_ItemCommand">
            <ItemTemplate>
                <asp:LinkButton Text=<%# Eval("addressType")%> ID="lbContact" 
                                CommandName="addressType" CommandArgument=<%# Eval("addressType")%> runat="server" PostBackUrl="~/Profile/Address.aspx"></asp:LinkButton>
            </ItemTemplate>
            <SeparatorTemplate>
                <br />
            </SeparatorTemplate>

        </asp:Repeater>
        <br />
        <asp:LinkButton ID="lbtnNew" runat="server" onclick="lbtnNew_Click" 
            PostBackUrl="~/Profile/Address.aspx" >New Address</asp:LinkButton>
    </div>
    <hr />
    <div>
        <asp:HiddenField ID="hfUsername" runat="server" />
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbAddressType" runat="server" Text="Address Type"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAddressType" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbAddressTypeError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbStreetName" runat="server" Text="Street Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtStreetName" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbStreetNameError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbUitNumber" runat="server" Text="UnitNumber"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUitNumber" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbUitNumberError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbSuburb" runat="server" Text="Suburb"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSuburb" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbSuburbError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbTown" runat="server" Text="Town"></asp:Label>
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
                    <asp:Label ID="lbProvince" runat="server" Text="Province"></asp:Label>
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
                    <asp:Label ID="lbCountry" runat="server" Text="Country"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbCountryError" runat="server" Text=""></asp:Label>
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
</div>


</asp:Content>
