<%@ Page Language="vb" MasterPageFile="~/Client/ClientSide.Master" AutoEventWireup="false" CodeBehind="ChangePassword.aspx.vb" Inherits="FYP.ChangePassword" %>

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
            width: 50px;
        }
        </style>

    <div style="color:teal;width:1000px;height:1000px">
    <table class="register">
            <tr><td colspan="3"><strong>Change Password</strong></td></tr>
                <tr><td colspan="3">&nbsp;</td></tr>
           
            <tr>
                    <td class="auto-style5">Old Password</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
                        <asp:TextBox ID="txtOldPw" runat="server" TextMode="Password"></asp:TextBox>
                        
                    </td>
               
                </tr>
        <tr>
                    <td class="auto-style5">New Password</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
                        <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                  
                        
                    </td>
           
            </tr>
        <tr>
                    <td class="auto-style5">Confirm Password</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
                        <asp:TextBox ID="txtConfPw" runat="server" TextMode="Password"></asp:TextBox>
                 
                        
                    </td>
          
            </tr>
           
            <tr><td colspan="3">&nbsp;</td></tr>

        <tr><td colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
            </td></tr>
           
            </table>
    </div>

    </asp:Content>



