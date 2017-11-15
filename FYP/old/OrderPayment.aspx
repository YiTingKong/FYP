<%@ Page Language="vb" MasterPageFile="~/Client/ClientSide.Master" AutoEventWireup="false" CodeBehind="OrderPayment.aspx.vb" Inherits="FYP.OrderPayment" %>

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
            width: 151px;
        }
        .auto-style10 {
            width: 382px;
            margin-right: 0px;
        }
        </style>
    
    <div style="width: 1000px;height:1000px;color:teal">
    <table class="auto-style10">
            <tr><td colspan="3"><strong>Payment</strong></td></tr>
                <tr><td colspan="3">&nbsp;</td></tr>
            <tr>
                    <td class="auto-style5">Payment Amount</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
                        RM
                        <asp:Label ID="lblPaymentAmt" runat="server"></asp:Label>
                    </td>
            </tr>
        <tr>
                    <td class="auto-style5">Payment Card Available</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
                        <asp:RadioButtonList ID="radPaymentMethod" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem>Credit</asp:ListItem>
                            <asp:ListItem>Debit</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
            </tr>
        <tr>
                    <td class="auto-style5">Name On Card</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    </td>
            </tr>

        <tr>
                    <td class="auto-style5">Card Number</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
                        <asp:TextBox ID="txtCardNumber" runat="server" MaxLength="16" ></asp:TextBox>
                    </td>
            </tr>

        <tr>
                    <td class="auto-style5">CVV</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
                        <asp:TextBox ID="txtCVV" runat="server" MaxLength="3"></asp:TextBox>
                    </td>
            </tr>
        <tr>
                    <td class="auto-style5">Bank</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
                        <asp:DropDownList ID="ddlBank" runat="server">
                            <asp:ListItem>Maybank</asp:ListItem>
                            <asp:ListItem>Public Bank</asp:ListItem>
                            <asp:ListItem>HSBC Bank</asp:ListItem>
                            <asp:ListItem>OCBC Bank</asp:ListItem>
                        </asp:DropDownList>
                    </td>
            </tr>
        <tr>
                    <td class="auto-style5">Expiration Date</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
                        <asp:Calendar ID="calenderExpire" runat="server" OnDayRender="calenderExpire_DayRender"></asp:Calendar>
                    </td>
            </tr>
        <tr><td colspan="3">&nbsp;</td></tr>
        <tr><td colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnPay" runat="server" Text="Pay Now" Width="100px" />
&nbsp;
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="100px" />
            </td></tr>
        <tr><td colspan="3">
            &nbsp;</td></tr>


        </table>
    </div>
    </asp:Content>