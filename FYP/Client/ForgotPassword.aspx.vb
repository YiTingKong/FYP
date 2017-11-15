Imports System.Data.SqlClient
Imports System.Net
Imports System.Net.Mail



Public Class ForgotPassword
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim err As New StringBuilder()
        Dim ctr As Control = Nothing

        'Validation
        If txtUsername.Text = "" Then
            err.AppendLine("- Please enter username.")
            ctr = If(ctr, txtUsername)
        End If

        If txtAnswer.Text = "" Then
            err.AppendLine("- Please enter security answer.")
            ctr = If(ctr, txtAnswer)
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
        Dim temp As String = GetRandomString(10)

        If dtr.HasRows Then
            dtr.Read()
            If dtr.Item("securityQuestion") = ddlQuestion.SelectedValue.ToString() AndAlso dtr.Item("securityAns").ToString.ToLower = txtAnswer.Text.ToLower() Then

                Try
                    Dim mail = New MailMessage()
                    mail.From = New MailAddress("testingprogram80@gmail.com")
                    Dim smtp = New SmtpClient()
                    '25 if use phone data
                    '587 if use wifi
                    smtp.Port = 25
                    smtp.EnableSsl = True
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                    smtp.UseDefaultCredentials = False
                    smtp.Credentials = New NetworkCredential("testingprogram80@gmail.com", "123456789abc")
                    smtp.Host = "smtp.gmail.com"

                    mail.To.Add(dtr.Item("email"))
                    mail.IsBodyHtml = True
                    Dim st As New StringBuilder

                    dtr.Close()

                    Dim updatesql As String = "Update Login SET password = @password WHERE userName = @username"
                    Dim updatecmd As SqlCommand = New SqlCommand(updatesql, connection)
                    updatecmd.Parameters.AddWithValue("@password", temp)
                    updatecmd.Parameters.AddWithValue("@userName", txtUsername.Text.Trim())
                    updatecmd.ExecuteNonQuery()

                    st.AppendLine("Your temperory password is: " + temp + ". Please change your password after this.")
                    mail.Body = st.ToString()
                    smtp.Send(mail)
                    MsgBox("Your temperory password has been sent to your email.", , "Important Note")

                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            Else
                MsgBox("Security question or answer mismatch. Please try again.", , "Important Note")
            End If
        Else
            MsgBox("Username not found. Please try again.", , "Important Note")
        End If

    End Sub

    Public Function GetRandomString(ByVal iLength As Integer) As String
        Dim sResult As String = ""
        Dim rdm As New Random()

        For i As Integer = 1 To iLength
            sResult &= ChrW(rdm.Next(32, 126))
        Next

        Return sResult
    End Function
End Class