Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO

Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim err As New StringBuilder()
        Dim ctr As Control = Nothing

        'Validation
        If txtUsername.Text = "" Then
            err.AppendLine("- Please enter username.")
            ctr = If(ctr, txtUsername)
        End If

        If txtPassword.Text = "" Then
            err.AppendLine("- Please enter password.")
            ctr = If(ctr, txtPassword)
        End If

        'show error message
        If err.Length > 0 Then
            MsgBox(err.ToString(), , "Input Error")
            ctr.Focus()
            Return
        End If

        Dim connection As SqlConnection = Nothing
        Dim conn As String = ConfigurationManager.ConnectionStrings("FYPDBConnectionString").ConnectionString
        connection = New SqlConnection(conn)
        connection.Open()
        Dim sql As String = "SELECT * FROM Login WHERE userName = @username"
        Dim cmd As SqlCommand = New SqlCommand(sql, connection)
        cmd.Parameters.AddWithValue("@userName", txtUsername.Text.Trim())
        Dim dtr As SqlDataReader
        dtr = cmd.ExecuteReader

        Dim password As String

        If dtr.HasRows Then
            dtr.Read()
            password = dtr.Item("password")
            If password.Equals(txtPassword.Text) Then
                ClientModule.userName = dtr.Item("userName")
                ClientModule.nickname = dtr.Item("name")
                ClientModule.email = dtr.Item("email")
                MsgBox("Login successfully. Redirecting to homepage.", , "Congratulation")
                Response.Redirect("~/Client/ClientHome.aspx")
            Else
                MsgBox("Incorrect username or password. Please try again.", , "Important Note")
            End If
        Else
            MsgBox("Username not found. Please try again.", , "Important Note")
        End If

    End Sub

    Protected Sub btnForgot_Click(sender As Object, e As EventArgs) Handles btnForgot.Click
        Response.Redirect("~/Client/ForgotPassword.aspx")
    End Sub
End Class