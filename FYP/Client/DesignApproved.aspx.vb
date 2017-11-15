Imports System.Data.SqlClient

Public Class DesignApproved
    Inherits System.Web.UI.Page
    Dim connection As SqlConnection = Nothing
    Dim conn As String = ConfigurationManager.ConnectionStrings("FYPDBConnectionString").ConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If ClientModule.userName = "" Then
            Response.Redirect("~/Client/ClientHome.aspx")
        End If
        If Not IsPostBack Then
            connection = New SqlConnection(conn)
            connection.Open()

            Dim productsql As String = "SELECT designID, status, validity, startDate, price FROM Design WHERE designID = @designID"
            Dim productcmd As SqlCommand = New SqlCommand(productsql, connection)
            productcmd.Parameters.AddWithValue("@designID", DesignModule.designID)

            Dim dt As SqlDataReader
            Try
                dt = productcmd.ExecuteReader
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            If dt.HasRows Then
                dt.Read()
                lblDetails.Text = "Design ID: " + dt.Item("designID") + "<br/>Status: " + dt.Item("status") + "<br/>Validity: " + dt.Item("validity").ToString + "<br/>Start Date: " + dt.Item("startDate").ToString + "<br/>Price: " + dt.Item("price").ToString
            Else
                MsgBox("No record found.")
                Return
            End If
        End If
        If rblAns.Text = "Yes" Then
            lblBank.Visible = True
            txtAcc.Visible = True
            btnSubmit.Visible = True
        ElseIf rblAns.Text = "No" Then
            lblBank.Visible = False
            txtAcc.Visible = False
            btnSubmit.Visible = False
            Dim msg = "Are you sure to reject our offer?"
            Dim title = "Important"
            Dim style = MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2
            Dim result = MsgBox(msg, style, title)
            If result = MsgBoxResult.Yes Then
                connection = New SqlConnection(conn)
                connection.Open()
                Dim updatesql As String = "Update Design SET status = @status WHERE designID = @designID"
                Dim updatecmd As SqlCommand = New SqlCommand(updatesql, connection)
                updatecmd.Parameters.AddWithValue("@status", "Reject")
                updatecmd.Parameters.AddWithValue("@designID", DesignModule.designID)
                updatecmd.ExecuteNonQuery()
                MsgBox("The offer has been rejected. Redirecting to check design page.")
                Response.Redirect("~/Client/CheckDesign.aspx")
            End If
        End If

    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim err As New StringBuilder()
        Dim ctr As Control = Nothing
        'Validation     
        If txtAcc.Text = "" Then
            err.AppendLine("- Please enter account number.")
            ctr = If(ctr, txtAcc)
        End If
        'show error message
        If err.Length > 0 Then
            MsgBox(err.ToString(), , "Input Error")
            ctr.Focus()
            Return
        End If

        connection = New SqlConnection(conn)
        connection.Open()
        Dim updatesql As String = "Update Login SET accountNumber = @accountNumber WHERE userName = @userName"
        Dim updatecmd As SqlCommand = New SqlCommand(updatesql, connection)
        updatecmd.Parameters.AddWithValue("@accountNumber", txtAcc.ToString)
        updatecmd.Parameters.AddWithValue("@userName", ClientModule.userName)
        updatecmd.ExecuteNonQuery()

        Dim sql As String = "Update Design SET status = @status WHERE designID = @designID"
        Dim cmd As SqlCommand = New SqlCommand(sql, connection)
        cmd.Parameters.AddWithValue("@status", "Approve")
        cmd.Parameters.AddWithValue("@designID", DesignModule.designID)
        cmd.ExecuteNonQuery()

        MsgBox("Status updated. Redirecting to check design status page.")
        Response.Redirect("~/Client/CheckDesign.aspx")
    End Sub
End Class