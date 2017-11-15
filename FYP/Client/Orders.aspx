<%@ Page Language="vb" MasterPageFile="~/Client/ClientSide.Master" AutoEventWireup="false" CodeBehind="Orders.aspx.vb" Inherits="FYP.Orders" %>

<asp:Content ID ="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<style type="text/css">
        .auto-style5 {
            width: 120px;
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
                        <asp:DropDownList ID="ddlColour" runat="server" DataSourceID="SqlDataSource1" DataTextField="colour" DataValueField="colour">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FYPDBConnectionString %>" SelectCommand="SELECT [colour] FROM [Colour]"></asp:SqlDataSource>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            </tr>
            <tr>
                    <td class="auto-style5">Size</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
                        <asp:DropDownList ID="ddlSize" runat="server" DataSourceID="SqlDataSource2" DataTextField="Size" DataValueField="Size">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:FYPDBConnectionString %>" SelectCommand="SELECT [Size] FROM [Size]"></asp:SqlDataSource>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            </tr>
            <tr>
                    <td class="auto-style5">Material</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
                        <asp:DropDownList ID="ddlMaterial" runat="server" DataSourceID="SqlDataSource3" DataTextField="Material" DataValueField="Material">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:FYPDBConnectionString %>" SelectCommand="SELECT [Material] FROM [Material]"></asp:SqlDataSource>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            </tr>
            <tr>
                    <td class="auto-style5">Type</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
                        <asp:DropDownList ID="ddlType" runat="server" DataSourceID="SqlDataSource4" DataTextField="Des" DataValueField="Des">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:FYPDBConnectionString %>" SelectCommand="SELECT [Des] FROM [ClothType]"></asp:SqlDataSource>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            </tr>

             <tr>
                    <td class="auto-style5">Cloth Design</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
                        <asp:RadioButtonList ID="radDesignType" runat="server" RepeatDirection="Horizontal" AutoPostBack="True">
                            <asp:ListItem>General Design</asp:ListItem>
                            <asp:ListItem>Customize Design</asp:ListItem>
                        </asp:RadioButtonList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            </tr>
            <tr>
                    <td class="auto-style5">
                        <asp:Label ID="lblDesign" runat="server" Text="Design" Visible="False"></asp:Label>
                    </td>
                    <td class="auto-style6">
                        <asp:Label ID="lbl" runat="server" Text=":" Visible="False"></asp:Label>
                    </td>
                    <td class="auto-style9">
                        <asp:FileUpload ID="FileUpload1" runat="server" Visible="False" />
                        <br />
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" Visible="False" >
                        <Columns>

                        <asp:BoundField DataField = "designID" HeaderText = "Design ID" />  

                        <asp:ImageField DataImageUrlField="designPath" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "Preview Image"/>
                        
                        
                        </Columns> 

                        </asp:GridView>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            </tr>

            <tr><td colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                </td></tr>
          


            
            <tr><td colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnNext" runat="server" Text="Next" />
                </td></tr>
            
        
        
        </table>

    </div>

    </asp:Content>
