Imports System.Data.SqlClient

Public Class DisplayProfile
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

            If dtr.HasRows Then
                dtr.Read()
                lblUserName.Text = dtr.Item("userName")
                lblName.Text = dtr.Item("name")
                lblContact.Text = dtr.Item("contact")
                lblEmail.Text = dtr.Item("email")
                lblAddress.Text = dtr.Item("address")
                lblGender.Text = dtr.Item("gender")

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

    Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Response.Redirect("~/Client/ProfileMaintenance.aspx")
    End Sub

    Protected Sub btnChangePW_Click(sender As Object, e As EventArgs) Handles btnChangePW.Click
        Response.Redirect("~/Client/ChangePassword.aspx")
    End Sub
End Class