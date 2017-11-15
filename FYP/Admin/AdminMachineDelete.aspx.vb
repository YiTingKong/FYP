Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO.Path

Public Class AdminMachineDelete
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

            'MachineID
            Dim IDquery As String = "SELECT MachineID FROM Machine WHERE status = @status"
            Dim IDcmd As SqlCommand = New SqlCommand(IDquery, connection)
            IDcmd.Parameters.AddWithValue("@status", "available")
            Dim IDdtr As SqlDataReader
            IDdtr = IDcmd.ExecuteReader

            If IDdtr.HasRows Then
                While IDdtr.Read()
                    ddlMachine.Items.Add(IDdtr(0).ToString())
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

        Dim machID As String = ddlMachine.SelectedItem.ToString()

        Dim query As String = "SELECT MachineID, model, colour, address, locationName, areaName FROM Machine WHERE MachineID = @machID"
        Dim cmd As SqlCommand = New SqlCommand(query, connection)
        cmd.Parameters.AddWithValue("@machID", machID)
        Dim dtr As SqlDataReader
        dtr = cmd.ExecuteReader

        If dtr.HasRows Then
            dtr.Read()
            'Visible
            lblArea.Visible = True
            lblAreaDetail.Visible = True
            lblLocation.Visible = True
            lblLocationDetail.Visible = True
            lblMachModel.Visible = True
            lblModelDetail.Visible = True
            lblColor.Visible = True
            lblColorDetail.Visible = True
            lblAddress.Visible = True
            lblAddressDetail.Visible = True
            btnDelete.Visible = True

            lblAreaDetail.Text = dtr.Item("areaName")
            lblLocationDetail.Text = dtr.Item("locationName")
            lblModelDetail.Text = dtr.Item("model")
            lblColorDetail.Text = dtr.Item("colour")
            lblAddressDetail.Text = dtr.Item("address")

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

        Dim machID As String = ddlMachine.SelectedValue

        Dim updateQuery As String = "UPDATE Machine SET status = @status WHERE MachineID = @machID"

        Dim cmd As SqlCommand = New SqlCommand(updateQuery, connection)
        cmd.Parameters.AddWithValue("@machID", machID)
        cmd.Parameters.AddWithValue("@status", "Not Available")
        cmd.ExecuteNonQuery()
        cmd.Dispose()

        MsgBox("Record deleted.", MsgBoxStyle.Information)

        Response.Redirect("AdminMachineDelete.aspx", True)
        connection.Close()
    End Sub
End Class