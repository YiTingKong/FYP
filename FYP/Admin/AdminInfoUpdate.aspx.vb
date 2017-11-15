Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO.Path

Public Class AdminInfoUpdate
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Me.GetData()
    End Sub

    Protected Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
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

        Dim query As String = "SELECT name, email, contact, address, type, gender, ICNumber, status, adminPath FROM Login WHERE userName = @userName AND type LIKE '%' + @type + '%'"
        Dim cmd As SqlCommand = New SqlCommand(query, connection)
        cmd.Parameters.AddWithValue("@userName", txtUserName.Text)
        cmd.Parameters.AddWithValue("@type", "Admin")
        Dim dtr As SqlDataReader
        dtr = cmd.ExecuteReader

        If dtr.HasRows Then
            dtr.Read()
            'Visible
            imgProfile.Visible = True
            fuImg.Visible = True
            lblImg.Visible = True
            lblName.Visible = True
            txtName.Visible = True
            lblContact.Visible = True
            txtContact.Visible = True
            lblIC.Visible = True
            txtIC.Visible = True
            lblEmail.Visible = True
            txtEmail.Visible = True
            lblAddress.Visible = True
            txtAddress.Visible = True
            lblType.Visible = True
            ddlType.Visible = True
            lblGender.Visible = True
            ddlGender.Visible = True
            lblStatus.Visible = True
            ddlStatus.Visible = True
            btnUpdate.Visible = True
            btnReset.Visible = True

            imgProfile.ImageUrl = dtr.Item("adminPath")
            txtName.Text = dtr.Item("name")
            txtContact.Text = dtr.Item("contact")
            txtIC.Text = dtr.Item("ICNumber")
            txtEmail.Text = dtr.Item("email")
            txtAddress.Text = dtr.Item("address")
            ddlType.SelectedValue = dtr.Item("type")
            ddlGender.SelectedValue = dtr.Item("gender")
            ddlStatus.SelectedValue = dtr.Item("status")
        Else
            MessageBox.Show("Invalid Admin's User Name.", "Error")
            txtUserName.Text = ""
        End If

        connection.Close()
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim err As New StringBuilder()

        'validation
        If txtName.Text = "" Then
            err.AppendLine("- Please enter the Name.")
        End If

        If txtContact.Text = "" Then
            err.AppendLine("- Please enter the Contact Number.")
        End If

        If txtIC.Text = "" Then
            err.AppendLine("- Please enter the User IC Number.")
        End If

        If txtEmail.Text = "" Then
            err.AppendLine("- Please enter the Email.")
        End If

        If txtAddress.Text = "" Then
            err.AppendLine("- Please enter the Address.")
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

        If fuImg.HasFile Then
            Dim imgPath As String = fuImg.FileName
            fuImg.PostedFile.SaveAs(Server.MapPath("~/Img/profileImage/" + imgPath))
            Dim disImgPath As String = "~/Img/profileImage/" + imgPath.ToString()

            Dim updateQuery As String = "UPDATE Login 
                                    SET name = @name, email = @email, contact = @contact, address = @address, type = @type, gender = @gender, ICNumber = @ICNumber, adminPath = @adminPath, status = @status
                                    WHERE userName = @userName"

            Dim cmd As SqlCommand = New SqlCommand(updateQuery, connection)
            cmd.Parameters.AddWithValue("@userName", txtUserName.Text)
            cmd.Parameters.AddWithValue("@name", txtName.Text)
            cmd.Parameters.AddWithValue("@email", txtEmail.Text)
            cmd.Parameters.AddWithValue("@contact", txtContact.Text)
            cmd.Parameters.AddWithValue("@address", txtAddress.Text)
            cmd.Parameters.AddWithValue("@type", ddlType.SelectedValue)
            cmd.Parameters.AddWithValue("@gender", ddlGender.SelectedValue)
            cmd.Parameters.AddWithValue("@ICNumber", txtIC.Text)
            cmd.Parameters.AddWithValue("@adminPath", disImgPath)
            cmd.Parameters.AddWithValue("@status", ddlStatus.SelectedValue)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            MsgBox("Record updated.", MsgBoxStyle.Information)

        Else
            Dim updateQuery As String = "UPDATE Login 
                                    SET name = @name, email = @email, contact = @contact, address = @address, type = @type, gender = @gender, ICNumber = @ICNumber, status = @status
                                    WHERE userName = @userName"

            Dim cmd As SqlCommand = New SqlCommand(updateQuery, connection)
            cmd.Parameters.AddWithValue("@userName", txtUserName.Text)
            cmd.Parameters.AddWithValue("@name", txtName.Text)
            cmd.Parameters.AddWithValue("@email", txtEmail.Text)
            cmd.Parameters.AddWithValue("@contact", txtContact.Text)
            cmd.Parameters.AddWithValue("@address", txtAddress.Text)
            cmd.Parameters.AddWithValue("@type", ddlType.SelectedValue)
            cmd.Parameters.AddWithValue("@gender", ddlGender.SelectedValue)
            cmd.Parameters.AddWithValue("@ICNumber", txtIC.Text)
            cmd.Parameters.AddWithValue("@status", ddlStatus.SelectedValue)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            MsgBox("Record updated.", MsgBoxStyle.Information)

        End If

        Response.Redirect("AdminInfoUpdate.aspx", True)
        connection.Close()
    End Sub
End Class