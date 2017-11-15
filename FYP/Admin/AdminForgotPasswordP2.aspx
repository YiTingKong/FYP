<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AdminForgotPasswordP2.aspx.vb" Inherits="FYP.AdminForgotPasswordP2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<style type="text/css">
        .home-style{            
            background-image: url(../image/login_background.jpg);
            background-size: cover;            
        }
        .logo-style{
            background-color : whitesmoke;
            border-style: ridge;
        }
        .label-style1 {
            width: 190px;
            height: 190px;
        }
    </style>
</head>
<body class="home-style">
    <form id="form1" runat="server">
    
        <%--Logo--%>
        <div style="margin-top:150px; margin-left:480px">  
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <img alt="logo" class="label-style1" src="../image/FYP%20logo.png" /><br />
        </div>

        <%--Header--%>
    <div style=" margin-top: 5px; margin-left: 410px; width: 511px;" class="logo-style">
        <div style="margin-left: 20px">
        <asp:Label ID="Label2" runat="server" ForeColor="#669900" Font-Bold="True" Font-Size="XX-Large" Text="Trendary"></asp:Label>
        &nbsp;  
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="XX-Large"  Text="Admin Forgot Password"></asp:Label>
        </div>
        <br />

        <%--Contain--%>
        <div style="margin-left: 120px; width: 291px;">
        <asp:Label ID="lblNPassword" runat="server" Text="New Password : " AccessKey="N" AssociatedControlID="txtNPassword"></asp:Label>
        &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtNPassword" runat="server" Width="140px" TextMode="Password"></asp:TextBox>
            <br />
        <br />
        <asp:Label ID="lblCPassword" runat="server" Text="Confirm Password   : " AccessKey="C" AssociatedControlID="txtCPassword"></asp:Label>
        &nbsp;<asp:TextBox ID="txtCPassword" runat="server" Width="140px" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:ImageButton ID="btnSubmit" runat="server" src="../image/button_submit.png"/>
        </div>
    </div>
    
    </form>
</body>
</html>
