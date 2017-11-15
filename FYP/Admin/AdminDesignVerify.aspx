<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Admin.Master" CodeBehind="AdminDesignVerify.aspx.vb" Inherits="FYP.AdminDesignVerify" %>
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
            <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Verify Design"></asp:Label>
            <br />
            <br />
            <br />
        <asp:Label ID="lbldesignID" runat="server" Text="Design ID : "></asp:Label>
&nbsp;<asp:DropDownList ID="ddlDesignID" runat="server">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSearch" runat="server" Text="Search" />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:Image ID="imgDesign" runat="server" Height="180px" Width="180px" Visible ="False"  />
            <br />
            <br />
            <asp:Label ID="lblstartDate" runat="server" Text="Start Run Date : " Visible ="False"></asp:Label>
            <asp:Calendar ID="designStartDate" OnDayRender="CalendarDRender" runat="server" BorderWidth="2px"
                          NextPrevFormat="FullMonth" BackColor="White" Width="350px" ForeColor="Black"
                          Height="190px" Font-Size="9pt" Font-Names="Verdana" BorderColor="Black" Visible ="False">
                <TodayDayStyle BackColor="#CCCCCC"></TodayDayStyle>
                <NextPrevStyle Font-Size="8pt" Font-Bold="True" ForeColor="#333333" VerticalAlign="Bottom">
                </NextPrevStyle>
                <DayHeaderStyle Font-Size="8pt" Font-Bold="True"></DayHeaderStyle>
                <SelectedDayStyle ForeColor="White" BackColor="#333399"></SelectedDayStyle>
                <TitleStyle Font-Size="12pt" Font-Bold="True" BorderWidth="2px" ForeColor="#333399"
                            BorderColor="Black" BackColor="White"></TitleStyle>                
                <OtherMonthDayStyle ForeColor="#999999"></OtherMonthDayStyle>
            </asp:Calendar>
            <br />
            <asp:Label ID="lblValid" runat="server" Text="Validity (month) : " Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtValid" runat="server" Visible="false"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblDesigner" runat="server" Text="Designer Information : " Visible="false"></asp:Label>
            <br />
            <asp:Label ID="lblUserName" runat="server" Text="User Name : " Visible="false"></asp:Label>
            <asp:TextBox ID="txtUserName" runat="server" Visible="false" Enabled="False"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblPrice" runat="server" Text="Price : " Visible="false"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtPrice" runat="server" Visible="false" TextMode="Number"></asp:TextBox>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnApprove" runat="server" Text="Approve" Visible="false"/>
            &nbsp;<asp:Button ID="btnReject" runat="server" Text="Reject" Visible ="False"/>
&nbsp;<br />
            <br />
            <br />
    </div>
</asp:Content>
