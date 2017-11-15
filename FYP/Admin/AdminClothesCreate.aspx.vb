Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO.Path
Public Class AdminCreateProduct
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

        'size
        Dim sizequery As String = "SELECT Size FROM Size WHERE status = @status"
        Dim sizecmd As SqlCommand = New SqlCommand(sizequery, connection)
        sizecmd.Parameters.AddWithValue("@status", "available")
        Dim sizedtr As SqlDataReader
        sizedtr = sizecmd.ExecuteReader

        If sizedtr.HasRows Then
            While sizedtr.Read()
                ddlSize.Items.Add(sizedtr(0).ToString())
            End While
        End If
        sizedtr.Dispose()

        'material
        Dim matquery As String = "SELECT Material FROM Material WHERE status = @status"
        Dim matcmd As SqlCommand = New SqlCommand(matquery, connection)
        matcmd.Parameters.AddWithValue("@status", "available")
        Dim matdtr As SqlDataReader
        matdtr = matcmd.ExecuteReader

        If matdtr.HasRows Then
            While matdtr.Read()
                ddlMaterial.Items.Add(matdtr(0).ToString())
            End While
        End If
        matdtr.Dispose()

        'type
        Try

            Dim typequery As String = "SELECT * FROM ClothType WHERE Status = @status"
            Dim typecmd As SqlCommand = New SqlCommand(typequery, connection)
            typecmd.Parameters.AddWithValue("@status", "available")
            Dim typedtr As SqlDataReader
            typedtr = typecmd.ExecuteReader

            If typedtr.HasRows Then
                While typedtr.Read()
                    ddlType.Items.Add(typedtr(1).ToString())
                End While
            End If
            typedtr.Dispose()

        Catch ex As SqlException
            MsgBox(ex.Message, , "Sql Exception")
        Catch ex As Exception
            MsgBox(ex.Message, , "General Exception")
        End Try



        'colour
        Dim colourquery As String = "SELECT colour FROM Colour WHERE status = @status"
        Dim colourcmd As SqlCommand = New SqlCommand(colourquery, connection)
        colourcmd.Parameters.AddWithValue("@status", "available")
        Dim colourdtr As SqlDataReader
        colourdtr = colourcmd.ExecuteReader

        If colourdtr.HasRows Then
            While colourdtr.Read()
                ddlColour.Items.Add(colourdtr(0).ToString())
            End While
        End If
        colourdtr.Dispose()
        connection.Close()
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
        If fuCDisplay.HasFile = False Then
            err.AppendLine("- Please select Image for DISPLAY.")
        End If

        If txtPrice.Text = "" Then
            err.AppendLine("- Please enter Clothes Price.")
        End If

        'display error messages
        If err.Length > 0 Then
            MessageBox.Show(err.ToString(), "Input Error")
            Return
        End If

        'get latest data
        Dim selectQuery As String = "SELECT MAX(clothID) AS LastId FROM Product"
        Dim selectCmd As SqlCommand = New SqlCommand(selectQuery, connection)
        Dim dtr As SqlDataReader
        dtr = selectCmd.ExecuteReader

        If dtr.HasRows Then
            dtr.Read()
            Try
                'generate next clothID
                Dim lastID As String = dtr.Item("LastId")
                Dim nextID As String = String.Format("C{0}", Integer.Parse(Regex.Match(lastID, "\d+$").Value + 1))
                dtr.Close()
                dtr = Nothing

                'cloth design image
                Dim disImg As String = fuCDisplay.FileName
                fuCDisplay.PostedFile.SaveAs(Server.MapPath("~/Img/" + disImg))
                Dim disImgPath As String = "~/Img/" + disImg.ToString()

                Dim query As String = "INSERT Product (clothID, colour, size, material, priceEach, clothDesign) VALUES (@id, @colour, @size, @material, @price, @design)"
                Dim cmd As SqlCommand = New SqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@id", nextID) 'String
                cmd.Parameters.AddWithValue("@colour", ddlColour.SelectedValue) 'String
                cmd.Parameters.AddWithValue("@size", ddlSize.SelectedValue) 'char
                cmd.Parameters.AddWithValue("@material", ddlMaterial.SelectedValue) 'String
                cmd.Parameters.AddWithValue("@price", txtPrice.Text) 'Float
                cmd.Parameters.AddWithValue("@design", disImgPath) 'nvarchar
                cmd.ExecuteNonQuery()
                cmd.Dispose()

                MsgBox("Record saved.", MsgBoxStyle.Information)
                Me.ddlColour.SelectedIndex = -1
                Me.ddlType.SelectedIndex = -1
                Me.txtPrice.Text = ""
                Me.fuCDisplay.Attributes.Clear()
                Me.ddlSize.SelectedIndex = -1
                Me.ddlMaterial.SelectedIndex = -1


            Catch ex As SqlException
                MsgBox(ex.Message, , "Sql Exception")
            Catch ex As Exception
                MsgBox(ex.Message, , "General Exception")
            End Try
        Else
            MessageBox.Show("No Clothes information selected.", "Sorry")
        End If

    End Sub

    Protected Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        fuCDisplay.Attributes.Clear()
        ddlColour.SelectedIndex = -1
        ddlType.SelectedIndex = -1
        txtPrice.Text = ""
        ddlSize.SelectedIndex = -1
        ddlMaterial.SelectedIndex = -1
    End Sub

End Class