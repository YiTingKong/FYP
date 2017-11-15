Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Imports System.Windows.Forms
Imports System.IO

Public Class AdminViewClothes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.BindGrid()
        End If
    End Sub

    Private Sub BindGrid()
        Dim dt As DataTable = New DataTable("product")
        Dim query As String = "SELECT clothID, colour, size, material, priceEach, clothDesign FROM Product WHERE status = @status"

        'database
        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\FinalYearProject\FYP\App_Data\FYPdatabase.mdf;Integrated Security=True")
        Try
            connection.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim memoryStream As MemoryStream = New MemoryStream()

        'select product
        Dim cmd As SqlCommand = New SqlCommand(query, connection)
        cmd.Parameters.AddWithValue("@status", "Available")
        cmd.CommandType = CommandType.Text
        cmd.Connection = connection
        Dim da As New SqlDataAdapter(cmd)
        Try

            da.Fill(dt)
            gvClothes.DataSource = dt
            gvClothes.DataBind()
        Catch ex As Exception
            Response.Write(ex.Message)
        Finally
            connection.Close()
            da.Dispose()
            connection.Dispose()
        End Try
    End Sub

    Protected Sub OnPageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvClothes.PageIndex = e.NewPageIndex
        Me.BindGrid()
    End Sub

End Class