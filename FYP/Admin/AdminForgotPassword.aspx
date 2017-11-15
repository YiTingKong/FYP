<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AdminForgotPassword.aspx.vb" Inherits="FYP.AdminForgotPassword" %>

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
        <div style="margin-top:110px; margin-left:480px">  
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <img alt="logo" class="label-style1" src="../image/FYP%20logo.png" /><br />
        </div>

        <%--Header--%>
    <div style=" margin-top: 5px; margin-left: 415px; height: 256px; width: 517px;" class="logo-style">
        <div style="margin-left: 20px">
        <asp:Label ID="Label2" runat="server" ForeColor="#669900" Font-Bold="True" Font-Size="XX-Large" Text="Trendary"></asp:Label>
        &nbsp;  
        <asp:Label ID="Label3" runat="server" Font-Bold="true" Font-Size="XX-Large"  Text="Admin Forgot Password"></asp:Label>
        </div>
        <br />

        <%--Contain--%>
        <div style="margin-left: 100px; width: 314px; height: 179px;">
            <asp:Label ID="lblUName" runat="server" Text="User Name : "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtUName" runat="server" Width="186px"></asp:TextBox>
            <br />
            <br />
        <asp:Label ID="lblSecQuestion" runat="server" Text="Security Question : "></asp:Label>
        &nbsp;<asp:DropDownList ID="ddlSecQuestion" runat="server" style="margin-left: 0px; margin-top: 0px">
                <asp:ListItem Value="Q1">What&#39;s your mother&#39;s middle name?</asp:ListItem>
                <asp:ListItem Value="Q2">Who was your childhood hero?</asp:ListItem>
                <asp:ListItem Value="Q3">What is the last name of your favourite teacher?</asp:ListItem>
            </asp:DropDownList>
            &nbsp;
            <br />
        <asp:Label ID="lblSecAns" runat="server" AssociatedControlID="txtSecAns" AccessKey="s" Text="Security Answer   : "></asp:Label>
        &nbsp;
        &nbsp;<br />
            <asp:TextBox ID="txtSecAns" runat="server" Width="302px"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:ImageButton ID="btnSubmit" runat="server" src="../image/button_submit.png"/>
        </div>
    </div>
    
    </form>
</body>
</html>
