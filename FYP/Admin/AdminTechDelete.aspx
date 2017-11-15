<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Admin.Master" CodeBehind="AdminTechDelete.aspx.vb" Inherits="FYP.AdminTechDelete" %>
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
            <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Update Technician Details"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblTechID" runat="server" Text="Technician ID : "></asp:Label>
            <asp:DropDownList ID="ddlTech" runat="server">
            </asp:DropDownList>
&nbsp;&nbsp;
            <asp:Button ID="btnSearch" runat="server" Text="Search" />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:Image ID="imgTech" runat="server" Height="200px" Width="200px" Visible="false" />
            <br />
            <br />
            <asp:Label ID="lblTechName" runat="server" Text="Name : " Visible="false" ></asp:Label>
            <asp:Label ID="lblName" runat="server" Visible="false" ></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblRArea" runat="server" Text="Area : " Visible="False" ></asp:Label>
&nbsp;
            <asp:Label ID="lblArea" runat="server" Visible="false" ></asp:Label>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:Button ID="btnDelete" runat="server" Text="Delete" Visible="false"  />
            <br />
        </div>
</asp:Content>
