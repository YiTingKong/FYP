Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO.Path

Public Class AdminDesignDelete
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
            Dim IDquery As String = "SELECT designID FROM Design WHERE status = @status"
            Dim IDcmd As SqlCommand = New SqlCommand(IDquery, connection)
            IDcmd.Parameters.AddWithValue("@status", "available")
            Dim IDdtr As SqlDataReader
            IDdtr = IDcmd.ExecuteReader

            If IDdtr.HasRows Then
                While IDdtr.Read()
                    ddlDesignID.Items.Add(IDdtr(0).ToString())
                End While
            End If
            IDdtr.Dispose()
        End If

        connection.Close()
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

        Dim designID As String = ddlDesignID.SelectedItem.ToString()

        Dim query As String = "SELECT designID, type, validity, startDate, price, userName, designPath FROM Design WHERE designID = @designID"
        Dim cmd As SqlCommand = New SqlCommand(query, connection)
        cmd.Parameters.AddWithValue("@designID", designID)
        Dim dtr As SqlDataReader
        dtr = cmd.ExecuteReader

        If dtr.HasRows Then
            dtr.Read()
            'Visible
            lblImage.Visible = True
            imgDesign.Visible = True
            lblValid.Visible = True
            lblValidDetails.Visible = True
            btnDelete.Visible = True

            Dim type As String = dtr.Item("type")
            Dim general As String = "General"

            If String.Compare(type, general) = 0 Then 'True
                lblDesigner.Visible = False
                lblUserName.Visible = False
                lblUserNameDetail.Visible = False
                lblPrice.Visible = False
                lblPriceDetail.Visible = False

                imgDesign.ImageUrl = dtr.Item("designPath")
                lblValidDetails.Text = dtr.Item("validity")
            Else
                lblDesigner.Visible = True
                lblUserName.Visible = True
                lblUserNameDetail.Visible = True
                lblPrice.Visible = True
                lblPriceDetail.Visible = True

                imgDesign.ImageUrl = dtr.Item("designPath")
                lblValidDetails.Text = dtr.Item("validity")
                lblUserNameDetail.Text = dtr.Item("userName")
                lblPriceDetail.Text = dtr.Item("price")
            End If
        End If

        connection.Close()
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Me.GetData()
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

        Dim designID As String = ddlDesignID.SelectedValue

        Dim updateQuery As String = "UPDATE Design SET status = @status WHERE designID = @designID"

        Dim cmd As SqlCommand = New SqlCommand(updateQuery, connection)
        cmd.Parameters.AddWithValue("@designID", designID)
        cmd.Parameters.AddWithValue("@status", "Not Available")
        cmd.ExecuteNonQuery()
        cmd.Dispose()

        MsgBox("Record deleted.", MsgBoxStyle.Information)

        Response.Redirect("AdminDesignDelete.aspx", True)
        connection.Close()
    End Sub
End Class