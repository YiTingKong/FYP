<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Admin.Master" CodeBehind="AdminMachineView.aspx.vb" Inherits="FYP.AdminMachineView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="Tree View Menu" style="margin-top:50px; float:left; height:auto">
    <asp:TreeView ID="tvProducts" runat="server" BorderStyle="None" ForeColor="#3A3A3A">
        <Nodes> 
            <asp:TreeNode Text="Machine" Value="Design">
                <asp:TreeNode Text="View Machines" Value="VD" NavigateUrl="~/Admin/AdminMachineView.aspx"></asp:TreeNode>
                <asp:TreeNode Text="Create Machines" Value="CD" NavigateUrl="~/Admin/AdminMachineCreate.aspx"></asp:TreeNode>
                <asp:TreeNode Text="Update Machines" Value="UD" NavigateUrl="~/Admin/AdminMachineUpdate.aspx"></asp:TreeNode>
                <asp:TreeNode Text="Delete Machines" Value="DD" NavigateUrl="~/Admin/AdminMachineDelete.aspx"></asp:TreeNode>
            </asp:TreeNode>
        </Nodes>
    </asp:TreeView>
        </div>
        <div style="margin-top:50px; margin-left:150px; float:left; height:auto " aria-orientation="horizontal">
            <asp:GridView ID="gvMachine" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="OnPageIndexChanging" PageSize="10"
                HeaderStyle-BackColor="CornflowerBlue" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" CellPadding="5">
                <Columns>
                    <asp:BoundField DataField="MachineID" HeaderText="Machine ID" />
                    <asp:BoundField DataField="model" HeaderText="Machine Model" />
                    <asp:BoundField DataField="colour" HeaderText="Machine Colour" />
                    <asp:BoundField DataField="startDate" HeaderText="Start Date" DataFormatString="{0:dd/MM/yyyy}"/>
                    <asp:BoundField DataField="locationName" HeaderText="Machine Location" />                  
                </Columns>
            </asp:GridView>
            <br />
            <br />
        </div>
</asp:Content>
