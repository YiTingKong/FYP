Public Class ClientReport
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If ClientModule.userName = "" Then
            Response.Redirect("~/Client/ClientHome.aspx")
        End If
        Label1.Text = ClientModule.userName
        If DropDownList1.Text = "Yearly Order Report" Then
            GridView1.Visible = True
            GridView2.Visible = False
            GridView3.Visible = False
            DropDownList2.Visible = True
        ElseIf DropDownList1.Text = "Yearly Payment Report" Then
            GridView1.Visible = False
            GridView2.Visible = True
            GridView3.Visible = False
            DropDownList2.Visible = True
        ElseIf DropDownList1.Text = "Overall Order And Payment Report" Then
            GridView1.Visible = False
            GridView2.Visible = False
            GridView3.Visible = True
            DropDownList2.Visible = False
        End If
    End Sub

End Class