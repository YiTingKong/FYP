Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO

Public Class OrderDesign
    Inherits System.Web.UI.Page
    Dim connection As SqlConnection = Nothing
    Dim conn As String = ConfigurationManager.ConnectionStrings("FYPDBConnectionString").ConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If ClientModule.userName = "" Then
            Response.Redirect("~/Client/ClientHome.aspx")
        End If
        If radDesignType.Text = "General Design" Then
            lblDesign.Text = "General Design"
            lbl.Visible = True
            lblDesign.Visible = True
            GridView1.Visible = True
            FileUpload1.Visible = False
            Dim dt As New DataTable()
            Dim sql As String = "Select designID, designPath From Design Where type = 'General'"
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
        ElseIf radDesignType.Text = "Customize Design" Then
            GridView1.Visible = False
            lbl.Visible = True
            lblDesign.Text = "Customize Design"
            FileUpload1.Visible = True
            lblDesign.Visible = True
            'btnNext.Attributes.Add("OnClick", "return confirm('Are you sure you want to delete this record?')")
        End If


    End Sub

    Protected Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim err As New StringBuilder()
        Dim ctr As Control = Nothing
        Dim designID As String
        Dim selectedRow As Integer = GridView1.SelectedIndex

        If radDesignType.Text = "" Then
            err.AppendLine("- Please select design type.")
            ctr = If(ctr, radDesignType)
        End If

        If radDesignType.Text.Equals("General Design") Then
            designID = GridView1.Rows(selectedRow).Cells(1).Text
            If designID = "" Then
                err.AppendLine("- Please select a design.")
                ctr = If(ctr, GridView1)
            End If
        ElseIf radDesignType.Text.Equals("Customize Design") Then
            designID = ""
            If FileUpload1.HasFile = False Then
                err.AppendLine("- Please upload design.")
                ctr = If(ctr, FileUpload1)
            Else
                Dim strpath As String = System.IO.Path.GetExtension(FileUpload1.FileName)
                If strpath <> ".jpg" AndAlso strpath <> ".jpeg" AndAlso strpath <> ".gif" AndAlso strpath <> ".png" Then
                    err.AppendLine("- Only image formats (jpg, png, gif) are accepted.")
                    ctr = If(ctr, FileUpload1)
                End If
            End If

        End If

        'show error message
        If err.Length > 0 Then
            MsgBox(err.ToString(), , "Input Error")
            ctr.Focus()
            Return
        End If

        If radDesignType.Text.Equals("Customize Design") Then
            OrderModule.designID = ""
            Dim img As FileUpload = CType(FileUpload1, FileUpload)
            OrderModule.customizeDesign = img
            OrderModule.customizePath = Path.GetFileName(img.PostedFile.FileName)

            Dim msg = "All copyright, trade marks, design rights, patents and other intellectual property rights registered in and on Trendary belong to the Trendary and/or third parties (which may include you or other users.) The Trendary reserves all of its rights in Trendary. Nothing in the Terms grants you a right or license to use any trade mark, design right or copyright owned or controlled by the Trendary or any other third party except as expressly provided in the Terms."
            Dim title = "Terms and Conditions"
            Dim style = MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2
            Dim result = MsgBox(msg, style, title)
            If result = MsgBoxResult.Yes Then
                Response.Redirect("~/Client/OrderDetails.aspx")
            Else

            End If
        ElseIf radDesignType.Text.Equals("General Design") Then
            OrderModule.designID = designID
            Response.Redirect("~/Client/OrderDetails.aspx")
        End If



    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        GridView1.SelectedRow.BackColor = Color.PaleGreen
    End Sub

End Class