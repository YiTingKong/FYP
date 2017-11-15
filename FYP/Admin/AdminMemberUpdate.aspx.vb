Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class AdminMemberUpdate
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtName.Enabled = False
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Me.userNameGetData()
    End Sub

    Private Sub userNameGetData()
        'database
        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\FinalYearProject\FYP\App_Data\FYPdatabase.mdf;Integrated Security=True")
        Try
            connection.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim query As String = "SELECT name, email, contact, address, gender FROM Login WHERE userName = @userName AND type = @type"
        Dim cmd As SqlCommand = New SqlCommand(query, connection)
        cmd.Parameters.AddWithValue("@userName", txtUserName.Text)
        cmd.Parameters.AddWithValue("@type", "Customer")
        Dim dtr As SqlDataReader
        dtr = cmd.ExecuteReader

        If dtr.HasRows Then
            dtr.Read()
            'Visible

            lblName.Visible = True
            txtName.Visible = True
            lblNameDisplay.Visible = True
            txtNameDisplay.Visible = True
            lblGender.Visible = True
            ddlGender.Visible = True
            lblContact.Visible = True
            txtContact.Visible = True
            lblEmail.Visible = True
            txtEmail.Visible = True
            lblAddress.Visible = True
            txtAddress.Visible = True
            btnUpdate.Visible = True
            btnReset.Visible = True

            ddlGender.SelectedValue = dtr.Item("gender")
            txtName.Text = txtUserName.Text
            txtNameDisplay.Text = dtr.Item("name")
            txtContact.Text = dtr.Item("contact")
            txtEmail.Text = dtr.Item("email")
            txtAddress.Text = dtr.Item("address")
            dtr.Dispose()
        Else
            MessageBox.Show("Invalid User Name", "Error")
            dtr.Dispose()
        End If
        connection.Close()
    End Sub

    Protected Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Me.userNameGetData()
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim err As New StringBuilder()

        'validation
        If txtNameDisplay.Text = "" Then
            err.AppendLine("- Please enter User Name.")
        End If

        If txtName.Text = "" Then
            err.AppendLine("- Please enter Email Address.")
        End If

        If txtContact.Text = "" Then
            err.AppendLine("- Please enter Contact Number.")
        End If

        If txtAddress.Text = "" Then
            err.AppendLine("- Please enter Address.")
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

        Dim updateQuery As String = "UPDATE Login 
                                    SET name = @name, email = @email, contact = @contact, address = @address, gender = @gender
                                    WHERE userName = @userName"

        Dim cmd As SqlCommand = New SqlCommand(updateQuery, connection)
        cmd.Parameters.AddWithValue("@name", txtNameDisplay.Text)
        cmd.Parameters.AddWithValue("@email", txtEmail.Text)
        cmd.Parameters.AddWithValue("@contact", txtContact.Text)
        cmd.Parameters.AddWithValue("@address", txtAddress.Text)
        cmd.Parameters.AddWithValue("@gender", ddlGender.SelectedValue)
        cmd.Parameters.AddWithValue("@userName", txtName.Text)
        cmd.ExecuteNonQuery()
        cmd.Dispose()

        MsgBox("Record updated.", MsgBoxStyle.Information)

        Response.Redirect("AdminMemberUpdate.aspx", True)
        connection.Close()
    End Sub
End Class