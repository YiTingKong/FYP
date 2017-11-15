Imports System.Data.SqlClient


Public Class Registration
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Dim err As New StringBuilder()
        Dim ctr As Control = Nothing
        Dim contact As String = txtContact.Text
        Dim gender As String
        Dim connection As SqlConnection = Nothing
        Dim conn As String = ConfigurationManager.ConnectionStrings("FYPDBConnectionString").ConnectionString
        connection = New SqlConnection(conn)

        connection.Open()

        'Validation
        If txtUsername.Text = "" Then
            err.AppendLine("- Please enter username.")
            ctr = If(ctr, txtUsername)
        End If

        Dim checksql As String = "SELECT * FROM Login WHERE userName = @username"
        Dim checkcmd As SqlCommand = New SqlCommand(checksql, connection)
        checkcmd.Parameters.AddWithValue("@userName", txtUsername.Text.Trim())
        Dim dtr As SqlDataReader
        dtr = checkcmd.ExecuteReader

        If dtr.HasRows Then
            err.AppendLine("- Username exist. Please enter other username.")
            ctr = If(ctr, txtUsername)
        End If
        dtr.Close()

        If txtPassword.Text = "" Then
            err.AppendLine("- Please enter password.")
            ctr = If(ctr, txtPassword)
        End If

        If txtConfirmPassword.Text = "" Then
            err.AppendLine("- Please enter confirm password.")
            ctr = If(ctr, txtConfirmPassword)
        End If

        If txtConfirmPassword.Text.Equals(txtPassword.Text) = False Then
            err.AppendLine("- Confirm password not match.")
            ctr = If(ctr, txtConfirmPassword)
        End If

        If txtNickname.Text = "" Then
            err.AppendLine("- Please enter nickname.")
            ctr = If(ctr, txtNickname)
        End If

        If radGender.Text.Equals("Male") Then
            gender = "Male"
        ElseIf radGender.Text.Equals("Female") Then
            gender = "Female"
        Else
            err.AppendLine("- Please select gender.")
            ctr = If(ctr, radGender)
        End If

        If contact = "" Then
            err.AppendLine("- Please enter contact number.")
            ctr = If(ctr, txtContact)
        End If

        If Not ValidatePhone(contact) Then
            err.AppendLine("- Must be a 10-digit contact number.")
            ctr = If(ctr, txtContact)
        End If

        If txtEmail.Text = "" Then
            err.AppendLine("- Please enter email.")
            ctr = If(ctr, txtEmail)
        End If

        If txtAddress.Text = "" Then
            err.AppendLine("- Please enter address.")
            ctr = If(ctr, txtAddress)
        End If

        If imgUpload.HasFile = False Then
            err.AppendLine("- Please upload profile picture.")
            ctr = If(ctr, imgUpload)
        End If

        Dim strpath As String = System.IO.Path.GetExtension(imgUpload.FileName)
        If strpath <> ".jpg" AndAlso strpath <> ".jpeg" AndAlso strpath <> ".gif" AndAlso strpath <> ".png" Then
            err.AppendLine("- Only image formats (jpg, png, gif) are accepted.")
            ctr = If(ctr, imgUpload)
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


        Dim img As FileUpload = CType(imgUpload, FileUpload)
            Dim imgByte As Byte() = Nothing
            If img.HasFile AndAlso Not img.PostedFile Is Nothing Then
                'To create a PostedFile
                Dim File As HttpPostedFile = imgUpload.PostedFile
                'Create byte Array with file len
                imgByte = New Byte(File.ContentLength - 1) {}
                'force the control to load data in array
                File.InputStream.Read(imgByte, 0, File.ContentLength)
            End If

        ' Insert data into db
        Dim sql As String = "INSERT INTO Login(userName, password, name, email, contact, address, profilePic, securityQuestion, securityAns, type, gender, ICNumber, accountNumber) VALUES(@userName, @password, @name, @email, @contact, @address, @profilePic, @securityQuestion, @securityAns, @type, @gender, @ICNumber, @accountNumber)"
        Dim cmd As SqlCommand = New SqlCommand(sql, connection)
            cmd.Parameters.AddWithValue("@userName", txtUsername.Text.Trim())
            cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim())
            cmd.Parameters.AddWithValue("@name", txtNickname.Text.Trim())
            cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim())
            cmd.Parameters.AddWithValue("@contact", contact)
            cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim())
            cmd.Parameters.AddWithValue("@profilePic", imgByte)
            cmd.Parameters.AddWithValue("@securityQuestion", ddlQuestion.Text.Trim())
            cmd.Parameters.AddWithValue("@securityAns", txtAnswer.Text.Trim())
            cmd.Parameters.AddWithValue("@type", "Customer")
        cmd.Parameters.AddWithValue("@gender", gender)
        cmd.Parameters.AddWithValue("@ICNumber", "")
        cmd.Parameters.AddWithValue("@accountNumber", "")

        Dim n As Integer = cmd.ExecuteNonQuery()
            If (n > 0) Then
            MsgBox("Register successfully. Redirecting to login page.", , "Congratulation")
            Response.Redirect("~/Client/Login.aspx")
        Else
                MsgBox("Register failed. Please try again.", , "Important Note")
            End If

        connection.Close()


    End Sub

    Public Function ValidatePhone(ByVal num As String) As Boolean
        Dim pattern As String = "^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$"
        Dim check As New Regex(pattern)
        Dim valid As Boolean = False
        If Not String.IsNullOrEmpty(num) Then
            valid = check.IsMatch(num)
        Else
            valid = False
        End If
        Return valid
    End Function

    Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        'clear all text
        txtUsername.Text = ""
        txtPassword.Text = ""
        txtConfirmPassword.Text = ""
        txtEmail.Text = ""
        txtContact.Text = ""
        txtAddress.Text = ""
        txtNickname.Text = ""
        radGender.SelectedIndex = -1
        txtAnswer.Text = ""
        imgUpload = New FileUpload
    End Sub
End Class