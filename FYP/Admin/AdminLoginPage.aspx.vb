Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class AdminLoginPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSignIn_Click(sender As Object, e As ImageClickEventArgs) Handles btnSignIn.Click
        'database
        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\FinalYearProject\FYP\App_Data\FYPdatabase.mdf;Integrated Security=True")
        Try
            connection.Open()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

        Dim err As New StringBuilder()
        'Dim ctr As Control = Nothing

        'validation
        If txtUName.Text = "" Then
            err.AppendLine("- Please enter username.")
            'ctr = If(ctr, txtUName)
        End If

        If txtpassword.Text = "" Then
            err.AppendLine("- Please enter password.")
            '    ctr = If(ctr, txtpassword)
        End If

        'display error messages
        If err.Length > 0 Then
            MessageBox.Show(err.ToString(), "Input Error")
            'ctr.Focus()
            Return

        End If

        'check login info
        Dim query As String = "SELECT * FROM Login WHERE type = @admin AND userName= @username"
        Dim cmd As SqlCommand = New SqlCommand(query, connection)
        cmd.Parameters.AddWithValue("@username", txtUName.Text)
        cmd.Parameters.AddWithValue("@admin", "admin")
        Dim dtr As SqlDataReader
        dtr = cmd.ExecuteReader

        Dim pword As String = txtpassword.Text

        If dtr.HasRows Then
            dtr.Read()
            If pword = dtr.Item("password") Then
                'set Login Info to AdminLoginSession
                AdminLoginSession.userName = txtUName.Text
                AdminLoginSession.email = dtr.Item("email")
                'AdminLoginSession.profilePic = dtr.Item("profilePic")
                'correct password
                MessageBox.Show("Login Success.", "Congratulation")
                Server.Transfer("AdminHome.aspx", True)
            Else
                'incorrect password
                txtUName.Text = ""
                txtpassword.Text = ""
                txtUName.Focus()
                MessageBox.Show("Incorrect username or password." & vbCrLf & "This is an Admin Login", "Sorry")

            End If
        Else
            'incorrect username
            txtUName.Text = ""
            txtpassword.Text = ""
            txtUName.Focus()
            MessageBox.Show("Incorrect username or password." & vbCrLf & "This is an Admin Login", "Sorry")
        End If

    End Sub
End Class