<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Admin.Master" CodeBehind="AdminClothesUpdate.aspx.vb" Inherits="FYP.AdminClothesUpdate" %>
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
            <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Update Clothes Details"></asp:Label>
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
            <asp:Label ID="lblImage" runat="server" Text="Image : " Visible="false"></asp:Label>
            <asp:FileUpload ID="fuImg" runat="server" Visible="false" />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Image ID="imgDis" runat="server" Height="200px" Width="200px" Visible ="False"  />
            <br />
            <asp:Label ID="lblSize" runat="server" Text="Size : " Visible="false"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlSize" runat="server" Visible="false">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblMaterial" runat="server" Text="Material : " Visible="false"></asp:Label>
            <asp:DropDownList ID="ddlMaterial" runat="server" Visible="false">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblType" runat="server" Text="Type : " Visible="false"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlType" runat="server" Visible="false">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblColour" runat="server" Text="Colour : " Visible="false"></asp:Label>
&nbsp;
            <asp:DropDownList ID="ddlColour" runat="server" Visible="false">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblPrice" runat="server" Text="Price : " Visible="false"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtPrice" runat="server" TextMode="Number" Visible="false"></asp:TextBox>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnUpdate" runat="server" Text="Update" Visible="false"/>
            <asp:Button ID="btnReset" runat="server" Text="Reset" Visible="false"/>
            <br />
            <br />
            <br />
            <br />
    </div> 

</asp:Content>
