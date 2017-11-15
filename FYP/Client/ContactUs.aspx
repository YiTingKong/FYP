<%@ Page Language="vb" MasterPageFile="~/Client/ClientSide.Master" AutoEventWireup="false" CodeBehind="ContactUs.aspx.vb" Inherits="FYP.ContactUs" %>

<asp:Content ID ="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="auto-style12" style="color:teal;height:1000px;width:1000px">
        <table class>
            <tr><td colspan="3"><strong>Contact Us</strong></td></tr>
            <tr><td colspan="3">&nbsp;</td></tr>
             <tr><td colspan="3">Main Campus<br />
                 <br />
                 Trendary<br />
                 A-20-19<br />
                 Wangsa Metroview Condominium<br />
                 Jalan Metro Wangsa<br />
                 Wangsa Maju Seksyen 2<br />
                 53300 Kuala Lumpur<br />
                 <br />
                 012-3456789<br />
                 05-8881118</td></tr>
                 <tr><td colspan="3">&nbsp;</td></tr>
            <tr><td colspan="3">Machine Locations</td></tr>
            <tr><td colspan="3">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="areaName" HeaderText="Area" SortExpression="areaName" />
                        <asp:BoundField DataField="locationName" HeaderText="Location" SortExpression="locationName" />
                        <asp:BoundField DataField="address" HeaderText="Address" SortExpression="address" />
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
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FYPDBConnectionString %>" SelectCommand="SELECT [areaName], [locationName], [address] FROM [Machine]"></asp:SqlDataSource>
                </td></tr>       
        
        
        </table>

    </div>

    </asp:Content>

