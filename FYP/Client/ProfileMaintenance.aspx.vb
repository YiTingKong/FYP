Imports System.Data.SqlClient


Public Class ProfileMaintenance
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If ClientModule.userName = "" Then
            Response.Redirect("~/Client/ClientHome.aspx")
        End If
        If IsPostBack = False Then
            Dim connection As SqlConnection = Nothing
            Dim conn As String = ConfigurationManager.ConnectionStrings("FYPDBConnectionString").ConnectionString
            connection = New SqlConnection(conn)
            connection.Open()
            Dim sql As String = "SELECT * FROM Login WHERE userName = @username"
            Dim cmd As SqlCommand = New SqlCommand(sql, connection)
            cmd.CommandTimeout = 1
            cmd.Parameters.AddWithValue("@userName", ClientModule.userName)
            Dim dtr As SqlDataReader
            dtr = cmd.ExecuteReader
            Dim gender As String

            If dtr.HasRows Then
                dtr.Read()
                lblUserName.Text = dtr.Item("userName")
                txtNickname.Text = dtr.Item("name")
                gender = dtr.Item("gender")
                If gender.Equals("Male") Then
                    radGender.SelectedIndex = 0
                ElseIf gender.Equals("Female") Then
                    radGender.SelectedIndex = 1
                End If

                txtContact.Text = dtr.Item("contact")
                txtEmail.Text = dtr.Item("email")
                txtAddress.Text = dtr.Item("address")

                Dim MyData() As Byte
                MyData = dtr.Item("profilePic")

                Dim oFileStream As New System.IO.FileStream(System.AppDomain.CurrentDomain.BaseDirectory & "image\image.jpg", System.IO.FileMode.Create, IO.FileAccess.ReadWrite)
                oFileStream.Write(MyData, 0, MyData.Length)
                oFileStream.Close()

                newProfilePic.ImageUrl = "~/image/image.jpg"
                dtr.Close()
                connection.Close()
            End If

        End If


    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim err As New StringBuilder()
        Dim ctr As Control = Nothing
        Dim contact As String = txtContact.Text
        Dim gender As String = ""

        'Validation     
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

        If imgUpload.HasFile = True Then
            Dim strpath As String = System.IO.Path.GetExtension(imgUpload.FileName)
            If strpath <> ".jpg" AndAlso strpath <> ".jpeg" AndAlso strpath <> ".gif" AndAlso strpath <> ".png" Then
                err.AppendLine("- Only image formats (jpg, png, gif) are accepted.")
                ctr = If(ctr, imgUpload)
            End If
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


        Dim updatesql As String = "Update Login SET name = @name , email = @email, contact = @contact, address = @address, profilePic = @profilePic, gender = @gender WHERE userName = @userName"
        Dim updatecmd As SqlCommand = New SqlCommand(updatesql, connection)
        updatecmd.CommandTimeout = 1
        updatecmd.Parameters.AddWithValue("@userName", lblUserName.Text)
        updatecmd.Parameters.AddWithValue("@name", txtNickname.Text)
        updatecmd.Parameters.AddWithValue("@email", txtEmail.Text)
        updatecmd.Parameters.AddWithValue("@contact", txtContact.Text)
        updatecmd.Parameters.AddWithValue("@address", txtAddress.Text)

        If imgUpload.HasFile = True Then
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
            updatecmd.Parameters.AddWithValue("@profilePic", imgByte)
        Else
            Dim sql As String = "SELECT * FROM Login WHERE userName = @username"
            Dim cmd As SqlCommand = New SqlCommand(sql, connection)
            cmd.CommandTimeout = 1
            cmd.Parameters.AddWithValue("@username", ClientModule.userName)
            Dim dtr As SqlDataReader
            dtr = cmd.ExecuteReader
            dtr.Read()
            updatecmd.Parameters.AddWithValue("@profilePic", dtr.Item("profilePic"))
            dtr.Close()
        End If

        updatecmd.Parameters.AddWithValue("@gender", gender)
        Try
            updatecmd.ExecuteNonQuery()
            MsgBox("Profile updated successfully.")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        connection.Close()
        Response.Redirect("~/Client/DisplayProfile.aspx")
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

    'Protected Sub btnDisplay_Click(sender As Object, e As EventArgs) Handles btnDisplay.Click
    '    If imgUpload.HasFile = True Then
    '        Dim fileName As String = System.IO.Path.GetFileName(imgUpload.PostedFile.FileName)
    '        imgUpload.PostedFile.SaveAs(Server.MapPath("~/image/" + fileName))
    '        newProfilePic.ImageUrl = "~/image/" + fileName

    '        Dim img As FileUpload = CType(imgUpload, FileUpload)

    '        If img.HasFile AndAlso Not img.PostedFile Is Nothing Then
    '            'To create a PostedFile
    '            Dim File As HttpPostedFile = imgUpload.PostedFile
    '            'Create byte Array with file len
    '            imgByte = New Byte(File.ContentLength - 1) {}
    '            'force the control to load data in array
    '            File.InputStream.Read(imgByte, 0, File.ContentLength)
    '        End If
    '    End If

    'End Sub



End Class