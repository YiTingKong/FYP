Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO.Path

Public Class AdminTechCreate
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
        If fuTech.HasFile = False Then
            err.AppendLine("- Please select Image for Technician.")
        End If

        If txtTName.Text = "" Then
            err.AppendLine("- Please enter Technician Name.")
        End If

        'display error messages
        If err.Length > 0 Then
            MessageBox.Show(err.ToString(), "Input Error")
            Return
        End If

        'get latest data
        Dim selectQuery As String = "SELECT MAX(techID) AS LastId FROM Technician"
        Dim selectCmd As SqlCommand = New SqlCommand(selectQuery, connection)
        Dim dtr As SqlDataReader
        dtr = selectCmd.ExecuteReader

        If dtr.HasRows Then
            dtr.Read()
            Try
                'generate next clothID
                Dim lastID As String = dtr.Item("LastId")
                Dim nextID As String = String.Format("T{0}", Integer.Parse(Regex.Match(lastID, "\d+$").Value + 1))
                dtr.Close()
                dtr = Nothing

                'technician image
                Dim techImg As String = fuTech.FileName
                fuTech.PostedFile.SaveAs(Server.MapPath("~/Img/profileImage/" + techImg))
                Dim techImgPath As String = "~/Img/profileImage/" + techImg.ToString()

                Dim datetime As System.DateTime = techJobDate.SelectedDate
                Dim startDate As Date = datetime.Date
                Dim status As String = "Available"
                Dim query As String = "INSERT Technician (techID, techName, startJobDate, areaName, techPath, status) VALUES (@id, @name, @date, @area, @techPath, @status)"
                Dim cmd As SqlCommand = New SqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@id", nextID) 'String
                cmd.Parameters.AddWithValue("@name", txtTName.Text) 'String
                cmd.Parameters.AddWithValue("@date", startDate) 'date
                cmd.Parameters.AddWithValue("@area", ddlArea.SelectedValue) 'String
                cmd.Parameters.AddWithValue("@techPath", techImgPath) 'nvarchar
                cmd.Parameters.AddWithValue("@status", status) 'nvarchar
                cmd.ExecuteNonQuery()
                cmd.Dispose()

                MsgBox("Record saved.", MsgBoxStyle.Information)
                fuTech.Attributes.Clear()
                txtTName.Text = ""
                ddlArea.SelectedIndex = -1
                techJobDate.SelectedDate = techJobDate.TodaysDate


            Catch ex As SqlException
                MsgBox(ex.Message, , "Sql Exception")
            Catch ex As Exception
                MsgBox(ex.Message, , "General Exception")
            End Try
        Else
            MessageBox.Show("No Technician information selected.", "Sorry")
        End If

    End Sub

    Protected Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        fuTech.Attributes.Clear()
        txtTName.Text = ""
        ddlArea.SelectedIndex = -1
        techJobDate.SelectedDate = techJobDate.TodaysDate
    End Sub

    Protected Sub CalendarDRender(sender As Object, e As DayRenderEventArgs)

        If e.Day.Date.CompareTo(DateTime.Today) < 0 Then
            e.Day.IsSelectable = False
        End If
    End Sub


End Class