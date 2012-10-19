<%@ Page Title="" Language="C#" MasterPageFile="~/Profile/Profile.master" AutoEventWireup="true" CodeBehind="HigherEducation.aspx.cs" Inherits="DAL.Profile.HigherEducation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="profileContent" runat="server">

    <div>
        <asp:Repeater ID="rptHigherEducation" runat="server" 
            onitemcommand="rptHigherEducation_ItemCommand">
            <ItemTemplate>
                <asp:LinkButton Text=<%# Eval("major")%> ID="lbContact" 
                                CommandName="major" CommandArgument=<%# Eval("major")%> runat="server" PostBackUrl="~/Profile/HigherEducation.aspx"></asp:LinkButton>
            </ItemTemplate>
            <SeparatorTemplate>
                <br />
            </SeparatorTemplate>

        </asp:Repeater>
        <br />
        <asp:LinkButton ID="lbtnNew" runat="server" onclick="lbtnNew_Click" 
            PostBackUrl="~/Profile/HigherEducation.aspx" >New Address</asp:LinkButton>
    </div>
    <hr />
    <div>
        <asp:HiddenField ID="hfUsername" runat="server" />
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbInstitution" runat="server" Text="Institution: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtInstitution" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbInstitutionError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbTown" runat="server" Text="Town Name"></asp:Label>
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
                    <asp:Label ID="lbEducationType" runat="server" Text="Education Type"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEducationType" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbEducationTypeError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbMajor" runat="server" Text="Major:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMajor" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbMajorError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbIndustry" runat="server" Text="Industry: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtIndustry" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbIndustryError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbLength" runat="server" Text="Length: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtLength" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbLengthError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbNqf" runat="server" Text="NQF: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNqf" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbNqfError" runat="server" Text=""></asp:Label>
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
