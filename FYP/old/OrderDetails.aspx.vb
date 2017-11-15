Imports System.Data.SqlClient
Imports System.Drawing

Public Class OrderDetails
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If ClientModule.userName = "" Then
            Response.Redirect("~/Client/ClientHome.aspx")
        End If
        Dim connection As SqlConnection = Nothing
        Dim conn As String = ConfigurationManager.ConnectionStrings("FYPDBConnectionString").ConnectionString
        connection = New SqlConnection(conn)
        connection.Open()

        lblColor.Text = OrderModule.colour
        lblSize.Text = OrderModule.size
        lblMaterial.Text = OrderModule.material

        If Not IsPostBack Then
            If OrderModule.designID = "" Then
                OrderModule.customizeDesign.SaveAs(Server.MapPath("~/image/" + OrderModule.customizePath))
                'Image2.ImageUrl = "~/image/" + OrderModule.customizePath

                'show the design outcome
                Dim img As Image
                img = New Bitmap(200, 200)
                If OrderModule.colour = "Black" Then
                    img = Image.FromFile(Server.MapPath("~/image/black.jpg"))
                ElseIf OrderModule.colour = "Blue" Then
                    img = Image.FromFile(Server.MapPath("~/image/blue.jpg"))
                ElseIf OrderModule.colour = "Red" Then
                    img = Image.FromFile(Server.MapPath("~/image/red.jpg"))
                ElseIf OrderModule.colour = "Green" Then
                    img = Image.FromFile(Server.MapPath("~/image/green.jpg"))
                ElseIf OrderModule.colour = "Grey" Then
                    img = Image.FromFile(Server.MapPath("~/image/grey.jpg"))
                End If

                Dim g As Graphics
                g = Graphics.FromImage(img)
                g.DrawImage(Image.FromFile(Server.MapPath("~/image/" + OrderModule.customizePath)), New Point(62, 50))
                img.Save(Server.MapPath("~/image/test.jpg"))
                Image2.ImageUrl = "~/image/test.jpg"

            Else
                Dim sql As String = "SELECT designPath FROM Design WHERE designID = @designID"
                Dim cmd As SqlCommand = New SqlCommand(sql, connection)
                cmd.Parameters.AddWithValue("@designID", OrderModule.designID)
                Dim dtr As SqlDataReader
                dtr = cmd.ExecuteReader
                Dim designUrl As String

                If dtr.HasRows Then
                    dtr.Read()
                    designUrl = dtr.Item("designPath")
                    'Image2.ImageUrl = dtr.Item("designPath")
                    dtr.Close()
                End If

                'show the design outcome
                Dim img As Image
                img = New Bitmap(200, 200)
                If OrderModule.colour = "Black" Then
                    img = Image.FromFile(Server.MapPath("~/image/black.jpg"))
                ElseIf OrderModule.colour = "Blue" Then
                    img = Image.FromFile(Server.MapPath("~/image/blue.jpg"))
                ElseIf OrderModule.colour = "Red" Then
                    img = Image.FromFile(Server.MapPath("~/image/red.jpg"))
                ElseIf OrderModule.colour = "Green" Then
                    img = Image.FromFile(Server.MapPath("~/image/green.jpg"))
                ElseIf OrderModule.colour = "Grey" Then
                    img = Image.FromFile(Server.MapPath("~/image/grey.jpg"))
                End If

                Dim g As Graphics
                g = Graphics.FromImage(img)
                g.DrawImage(Image.FromFile(Server.MapPath(designUrl)), New Point(62, 50))
                img.Save(Server.MapPath("~/image/test.jpg"))
                Image2.ImageUrl = "~/image/test.jpg"
            End If
        End If


        Dim productsql As String = "SELECT clothID, priceEach FROM Product WHERE colour = @colour AND size = @size AND material = @material"
        Dim productcmd As SqlCommand = New SqlCommand(productsql, connection)
        productcmd.Parameters.AddWithValue("@colour", OrderModule.colour)
        productcmd.Parameters.AddWithValue("@size", OrderModule.size)
        productcmd.Parameters.AddWithValue("@material", OrderModule.material)
        Dim dt As SqlDataReader
        dt = productcmd.ExecuteReader

        If dt.HasRows Then
            dt.Read()
            OrderModule.clothID = dt.Item("clothID")
            OrderModule.priceEach = dt.Item("priceEach")
        Else
            MsgBox("No record found.")
        End If
        dt.Close()
        Dim quantity As Integer
        quantity = Integer.Parse(ddlQuantity.SelectedItem.Text)

        Dim dtable As New DataTable()
        Dim productDetailsql As String = "SELECT PD.MachineID, M.locationName, M.address, PD.qty FROM Machine M, ProductDetail PD WHERE PD.clothID = @clothID AND PD.qty >= @qty AND PD.MachineID = M.MachineID"
        Dim productDetailcmd As New SqlCommand(productDetailsql)
        productDetailcmd.Parameters.AddWithValue("@clothID", OrderModule.clothID)
        productDetailcmd.Parameters.AddWithValue("@qty", quantity)
        Dim con As New SqlConnection(conn)
        Dim sda As New SqlDataAdapter()
        productDetailcmd.CommandType = CommandType.Text
        productDetailcmd.Connection = con
        Try
            con.Open()
            sda.SelectCommand = productDetailcmd
            sda.Fill(dtable)
            GridView1.DataSource = dtable
            GridView1.DataBind()
            If GridView1.Rows.Count < 1 Then
                lblLocation.Text = "Sorry, not enough of stock in any location."
            Else
                lblLocation.Text = ""
            End If
        Catch ex As Exception
            Response.Write(ex.Message)
        Finally
            con.Close()
            sda.Dispose()
            con.Dispose()
        End Try

    End Sub

    Protected Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim err As New StringBuilder()
        Dim ctr As Control = Nothing
        Dim selectedRow As Integer = GridView1.SelectedIndex

        Dim machineID As String
        Dim qty As Integer
        Dim location As String

        If GridView1.SelectedIndex = -1 Then
            err.AppendLine("- Please select a location.")
            ctr = If(ctr, GridView1)
        Else
            machineID = GridView1.Rows(selectedRow).Cells(1).Text
            qty = GridView1.Rows(selectedRow).Cells(4).Text
            location = GridView1.Rows(selectedRow).Cells(2).Text
            OrderModule.machineID = machineID
            OrderModule.stock = qty
            OrderModule.machineLocation = location
        End If

        OrderModule.quantity = Integer.Parse(ddlQuantity.SelectedItem.Text)

        'show error message
        If Err.Length > 0 Then
            MsgBox(Err.ToString(), , "Input Error")
            ctr.Focus()
            Return
        End If

        Response.Redirect("~/Client/OrderPayments.aspx")
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        GridView1.SelectedRow.BackColor = Color.PaleGreen
    End Sub
End Class