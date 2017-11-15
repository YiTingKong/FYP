<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Admin.Master" CodeBehind="AdminInfoDelete.aspx.vb" Inherits="FYP.AdminInfoDelete" %>
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
        <div style="margin-top:50px; margin-left:150px; float:left; height:auto " aria-orientation="horizontal">
            <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Update Admin Details"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Label ID="lblUserName" runat="server" Text="User Name : "></asp:Label>
            &nbsp; &nbsp;
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
            &nbsp;
            <asp:Button ID="btnSearch" runat="server" Text="Search" />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
            <asp:Image ID="imgProfile" runat="server" Height="200px" Width="200px" Visible="false"/>
            <br />
            <br />
            <asp:Label ID="lblName" runat="server" Text="Name : " Visible="false"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblVName" runat="server" Visible="false"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblType" runat="server" Text="Admin Position : " Visible="False"></asp:Label>
            &nbsp;<asp:Label ID="lblVType" runat="server" Visible="false"></asp:Label>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnDelete" runat="server" Text="Delete" Visible="false"/>
            <br />
            <br />
            <br />
        </div>
</asp:Content>
