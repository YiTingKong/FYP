Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class AdminForgotPasswordP2
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As ImageClickEventArgs) Handles btnSubmit.Click
        Dim user As String = CType(Session.Item("userName"), String)

        'database
        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\FinalYearProject\FYP\App_Data\FYPdatabase.mdf;Integrated Security=True")
        Try
            connection.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim err As New StringBuilder()

        'validation
        If txtNPassword.Text = "" Then
            err.AppendLine("- Please enter New Password.")
        End If

        If txtCPassword.Text = "" Then
            err.AppendLine("- Please enter Confirm Password.")
        End If

        'display error messages
        If err.Length > 0 Then
            MessageBox.Show(err.ToString(), "Input Error")
            Return
        End If

        'update database
        If txtNPassword.Text.Equals(txtCPassword.Text) Then
            Try
                If connection.State = ConnectionState.Open Then connection.Close()
                connection.Open()
                Dim cmd As SqlCommand = New SqlCommand("UPDATE Login SET password = @pwd WHERE userName = @userName", connection)
                cmd.Parameters.AddWithValue("@userName", user)
                cmd.Parameters.AddWithValue("@pwd", txtNPassword.Text)
                cmd.ExecuteNonQuery()
                cmd.Dispose()

                MessageBox.Show("Your password has been changed!", "Congratulation")
                'Server.Transfer will cause thread aborted error message
                Server.Execute("AdminLoginPage.aspx", True)

            Catch ex As Exception
                MsgBox("Trace No 4: System Error or Data Error!" + Chr(13) + ex.Message + Chr(13) + "Please Contact Your System Administrator!", vbInformation, "Message")
            End Try

        Else
            'pasword not match
            MessageBox.Show("New Password is not match with the Confirm Password", "Input Error")
        End If

    End Sub
End Class