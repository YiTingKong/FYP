Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO.Path

Public Class AdminTechDelete
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

            'clothID
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
        End If

        connection.Close()
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

        Dim techID As String = ddlTech.SelectedValue

        Dim updateQuery As String = "UPDATE Technician SET status = @status WHERE techID = @techID"

        Dim cmd As SqlCommand = New SqlCommand(updateQuery, connection)
        cmd.Parameters.AddWithValue("@techID", techID)
        cmd.Parameters.AddWithValue("@status", "Not Available")
        cmd.ExecuteNonQuery()
        cmd.Dispose()

        MsgBox("Record deleted.", MsgBoxStyle.Information)

        Response.Redirect("AdminTechDelete.aspx", True)
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

        Dim techID As String = ddlTech.SelectedItem.ToString()

        Dim query As String = "SELECT techID, techName, areaName, techPath FROM Technician WHERE techID = @techID"
        Dim cmd As SqlCommand = New SqlCommand(query, connection)
        cmd.Parameters.AddWithValue("@techID", techID)
        Dim dtr As SqlDataReader
        dtr = cmd.ExecuteReader

        If dtr.HasRows Then
            dtr.Read()
            'Visible
            imgTech.Visible = True
            lblName.Visible = True
            lblTechName.Visible = True
            lblArea.Visible = True
            lblRArea.Visible = True
            btnDelete.Visible = True

            imgTech.ImageUrl = dtr.Item("techPath")
            lblName.Text = dtr.Item("techName")
            lblArea.Text = dtr.Item("areaName")

        End If

        connection.Close()
    End Sub
End Class