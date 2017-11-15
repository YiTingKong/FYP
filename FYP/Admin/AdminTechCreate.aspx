<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Admin.Master" CodeBehind="AdminTechCreate.aspx.vb" Inherits="FYP.AdminTechCreate" %>
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
            <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Create New Technician"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblJobDate" runat="server" Text="Start Job Date : "></asp:Label>
            <asp:Calendar ID="techJobDate" OnDayRender="CalendarDRender" runat="server" BorderWidth="2px"
                          NextPrevFormat="FullMonth" BackColor="White" Width="350px" ForeColor="Black"
                          Height="190px" Font-Size="9pt" Font-Names="Verdana" BorderColor="Black">
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
            <asp:Label ID="lblTech" runat="server" Text="Select the profile image for Technician : "></asp:Label>
            <br />
            <asp:FileUpload ID="fuTech" runat="server" />
            <br />
            <br />
            <asp:Label ID="lblTechName" runat="server" Text="Technician Name : "></asp:Label>
            <asp:TextBox ID="txtTName" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblArea" runat="server" Text="Area : "></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlArea" runat="server">
            </asp:DropDownList>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:Button ID="btnCreate" runat="server" Text="Create" />
            &nbsp;<asp:Button ID="btnReset" runat="server" Text="Reset" />
            <br />
            <br />
            <br />
        </div>

</asp:Content>
