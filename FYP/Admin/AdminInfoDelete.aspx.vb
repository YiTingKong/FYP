Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO.Path

Public Class AdminInfoDelete
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Me.GetData()
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        'database
        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\FinalYearProject\FYP\App_Data\FYPdatabase.mdf;Integrated Security=True")
        Try
            connection.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim updateQuery As String = "UPDATE Login SET status = @status WHERE userName = @userName"

        Dim cmd As SqlCommand = New SqlCommand(updateQuery, connection)
        cmd.Parameters.AddWithValue("@userName", txtUserName.Text)
        cmd.Parameters.AddWithValue("@status", "Not Available")
        cmd.ExecuteNonQuery()
        cmd.Dispose()

        MsgBox("Record deleted.", MsgBoxStyle.Information)

        Response.Redirect("AdminInfoDelete.aspx", True)
        connection.Close()
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

        Dim query As String = "SELECT name, type, adminPath FROM Login WHERE userName = @userName AND status = @status AND type LIKE '%' + @type + '%'"
        Dim cmd As SqlCommand = New SqlCommand(query, connection)
        cmd.Parameters.AddWithValue("@userName", txtUserName.Text)
        cmd.Parameters.AddWithValue("@status", "Available")
        cmd.Parameters.AddWithValue("@type", "Admin")
        Dim dtr As SqlDataReader
        dtr = cmd.ExecuteReader

        If dtr.HasRows Then
            dtr.Read()
            'Visible
            imgProfile.Visible = True
            lblName.Visible = True
            lblVName.Visible = True
            lblType.Visible = True
            lblVType.Visible = True
            btnDelete.Visible = True

            imgProfile.ImageUrl = dtr.Item("adminPath")
            lblVName.Text = dtr.Item("name")
            lblVType.Text = dtr.Item("type")
        Else
            MessageBox.Show("Invalid Admin's User Name.", "Error")
            txtUserName.Text = ""
        End If

        connection.Close()
    End Sub
End Class