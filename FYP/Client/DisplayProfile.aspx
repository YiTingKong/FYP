<%@ Page Language="vb" MasterPageFile="~/Client/ClientSide.Master" AutoEventWireup="false" CodeBehind="DisplayProfile.aspx.vb" Inherits="FYP.DisplayProfile" %>

<asp:Content ID ="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
        
        


        <style type="text/css">
             .auto-style5 {
            width: 150px;
            height: 26px;
            font-weight: bold;
        }
        .auto-style6 {
            width: 23px;
            height: 26px;
        }
        .auto-style9 {
            height: 26px;
            width: 500px;
        }
        </style>

    <div style="color:teal">
    <table class="register">
            <tr><td colspan="3"><strong>Profile Maintenance</strong></td></tr>
                <tr><td colspan="3">&nbsp;</td></tr>
            <tr>
                    <td class="auto-style5">Username</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
                        <asp:Label ID="lblUserName" runat="server"></asp:Label>
                    </td>
            </tr>           
            
            <tr>
                    <td class="auto-style5">Nickname</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
                        <asp:Label ID="lblName" runat="server"></asp:Label>
                    </td>
            </tr>
            <tr>
                    <td class="auto-style5">Gender</td>
                    <td class="auto-style6">:</td>
                    <td>
                        
                        <asp:Label ID="lblGender" runat="server"></asp:Label>
                        
                    </td>
            </tr>
            <tr>
                    <td class="auto-style5">Contact Number</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
                        <asp:Label ID="lblContact" runat="server"></asp:Label>
                    </td>
            </tr>
            <tr>
                    <td class="auto-style5">Email</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
                        <asp:Label ID="lblEmail" runat="server"></asp:Label>
                    </td>
            </tr>
            <tr>
                    <td class="auto-style5">Address</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
                        <asp:Label ID="lblAddress" runat="server"></asp:Label>
                    </td>
            </tr>
            <tr>
                    <td class="auto-style5">Profile Picture</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
                        <asp:Image ID="newProfilePic" runat="server" Height="200px" Width="200px" />                     
       </td>
            </tr>
            
            <tr><td colspan="3">&nbsp;</td></tr>
            <tr><td colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                <asp:Button ID="btnEdit" runat="server" Text="Edit Profile" />
&nbsp;<asp:Button ID="btnChangePW" runat="server" Text="Change Password" />
                &nbsp;
                </td></tr>

            </table>
    </div>

    </asp:Content>



