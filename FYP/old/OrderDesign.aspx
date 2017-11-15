<%@ Page Language="vb" MasterPageFile="~/Client/ClientSide.Master" AutoEventWireup="false" CodeBehind="OrderDesign.aspx.vb" Inherits="FYP.OrderDesign" %>

<asp:Content ID ="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
&nbsp;<style type="text/css">
        .auto-style5 {
            width: 100px;
            height: 26px;
            font-weight: bold;
        }
        .auto-style6 {
            width: 23px;
            height: 26px;
        }
        .auto-style9 {
            height: 26px;
            width: 718px;
        }
       

        </style><div style="color:teal;height:1000px;width:1000px">
        <table class>
            <tr><td colspan="3"><strong>Select Design</strong></td></tr>
            <tr><td colspan="3">&nbsp;</td></tr>
            <tr>
                    <td class="auto-style5">Design Type</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
<asp:RadioButtonList ID="radDesignType" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                            <asp:ListItem>General Design</asp:ListItem>
                            <asp:ListItem>Customize Design</asp:ListItem>
                        </asp:RadioButtonList>
 </td>
            </tr>
            <tr> <td class="auto-style5">
                <asp:Label ID="lblDesign" runat="server" Visible="False">Design</asp:Label>
                </td>
                    <td class="auto-style6">
                        <asp:Label ID="lbl" runat="server" Text=":" Visible="False"></asp:Label>
                </td>
                    <td class="auto-style9">
                        <asp:FileUpload ID="FileUpload1" runat="server" Visible="False" />
                        <br />
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" Visible="False" >
                        <Columns>

                        <asp:BoundField DataField = "designID" HeaderText = "Design ID" />  

                        <asp:ImageField DataImageUrlField="designPath" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "Preview Image"/>
                        
                        
                        </Columns> 

                        </asp:GridView>
                </tr>
          
            <tr><td colspan="3">&nbsp;</td></tr>
            <tr><td colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnNext" runat="server" Text="Next" style="height: 26px" />
                </td></tr>
            
        
        
        </table>

    </div>

    </asp:Content>

