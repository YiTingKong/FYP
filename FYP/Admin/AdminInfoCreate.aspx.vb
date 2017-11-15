Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO.Path

Public Class AdminCreate
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
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
        If fuImg.HasFile = False Then
            err.AppendLine("- Please select Profile Image.")
        End If

        If txtUserName.Text = "" Then
            err.AppendLine("- Please enter the User Name.")
        End If

        If txtPassword.Text = "" Then
            err.AppendLine("- Please enter the Password.")
        End If

        If txtName.Text = "" Then
            err.AppendLine("- Please enter the Name.")
        End If

        If txtContact.Text = "" Then
            err.AppendLine("- Please enter the Contact Number.")
        End If

        If txtEmail.Text = "" Then
            err.AppendLine("- Please enter the Email.")
        End If

        If txtSecA.Text = "" Then
            err.AppendLine("- Please enter the Security Answer.")
        End If

        If txtAddress.Text = "" Then
            err.AppendLine("- Please enter the Address.")
        End If

        'display error messages
        If err.Length > 0 Then
            MessageBox.Show(err.ToString(), "Input Error")
            Return
        End If

        Try

            Dim datetime As System.DateTime = jobStartDate.SelectedDate
            Dim startDate As Date = datetime.Date

            'admin image
            Dim techImg As String = fuImg.FileName
            fuImg.PostedFile.SaveAs(Server.MapPath("~/Img/profileImage/" + techImg))
            Dim techImgPath As String = "~/Img/profileImage/" + techImg.ToString()

            Dim query As String = "INSERT Login (userName, password, name, email, contact, address, profilePic, securityQuestion, securityAns, type, gender, ICNumber, accountNumber, adminPath, status, adminStartDate) 
                                       VALUES (@userName, @password, @name, @email, @contact, @address, null, @secQ, @secA, @type, @gender, @IC, null, @imgPath, @status, @date)"
            Dim cmd As SqlCommand = New SqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@userName", txtUserName.Text)
            cmd.Parameters.AddWithValue("@password", txtPassword.Text)
            cmd.Parameters.AddWithValue("@name", txtName.Text)
            cmd.Parameters.AddWithValue("@email", txtEmail.Text)
            cmd.Parameters.AddWithValue("@contact", txtContact.Text)
            cmd.Parameters.AddWithValue("@address", txtAddress.Text)
            cmd.Parameters.AddWithValue("@secQ", ddlSecQ.SelectedValue)
            cmd.Parameters.AddWithValue("@secA", txtSecA.Text)
            cmd.Parameters.AddWithValue("@type", ddlType.SelectedValue)
            cmd.Parameters.AddWithValue("@gender", ddlGender.SelectedValue)
            cmd.Parameters.AddWithValue("@IC", txtIC.Text)
            cmd.Parameters.AddWithValue("@imgPath", techImgPath)
            cmd.Parameters.AddWithValue("@status", ddlStatus.SelectedValue)
            cmd.Parameters.AddWithValue("@date", startDate)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            MsgBox("Record saved.", MsgBoxStyle.Information)
            fuImg.Attributes.Clear()
            txtUserName.Text = ""
            txtPassword.Text = ""
            txtName.Text = ""
            txtContact.Text = ""
            txtEmail.Text = ""
            txtAddress.Text = ""
            txtSecA.Text = ""
            txtIC.Text = ""
            ddlSecQ.SelectedIndex = -1
            ddlGender.SelectedIndex = -1
            ddlStatus.SelectedIndex = -1
            ddlType.SelectedIndex = -1

        Catch ex As SqlException
            MsgBox(ex.Message, , "Sql Exception")
        Catch ex As Exception
            MsgBox(ex.Message, , "General Exception")
        End Try
    End Sub

    Protected Sub CalendarDRender(sender As Object, e As DayRenderEventArgs)
        If e.Day.Date.CompareTo(DateTime.Today) < 0 Then
            e.Day.IsSelectable = False
        End If
    End Sub

    Protected Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        fuImg.Attributes.Clear()
        txtUserName.Text = ""
        txtPassword.Text = ""
        txtName.Text = ""
        txtContact.Text = ""
        txtEmail.Text = ""
        txtAddress.Text = ""
        txtSecA.Text = ""
        txtIC.Text = ""
        ddlSecQ.SelectedIndex = -1
        ddlGender.SelectedIndex = -1
        ddlStatus.SelectedIndex = -1
        ddlType.SelectedIndex = -1
    End Sub



End Class