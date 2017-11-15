<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Admin.Master" CodeBehind="AdminClothesDelete.aspx.vb" Inherits="FYP.AdminClothesDelete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div id="Tree View Menu" style="margin-top:50px; float:left; height:auto">    
    <asp:TreeView ID="tvProducts" runat="server" BorderStyle="None" ForeColor="#3A3A3A">
        <Nodes>
            <asp:TreeNode Text="Clothes" Value="Clothes">
                <asp:TreeNode Text="View Clothes" Value="VC" NavigateUrl="~/Admin/AdminClothesView.aspx"></asp:TreeNode>
                <asp:TreeNode Text="Create Clothes" Value="CC" NavigateUrl="~/Admin/AdminClothesCreate.aspx"></asp:TreeNode>
                <asp:TreeNode Text="Update Clothes" Value="UC" NavigateUrl="~/Admin/AdminClothesUpdate.aspx"></asp:TreeNode>
                <asp:TreeNode Text="Delete Clothes" Value="DC" NavigateUrl="~/Admin/AdminClothesDelete.aspx"></asp:TreeNode>
            </asp:TreeNode>
            <asp:TreeNode Text="Design" Value="Design">
                <asp:TreeNode Text="View Design" Value="VD" NavigateUrl="~/Admin/AdminDesignView.aspx"></asp:TreeNode>
                <asp:TreeNode Text="Create Design" Value="CD" NavigateUrl="~/Admin/AdminDesignCreate.aspx"></asp:TreeNode>
                <asp:TreeNode Text="Update Design" Value="UD" NavigateUrl="~/Admin/AdminDesignUpdate.aspx"></asp:TreeNode>
                <asp:TreeNode Text="Delete Design" Value="DD" NavigateUrl="~/Admin/AdminDesignDelete.aspx"></asp:TreeNode>
            </asp:TreeNode>
            <asp:TreeNode Text="Material" Value="Material" NavigateUrl="~/Admin/AdminColourCreate.aspx"></asp:TreeNode>
        </Nodes>
    </asp:TreeView>
    </div>

    <div style="margin-top:50px; margin-left:150px; float:left; height:auto " aria-orientation="horizontal">
            <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Delete Clothes"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Label ID="lblclothID" runat="server" Text="Cloth ID : "></asp:Label>
&nbsp;<asp:DropDownList ID="ddlClothID" runat="server">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSearch" runat="server" Text="Search" />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Image ID="imgDis" runat="server" Height="200px" Width="200px" Visible ="False" />
            <br />
            <asp:Label ID="lblSize" runat="server" Text="Size : " Visible ="False"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblSizeDetail" runat="server" Visible ="False"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblMaterial" runat="server" Text="Material : " Visible ="False"></asp:Label>
            <asp:Label ID="lblMaterialDetail" runat="server" Visible ="False"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblType" runat="server" Text="Type : " Visible ="False"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblTypeDetail" runat="server" Visible ="False"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblColour" runat="server" Text="Colour : " Visible ="False"></asp:Label>
&nbsp;
            <asp:Label ID="lblColourDetail" runat="server" Visible ="False"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblPrice" runat="server" Text="Price : " Visible ="False"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblPriceDetail" runat="server"></asp:Label>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnDelete" runat="server" Text="Delete" Visible ="False"/>
            <br />
            <br />
            <br />
    </div>
</asp:Content>
