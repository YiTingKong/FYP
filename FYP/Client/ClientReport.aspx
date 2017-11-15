<%@ Page Language="vb" MasterPageFile="~/Client/ClientSide.Master" AutoEventWireup="false" CodeBehind="ClientReport.aspx.vb" Inherits="FYP.ClientReport" %>


<asp:Content ID ="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="auto-style12" style="color:teal;height:1000px;width:1000px">
        <table class>
            <tr><td colspan="3" class="auto-style5"><strong>Reports</strong></td></tr>
            <tr><td colspan="3" class="auto-style5">
        

                <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
        

                </td></tr>
            <tr><td colspan="3" class="auto-style5">
        

                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                    <asp:ListItem>Yearly Order Report</asp:ListItem>
                    <asp:ListItem>Yearly Payment Report</asp:ListItem>
                    <asp:ListItem>Overall Order And Payment Report</asp:ListItem>
                </asp:DropDownList>
        

                &nbsp;&nbsp;
                <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True">
                    <asp:ListItem>2016</asp:ListItem>
                    <asp:ListItem>2017</asp:ListItem>
                    <asp:ListItem>2018</asp:ListItem>
                    <asp:ListItem>2019</asp:ListItem>
                    <asp:ListItem>2020</asp:ListItem>
                </asp:DropDownList>
        

                </td></tr>
            <tr><td colspan="3" class="auto-style4">
        

                </td></tr>
            <tr><td colspan="3" class="auto-style4">
        

                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="orderID" DataSourceID="SqlDataSource1" Visible="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="orderID" HeaderText="OrderID" ReadOnly="True" SortExpression="orderID" />
                        <asp:BoundField DataField="colour" HeaderText="Colour" SortExpression="colour" />
                        <asp:BoundField DataField="material" HeaderText="Material" SortExpression="material" />
                        <asp:BoundField DataField="clothType" HeaderText="ClothType" SortExpression="clothType" />
                        <asp:BoundField DataField="size" HeaderText="Size" SortExpression="size" />
                        <asp:BoundField DataField="qty" HeaderText="Quantity" SortExpression="qty" />
                        <asp:BoundField DataField="designID" HeaderText="Design ID" SortExpression="designID" />
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
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FYPDBConnectionString %>" SelectCommand="SELECT O.orderID, PD.colour, PD.material, PD.clothType, PD.size, OD.qty, OD.designID FROM Orders AS O INNER JOIN Payment AS P ON O.orderID = P.orderID INNER JOIN OrderDetails AS OD ON O.orderID = OD.orderID INNER JOIN Product AS PD ON OD.clothID = PD.clothID WHERE (O.userName = @userName) AND (YEAR(P.payDate) = @year)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="Label1" DefaultValue="" Name="userName" PropertyName="Text" />
                        <asp:ControlParameter ControlID="DropDownList2" DefaultValue="" Name="year" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
        

                </td></tr>
            <tr><td colspan="3" class="auto-style4">
        

                </td></tr>
            <tr><td colspan="3" class="auto-style4">
        

                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="paymentID" DataSourceID="SqlDataSource2" Visible="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="paymentID" HeaderText="paymentID" ReadOnly="True" SortExpression="paymentID" />
                        <asp:BoundField DataField="payDate" HeaderText="payDate" SortExpression="payDate" />
                        <asp:BoundField DataField="paymentTotal" HeaderText="paymentTotal" SortExpression="paymentTotal" />
                        <asp:BoundField DataField="paymentMethod" HeaderText="paymentMethod" SortExpression="paymentMethod" />
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
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:FYPDBConnectionString %>" SelectCommand="SELECT P.paymentID, P.payDate, P.paymentTotal, P.paymentMethod FROM Payment AS P INNER JOIN Orders AS O ON P.orderID = O.orderID WHERE (O.userName = @userName) AND (YEAR(P.payDate) = @year) order by p.paymentID">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="Label1" Name="userName" PropertyName="Text" />
                        <asp:ControlParameter ControlID="DropDownList2" Name="year" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
        

                <br />
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="orderID" DataSourceID="SqlDataSource3" ForeColor="#333333" GridLines="None" Visible="False">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="orderID" HeaderText="orderID" ReadOnly="True" SortExpression="orderID" />
                        <asp:BoundField DataField="colour" HeaderText="colour" SortExpression="colour" />
                        <asp:BoundField DataField="material" HeaderText="material" SortExpression="material" />
                        <asp:BoundField DataField="size" HeaderText="size" SortExpression="size" />
                        <asp:BoundField DataField="clothType" HeaderText="clothType" SortExpression="clothType" />
                        <asp:ImageField DataImageUrlField="designPath" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "Design">
                        </asp:ImageField>
                        <asp:BoundField DataField="paymentTotal" HeaderText="paymentTotal" SortExpression="paymentTotal" />
                        <asp:BoundField DataField="locationName" HeaderText="locationName" SortExpression="locationName" />
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
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:FYPDBConnectionString %>" SelectCommand="select O.orderID, PD.colour, PD.material, PD.size, PD.clothType, D.designPath, P.paymentTotal, M.locationName
from Orders O, OrderDetails OD, Payment P, Machine M, Product PD, Design D
where O.userName = @userName AND
O.orderID = P.orderID AND
O.machineID = M.machineID AND
O.orderID = OD.orderID AND
OD.clothID = PD.clothID AND
OD.designID = D.designID 
order by O.orderID
">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="Label1" Name="userName" PropertyName="Text" />
                    </SelectParameters>
                </asp:SqlDataSource>
        

                </td></tr>
                       
        
        </table>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

    </div>

    </asp:Content>



<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style4 {
            height: 20px;
            width: 313px;
        }
        .auto-style5 {
            width: 313px;
        }
    </style>
</asp:Content>




