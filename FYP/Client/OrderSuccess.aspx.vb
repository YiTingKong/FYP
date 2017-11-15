Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports ZXing

Public Class OrderSuccess
    Inherits System.Web.UI.Page
    Dim count As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If ClientModule.userName = "" Then
            Response.Redirect("~/Client/ClientHome.aspx")
        End If
        If Not IsPostBack Then
            count = count + 1
            'try
            Dim writer = New BarcodeWriter()
            writer.Format = BarcodeFormat.QR_CODE
            Dim result = writer.Write("Payment ID :" + OrderModule.qrID)
            Dim path As String = Server.MapPath("~/image/QRImage.jpg")
            Dim barcodeBitmap = New Bitmap(result)

            Using memory As New MemoryStream()
                Using fs As New FileStream(path, FileMode.Create, FileAccess.ReadWrite)
                    barcodeBitmap.Save(memory, ImageFormat.Jpeg)
                    Dim bytes As Byte() = memory.ToArray()
                    fs.Write(bytes, 0, bytes.Length)
                    fs.Close()
                End Using
                memory.Close()
            End Using
            barcodeBitmap.Dispose()


            imgQRCode.ImageUrl = "~/image/QRImage.jpg"

            Dim reader = New BarcodeReader()
            Dim filename As String = Request.MapPath("~/image/QRImage.jpg")
            ' Detect and decode the barcode inside the bitmap
            Dim result2 = reader.Decode(New Bitmap(filename))
            If result IsNot Nothing Then
                lblQRCode.Text = "QR Code: " + result2.Text
            End If
        End If

    End Sub

    Protected Sub btnClick_Click(sender As Object, e As EventArgs) Handles btnClick.Click
        Dim connection As SqlConnection = Nothing
        Dim conn As String = ConfigurationManager.ConnectionStrings("FYPDBConnectionString").ConnectionString
        connection = New SqlConnection(conn)
        connection.Open()
        Dim sql As String = "SELECT * FROM Login WHERE userName = @username"
        Dim cmd As SqlCommand = New SqlCommand(sql, connection)
        cmd.Parameters.AddWithValue("@userName", ClientModule.userName)
        Dim dtr As SqlDataReader
        dtr = cmd.ExecuteReader

        If dtr.HasRows Then
            dtr.Read()
            Try
                Dim mail = New MailMessage()
                mail.From = New MailAddress("testingprogram80@gmail.com")
                Dim smtp = New SmtpClient()
                '25 if use phone data
                '587 if use wifi
                smtp.Port = 25
                smtp.EnableSsl = True
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                smtp.UseDefaultCredentials = False
                smtp.Credentials = New NetworkCredential("testingprogram80@gmail.com", "123456789abc")
                smtp.Host = "smtp.gmail.com"

                mail.To.Add(dtr.Item("email"))
                mail.IsBodyHtml = True
                Dim st As New StringBuilder

                st.AppendLine("Hi " + ClientModule.nickname + ",<br/><br/>" + " Your payment number is: " + OrderModule.qrID + "<br/>Location: " + OrderModule.machineLocation + "<br/>Please scan the attachment below in front of the machine to retrieve cloth." + "<br/><br/>Best Regards," + Environment.NewLine + "<br/>Trendary")
                mail.Body = st.ToString()

                Dim attachment As System.Net.Mail.Attachment
                attachment = New System.Net.Mail.Attachment(Request.MapPath("~/image/QRImage.jpg"))
                mail.Attachments.Add(attachment)
                smtp.Send(mail)
                MsgBox("Your QR Code and payment details has been sent to your email.", , "Important Note")

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub
End Class