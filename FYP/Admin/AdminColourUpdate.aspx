<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Admin.Master" CodeBehind="AdminColourUpdate.aspx.vb" Inherits="FYP.AdminColourUpdate" %>
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
                <asp:TreeNode Text="Verify Design" Value="Verify Design"></asp:TreeNode>
            </asp:TreeNode>
            <asp:TreeNode Text="Material" Value="Material" >
                <asp:TreeNode Text="Create Material" Value="Create Material" NavigateUrl="~/Admin/AdminColourCreate.aspx"></asp:TreeNode>
                <asp:TreeNode Text="Update Material" Value="Update Material"></asp:TreeNode>
            </asp:TreeNode>
        </Nodes>
    </asp:TreeView>
        </div>
        <div style="margin-top:50px; margin-left:200px; float:left; height:auto " aria-orientation="horizontal">
            <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Update Colour Details"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Label ID="lblColour" runat="server" Text="Colour : "></asp:Label>
            <asp:TextBox ID="txtColour" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblStatus" runat="server" Text="Status : "></asp:Label>
            &nbsp;<asp:DropDownList ID="ddlStatus" runat="server">
                <asp:ListItem>Available</asp:ListItem>
                <asp:ListItem>Not Available</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCreateC" runat="server" Text="Create" />
&nbsp;
            <asp:Button ID="btnResetC" runat="server" Text="Reset" />
            <br />
            <br />
            <br />
            <asp:Label ID="lblTitleM" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Update Material Details"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Label ID="lblMaterial" runat="server" Text="Material : "></asp:Label>
            <asp:TextBox ID="txtMaterial" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblStatusM" runat="server" Text="Status : "></asp:Label>
            &nbsp;&nbsp;
            <asp:DropDownList ID="ddlStatusM" runat="server">
                <asp:ListItem>Available</asp:ListItem>
                <asp:ListItem>Not Available</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCreateM" runat="server" Text="Create" />
&nbsp;
            <asp:Button ID="btnResetM" runat="server" Text="Reset" />
            <br />
            <br />
            <br />
        </div>

    <div style="margin-top:50px; margin-left:100px; float:left; height:auto " aria-orientation="horizontal">
            <asp:Label ID="lblTitleA" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Update Area Details"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Label ID="lblArea" runat="server" Text="Area : "></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtArea" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblStatusA" runat="server" Text="Status : "></asp:Label>
            <asp:DropDownList ID="ddlStatusA" runat="server">
                <asp:ListItem>Available</asp:ListItem>
                <asp:ListItem>Not Available</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCreateA" runat="server" Text="Create" />
&nbsp;
            <asp:Button ID="btnResetA" runat="server" Text="Reset" />
            <br />
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Update Location Details"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Label ID="lblLocation" runat="server" Text="Location : "></asp:Label>
            <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblAreaL" runat="server" Text="Area : "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlAreaL" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblStatusL" runat="server" Text="Status : "></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlStatusL" runat="server">
                <asp:ListItem>Available</asp:ListItem>
                <asp:ListItem>Not Available</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCreateL" runat="server" Text="Create" />
&nbsp;
            <asp:Button ID="btnResetL" runat="server" Text="Reset" />
            <br />
            <br />
            <br />
        </div>
</asp:Content>
