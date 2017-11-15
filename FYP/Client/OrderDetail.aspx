<%@ Page Language="vb" MasterPageFile="~/Client/ClientSide.Master" AutoEventWireup="false" CodeBehind="OrderDetail.aspx.vb" Inherits="FYP.OrderDetail" %>

<asp:Content ID ="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    &nbsp;<style type="text/css">
        .auto-style5 {
            width: 100px;
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
       

        </style><div style="color:teal;height:1000px;width:1000px">
        <table class>
            <tr><td colspan="3"><strong>Order Details</strong></td></tr>
            <tr><td colspan="3">&nbsp;</td></tr>
            <tr>
                    <td class="auto-style5">Color</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
                        <asp:Label ID="lblColor" runat="server" Text="Label"></asp:Label>
                    </td>
            </tr>
            <tr> <td class="auto-style5">
                Size</td>
                    <td class="auto-style6">
                        :</td>
                    <td class="auto-style9">
                        <asp:Label ID="lblSize" runat="server" Text="Label"></asp:Label>
                        <br />
                </tr>
            <tr> <td class="auto-style5">
                Material</td>
                    <td class="auto-style6">
                        :</td>
                    <td class="auto-style9">
                        <asp:Label ID="lblMaterial" runat="server" Text="Label"></asp:Label>
                        <br />
                </tr>
            <tr> <td class="auto-style5">
                Type</td>
                    <td class="auto-style6">
                        :</td>
                    <td class="auto-style9">
                        <asp:Label ID="lblType" runat="server" Text="Label"></asp:Label>
                        <br />
                </tr>
            <tr> <td class="auto-style5">
                Design Pattern</td>
                    <td class="auto-style6">
                        :</td>
                    <td class="auto-style9">
                        <asp:Image ID="Image2" runat="server" Height="200px" Width="200px" />
                        <br />
                </tr>
            <tr> <td class="auto-style5">
                Quantity</td>
                    <td class="auto-style6">
                        :</td>
                    <td class="auto-style9">
                        <asp:DropDownList ID="ddlQuantity" runat="server" AutoPostBack="True">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                </tr>
            <tr> <td class="auto-style5">
                Location</td>
                    <td class="auto-style6">
                        :</td>
                    <td class="auto-style9">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" AutoGenerateColumns="False">
                        <Columns>
                        <asp:BoundField DataField = "MachineID" HeaderText = "Machine ID" />   
                            <asp:BoundField DataField = "locationName" HeaderText = "Location" />  
                            <asp:BoundField DataField = "address" HeaderText = "Address" />  
                            <asp:BoundField DataField = "qty" HeaderText = "Stock Available" />                   
                        </Columns> 
                        </asp:GridView>
                        <asp:Label ID="lblLocation" runat="server"></asp:Label>
                        <br />
                </tr>
           

          
            <tr><td colspan="3">&nbsp;</td></tr>
            <tr><td colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnNext" runat="server" Text="Next" style="height: 26px" />
                </td></tr>
            
        
        
        </table>

    </div>

    </asp:Content>

