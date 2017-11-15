<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Admin.Master" CodeBehind="AdminInfoCreate.aspx.vb" Inherits="FYP.AdminCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="Tree View Menu" style="margin-top:50px; float:left; height:auto">
    <asp:TreeView ID="tvProducts" runat="server" BorderStyle="None" ForeColor="#3A3A3A">
        <Nodes> 
            <asp:TreeNode Text="Admin" Value="Design">
                <asp:TreeNode Text="View Admin" Value="VD" NavigateUrl="~/Admin/AdminInfoView.aspx"></asp:TreeNode>
                <asp:TreeNode Text="Create Admin" Value="CD" NavigateUrl="~/Admin/AdminInfoCreate.aspx"></asp:TreeNode>
                <asp:TreeNode Text="Update Admin" Value="UD" NavigateUrl="~/Admin/AdminInfoUpdate.aspx"></asp:TreeNode>
                <asp:TreeNode Text="Delete Admin" Value="DD" NavigateUrl="~/Admin/AdminInfoDelete.aspx"></asp:TreeNode>
            </asp:TreeNode>
        </Nodes>
    </asp:TreeView>
        </div>
        <div style="margin-top:50px; margin-left:150px; float:left; height:auto " aria-orientation="horizontal">
            <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Create New Admin"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Select Start Job Date : "></asp:Label>
            <asp:Calendar ID="jobStartDate" OnDayRender="CalendarDRender" runat="server" BorderWidth="2px"
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
            <asp:Label ID="lblImg" runat="server" Text="Profile Image : "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:FileUpload ID="fuImg" runat="server" />
            <br />
            <br />
            <asp:Label ID="lblUserName" runat="server" Text="User Name : "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblPassword" runat="server" Text="Password : "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtPassword" runat="server" MaxLength="10" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblName" runat="server" Text="Name : "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblContact" runat="server" Text="Contact : "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtContact" runat="server" MaxLength="12" TextMode="Number"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblIC" runat="server" Text="IC Number : "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtIC" runat="server" MaxLength="12" TextMode="Number"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblEmail" runat="server" Text="Email : "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtEmail" runat="server" Width="283px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblAddress" runat="server" Text="Address : "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtAddress" runat="server" Height="66px" TextMode="MultiLine" Width="289px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblSecQ" runat="server" Text="Security Question : "></asp:Label>
            <asp:DropDownList ID="ddlSecQ" runat="server">
                <asp:ListItem Value="Q1">What&#39;s your mother&#39;s middle name?</asp:ListItem>
                <asp:ListItem Value="Q2">Who was your childhood hero?</asp:ListItem>
                <asp:ListItem Value="Q3">What is the last name of your favourite teacher?</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblSecA" runat="server" Text="Security Answer : "></asp:Label>
&nbsp;
            <asp:TextBox ID="txtSecA" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblType" runat="server" Text="Admin Type : "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlType" runat="server">
                <asp:ListItem>Admin Leader</asp:ListItem>
                <asp:ListItem>Admin</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblGender" runat="server" Text="Gender : "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlGender" runat="server">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblStatus" runat="server" Text="Status : "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlStatus" runat="server">
                <asp:ListItem>Available</asp:ListItem>
                <asp:ListItem>Not Available</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCreate" runat="server" Text="Create" />
            &nbsp;<asp:Button ID="btnReset" runat="server" Text="Reset" />
            <br />
            <br />
            <br />
        </div>
</asp:Content>
