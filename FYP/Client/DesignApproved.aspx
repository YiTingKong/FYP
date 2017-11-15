<%@ Page Language="vb"  MasterPageFile="~/Client/ClientSide.Master" AutoEventWireup="false" CodeBehind="DesignApproved.aspx.vb" Inherits="FYP.DesignApproved" %>


<asp:Content ID ="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="auto-style12" style="color:teal;height:1000px;width:1000px">
        <table class>
            <tr><td><strong>Design Approved</strong></td></tr>
            <tr><td>&nbsp;</td></tr>
            <tr><td>
                <asp:Label ID="lblDetails" runat="server"></asp:Label>
                <br />
                Do you want to take our offer?</td></tr>
            <tr><td>
                <asp:RadioButtonList ID="rblAns" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:RadioButtonList>
                </td></tr>
            <tr><td>&nbsp;</td></tr>
            <tr><td>
                <asp:Label ID="lblBank" runat="server" Text="Please fill in your bank account for us to bank inthe amount to you." Visible="False"></asp:Label>
                </td></tr>
            <tr><td>
                <asp:TextBox ID="txtAcc" runat="server" MaxLength="16" Visible="False"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" Visible="False" />
                </td></tr>
                     
        
        </table>

    </div>

    </asp:Content>


