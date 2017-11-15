<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Admin.Master" CodeBehind="AdminMachineCreate.aspx.vb" Inherits="FYP.AdminMachineCreate" %>
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
            <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Create New Machine"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblstartDate" runat="server" Text="Start Run Date : "></asp:Label>
            <asp:Calendar ID="machStartDate" OnDayRender="CalendarDRender" runat="server" BorderWidth="2px"
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
            <asp:Label ID="lblArea" runat="server" Text="Area : "></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlArea" runat="server" AutoPostBack="true" CausesValidation="false" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblLocation" runat="server" Text="Location : "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlLocation" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblMachModel" runat="server" Text="Machine Model : "></asp:Label>
            <asp:TextBox ID="txtModel" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblColor" runat="server" Text="Machine Color : "></asp:Label>
            &nbsp;<asp:TextBox ID="txtColor" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblAddress" runat="server" Text="Address : "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
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
