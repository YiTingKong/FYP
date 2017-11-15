Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO.Path

Public Class AdminClothesDelete
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

        Dim clothID As String = ddlClothID.SelectedItem.ToString()

        Dim query As String = "SELECT clothID, colour, size, material, priceEach, clothDesign, type FROM Product WHERE clothID = @clothID"
        Dim cmd As SqlCommand = New SqlCommand(query, connection)
        cmd.Parameters.AddWithValue("@clothID", clothID)
        Dim dtr As SqlDataReader
        dtr = cmd.ExecuteReader

        If dtr.HasRows Then
            dtr.Read()
            'set visible to true
            imgDis.Visible = True
            lblSize.Visible = True
            lblSizeDetail.Visible = True
            lblMaterial.Visible = True
            lblMaterialDetail.Visible = True
            lblType.Visible = True
            lblTypeDetail.Visible = True
            lblColour.Visible = True
            lblColourDetail.Visible = True
            lblPrice.Visible = True
            lblPriceDetail.Visible = True
            btnDelete.Visible = True

            'display data
            imgDis.ImageUrl = dtr.Item("clothDesign")
            lblSizeDetail.Text = dtr.Item("size")
            lblMaterialDetail.Text = dtr.Item("material")
            lblTypeDetail.Text = dtr.Item("type")
            lblColourDetail.Text = dtr.Item("colour")
            lblPriceDetail.Text = dtr.Item("priceEach")
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

        Dim clothID As String = ddlClothID.SelectedValue

        Dim updateQuery As String = "UPDATE Product SET status = @status WHERE clothID = @clothID"

        Dim cmd As SqlCommand = New SqlCommand(updateQuery, connection)
        cmd.Parameters.AddWithValue("@clothID", clothID)
        cmd.Parameters.AddWithValue("@status", "Not Available")
        cmd.ExecuteNonQuery()
        cmd.Dispose()

        MsgBox("Record deleted.", MsgBoxStyle.Information)

        Response.Redirect("AdminClothesDelete.aspx", True)
        connection.Close()
    End Sub
End Class