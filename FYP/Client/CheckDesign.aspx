<%@ Page Language="vb" MasterPageFile="~/Client/ClientSide.Master" AutoEventWireup="false" CodeBehind="CheckDesign.aspx.vb" Inherits="FYP.CheckDesign" %>

<asp:Content ID ="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="auto-style12" style="color:teal;height:1000px;width:1000px">
        <table class>
            <tr><td colspan="3"><strong>Design Status</strong><asp:Label ID="lblUsername" runat="server" Visible="False"></asp:Label>
                </td></tr>
            <tr><td colspan="3">
                Pending - Waiting admin to reveal
                <br />
                Success - Admin had approve your application<br />
                Unsuccess - Admin had rejected your application<br />
                Approve - You had accept the offer provided<br />
                Reject - You had reject the offer provided</td></tr>
            <tr><td colspan="3">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField = "designID" HeaderText = "Design ID" />
                        <asp:BoundField DataField = "status" HeaderText = "Status" />                          
                        <asp:ImageField DataImageUrlField="designPath" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "Preview Image">
                        
                        
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
                <br />
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField = "designID" HeaderText = "Design ID" />
                        <asp:BoundField DataField = "status" HeaderText = "Status" />                          
                        <asp:ImageField DataImageUrlField="designPath" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "Preview Image">
                        
                        
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
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnNext" runat="server" style="width: 41px" Text="Next" />
                </td></tr>
             

                 
        
        
        </table>

    </div>

    </asp:Content>


