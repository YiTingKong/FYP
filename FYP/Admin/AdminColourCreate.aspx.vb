Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO.Path

Public Class AdminColourCreate
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
            Dim query As String = "SELECT * FROM Area WHERE status = @status"
            Dim cmd As SqlCommand = New SqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@status", "available")
            Dim dtr As SqlDataReader
            dtr = cmd.ExecuteReader

            If dtr.HasRows Then
                While dtr.Read()
                    ddlAreaL.Items.Add(dtr(1).ToString())
                End While
            End If
            dtr.Dispose()
        End If


    End Sub

    'Colour
    Protected Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreateC.Click
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
        If txtColour.Text = "" Then
            err.AppendLine("- Please enter Clothes Colour.")
        End If

        'display error messages
        If err.Length > 0 Then
            MessageBox.Show(err.ToString(), "Input Error")
            Return
        End If

        Try

            Dim query As String = "INSERT Colour (colour, status) VALUES (@colour, @status)"
            Dim cmd As SqlCommand = New SqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@colour", txtColour.Text) 'nvarchar
            cmd.Parameters.AddWithValue("@status", ddlStatus.SelectedValue) 'nvarchar
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            MsgBox("Record saved.", MsgBoxStyle.Information)
            txtColour.Text = ""
            ddlStatus.SelectedIndex = -1

        Catch ex As SqlException
            MsgBox(ex.Message, , "Sql Exception")
        Catch ex As Exception
            MsgBox(ex.Message, , "General Exception")
        End Try

    End Sub

    Protected Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnResetC.Click
        txtColour.Text = ""
        ddlStatus.SelectedIndex = -1
    End Sub

    'Material
    Protected Sub btnCreateM_Click(sender As Object, e As EventArgs) Handles btnCreateM.Click
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
        If txtMaterial.Text = "" Then
            err.AppendLine("- Please enter Clothes Material.")
        End If

        'display error messages
        If err.Length > 0 Then
            MessageBox.Show(err.ToString(), "Input Error")
            Return
        End If

        Try

            Dim query As String = "INSERT Material (Material, status) VALUES (@material, @status)"
            Dim cmd As SqlCommand = New SqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@material", txtMaterial.Text) 'nvarchar
            cmd.Parameters.AddWithValue("@status", ddlStatusM.SelectedValue) 'nvarchar
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            MsgBox("Record saved.", MsgBoxStyle.Information)
            txtMaterial.Text = ""
            ddlStatusM.SelectedIndex = -1

        Catch ex As SqlException
            MsgBox(ex.Message, , "Sql Exception")
        Catch ex As Exception
            MsgBox(ex.Message, , "General Exception")
        End Try
    End Sub

    Protected Sub btnResetM_Click(sender As Object, e As EventArgs) Handles btnResetM.Click
        txtMaterial.Text = ""
        ddlStatusM.SelectedIndex = -1
    End Sub

    'Area
    Protected Sub btnCreateA_Click(sender As Object, e As EventArgs) Handles btnCreateA.Click
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
        If txtArea.Text = "" Then
            err.AppendLine("- Please enter Area.")
        End If

        'display error messages
        If err.Length > 0 Then
            MessageBox.Show(err.ToString(), "Input Error")
            Return
        End If
        'get latest data
        Dim selectQuery As String = "SELECT MAX(areaID) AS LastId FROM Area"
        Dim selectCmd As SqlCommand = New SqlCommand(selectQuery, connection)
        Dim dtr As SqlDataReader
        dtr = selectCmd.ExecuteReader

        If dtr.HasRows Then
            dtr.Read()

            Try
                'generate next areaID
                Dim lastID As String = dtr.Item("LastId")
                Dim nextID As String = String.Format("A{0}", Integer.Parse(Regex.Match(lastID, "\d+$").Value + 1))
                dtr.Close()
                dtr = Nothing

                Dim query As String = "INSERT Area (areaID,areaName, status) VALUES (@areaID, @areaName, @status)"
                Dim cmd As SqlCommand = New SqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@areaID", nextID)
                cmd.Parameters.AddWithValue("@areaName", txtArea.Text) 'nvarchar
                cmd.Parameters.AddWithValue("@status", ddlStatusA.SelectedValue) 'nvarchar
                cmd.ExecuteNonQuery()
                cmd.Dispose()

                MsgBox("Record saved.", MsgBoxStyle.Information)
                txtArea.Text = ""
                ddlStatusA.SelectedIndex = -1

            Catch ex As SqlException
                MsgBox(ex.Message, , "Sql Exception")
            Catch ex As Exception
                MsgBox(ex.Message, , "General Exception")
            End Try
        End If

    End Sub

    Protected Sub btnResetA_Click(sender As Object, e As EventArgs) Handles btnResetA.Click
        txtArea.Text = ""
        ddlStatusA.SelectedIndex = -1
    End Sub

    'Location
    Protected Sub btnCreateL_Click(sender As Object, e As EventArgs) Handles btnCreateL.Click
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
        If txtLocation.Text = "" Then
            err.AppendLine("- Please enter Location.")
        End If

        'display error messages
        If err.Length > 0 Then
            MessageBox.Show(err.ToString(), "Input Error")
            Return
        End If
        'get latest data
        Dim selectQuery As String = "SELECT MAX(locationID) AS LastId FROM Location"
        Dim selectCmd As SqlCommand = New SqlCommand(selectQuery, connection)
        Dim dtr As SqlDataReader
        dtr = selectCmd.ExecuteReader

        If dtr.HasRows Then
            dtr.Read()

            Try
                'generate next areaID
                Dim lastID As String = dtr.Item("LastId")
                Dim nextID As String = String.Format("L{0}", Integer.Parse(Regex.Match(lastID, "\d+$").Value + 1))
                dtr.Close()
                dtr = Nothing

                Dim query As String = "INSERT Location (locationID, locationName, status, areaName) VALUES (@locationID, @locationName, @status, @areaName)"
                Dim cmd As SqlCommand = New SqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@locationID", nextID)
                cmd.Parameters.AddWithValue("@locationName", txtLocation.Text) 'nvarchar
                cmd.Parameters.AddWithValue("@status", ddlStatusA.SelectedValue) 'nvarchar
                cmd.Parameters.AddWithValue("@areaName", ddlAreaL.SelectedValue) 'nvarchar
                cmd.ExecuteNonQuery()
                cmd.Dispose()

                MsgBox("Record saved.", MsgBoxStyle.Information)
                txtLocation.Text = ""
                ddlAreaL.SelectedIndex = -1
                ddlStatusL.SelectedIndex = -1

            Catch ex As SqlException
                MsgBox(ex.Message, , "Sql Exception")
            Catch ex As Exception
                MsgBox(ex.Message, , "General Exception")
            End Try
        End If

    End Sub

    Protected Sub btnResetL_Click(sender As Object, e As EventArgs) Handles btnResetL.Click
        txtLocation.Text = ""
        ddlAreaL.SelectedIndex = -1
        ddlStatusL.SelectedIndex = -1
    End Sub
End Class