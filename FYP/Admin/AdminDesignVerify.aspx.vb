Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO.Path
Imports System.Net.Mail

Public Class AdminDesignVerify
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'database
        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\FinalYearProject\FYP\App_Data\FYPdatabase.mdf;Integrated Security=True")
        Try
            connection.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If Not Me.IsPostBack Then

            'designID
            Dim IDquery As String = "SELECT designID FROM Design WHERE status = @status"
            Dim IDcmd As SqlCommand = New SqlCommand(IDquery, connection)
            IDcmd.Parameters.AddWithValue("@status", "Pending")
            Dim IDdtr As SqlDataReader
            IDdtr = IDcmd.ExecuteReader

            If IDdtr.HasRows Then
                While IDdtr.Read()
                    ddlDesignID.Items.Add(IDdtr(0).ToString())
                End While
            End If
            IDdtr.Dispose()
        End If

        connection.Close()
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Me.GetData()
    End Sub

    Private Sub GetData()
        'database
        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\FinalYearProject\FYP\App_Data\FYPdatabase.mdf;Integrated Security=True")
        Try
            connection.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim designID As String = ddlDesignID.SelectedItem.ToString()

        Dim query As String = "SELECT designID, type, validity, startDate, price, userName, designPath FROM Design WHERE designID = @designID"
        Dim cmd As SqlCommand = New SqlCommand(query, connection)
        cmd.Parameters.AddWithValue("@designID", designID)
        Dim dtr As SqlDataReader
        dtr = cmd.ExecuteReader

        If dtr.HasRows Then
            dtr.Read()
            'Visible
            imgDesign.Visible = True
            lblstartDate.Visible = True
            designStartDate.Visible = True
            lblValid.Visible = True
            txtValid.Visible = True
            lblDesigner.Visible = True
            lblUserName.Visible = True
            txtUserName.Visible = True
            lblPrice.Visible = True
            txtPrice.Visible = True

            btnApprove.Visible = True
            btnReject.Visible = True

            imgDesign.ImageUrl = dtr.Item("designPath")
            txtUserName.Text = dtr.Item("userName")
        End If


        connection.Close()
    End Sub

    Protected Sub CalendarDRender(sender As Object, e As DayRenderEventArgs)
        If e.Day.Date.CompareTo(DateTime.Today) < 0 Then
            e.Day.IsSelectable = False
        End If
    End Sub

    Protected Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        Dim err As New StringBuilder()

        'validation
        If txtValid.Text = "" Then
            err.AppendLine("- Please enter validity(Month) of design.")
        End If

        If Not txtValid.Text = "" Then
            Dim validity As Integer = Convert.ToInt32(txtValid.Text)
            If validity < 1 Or validity > 24 Then
                err.AppendLine("- Validity(month) only between 1 to 24.")
            End If
        End If

        If txtPrice.Text = "" Then
            err.AppendLine("- Please enter the price.")
        End If

        'display error messages
        If err.Length > 0 Then
            MessageBox.Show(err.ToString(), "Input Error")
            Return
        End If

        'database
        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\FinalYearProject\FYP\App_Data\FYPdatabase.mdf;Integrated Security=True")
        Try
            connection.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim datetime As System.DateTime = designStartDate.SelectedDate
        Dim startDate As Date = datetime.Date

        Dim updateQuery As String = "UPDATE Design 
                                    SET status = @status, validity = @validity, startDate = @date, price = @price
                                    WHERE designID = @designID"

        Dim cmd As SqlCommand = New SqlCommand(updateQuery, connection)
        cmd.Parameters.AddWithValue("@status", "Success")
        cmd.Parameters.AddWithValue("@validity", txtValid.Text)
        cmd.Parameters.AddWithValue("@price", txtPrice.Text)
        cmd.Parameters.AddWithValue("@designID", ddlDesignID.SelectedValue)
        cmd.Parameters.AddWithValue("@date", startDate)
        cmd.ExecuteNonQuery()
        cmd.Dispose()

        MsgBox("Record updated.", MsgBoxStyle.Information)

        'email
        Dim query As String = "SELECT email FROM Login WHERE userName = @userName"
        Dim emailcmd As SqlCommand = New SqlCommand(query, connection)
        emailcmd.Parameters.AddWithValue("@userName", txtUserName.Text)
        Dim emaildtr As SqlDataReader
        emaildtr = emailcmd.ExecuteReader

        If emaildtr.HasRows Then
            emaildtr.Read()

            Dim userEmail As String = emaildtr.Item("email")
            Dim emailBody As String = "Dear " + txtUserName.Text + ", " + vbCrLf + "" + vbCrLf +
                                    "Your Design had been accepted by our company with the price RM" + txtPrice.Text +
                                    " and the validity of the design will be " + txtValid.Text +
                                    " month. Your design will be shown in our system start from " + startDate.ToString() +
                                    " if you accept our offer. Please login to your TRENDARY account to approve the offer." +
                                    vbCrLf + "" + vbCrLf + "Regards, " + vbCrLf + "TRENDARY Admin"
            Try
                Dim Smtp_Server As New SmtpClient
                Dim e_mail As New MailMessage()
                Smtp_Server.UseDefaultCredentials = False
                Smtp_Server.Credentials = New Net.NetworkCredential("kongyt-wa14@student.tarc.edu.my", "13anhuakt")
                Smtp_Server.Port = 587
                Smtp_Server.EnableSsl = True
                Smtp_Server.Host = "smtp.gmail.com"

                e_mail = New MailMessage()
                e_mail.From = New MailAddress("kongyt-wa14@student.tarc.edu.my")
                e_mail.To.Add("ktkarensakura255@gmail.com")
                e_mail.Subject = "TRENDARY Design Approval"
                e_mail.IsBodyHtml = False
                e_mail.Body = emailBody
                Smtp_Server.Send(e_mail)
                MsgBox("Mail Sent")

            Catch error_t As Exception
                MsgBox(error_t.ToString)
            End Try
        End If

        emaildtr.Dispose()
        Response.Redirect("AdminDesignVerify.aspx", True)
        connection.Close()

    End Sub

    Protected Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click

        'database
        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\FinalYearProject\FYP\App_Data\FYPdatabase.mdf;Integrated Security=True")
        Try
            connection.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim datetime As System.DateTime = designStartDate.SelectedDate
        Dim startDate As Date = datetime.Date

        Dim updateQuery As String = "UPDATE Design SET status = @status WHERE designID = @designID"
        Dim cmd As SqlCommand = New SqlCommand(updateQuery, connection)
        cmd.Parameters.AddWithValue("@status", "Unsuccess")
        cmd.Parameters.AddWithValue("@designID", ddlDesignID.SelectedValue)
        cmd.ExecuteNonQuery()
        cmd.Dispose()

        MsgBox("Record updated.", MsgBoxStyle.Information)


        Response.Redirect("AdminDesignVerify.aspx", True)
        connection.Close()
    End Sub
End Class