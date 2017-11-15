Imports System.Data.SqlClient
Imports System.Drawing

Public Class Products
    Inherits System.Web.UI.Page
    Dim connection As SqlConnection = Nothing
    Dim conn As String = ConfigurationManager.ConnectionStrings("FYPDBConnectionString").ConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim dt As New DataTable()
            Dim sql As String = "Select clothType, material, priceEach, clothDesign From Product"
            Dim cmd As New SqlCommand(sql)
            Dim con As New SqlConnection(conn)
            Dim sda As New SqlDataAdapter()
            cmd.CommandType = CommandType.Text
            cmd.Connection = con
            Try
                con.Open()
                sda.SelectCommand = cmd
                sda.Fill(dt)
                GridView1.DataSource = dt
                GridView1.DataBind()
            Catch ex As Exception
                Response.Write(ex.Message)
            Finally
                con.Close()
                sda.Dispose()
                con.Dispose()
            End Try
        End If

    End Sub

    Protected Sub btnChoose_Click(sender As Object, e As EventArgs) Handles btnChoose.Click
        If preference.Text = "- Choose From Here -" Then
            MsgBox("Please choose a category.")
            Return
        ElseIf preference.Text.Equals("All Products") Then
            Dim dt As New DataTable()
            Dim sql As String = "Select clothType, material, priceEach, clothDesign From Product"
            Dim cmd As New SqlCommand(sql)
            Dim con As New SqlConnection(conn)
            Dim sda As New SqlDataAdapter()
            cmd.CommandType = CommandType.Text
            cmd.Connection = con
            Try
                con.Open()
                sda.SelectCommand = cmd
                sda.Fill(dt)
                GridView1.DataSource = dt
                GridView1.DataBind()
            Catch ex As Exception
                Response.Write(ex.Message)
            Finally
                con.Close()
                sda.Dispose()
                con.Dispose()
                btnSearch.Visible = False
                DropDownList1.Visible = False
            End Try
        ElseIf preference.Text.Equals("Colours") Then
            Dim dt As New DataTable()
            Dim sql As String = "Select colour From Colour"
            Dim cmd As New SqlCommand(sql)
            Dim con As New SqlConnection(conn)
            cmd.CommandType = CommandType.Text
            cmd.Connection = con
            Try
                con.Open()
                DropDownList1.DataSource = cmd.ExecuteReader()
                DropDownList1.DataTextField = "colour"
                DropDownList1.DataValueField = "colour"
                DropDownList1.DataBind()

            Catch ex As Exception
                Response.Write(ex.Message)
            Finally
                con.Close()
                con.Dispose()
                btnSearch.Visible = True
                DropDownList1.Visible = True
            End Try
        ElseIf preference.Text.Equals("Material") Then
            Dim dt As New DataTable()
            Dim sql As String = "Select Material From Material"
            Dim cmd As New SqlCommand(sql)
            Dim con As New SqlConnection(conn)
            cmd.CommandType = CommandType.Text
            cmd.Connection = con
            Try
                con.Open()
                DropDownList1.DataSource = cmd.ExecuteReader()
                DropDownList1.DataTextField = "Material"
                DropDownList1.DataValueField = "Material"
                DropDownList1.DataBind()
            Catch ex As Exception
                Response.Write(ex.Message)
            Finally
                con.Close()
                con.Dispose()
                btnSearch.Visible = True
                DropDownList1.Visible = True
            End Try
        ElseIf preference.Text.Equals("Cloth Type") Then
            Dim dt As New DataTable()
            Dim sql As String = "Select Des From ClothType"
            Dim cmd As New SqlCommand(sql)
            Dim con As New SqlConnection(conn)
            cmd.CommandType = CommandType.Text
            cmd.Connection = con
            Try
                con.Open()
                DropDownList1.DataSource = cmd.ExecuteReader()
                DropDownList1.DataTextField = "Des"
                DropDownList1.DataValueField = "Des"
                DropDownList1.DataBind()
                btnSearch.Visible = True
                DropDownList1.Visible = True
            Catch ex As Exception
                Response.Write(ex.Message)
            Finally
                con.Close()
                con.Dispose()
            End Try
        End If

    End Sub

    Protected Sub btnSearch_Click1(sender As Object, e As EventArgs) Handles btnSearch.Click
        If preference.Text = "- Choose From Here -" Then
            MsgBox("Please choose a category.")
            Return
        ElseIf preference.Text.Equals("All Products") Then

        ElseIf preference.Text.Equals("Colours") Then
            Dim colour As String = DropDownList1.SelectedValue.ToString
            Dim dt2 As New DataTable()
            Dim sql2 As String = "Select clothType, material, priceEach, clothDesign From Product where colour = @colour"
            Dim cmd2 As New SqlCommand(sql2)
            Dim con2 As New SqlConnection(conn)
            Dim sda As New SqlDataAdapter()
            cmd2.Parameters.AddWithValue("@colour", colour)
            cmd2.CommandType = CommandType.Text
            cmd2.Connection = con2
            Try
                con2.Open()
                sda.SelectCommand = cmd2
                sda.Fill(dt2)
                If dt2.Rows.Count < 1 Then
                    MsgBox("Column mismatch. Please click the choose button before search button.")
                    Return
                End If
                GridView1.DataSource = dt2
                GridView1.DataBind()
            Catch ex As Exception
                Response.Write(ex.Message)
            Finally
                con2.Close()
                sda.Dispose()
                con2.Dispose()
            End Try
        ElseIf preference.Text.Equals("Material") Then
            Dim material As String = DropDownList1.SelectedValue.ToString
            Dim dt2 As New DataTable()
            Dim sql2 As String = "Select clothType, material, priceEach, clothDesign From Product where material = @material"
            Dim cmd2 As New SqlCommand(sql2)
            Dim con2 As New SqlConnection(conn)
            Dim sda As New SqlDataAdapter()
            cmd2.Parameters.AddWithValue("@material", material)
            cmd2.CommandType = CommandType.Text
            cmd2.Connection = con2
            Try
                con2.Open()
                sda.SelectCommand = cmd2
                sda.Fill(dt2)
                If dt2.Rows.Count < 1 Then
                    MsgBox("Column mismatch. Please click the choose button before search button.")
                    Return
                End If
                GridView1.DataSource = dt2
                GridView1.DataBind()
            Catch ex As Exception
                Response.Write(ex.Message)
            Finally
                con2.Close()
                sda.Dispose()
                con2.Dispose()
            End Try
        ElseIf preference.Text.Equals("Cloth Type") Then
            Dim type As String = DropDownList1.SelectedValue.ToString
            Dim dt2 As New DataTable()
            Dim sql2 As String = "Select clothType, material, priceEach, clothDesign From Product where clothType = @clothType"
            Dim cmd2 As New SqlCommand(sql2)
            Dim con2 As New SqlConnection(conn)
            Dim sda As New SqlDataAdapter()
            cmd2.Parameters.AddWithValue("@clothType", type)
            cmd2.CommandType = CommandType.Text
            cmd2.Connection = con2
            Try
                con2.Open()
                sda.SelectCommand = cmd2
                sda.Fill(dt2)
                If dt2.Rows.Count < 1 Then
                    MsgBox("Column mismatch. Please click the choose button before search button.")
                    Return
                End If
                GridView1.DataSource = dt2
                GridView1.DataBind()
            Catch ex As Exception
                Response.Write(ex.Message)
            Finally
                con2.Close()
                sda.Dispose()
                con2.Dispose()
            End Try

        Else
        End If

    End Sub

    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        If ClientModule.userName = "" Then
            MsgBox("Please login to continue.")
            Response.Redirect("~/Client/Login.aspx")
        Else
            Response.Redirect("~/Client/Orders.aspx")
            End If

    End Sub


End Class