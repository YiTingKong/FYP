<%@ Page Language="vb" MasterPageFile="~/Client/ClientSide.Master" AutoEventWireup="false" CodeBehind="UploadDesign.aspx.vb" Inherits="FYP.UploadDesign" %>

<asp:Content ID ="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <style type="text/css">
             .auto-style5 {
            width: 133px;
            height: 26px;
            font-weight: bold;
        }
        .auto-style6 {
            width: 23px;
            height: 26px;
        }
        .auto-style9 {
            height: 26px;
            width: 126px;
        }
        .auto-style10 {
            width: 303px;
            margin-right: 0px;
        }
        </style>
    
    <div style="width: 1000px;height:1000px;color:teal">
    <table class="auto-style10">
            <tr><td colspan="3"><strong>Upload Official Design</strong></td></tr>
                <tr><td colspan="3">&nbsp;</td></tr>
            <tr>
                    <td class="auto-style5">Design</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
                        <asp:FileUpload ID="imgUpload" runat="server" />
                    </td>
            </tr>
        
        <tr><td colspan="3">&nbsp;</td></tr>
        <tr><td colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="99px" />
&nbsp;
            <br />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Client/CheckDesign.aspx">Click here to check design status</asp:HyperLink>
            </td></tr>
       

        </table>
    </div>
    </asp:Content>