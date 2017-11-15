<%@ Page Language="vb" MasterPageFile="~/Client/ClientSide.Master" AutoEventWireup="false" CodeBehind="Order.aspx.vb" Inherits="FYP.Order" %>

<asp:Content ID ="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<style type="text/css">
        .auto-style5 {
            width: 17px;
            height: 26px;
            font-weight: bold;
        }
        .auto-style6 {
            width: 23px;
            height: 26px;
        }
        .auto-style9 {
            height: 26px;
            width: 718px;
        }
       

        </style>

    <div class="auto-style12" style="color:teal;height:1000px;width:1000px">
        <table class>
            <tr><td colspan="3"><strong>Place Order</strong></td></tr>
            <tr><td colspan="3">&nbsp;</td></tr>
            <tr>
                    <td class="auto-style5">Colour</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
                        <asp:ImageButton ID="btnBlack" runat="server" Height="30px" ImageUrl="~/image/btnBlack.png" Width="30px" />
&nbsp;<asp:ImageButton ID="btnGrey" runat="server" Height="30px" ImageUrl="~/image/btnGrey.png" Width="30px" />
&nbsp;<asp:ImageButton ID="btnGreen" runat="server" Height="30px" ImageUrl="~/image/btnGreen.png" Width="30px" />
&nbsp;<asp:ImageButton ID="btnRed" runat="server" Height="30px" ImageUrl="~/image/btnRed.png" Width="30px" />
&nbsp;<asp:ImageButton ID="btnBlue" runat="server" Height="30px" ImageUrl="~/image/btnBlue.png" Width="30px" />
&nbsp;&nbsp;&nbsp;&nbsp; </td>
            </tr>
            <tr><td colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                <asp:Image ID="imgDisplay" runat="server" Height="200px" Visible="False" Width="200px" />
                </td></tr>
           <tr> <td class="auto-style5">Size</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
                        <asp:RadioButtonList ID="radSize" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem>S</asp:ListItem>
                            <asp:ListItem>M</asp:ListItem>
                            <asp:ListItem>L</asp:ListItem>
                        </asp:RadioButtonList>                    
               </tr>
            <tr> <td class="auto-style5">Material</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
                        <asp:RadioButtonList ID="radMaterial" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem>Cotton</asp:ListItem>
                            <asp:ListItem>Polyester</asp:ListItem>
                        </asp:RadioButtonList>
                </tr>
            <tr><td colspan="3">&nbsp;</td></tr>
            <tr><td colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnNext" runat="server" Text="Next" />
                </td></tr>
            
        
        
        </table>

    </div>

    </asp:Content>
