Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO.Path

Public Class AdminClothesUpdate
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
            Dim IDquery As String = "SELECT clothID FROM Product WHERE status = @status"
            Dim IDcmd As SqlCommand = New SqlCommand(IDquery, connection)
            IDcmd.Parameters.AddWithValue("@status", "available")
            Dim IDdtr As SqlDataReader
            IDdtr = IDcmd.ExecuteReader

            If IDdtr.HasRows Then
                While IDdtr.Read()
                    ddlClothID.Items.Add(IDdtr(0).ToString())
                End While
            End If
            IDdtr.Dispose()

            'size
            Dim sizequery As String = "SELECT * FROM Size WHERE status = @status"
            Dim sizecmd As SqlCommand = New SqlCommand(sizequery, connection)
            sizecmd.Parameters.AddWithValue("@status", "available")
            Dim sizedtr As SqlDataReader
            sizedtr = sizecmd.ExecuteReader

            If sizedtr.HasRows Then
                While sizedtr.Read()
                    ddlSize.Items.Add(sizedtr(1).ToString())
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
        End If

        connection.Close()

    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim err As New StringBuilder()

        'validation
        If txtPrice.Text = "" Then
            err.AppendLine("- Please enter Clothes Price.")
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

        Dim clothID As String = ddlClothID.SelectedValue
        Dim colour As String = ddlColour.SelectedValue
        Dim size As String = ddlSize.SelectedValue
        Dim material As String = ddlMaterial.SelectedValue
        Dim price As String = txtPrice.Text
        Dim type As String = ddlType.SelectedValue

        If fuImg.HasFile Then
            Dim imgPath As String = fuImg.FileName
            fuImg.PostedFile.SaveAs(Server.MapPath("~/Img/" + imgPath))
            Dim disImgPath As String = "~/Img/" + imgPath.ToString()

            Dim updateQuery As String = "UPDATE Product 
                                    SET colour = @colour, size = @size, material = @material, priceEach = @price, clothDesign = @design, type = @type 
                                    WHERE clothID = @clothID"

            Dim cmd As SqlCommand = New SqlCommand(updateQuery, connection)
            cmd.Parameters.AddWithValue("@clothID", clothID)
            cmd.Parameters.AddWithValue("@colour", colour)
            cmd.Parameters.AddWithValue("@size", size)
            cmd.Parameters.AddWithValue("@material", material)
            cmd.Parameters.AddWithValue("@price", price)
            cmd.Parameters.AddWithValue("@design", disImgPath)
            cmd.Parameters.AddWithValue("@type", type)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            MsgBox("Record updated.", MsgBoxStyle.Information)

        Else
            Dim updateQuery As String = "UPDATE Product 
                                    SET colour = @colour, size = @size, material = @material, priceEach = @price, type = @type 
                                    WHERE clothID = @clothID"

            Dim cmd As SqlCommand = New SqlCommand(updateQuery, connection)
            cmd.Parameters.AddWithValue("@clothID", clothID)
            cmd.Parameters.AddWithValue("@colour", colour)
            cmd.Parameters.AddWithValue("@size", size)
            cmd.Parameters.AddWithValue("@material", material)
            cmd.Parameters.AddWithValue("@price", price)
            cmd.Parameters.AddWithValue("@type", type)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            MsgBox("Record updated.", MsgBoxStyle.Information)

        End If

        Response.Redirect("AdminClothesUpdate.aspx", True)
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

        Dim clothID As String = ddlClothID.SelectedItem.ToString()

        Dim query As String = "SELECT clothID, colour, size, material, priceEach, clothDesign, clothType FROM Product WHERE clothID = @clothID"
        Dim cmd As SqlCommand = New SqlCommand(query, connection)
        cmd.Parameters.AddWithValue("@clothID", clothID)
        Dim dtr As SqlDataReader
        dtr = cmd.ExecuteReader

        If dtr.HasRows Then
            dtr.Read()
            'Visible
            lblImage.Visible = True
            fuImg.Visible = True
            imgDis.Visible = True
            lblSize.Visible = True
            ddlSize.Visible = True
            lblMaterial.Visible = True
            ddlMaterial.Visible = True
            lblType.Visible = True
            ddlType.Visible = True
            lblColour.Visible = True
            ddlColour.Visible = True
            lblPrice.Visible = True
            txtPrice.Visible = True
            btnUpdate.Visible = True
            btnReset.Visible = True

            imgDis.ImageUrl = dtr.Item("clothDesign")
            ddlSize.SelectedValue = dtr.Item("size")
            ddlMaterial.SelectedValue = dtr.Item("material")
            ddlColour.SelectedValue = dtr.Item("colour")
            ddlType.SelectedValue = dtr.Item("clothType")
            txtPrice.Text = dtr.Item("priceEach")
        End If
        connection.Close()
    End Sub

    Protected Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Me.GetData()
    End Sub

End Class