<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DisabilityView.aspx.cs" Inherits="careers.PRESENTATION.Profile.DisabilityView" culture="auto" meta:resourcekey="PageResource2" uiculture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <table>
            <tr>
                <td>
                    <asp:HiddenField ID="hfUsername" runat="server" />                
                </td>         
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbDisabilityType" runat="server" Text="Label" 
                        meta:resourcekey="lbDisabilityTypeResource1"></asp:Label>
                </td>    
                <td>        
                    <asp:TextBox ID="txtDisabilityType" runat="server" 
                        meta:resourcekey="txtDisabilityTypeResource1"></asp:TextBox>
                </td>         
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbDescription" runat="server" Text="Label" 
                        meta:resourcekey="lbDescriptionResource1"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" 
                        meta:resourcekey="txtDescriptionResource1"></asp:TextBox>
                </td>
            </tr>
            
        </table>




        <asp:Button ID="btnCancle" runat="server" Text="Button" 
            onclick="btnCancle_Click" meta:resourcekey="btnCancleResource2" />
        
        <asp:Button ID="btnSave" runat="server" Text="Button"
            meta:resourcekey="btnSaveResource2" onclick="btnSave_Click" />





    </div>
    </form>
</body>
</html>
