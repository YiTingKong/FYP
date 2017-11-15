<%@ Page Language="vb" MasterPageFile="~/Client/ClientSide.Master" AutoEventWireup="false" CodeBehind="Product.aspx.vb" Inherits="FYP.Product" %>
<asp:Content ID ="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<style type="text/css">
             .auto-style10 {
            width: 800px;
            margin-right: 0px;           
        }
        .auto-style11 {
        height: 20px;
        font-style:italic;
        font-weight:bold;    
    }
        .auto-style12 {
        width: 1000px;
        height: 810px;
    }
        </style>

    <div class="auto-style12" style="color:teal">
        <table class="auto-style10">
            <tr><td colspan="3"><strong>Products</strong></td></tr>
                <tr><td colspan="3">&nbsp;</td></tr>
            
        
        <tr><td colspan="3" class="auto-style11">Step 1 :</td>
            <td colspan="3" class="auto-style11">Step 2 :</td>
            <td colspan="3" class="auto-style11">Step 3 :</td>
        </tr>
                           

        <tr><td colspan="3">Make Selection of Cloth (Colour, Size, Material, Quantity)</td>
            <td colspan="3">Choose Design Option (General Design, Customize Design)</td>
            <td colspan="3">Choose the Desired Location To Retrieve The Cloth</td>
        </tr>
        <tr><td colspan="3">&nbsp;</td></tr>
            
        <tr><td colspan="3">
            <asp:ImageButton ID="Image1" runat="server" Height="200px" Width="200px" ImageUrl="~/image/black.jpg" />
            </td>
            <td colspan="3">
            <asp:ImageButton ID="Image2" runat="server" Height="200px" Width="200px" ImageUrl="~/image/grey.jpg" />
            </td>
            <td colspan="3">
            <asp:ImageButton ID="Image3" runat="server" Height="200px" Width="200px" ImageUrl="~/image/green.jpg" />
            </td>
        </tr>
            <tr><td colspan="3"> &nbsp;&nbsp; Black Colour T-Shirt</td>
            <td colspan="3"> &nbsp;&nbsp; Grey Colour T-Shirt</td>
            <td colspan="3"> &nbsp;&nbsp; Green Colour T-shirt</td>
        </tr>
            <tr><td colspan="3">&nbsp;</td></tr>
            <tr><td colspan="3">
            <asp:ImageButton ID="Image4" runat="server" Height="200px" Width="200px" ImageUrl="~/image/red.jpg" />
            </td>
            <td colspan="3">
            <asp:ImageButton ID="Image5" runat="server" Height="200px" Width="200px" ImageUrl="~/image/blue.jpg" />
            </td>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        </tr>
            <tr><td colspan="3"> &nbsp;&nbsp; Red Colour T-Shirt</td>
            <td colspan="3"> &nbsp;&nbsp; Blue Colour T-Shirt</td>
            <td colspan="3"> &nbsp;</td>
        </tr>
            <tr><td colspan="3">&nbsp;</td></tr>
            <tr><td colspan="3" style="font-weight:bold">What Are You Waiting For ?</td> <td>
                <asp:ImageButton ID="ImageButton1" runat="server" Height="50px" ImageUrl="~/image/buy.gif" />
                </td></tr>
        </table>

    </div>

    </asp:Content>