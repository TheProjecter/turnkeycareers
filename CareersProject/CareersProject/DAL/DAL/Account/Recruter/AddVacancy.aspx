<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Recruter/Recruter.master" AutoEventWireup="true" CodeBehind="AddVacancy.aspx.cs" Inherits="DAL.Account.Recruter.AddVacancy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AccountContent" runat="server">
    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Add New</asp:LinkButton>0
    <br />
    <asp:Label ID="Label1" runat="server" Text="Update: "></asp:Label>
    <asp:DropDownList ID="ddlVacancies" runat="server" 
        onselectedindexchanged="ddlVacancies_SelectedIndexChanged" AutoPostBack="False"></asp:DropDownList>
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbVacancyNumber" runat="server" Text="Vacancy Number: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtVacancyNumber" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbVacancyNumberError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbViewStatus" runat="server" Text="View Status: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtViewStatus" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbViewStatusError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
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
                    <asp:Label ID="lbDescription" runat="server" Text="Description: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbDescriptionError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbDepartment" runat="server" Text="Department: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDepartment" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbDepartmentError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbSite" runat="server" Text="Site: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSite" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbSiteError" runat="server" Text=""></asp:Label>
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
                    <asp:Label ID="lbViewCount" runat="server" Text="View Count: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtViewCount" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbViewCountError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbStatus" runat="server" Text="Status: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtStatus" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbStatusError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbManager" runat="server" Text="Manager: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtManager" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbManagerError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbRecruiter" runat="server" Text="Recruiter: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtRecruiter" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbRecruiterError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbCostToCompany" runat="server" Text="Cost To Company: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCostToCompany" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbCostToCompanyError" runat="server" Text=""></asp:Label>
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
        <hr />

        <div>
            <asp:Label ID="lbQuestions" runat="server" Text="Questions: "></asp:Label>
            
            <br />
            <asp:Repeater ID="rptQuestion" runat="server" 
                onitemcommand="rptQuestion_ItemCommand">
                <ItemTemplate>
                    <asp:LinkButton Text=<%# Eval("question")%> ID="lbContact"
                                    CommandName="question" CommandArgument=<%# Eval("question")%> runat="server" PostBackUrl="~/Account/Recruter/AddVacancy.aspx"></asp:LinkButton>
                </ItemTemplate>
                <SeparatorTemplate>
                    <br />
                </SeparatorTemplate>

            </asp:Repeater>
            <br />
            <asp:LinkButton ID="lbtnNewQuestion" runat="server" onclick="lbtnNewQuestion_Click" 
                PostBackUrl="~/Account/Recruter/AddVacancy.aspx" >New Killer Question</asp:LinkButton>
        </div>
        
        <asp:Panel ID="questionPanel" runat="server" Visible="False">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbQuestion" runat="server" Text="Question: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtQuestion" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbQuestionError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbAnswer" runat="server" Text="Answer: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAnswer" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbAnswerError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <div>
            <asp:Button ID="btnUpdateQuestion" runat="server" Text="Update" 
                onclick="btnUpdateQuestion_Click" />
            <asp:Button ID="btnSaveQuestion" runat="server" Text="Save" 
                onclick="btnSaveQuestion_Click" />
            <asp:Button ID="btnResetQuestion" runat="server" Text="Reset" 
                onclick="btnResetQuestion_Click" />
            <asp:Button ID="btnDeleteQuestion" runat="server" Text="Delete" 
                onclick="btnDeleteQuestion_Click" />
        </div>
        </asp:Panel>
        <hr />
        
        <div>
            <asp:Label ID="lbKeyWords" runat="server" Text="Key Words: "></asp:Label>
            <br />
            <asp:Repeater ID="rptKeyWord" runat="server" 
                onitemcommand="rptKeyWord_ItemCommand">
                <ItemTemplate>
                    <asp:LinkButton Text=<%# Eval("word")%> ID="lbContact"
                                    CommandName="word" CommandArgument=<%# Eval("word")%> runat="server" PostBackUrl="~/Account/Recruter/AddVacancy.aspx"></asp:LinkButton>
                </ItemTemplate>
                <SeparatorTemplate>
                    <br />
                </SeparatorTemplate>

            </asp:Repeater>
            <br />
            <asp:LinkButton ID="lbtnNewKeyWord" runat="server" onclick="lbtnNewKeyWord_Click" 
                PostBackUrl="~/Account/Recruter/AddVacancy.aspx" >New Key Word</asp:LinkButton>
        </div>
        <asp:Panel ID="keyWordPanel" runat="server" Visible="False">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbKeyWord" runat="server" Text="Key Word: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtKeyWord" runat="server"></asp:TextBox>            
                </td>
                <td>
                    <asp:Label ID="lbKeyWordError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <div>
            <asp:Button ID="btnUpdateKeyWord" runat="server" Text="Update" 
                onclick="btnUpdateKeyWord_Click" />
            <asp:Button ID="btnSaveKeyWord" runat="server" Text="Save" 
                onclick="btnSaveKeyWord_Click" />
            <asp:Button ID="btnResetKeyWord" runat="server" Text="Reset" 
                onclick="btnResetKeyWord_Click" />
            <asp:Button ID="btnDeleteKeyWord" runat="server" Text="Delete" 
                onclick="btnDeleteKeyWord_Click" />
        </div>
        </asp:Panel>



    </div>
</asp:Content>
