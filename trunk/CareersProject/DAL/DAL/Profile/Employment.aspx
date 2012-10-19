<%@ Page Title="" Language="C#" MasterPageFile="~/Profile/Profile.master" AutoEventWireup="true" CodeBehind="Employment.aspx.cs" Inherits="DAL.Profile.Employment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="profileContent" runat="server">

    <div>
        <asp:Repeater ID="rptEmployment" runat="server" 
            onitemcommand="rptEmployment_ItemCommand">
            <ItemTemplate>
                <asp:LinkButton Text=<%# Eval("title")%> ID="lbContact"
                                CommandName="startDate" CommandArgument=<%# Eval("startDate")%> runat="server" PostBackUrl="~/Profile/Employment.aspx"></asp:LinkButton>
            </ItemTemplate>
            <SeparatorTemplate>
                <br />
            </SeparatorTemplate>

        </asp:Repeater>
        <br />
        <asp:LinkButton ID="lbtnNew" runat="server" onclick="lbtnNew_Click" 
            PostBackUrl="~/Profile/Employment.aspx" >New Address</asp:LinkButton>
    </div>
    <hr />
    <div>
        <asp:HiddenField ID="hfUsername" runat="server" />
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbTitle" runat="server" Text="Title: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbTitleError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbCompany" runat="server" Text="Company: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCompany" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbCompanyError" runat="server" Text=""></asp:Label>
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
                    <asp:Label ID="lbEmpType" runat="server" Text="Employment Type: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmpType" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbEmpTypeError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbCurrentEmployer" runat="server" Text="Current Employer: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCurrentEmployer" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbCurrentEmployerError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbGross" runat="server" Text="Gross: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtGross" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbGrossError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbStartDate" runat="server" Text="Start Date: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbStartDateError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbEndDate" runat="server" Text="End Date: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>   
                             
                </td>
                <td>
                    <asp:Label ID="lbEndDateError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbResponsibilities" runat="server" Text="Responsibilities: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtResponsibilities" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbResponsibilitiesError" runat="server" Text=""></asp:Label>
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
