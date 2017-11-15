Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO.Path

Public Class AdminMachineUpdate
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
        If txtModel.Text = "" Then
            err.AppendLine("- Please enter Machine Model.")
        End If

        If txtColor.Text = "" Then
            err.AppendLine("- Please enter Machine Color.")
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

        Dim machID As String = ddlMachine.SelectedValue
        Dim area As String = ddlArea.SelectedValue

        Dim updateQuery As String = "UPDATE Machine 
                                    SET model = @model, colour = @color, address = @address, locationName = @location, areaName = @area
                                    WHERE MachineID = @machID"

        Dim cmd As SqlCommand = New SqlCommand(updateQuery, connection)
        cmd.Parameters.AddWithValue("@machID", machID)
        cmd.Parameters.AddWithValue("@model", txtModel.Text)
        cmd.Parameters.AddWithValue("@color", txtColor.Text)
        cmd.Parameters.AddWithValue("@address", txtAddress.Text)
        cmd.Parameters.AddWithValue("@location", ddlLocation.SelectedValue)
        cmd.Parameters.AddWithValue("@area", ddlArea.SelectedValue)
        cmd.ExecuteNonQuery()
        cmd.Dispose()

        MsgBox("Record updated.", MsgBoxStyle.Information)

        Response.Redirect("AdminMachineUpdate.aspx", True)
        connection.Close()
    End Sub

    Protected Sub ddlArea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlArea.SelectedIndexChanged
        'database
        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\FinalYearProject\FYP\App_Data\FYPdatabase.mdf;Integrated Security=True")
        Try
            connection.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim area As String = ddlArea.SelectedValue()
        ddlLocation.Items.Clear()

        'location
        Dim locationquery As String = "SELECT * FROM Location WHERE status = @status"
        Dim locationcmd As SqlCommand = New SqlCommand(locationquery, connection)
        locationcmd.Parameters.AddWithValue("@status", "available")
        Dim locationdtr As SqlDataReader
        locationdtr = locationcmd.ExecuteReader

        If locationdtr.HasRows Then
            While locationdtr.Read()
                If String.Compare(area, locationdtr(3).ToString()) = 0 Then
                    ddlLocation.Items.Add(locationdtr(1).ToString())
                End If
            End While
        End If
        locationdtr.Dispose()

    End Sub

    Protected Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Me.GetData()
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

        Dim machineID As String = ddlMachine.SelectedItem.ToString()

        Dim query As String = "SELECT MachineID, model, colour, address, locationName, areaName FROM Machine WHERE MachineID = @machineID"
        Dim cmd As SqlCommand = New SqlCommand(query, connection)
        cmd.Parameters.AddWithValue("@machineID", machineID)
        Dim dtr As SqlDataReader
        dtr = cmd.ExecuteReader

        If dtr.HasRows Then
            dtr.Read()
            'Visible
            lblArea.Visible = True
            ddlArea.Visible = True
            lblLocation.Visible = True
            ddlLocation.Visible = True
            lblMachModel.Visible = True
            txtModel.Visible = True
            lblColor.Visible = True
            txtColor.Visible = True
            lblAddress.Visible = True
            txtAddress.Visible = True
            btnUpdate.Visible = True
            btnReset.Visible = True

            ddlArea.SelectedValue = dtr.Item("areaName")
            lblStore.Text = dtr.Item("locationName")
            txtModel.Text = dtr.Item("model")
            txtColor.Text = dtr.Item("colour")
            txtAddress.Text = dtr.Item("address")
            dtr.Dispose()
        End If

        Dim area As String = ddlArea.SelectedValue
        ddlLocation.Items.Clear()
        'location
        Dim locationquery As String = "SELECT * FROM Location WHERE status = @status"
        Dim locationcmd As SqlCommand = New SqlCommand(locationquery, connection)
        locationcmd.Parameters.AddWithValue("@status", "available")
        Dim locationdtr As SqlDataReader
        locationdtr = locationcmd.ExecuteReader

        If locationdtr.HasRows Then
            While locationdtr.Read()
                If String.Compare(area, locationdtr(3).ToString()) = 0 Then
                    ddlLocation.Items.Add(locationdtr(1).ToString())
                End If
            End While
        End If
        locationdtr.Dispose()
        ddlLocation.SelectedValue = lblStore.Text
        connection.Close()
    End Sub
End Class