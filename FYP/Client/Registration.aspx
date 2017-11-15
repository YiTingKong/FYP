<%@ Page Language="vb" MasterPageFile="~/Client/ClientSide.Master" AutoEventWireup="false" CodeBehind="Registration.aspx.vb" Inherits="FYP.Registration" %>

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
            width: 63px;
        }
        </style>

    <div style="color:teal">
    <table class="register">
            <tr><td colspan="3"><strong>Sign Up As New Customer.</strong></td></tr>
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
            <tr>
                    <td class="auto-style5">Confirm Password</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
                        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                    <td class="auto-style5">Nickname</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
                        <asp:TextBox ID="txtNickname" runat="server"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                    <td class="auto-style5">Gender</td>
                    <td class="auto-style6">:</td>
                    <td>
                        
                        <asp:RadioButtonList ID="radGender" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:RadioButtonList>
                        
                    </td>
            </tr>
            <tr>
                    <td class="auto-style5">Contact Number</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
                        <asp:TextBox ID="txtContact" runat="server" MaxLength="10"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                    <td class="auto-style5">Email</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
                        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                    <td class="auto-style5">Address</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
                        <asp:TextBox ID="txtAddress" runat="server" Height="45px" TextMode="MultiLine" Width="124px"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                    <td class="auto-style5">Profile Picture</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
                        <asp:FileUpload ID="imgUpload" runat="server" />
                    </td>
            </tr>
            <tr>
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
            <tr><td colspan="3">&nbsp;</td></tr>
            <tr><td colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnRegister" runat="server" Text="Register" />
&nbsp;&nbsp;
                <asp:Button ID="btnClear" runat="server" Text="Clear" />
                </td></tr>

            </table>
    </div>

    </asp:Content>

