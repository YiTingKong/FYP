Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO.Path

Public Class AdminDesignCreate
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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
        If fuDesign.HasFile = False Then
            err.AppendLine("- Please select Image for DISPLAY.")
        End If

        If Not txtValid.Text = "" Then
            Dim validity As Integer = Convert.ToInt32(txtValid.Text)
            If validity < 1 Or validity > 24 Then
                err.AppendLine("- Validity(month) only between 1 to 24.")
            End If
        End If

        If txtValid.Text = "" Then
            err.AppendLine("- Please enter the validity(month) for the design.")
        End If

        'display error messages
        If err.Length > 0 Then
            MessageBox.Show(err.ToString(), "Input Error")
            Return
        End If

        'get latest data
        Dim selectQuery As String = "SELECT MAX(designID) AS LastId FROM Design"
        Dim selectCmd As SqlCommand = New SqlCommand(selectQuery, connection)
        Dim dtr As SqlDataReader
        dtr = selectCmd.ExecuteReader

        Dim type As String = "Official"
        Dim status As String = "Available"
        Dim datetime As System.DateTime = System.DateTime.Now
        Dim currentdate As Date = datetime.Date

        If dtr.HasRows Then
            dtr.Read()
            Try
                'generate next designID
                Dim lastID As String = dtr.Item("LastId")
                Dim nextID As String = String.Format("D{0}", Integer.Parse(Regex.Match(lastID, "\d+$").Value + 1))
                dtr.Close()
                dtr = Nothing

                'design image
                Dim disImg As String = fuDesign.FileName
                fuDesign.PostedFile.SaveAs(Server.MapPath("~/Img/FashionLogo/" + disImg))
                Dim disImgPath As String = "~/Img/FashionLogo/" + disImg.ToString()

                Dim query As String = "INSERT Design (designID, type, status, validity, startDate, price, userName, designPath) VALUES (@id, @type, @status, @validity, @startDate, null, null, @designPath)"
                Dim cmd As SqlCommand = New SqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@id", nextID) 'String
                cmd.Parameters.AddWithValue("@type", type) 'String
                cmd.Parameters.AddWithValue("@status", status) 'String
                cmd.Parameters.AddWithValue("@validity", txtValid.Text) 'int
                cmd.Parameters.AddWithValue("@startDate", currentdate) 'date
                cmd.Parameters.AddWithValue("@designPath", disImgPath) 'nvarchar
                cmd.ExecuteNonQuery()
                cmd.Dispose()

                MsgBox("Record saved.", MsgBoxStyle.Information)
                Me.txtValid.Text = ""
                Me.fuDesign.Attributes.Clear()

            Catch ex As SqlException
                MsgBox(ex.Message, , "Sql Exception")
            Catch ex As Exception
                MsgBox(ex.Message, , "General Exception")
            End Try
        End If

    End Sub

    Protected Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        fuDesign.Attributes.Clear()
        txtValid.Text = ""
    End Sub
End Class