Imports System.Data.SqlClient
Imports System.Drawing

Public Class CheckDesign
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If ClientModule.userName = "" Then
            Response.Redirect("~/Client/ClientHome.aspx")
        End If
        lblUsername.Text = ClientModule.userName

        Dim connection2 As SqlConnection = Nothing
        Dim conn2 As String = ConfigurationManager.ConnectionStrings("FYPDBConnectionString").ConnectionString
        Dim dt2 As New DataTable()
        Dim sql2 As String = "Select designID, status, validity, startDate, price, designPath From Design Where userName = @userName AND status = @status"
        Dim cmd2 As New SqlCommand(sql2)
        cmd2.Parameters.AddWithValue("@userName", ClientModule.userName)
        cmd2.Parameters.AddWithValue("@status", "Success")
        Dim con2 As New SqlConnection(conn2)
        Dim sda2 As New SqlDataAdapter()
        cmd2.CommandType = CommandType.Text
        cmd2.Connection = con2
        Try
            con2.Open()
            sda2.SelectCommand = cmd2
            sda2.Fill(dt2)
            GridView2.DataSource = dt2
            GridView2.DataBind()
        Catch ex As Exception
            Response.Write(ex.Message)
        Finally
            con2.Close()
            sda2.Dispose()
            con2.Dispose()
        End Try

        Dim connection As SqlConnection = Nothing
        Dim conn As String = ConfigurationManager.ConnectionStrings("FYPDBConnectionString").ConnectionString
        Dim dt As New DataTable()
        Dim sql As String = "Select designID, status, validity, startDate, price, designPath From Design Where userName = @userName AND status <> @status"
        Dim cmd As New SqlCommand(sql)
        cmd.Parameters.AddWithValue("@userName", ClientModule.userName)
        cmd.Parameters.AddWithValue("@status", "")
        Dim con As New SqlConnection(conn)
        Dim sda As New SqlDataAdapter()
        cmd.CommandType = CommandType.Text
        cmd.Connection = con
        Try
            con.Open()
            sda.SelectCommand = cmd
            sda.Fill(dt)
            GridView1.DataSource = dt
            GridView1.DataBind()
        Catch ex As Exception
            Response.Write(ex.Message)
        Finally
            con.Close()
            sda.Dispose()
            con.Dispose()
        End Try



    End Sub

    Protected Sub GridView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView2.SelectedIndexChanged
        GridView2.SelectedRow.BackColor = Color.PaleGreen
    End Sub

    Protected Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim err As New StringBuilder()
        Dim ctr As Control = Nothing
        Dim designID As String
        Dim selectedRow As Integer = GridView2.SelectedIndex


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
        designID = GridView2.Rows(selectedRow).Cells(1).Text
        DesignModule.designID = designID
        Response.Redirect("~/Client/DesignApproved.aspx")
    End Sub
End Class