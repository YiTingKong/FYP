<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Admin.Master" CodeBehind="AdminMemberUpdate.aspx.vb" Inherits="FYP.AdminMemberUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="Tree View Menu" style="margin-top:50px; float:left; height:auto">
    <asp:TreeView ID="tvProducts" runat="server" BorderStyle="None" ForeColor="#3A3A3A">
        <Nodes>
            <asp:TreeNode Text="Member" Value="Member">
                <asp:TreeNode Text="View Members" Value="VC" NavigateUrl="~/Admin/AdminMemberView.aspx"></asp:TreeNode>
                <asp:TreeNode Text="Update Members" Value="UC" NavigateUrl="~/Admin/AdminClothesUpdate.aspx"></asp:TreeNode>
            </asp:TreeNode>
        </Nodes>
    </asp:TreeView>
    </div>
    <div style="margin-top:50px; margin-left:150px; float:left; height:auto " aria-orientation="horizontal">
            <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Update Member Details"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblUserName" runat="server" Text="User Name : "></asp:Label>
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
&nbsp;
            <asp:Button ID="btnSearch" runat="server" Text="Search" />
            <br />
            <br />
            <br />
            <asp:Label ID="lblName" runat="server" Text="User Name : "></asp:Label>
&nbsp;<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
&nbsp;
            <br />
            <br />
            <asp:Label ID="lblNameDisplay" runat="server" Text="Name : "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtNameDisplay" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblGender" runat="server" Text="Gender : "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlGender" runat="server">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblContact" runat="server" Text="Contact : "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtContact" runat="server" TextMode="Number"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblEmail" runat="server" Text="Email : "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtEmail" runat="server" Width="285px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblAddress" runat="server" Text="Address : "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtAddress" runat="server" Height="60px" TextMode="MultiLine" Width="291px"></asp:TextBox>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnUpdate" runat="server" Text="Update" />
&nbsp;<asp:Button ID="btnReset" runat="server" Text="Reset" />
            <br />
            <br />
            <br />
    </div>
</asp:Content>
