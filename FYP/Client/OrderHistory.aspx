<%@ Page Language="vb" MasterPageFile="~/Client/ClientSide.Master" AutoEventWireup="false" CodeBehind="OrderHistory.aspx.vb" Inherits="FYP.OrderHistory" %>

<asp:Content ID ="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="auto-style12" style="color:teal;height:1000px;width:1000px">
        <table class>
            <tr><td colspan="3"><strong>Order History</strong>
                </td></tr>
           
            <tr><td colspan="3">

                <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>

             </td></tr>
            <tr><td colspan="3">

                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="clothID" DataSourceID="SqlDataSource1" AutoGenerateSelectButton="True" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="clothID" HeaderText="Cloth ID" ReadOnly="True" SortExpression="clothID" />
                        <asp:BoundField DataField="colour" HeaderText="Colour" SortExpression="colour" />
                        <asp:BoundField DataField="size" HeaderText="Size" SortExpression="size" />
                        <asp:BoundField DataField="material" HeaderText="Material" SortExpression="material" />
                        <asp:BoundField DataField="priceEach" HeaderText="Price Each" SortExpression="priceEach" />
                        <asp:BoundField DataField="clothType" HeaderText="Cloth Type" SortExpression="clothType" />
                        <asp:BoundField DataField="designID" HeaderText="Design ID" SortExpression="designID" />
                        <asp:ImageField HeaderText="Design Image" DataImageUrlField="designPath" SortExpression="designPath" ControlStyle-Width="100" ControlStyle-Height = "100">
<ControlStyle Height="100px" Width="100px"></ControlStyle>
                        </asp:ImageField>
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FYPDBConnectionString %>" SelectCommand="SELECT P.clothID, P.colour, P.size, P.material, P.priceEach, P.clothType, OD.designID, D.designPath FROM Orders AS O INNER JOIN OrderDetails AS OD ON O.orderID = OD.orderID INNER JOIN Design AS D ON OD.designID = D.designID INNER JOIN Product AS P ON OD.clothID = P.clothID WHERE (O.userName = @username)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="Label1" DefaultValue="" Name="username" PropertyName="Text" />
                    </SelectParameters>
                </asp:SqlDataSource>

             </td></tr>
            <tr><td colspan="3">

             </td></tr>
            <tr><td colspan="3">

             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnNext" runat="server" style="height: 26px" Text="Next" />

             </td></tr>
             

                 
        
        
        </table>

    </div>

    </asp:Content>


