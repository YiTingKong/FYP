Imports System.Data.SqlClient
Imports System.Windows.Forms



Public Class AdminForgotPassword
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As ImageClickEventArgs) Handles btnSubmit.Click
        'pass username to next form
        Session("userName") = txtUName.Text

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
        If txtUName.Text = "" Then
            err.AppendLine("- Please enter User Name.")
        End If

        If txtSecAns.Text = "" Then
            err.AppendLine("- Please provide Answer for Security Question.")
        End If

        'display error messages
        If err.Length > 0 Then
            MessageBox.Show(err.ToString(), "Input Error")
            Return
        End If

        'check user info
        Dim query As String = "SELECT * FROM Login WHERE type = @admin AND userName= @username"
        Dim cmd As SqlCommand = New SqlCommand(query, connection)
        cmd.Parameters.AddWithValue("@username", txtUName.Text)
        cmd.Parameters.AddWithValue("@admin", "admin")
        Dim dtr As SqlDataReader
        dtr = cmd.ExecuteReader

        Dim ques As String = ddlSecQuestion.SelectedValue()
        Dim ans As String = txtSecAns.Text

        If dtr.HasRows Then
            'valid username 
            dtr.Read()
            If ques = dtr.Item("securityQuestion") Then
                'correct question
                If ans = dtr.Item("securityAns") Then
                    'correct answer
                    MessageBox.Show("Security Passed", "Congratulation")
                    Server.Transfer("AdminForgotPasswordP2.aspx", True)
                Else
                    'incorrect answer
                    txtUName.Text = ""
                    txtSecAns.Text = ""
                    txtUName.Focus()
                    MessageBox.Show("Invalid Username " & vbCrLf & "Incorrect Question or Answer", "Sorry")
                End If

            Else
                'incorrect question
                txtUName.Text = ""
                txtSecAns.Text = ""
                txtUName.Focus()
                MessageBox.Show("Invalid Username" & vbCrLf & "Incorrect Question or Answer", "Sorry")

            End If
        Else
            'incorrect username
            txtUName.Text = ""
            txtSecAns.Text = ""
            txtUName.Focus()
            MessageBox.Show("Invalid Username" & vbCrLf & "Incorrect Question or Answer", "Sorry")
        End If

    End Sub
End Class