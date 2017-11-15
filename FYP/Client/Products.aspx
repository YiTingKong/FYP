<%@ Page Language="vb" MasterPageFile="~/Client/ClientSide.Master"  AutoEventWireup="false" CodeBehind="Products.aspx.vb" Inherits="FYP.Products" %>

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
        height: 1000px;
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
            </table>
            <br />
        <asp:DropDownList ID="preference" runat="server">
            <asp:ListItem Value="- Choose From Here -">- Choose From Here -</asp:ListItem>
            <asp:ListItem>All Products</asp:ListItem>
<asp:ListItem Value="Material">Material</asp:ListItem>
            <asp:ListItem Value="Cloth Type">Cloth Type</asp:ListItem>
            <asp:ListItem>Colours</asp:ListItem>
        </asp:DropDownList>
        &nbsp;
        <asp:Button ID="btnChoose" runat="server" Text="Choose" />
        <br />
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
&nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" />
            <br />
            <br />
        <div style="width: 400px;height: 450px; overflow: scroll">
            
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" >
                    <Columns>                     
                        <asp:BoundField DataField = "clothType" HeaderText = "Type" />
                        <asp:BoundField DataField = "material" HeaderText = "Material" />
                        <asp:BoundField DataField = "priceEach" HeaderText = "Price Each" />
                        <asp:ImageField DataImageUrlField="clothDesign" ControlStyle-Width="200" ControlStyle-Height = "200" HeaderText = "Product Image"/>                                          
                        </Columns> 
                </asp:GridView>
        </div>
                
                
            What Are You Waiting For ?
                <asp:ImageButton ID="ImageButton1" runat="server" Height="50px" ImageUrl="~/image/buy.gif" />
                
        

    </div>

    </asp:Content>
