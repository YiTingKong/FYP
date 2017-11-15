Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO.Path

Public Class AdminTechUpdate
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

            'techID
            Dim IDquery As String = "SELECT techID FROM Technician WHERE status = @status"
            Dim IDcmd As SqlCommand = New SqlCommand(IDquery, connection)
            IDcmd.Parameters.AddWithValue("@status", "available")
            Dim IDdtr As SqlDataReader
            IDdtr = IDcmd.ExecuteReader

            If IDdtr.HasRows Then
                While IDdtr.Read()
                    ddlTech.Items.Add(IDdtr(0).ToString())
                End While
            End If
            IDdtr.Dispose()

            'area
            Dim areaquery As String = "SELECT * FROM Area WHERE status = @status"
            Dim areacmd As SqlCommand = New SqlCommand(areaquery, connection)
            areacmd.Parameters.AddWithValue("@status", "available")
            Dim areadtr As SqlDataReader
            areadtr = areacmd.ExecuteReader

            If areadtr.HasRows Then
                While areadtr.Read()
                    ddlArea.Items.Add(areadtr(1).ToString())
                End While
            End If
            areadtr.Dispose()
        End If
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim err As New StringBuilder()

        'validation
        If txtTechName.Text = "" Then
            err.AppendLine("- Please enter Technician Name.")
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

        Dim techID As String = ddlTech.SelectedValue
        Dim area As String = ddlArea.SelectedValue

        If fuImg.HasFile Then
            Dim imgPath As String = fuImg.FileName
            fuImg.PostedFile.SaveAs(Server.MapPath("~/Img/profileImage/" + imgPath))
            Dim disImgPath As String = "~/Img/profileImage/" + imgPath.ToString()

            Dim updateQuery As String = "UPDATE Technician 
                                    SET techName = @name, areaName = @area, techPath = @techPath
                                    WHERE techID = @techID"

            Dim cmd As SqlCommand = New SqlCommand(updateQuery, connection)
            cmd.Parameters.AddWithValue("@techID", techID)
            cmd.Parameters.AddWithValue("@name", txtTechName.Text)
            cmd.Parameters.AddWithValue("@area", area)
            cmd.Parameters.AddWithValue("@techPath", disImgPath)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            MsgBox("Record updated.", MsgBoxStyle.Information)

        Else
            Dim updateQuery As String = "UPDATE Technician 
                                    SET techName = @name, areaName = @area
                                    WHERE techID = @techID"

            Dim cmd As SqlCommand = New SqlCommand(updateQuery, connection)
            cmd.Parameters.AddWithValue("@techID", techID)
            cmd.Parameters.AddWithValue("@name", txtTechName.Text)
            cmd.Parameters.AddWithValue("@area", area)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            MsgBox("Record updated.", MsgBoxStyle.Information)

        End If

        Response.Redirect("AdminTechUpdate.aspx", True)
        connection.Close()
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

        Dim techID As String = ddlTech.SelectedItem.ToString()

        Dim query As String = "SELECT techID, techName, areaName, techPath FROM Technician WHERE techID = @techID"
        Dim cmd As SqlCommand = New SqlCommand(query, connection)
        cmd.Parameters.AddWithValue("@techID", techID)
        Dim dtr As SqlDataReader
        dtr = cmd.ExecuteReader

        If dtr.HasRows Then
            dtr.Read()
            'Visible
            lblImage.Visible = True
            fuImg.Visible = True
            imgTech.Visible = True
            lblTechName.Visible = True
            txtTechName.Visible = True
            lblArea.Visible = True
            ddlArea.Visible = True
            btnUpdate.Visible = True
            btnReset.Visible = True

            imgTech.ImageUrl = dtr.Item("techPath")
            txtTechName.Text = dtr.Item("techName")
            ddlArea.SelectedValue = dtr.Item("areaName")

        End If
        connection.Close()
    End Sub
End Class