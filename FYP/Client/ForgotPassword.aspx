<%@ Page Language="vb" MasterPageFile="~/Client/ClientSide.Master" AutoEventWireup="false" CodeBehind="ForgotPassword.aspx.vb" Inherits="FYP.ForgotPassword" %>
<asp:Content ID ="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <style type="text/css">
             .auto-style5 {
            width: 133px;
            height: 26px;
            font-weight: bold;
        }
        .auto-style6 {
            width: 23px;
            height: 26px;
        }
        .auto-style9 {
            height: 26px;
            width: 126px;
        }
        .auto-style10 {
            width: 303px;
            margin-right: 0px;
        }
        </style>
    
    <div style="width: 1000px;height:1000px; color:teal">
    <table class="auto-style10">
            <tr><td colspan="3"><strong>Forgot Password</strong></td></tr>
                <tr><td colspan="3">&nbsp;</td></tr>
            <tr>
                    <td class="auto-style5">Username</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
                        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                    </td>
            </tr>
        
        <<tr>
                    <td class="auto-style5">Security Question</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
                        <asp:DropDownList ID="ddlQuestion" runat="server">
                            <asp:ListItem>Where is your hometown?</asp:ListItem>
                            <asp:ListItem>What is the name of your first pet?</asp:ListItem>
                            <asp:ListItem>What is your favourite food?</asp:ListItem>
                        </asp:DropDownList>
                    </td>
            </tr>
            <tr>
                    <td class="auto-style5">Security Answer</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
                        <asp:TextBox ID="txtAnswer" runat="server"></asp:TextBox>
                    </td>
            </tr>

        <tr><td colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="99px" />
&nbsp;
            </td></tr>
        <tr><td colspan="3">&nbsp;</td></tr>
        <tr><td colspan="3">&nbsp;<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Client/Login.aspx">Back to login page</asp:HyperLink>
            </td></tr>

        </table>
        </div>

</asp:Content>




