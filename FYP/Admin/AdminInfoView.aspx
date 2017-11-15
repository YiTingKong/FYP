<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Admin.Master" CodeBehind="AdminInfoView.aspx.vb" Inherits="FYP.AdminInfoView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="Tree View Menu" style="margin-top:50px; float:left; height:auto">
    <asp:TreeView ID="tvProducts" runat="server" BorderStyle="None" ForeColor="#3A3A3A">
        <Nodes> 
            <asp:TreeNode Text="Admin" Value="Design">
                <asp:TreeNode Text="View Admin" Value="VD" NavigateUrl="~/Admin/AdminInfoView.aspx"></asp:TreeNode>
                <asp:TreeNode Text="Create Admin" Value="CD" NavigateUrl="~/Admin/AdminInfoCreate.aspx"></asp:TreeNode>
                <asp:TreeNode Text="Update Admin" Value="UD" NavigateUrl="~/Admin/AdminInfoUpdate.aspx"></asp:TreeNode>
                <asp:TreeNode Text="Delete Admin" Value="DD" NavigateUrl="~/Admin/AdminInfoDelete.aspx"></asp:TreeNode>
            </asp:TreeNode>
        </Nodes>
    </asp:TreeView>
        </div>
        <div style="margin-top:50px; margin-left:50px; float:left; height:auto " aria-orientation="horizontal">
            <asp:GridView ID="gvAdmin" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="OnPageIndexChanging" PageSize="10"
                HeaderStyle-BackColor="CornflowerBlue" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" CellPadding="5">
                <Columns>
                    <asp:BoundField DataField="userName" HeaderText="Login Name" /> 
                    <asp:BoundField DataField="name" HeaderText="Admin Name" />                    
                    <asp:BoundField DataField="ICNumber" HeaderText="IC Number" />  
                    <asp:BoundField DataField="contact" HeaderText="Contact Number" />
                    <asp:BoundField DataField="email" HeaderText="Email"/>
                    <asp:BoundField DataField="type" HeaderText="Position" />                  
                </Columns>
            </asp:GridView>
            <br />
            <br />
        </div>
</asp:Content>
