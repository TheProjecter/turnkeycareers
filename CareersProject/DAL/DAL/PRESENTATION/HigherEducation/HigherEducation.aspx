<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HigherEducation.aspx.cs" Inherits="careers.PRESENTATION.HigherEducation.HigherEducation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Repeater ID="rptHigherEducation" runat="server" 
            onitemcommand="rptHigherEducation_ItemCommand">
            <ItemTemplate>
                <asp:LinkButton Text=<%# Eval("major")%> ID="lbContact" 
                                CommandName="major" CommandArgument=<%# Eval("major")%> runat="server" PostBackUrl="~/PRESENTATION/HigherEducation/HigherEducation.aspx"></asp:LinkButton>
            </ItemTemplate>
            <SeparatorTemplate>
                <br />
            </SeparatorTemplate>

        </asp:Repeater>
        <br />
        <asp:LinkButton ID="lbtnNew" runat="server" onclick="lbtnNew_Click" 
            PostBackUrl="~/PRESENTATION/HigherEducation/HigherEducation.aspx" >New Address</asp:LinkButton>
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
    </form>
</body>
</html>
