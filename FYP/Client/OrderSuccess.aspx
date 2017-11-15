<%@ Page Language="vb" MasterPageFile="~/Client/ClientSide.Master" AutoEventWireup="false" CodeBehind="OrderSuccess.aspx.vb" Inherits="FYP.OrderSuccess" %>



<asp:Content ID ="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
    <div style="width: 1000px;height:1000px;color:teal">
    <table>
            <tr><td colspan="3"><strong>Payment Success</strong></td></tr>
                <tr><td colspan="3">&nbsp;</td></tr>
            <tr>
                    <td>This is the QR Code for you to scan in front of the machine chosen.</td>                   
            </tr>
        <tr><td colspan="3">
            <asp:Image ID="imgQRCode" runat="server" />
            </td></tr>
        <tr><td><asp:Label ID="lblQRCode" runat="server" Text="Label"></asp:Label>
            </td></tr>
       
        <tr><td colspan="3">&nbsp;</td></tr>
        <tr><td>To send the QR code to your email as a reference or backup
            <asp:Button ID="btnClick" runat="server" Text="Click Here" Width="100px" BackColor="Transparent" BorderStyle="None" ForeColor="Blue" />          
            </td></tr>       


        </table>
    </div>
    </asp:Content>
