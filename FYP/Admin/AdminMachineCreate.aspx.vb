Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO.Path

Public Class AdminMachineCreate
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
        End If
    End Sub

    Protected Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        'database
        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\FinalYearProject\FYP\App_Data\FYPdatabase.mdf;Integrated Security=True")
        Try
            connection.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim err As New StringBuilder()

        'validation
        If txtModel.Text = "" Then
            err.AppendLine("- Please enter the Machine Model.")
        End If

        If txtColor.Text = "" Then
            err.AppendLine("- Please enter the Machine Color.")
        End If

        If txtAddress.Text = "" Then
            err.AppendLine("- Please enter the Address.")
        End If

        'display error messages
        If err.Length > 0 Then
            MessageBox.Show(err.ToString(), "Input Error")
            Return
        End If

        'get latest data
        Dim selectQuery As String = "SELECT MAX(MachineID) AS LastId FROM Machine"
        Dim selectCmd As SqlCommand = New SqlCommand(selectQuery, connection)
        Dim dtr As SqlDataReader
        dtr = selectCmd.ExecuteReader

        If dtr.HasRows Then
            dtr.Read()
            Try
                'generate next designID
                Dim lastID As String = dtr.Item("LastId")
                Dim nextID As String = String.Format("M{0}", Integer.Parse(Regex.Match(lastID, "\d+$").Value + 1))
                dtr.Close()
                dtr = Nothing

                Dim datetime As System.DateTime = machStartDate.SelectedDate
                Dim startDate As Date = datetime.Date

                Dim query As String = "INSERT Machine (MachineID, model, startDate, colour, address, locationName, areaName, status) VALUES (@id, @model, @date, @colour, @address, @location, @area, @status)"
                Dim cmd As SqlCommand = New SqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@id", nextID) 'String
                cmd.Parameters.AddWithValue("@model", txtModel.Text) 'String
                cmd.Parameters.AddWithValue("@date", startDate) 'date
                cmd.Parameters.AddWithValue("@colour", txtColor.Text) 'nvarchar
                cmd.Parameters.AddWithValue("@address", txtAddress.Text) 'nvarchar
                cmd.Parameters.AddWithValue("@location", ddlLocation.SelectedValue) 'nvarchar
                cmd.Parameters.AddWithValue("@area", ddlArea.SelectedValue) 'nvarchar
                cmd.Parameters.AddWithValue("@status", "Available") 'nvarchar
                cmd.ExecuteNonQuery()
                cmd.Dispose()

                MsgBox("Record saved.", MsgBoxStyle.Information)
                ddlArea.SelectedIndex = -1
                ddlLocation.SelectedIndex = -1
                txtModel.Text = ""
                txtColor.Text = ""
                txtAddress.Text = ""
                machStartDate.SelectedDate = machStartDate.TodaysDate

            Catch ex As SqlException
                MsgBox(ex.Message, , "Sql Exception")
            Catch ex As Exception
                MsgBox(ex.Message, , "General Exception")
            End Try
        End If
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

    Protected Sub CalendarDRender(sender As Object, e As DayRenderEventArgs)
        If e.Day.Date.CompareTo(DateTime.Today) < 0 Then
            e.Day.IsSelectable = False
        End If
    End Sub

    Protected Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        ddlArea.SelectedIndex = -1
        ddlLocation.SelectedIndex = -1
        txtModel.Text = ""
        txtColor.Text = ""
        txtAddress.Text = ""
        machStartDate.SelectedDate = machStartDate.TodaysDate
    End Sub
End Class