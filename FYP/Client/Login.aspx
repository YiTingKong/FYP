<%@ Page Language="vb" MasterPageFile="~/Client/ClientSide.Master" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="FYP.Login" %>
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
    
    <div style="width: 1000px;height:1000px;color:teal">
    <table class="auto-style10">
            <tr><td colspan="3"><strong>Login</strong></td></tr>
                <tr><td colspan="3">&nbsp;</td></tr>
            <tr>
                    <td class="auto-style5">Username</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
                        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                    </td>
            </tr>
        <tr>
                    <td class="auto-style5">Password</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
            </tr>
        <tr><td colspan="3">&nbsp;</td></tr>
        <tr><td colspan="3">&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnLogin" runat="server" Text="Login" Width="99px" />
&nbsp;
            <asp:Button ID="btnForgot" runat="server" Text="Forgot Password" Width="122px" />
            </td></tr>
        <tr><td colspan="3">&nbsp;</td></tr>
        <tr><td colspan="3">&nbsp;
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Client/Registration.aspx">Not a member? Click here to Register</asp:HyperLink>
            </td></tr>

        </table>
    </div>

    </asp:Content>


