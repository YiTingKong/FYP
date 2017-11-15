Imports System.Data.SqlClient
Imports System.IO

Public Class UploadDesign
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If ClientModule.userName = "" Then
            Response.Redirect("~/Client/ClientHome.aspx")
        End If
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim err As New StringBuilder()
        Dim ctr As Control = Nothing

        If imgUpload.HasFile = False Then
            err.AppendLine("- Please upload design.")
            ctr = If(ctr, imgUpload)
        Else
            Dim strpath As String = System.IO.Path.GetExtension(imgUpload.FileName)
            If strpath <> ".jpg" AndAlso strpath <> ".jpeg" AndAlso strpath <> ".gif" AndAlso strpath <> ".png" Then
                err.AppendLine("- Only image formats (jpg, png, gif) are accepted.")
                ctr = If(ctr, imgUpload)
            End If
            Dim img2 As System.Drawing.Image = System.Drawing.Image.FromStream(imgUpload.PostedFile.InputStream)
            Dim height As Integer = img2.Height
            Dim width As Integer = img2.Width
            Dim size As Decimal = Math.Round((CDec(imgUpload.PostedFile.ContentLength) / CDec(1024)), 2)
            If height > 100 Or width > 100 Then
                err.AppendLine("- Only image 100x100 are accepted.")
                ctr = If(ctr, imgUpload)
            End If

        End If



        'show error message
        If err.Length > 0 Then
            MsgBox(err.ToString(), , "Input Error")
            ctr.Focus()
            Return
        End If

        Dim img As FileUpload = CType(imgUpload, FileUpload)
        DesignModule.design = img
        DesignModule.filename = Path.GetFileName(img.PostedFile.FileName)

        MsgBox("Upload successfully. Redirecting to payment.", , "Congratulation")
        Response.Redirect("~/Client/Payment.aspx")

    End Sub

End Class