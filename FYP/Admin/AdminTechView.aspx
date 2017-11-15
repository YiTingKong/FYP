<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Admin.Master" CodeBehind="AdminTechView.aspx.vb" Inherits="FYP.AdminTechView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="Tree View Menu" style="margin-top:50px; float:left; height:auto">
    <asp:TreeView ID="tvProducts" runat="server" BorderStyle="None" ForeColor="#3A3A3A">
        <Nodes> 
            <asp:TreeNode Text="Technician" Value="Design">
                <asp:TreeNode Text="View Technician" Value="VD" NavigateUrl="~/Admin/AdminTechView.aspx"></asp:TreeNode>
                <asp:TreeNode Text="Create Technician" Value="CD" NavigateUrl="~/Admin/AdminTechCreate.aspx"></asp:TreeNode>
                <asp:TreeNode Text="Update Technician" Value="UD" NavigateUrl="~/Admin/AdminTechUpdate.aspx"></asp:TreeNode>
                <asp:TreeNode Text="Delete Technician" Value="DD" NavigateUrl="~/Admin/AdminTechDelete.aspx"></asp:TreeNode>
            </asp:TreeNode>
        </Nodes>
    </asp:TreeView>
        </div>
        <div style="margin-top:50px; margin-left:150px; float:left; height:auto " aria-orientation="horizontal">
            <asp:GridView ID="gvTech" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="OnPageIndexChanging" PageSize="10"
                HeaderStyle-BackColor="CornflowerBlue" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" CellPadding="5">
                <Columns>
                    <asp:BoundField DataField="techID" HeaderText="Technician ID" />
                    <asp:BoundField DataField="techName" HeaderText="Technician Name" />
                    <asp:BoundField DataField="startJobDate" HeaderText="Start Job Date" DataFormatString="{0:dd/MM/yyyy}"/>
                    <asp:BoundField DataField="areaName" HeaderText="Responsible Area" />                  
                </Columns>
            </asp:GridView>
            <br />
            <br />
        </div>
</asp:Content>
