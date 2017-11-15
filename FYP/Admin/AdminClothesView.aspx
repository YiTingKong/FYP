<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Admin.Master" CodeBehind="AdminClothesView.aspx.vb" Inherits="FYP.AdminViewClothes" %>
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
            <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Size="X-Large" Text="View Clothes"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="gvClothes" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="OnPageIndexChanging" PageSize="5"
                HeaderStyle-BackColor="CornflowerBlue" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" CellPadding="5">
                <Columns>
                    <asp:BoundField DataField="clothID" HeaderText="Cloth ID" />
                    <asp:BoundField DataField="colour" HeaderText="Colour" />
                    <asp:BoundField DataField="size" HeaderText="Size" />
                    <asp:BoundField DataField="material" HeaderText="Material" />
                    <asp:BoundField DataField="priceEach" HeaderText="Price" />                    
                    <asp:ImageField DataImageUrlField="clothDesign" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText="Cloth Preview" />
                    <asp:ButtonField ButtonType="Image" ImageUrl="~/image/button_update.png" ControlStyle-Height="15px" ControlStyle-Width="15px" Text="Update" CommandName="Update"/>
                    <asp:ButtonField ButtonType="Image" ImageUrl="~/image/delete_button.png" ControlStyle-Height="15px" ControlStyle-Width="15px" Text="Delete" CommandName="Delete"/> 
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="UpdateButton" runat="server" ImageUrl="~/image/button_update.png" Height="20px" Width="20px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            
&nbsp;&nbsp;
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
        </div>
</asp:Content>
