Imports System.Data.SqlClient

Public Class ChangePassword
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If ClientModule.userName = "" Then
            Response.Redirect("~/Client/ClientHome.aspx")
        End If
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim err As New StringBuilder()
        Dim ctr As Control = Nothing

        'Validation     
        If txtOldPw.Text = "" Then
            err.AppendLine("- Please enter old password.")
            ctr = If(ctr, txtOldPw)
        End If

        If txtNewPassword.Text = "" Then
            err.AppendLine("- Please enter new password.")
            ctr = If(ctr, txtNewPassword)
        End If

        If txtConfPw.Text = "" Then
            err.AppendLine("- Please enter confirm password.")
            ctr = If(ctr, txtConfPw)
        End If

        If txtNewPassword.Text.Equals(txtConfPw.Text) Then
        Else
            err.AppendLine("- Confirm password mismatch.")
            ctr = If(ctr, txtConfPw)
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
        Dim sql As String = "SELECT password FROM Login WHERE userName = @username"
        Dim cmd As SqlCommand = New SqlCommand(sql, connection)
        cmd.Parameters.AddWithValue("@userName", ClientModule.userName)
        Dim dtr As SqlDataReader
        dtr = cmd.ExecuteReader
        Dim oldPw As String
        If dtr.HasRows Then
            dtr.Read()
            oldPw = dtr.Item("password")
            dtr.Close()
            If oldPw.Equals(txtOldPw.Text) Then
                Dim updatesql As String = "Update Login SET password = @password WHERE userName = @userName"
                Dim updatecmd As SqlCommand = New SqlCommand(updatesql, connection)
                updatecmd.Parameters.AddWithValue("@password", txtNewPassword.Text)
                updatecmd.Parameters.AddWithValue("@userName", ClientModule.userName)
                updatecmd.ExecuteNonQuery()
                MsgBox("Password changed successfully. Redirecting to home page.")
                Response.Redirect("~/Client/ClientHome.aspx")
            Else
                MsgBox("Incorrect old password.")
            End If
        End If


    End Sub
End Class