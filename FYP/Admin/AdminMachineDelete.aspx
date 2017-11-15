<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Admin.Master" CodeBehind="AdminMachineDelete.aspx.vb" Inherits="FYP.AdminMachineDelete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="Tree View Menu" style="margin-top:50px; float:left; height:auto">
    <asp:TreeView ID="tvProducts" runat="server" BorderStyle="None" ForeColor="#3A3A3A">
        <Nodes> 
            <asp:TreeNode Text="Technician" Value="Design">
                <asp:TreeNode Text="View Machines" Value="VD" NavigateUrl="~/Admin/AdminMachineView.aspx"></asp:TreeNode>
                <asp:TreeNode Text="Create Machines" Value="CD" NavigateUrl="~/Admin/AdminMachineCreate.aspx"></asp:TreeNode>
                <asp:TreeNode Text="Update Machines" Value="UD" NavigateUrl="~/Admin/AdminMachineUpdate.aspx"></asp:TreeNode>
                <asp:TreeNode Text="Delete Machines" Value="DD" NavigateUrl="~/Admin/AdminMachineDelete.aspx"></asp:TreeNode>
            </asp:TreeNode>
        </Nodes>
    </asp:TreeView>
        </div>
        <div style="margin-top:50px; margin-left:150px; float:left; height:auto " aria-orientation="horizontal">
            <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Delete Machine Detail"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblMachine" runat="server" Text="Machine ID : "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlMachine" runat="server">
            </asp:DropDownList>
&nbsp;
            <asp:Button ID="btnSearch" runat="server" Text="Search" />
            <br />
            <br />
            <asp:Label ID="lblArea" runat="server" Text="Area : " Visible="false"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblAreaDetail" runat="server" Visible="false"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblLocation" runat="server" Text="Location : " Visible="false"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblLocationDetail" runat="server" Visible="false"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblMachModel" runat="server" Text="Machine Model : " Visible="false"></asp:Label>
            <asp:Label ID="lblModelDetail" runat="server" Visible="false"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblColor" runat="server" Text="Machine Color : " Visible="false"></asp:Label>
            &nbsp;<asp:Label ID="lblColorDetail" runat="server" Visible="false"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblAddress" runat="server" Text="Address : " Visible="false"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
            <asp:Label ID="lblAddressDetail" runat="server" Visible="false"></asp:Label>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:Button ID="btnDelete" runat="server" Text="Delete" Visible="false"/>
            &nbsp;<br />
            <br />
            <br />
        </div>
</asp:Content>
