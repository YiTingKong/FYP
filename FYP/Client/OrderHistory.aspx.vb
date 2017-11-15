Imports System.Data.SqlClient
Imports System.Drawing

Public Class OrderHistory
    Inherits System.Web.UI.Page
    Dim connection As SqlConnection = Nothing
    Dim conn As String = ConfigurationManager.ConnectionStrings("FYPDBConnectionString").ConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If ClientModule.userName = "" Then
            Response.Redirect("~/Client/ClientHome.aspx")
        End If
        Label1.Text = ClientModule.userName

    End Sub

    Protected Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim err As New StringBuilder()
        Dim ctr As Control = Nothing
        Dim selectedRow As Integer = GridView1.SelectedIndex

        If selectedRow = -1 Then
            err.AppendLine("- Please select a design.")
            ctr = If(ctr, GridView1)
        End If

        'show error message
        If err.Length > 0 Then
            MsgBox(err.ToString(), , "Input Error")
            ctr.Focus()
            Return
        End If

        OrderModule.colour = GridView1.Rows(selectedRow).Cells(2).Text
        OrderModule.size = GridView1.Rows(selectedRow).Cells(3).Text
        OrderModule.type = GridView1.Rows(selectedRow).Cells(6).Text
        OrderModule.material = GridView1.Rows(selectedRow).Cells(4).Text
        OrderModule.designID = GridView1.Rows(selectedRow).Cells(7).Text
        'OrderModule.clothID = GridView1.Rows(selectedRow).Cells(1).Text
        Response.Redirect("~/Client/OrderDetail.aspx")
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        GridView1.SelectedRow.BackColor = Color.PaleGreen
    End Sub
End Class