Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO.Path

Public Class AdminDesignUpdate
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

        txtPrice.Enabled = False
        txtUserName.Enabled = False

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
            fuImg.Visible = True
            imgDesign.Visible = True
            lblValid.Visible = True
            txtValid.Visible = True
            btnUpdate.Visible = True
            btnReset.Visible = True

            Dim type As String = dtr.Item("type")
            Dim official As String = "Official"

            If String.Compare(type, official) = 0 Then
                lblDesigner.Visible = False
                lblUserName.Visible = False
                txtUserName.Visible = False
                lblPrice.Visible = False
                txtPrice.Visible = False

                imgDesign.ImageUrl = dtr.Item("designPath")
                txtValid.Text = dtr.Item("validity")
            Else
                fuImg.Visible = False
                lblDesigner.Visible = True
                lblUserName.Visible = True
                txtUserName.Visible = True
                lblPrice.Visible = True
                txtPrice.Visible = True

                imgDesign.ImageUrl = dtr.Item("designPath")
                txtValid.Text = dtr.Item("validity")
                txtUserName.Text = dtr.Item("userName")
                txtPrice.Text = dtr.Item("price")
            End If
        End If

        connection.Close()
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Me.GetData()
    End Sub

    Protected Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Me.GetData()
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim err As New StringBuilder()

        'validation
        If txtValid.Text = "" Then
            err.AppendLine("- Please enter validity of design.")
        End If

        If Not txtValid.Text = "" Then
            Dim validity As Integer = Convert.ToInt32(txtValid.Text)
            If validity < 1 Or validity > 24 Then
                err.AppendLine("- Validity(month) only between 1 to 24.")
            End If
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

        Dim designID As String = ddlDesignID.SelectedValue

        If fuImg.HasFile Then
            Dim imgPath As String = fuImg.FileName
            fuImg.PostedFile.SaveAs(Server.MapPath("~/Img/" + imgPath))
            Dim designPath As String = "~/Img/" + imgPath.ToString()

            If txtUserName.Visible = True Then
                Dim updateQuery As String = "UPDATE Design 
                                    SET validity = @validity, price = @price, userName = @userName, designPath = @design
                                    WHERE designID = @designID"

                Dim cmd As SqlCommand = New SqlCommand(updateQuery, connection)
                cmd.Parameters.AddWithValue("@designID", designID)
                cmd.Parameters.AddWithValue("@validity", txtValid.Text)
                cmd.Parameters.AddWithValue("@price", txtPrice.Text)
                cmd.Parameters.AddWithValue("@userName", txtUserName.Text)
                cmd.Parameters.AddWithValue("@design", designPath)
                cmd.ExecuteNonQuery()
                cmd.Dispose()

                MsgBox("Record updated.", MsgBoxStyle.Information)
            Else
                Dim updateQuery As String = "UPDATE Design 
                                    SET validity = @validity, designPath = @design
                                    WHERE designID = @designID"

                Dim cmd As SqlCommand = New SqlCommand(updateQuery, connection)
                cmd.Parameters.AddWithValue("@designID", designID)
                cmd.Parameters.AddWithValue("@validity", txtValid.Text)
                cmd.Parameters.AddWithValue("@design", designPath)
                cmd.ExecuteNonQuery()
                cmd.Dispose()

                MsgBox("Record updated.", MsgBoxStyle.Information)
            End If
        Else
            If txtUserName.Visible = True Then
                Dim updateQuery As String = "UPDATE Design 
                                    SET validity = @validity, price = @price, userName = @userName
                                    WHERE designID = @designID"

                Dim cmd As SqlCommand = New SqlCommand(updateQuery, connection)
                cmd.Parameters.AddWithValue("@designID", designID)
                cmd.Parameters.AddWithValue("@validity", txtValid.Text)
                cmd.Parameters.AddWithValue("@price", txtPrice.Text)
                cmd.Parameters.AddWithValue("@userName", txtUserName.Text)
                cmd.ExecuteNonQuery()
                cmd.Dispose()

                MsgBox("Record updated.", MsgBoxStyle.Information)
            Else
                Dim updateQuery As String = "UPDATE Design 
                                    SET validity = @validity
                                    WHERE designID = @designID"

                Dim cmd As SqlCommand = New SqlCommand(updateQuery, connection)
                cmd.Parameters.AddWithValue("@designID", designID)
                cmd.Parameters.AddWithValue("@validity", txtValid.Text)
                cmd.ExecuteNonQuery()
                cmd.Dispose()

                MsgBox("Record updated.", MsgBoxStyle.Information)
            End If
        End If


        Response.Redirect("AdminDesignUpdate.aspx", True)
        connection.Close()
    End Sub
End Class