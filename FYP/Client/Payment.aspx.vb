Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO

Public Class Payment
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If ClientModule.userName = "" Then
            Response.Redirect("~/Client/ClientHome.aspx")
        End If

        lblPaymentAmt.Text = "5"
    End Sub

    Protected Sub btnPay_Click(sender As Object, e As EventArgs) Handles btnPay.Click
        Dim err As New StringBuilder()
        Dim ctr As Control = Nothing
        Dim paymentMethod As String

        Dim connection As SqlConnection = Nothing
        Dim conn As String = ConfigurationManager.ConnectionStrings("FYPDBConnectionString").ConnectionString
        connection = New SqlConnection(conn)
        connection.Open()

        'Validation
        If txtName.Text = "" Then
            err.AppendLine("- Please enter name on card.")
            ctr = If(ctr, txtName)
        End If

        If radPaymentMethod.Text.Equals("Credit") Then
            paymentMethod = "Credit Card"
        ElseIf radPaymentMethod.Text.Equals("Debit") Then
            paymentMethod = "Debit Card"
        Else
            err.AppendLine("- Please select payment method.")
            ctr = If(ctr, radPaymentMethod)
        End If

        If txtCardNumber.Text = "" Then
            err.AppendLine("- Please enter card number.")
            ctr = If(ctr, txtCardNumber)
        End If

        If Not ValidateCard(txtCardNumber.Text) Then
            err.AppendLine("- Must be a 16-digit card number.")
            ctr = If(ctr, txtCardNumber)
        End If

        If txtCVV.Text = "" Then
            err.AppendLine("- Please enter cvv.")
            ctr = If(ctr, txtCVV)
        End If

        If Not ValidateCVV(txtCVV.Text) Then
            err.AppendLine("- Must be a 3-digit CVV.")
            ctr = If(ctr, txtCVV)
        End If

        If calenderExpire.SelectedDate.Date = Nothing Then
            err.AppendLine("- Please select expiration date.")
            ctr = If(ctr, calenderExpire)
        End If

        'show error message
        If err.Length > 0 Then
            MsgBox(err.ToString(), , "Input Error")
            ctr.Focus()
            Return
        End If

        Dim banksql As String = "SELECT * FROM bank WHERE cardNum = @cardNum"
        Dim bankcmd As SqlCommand = New SqlCommand(banksql, connection)
        bankcmd.Parameters.AddWithValue("@cardNum", txtCardNumber.Text)
        Dim dtr As SqlDataReader
        dtr = bankcmd.ExecuteReader

        If dtr.HasRows Then
            dtr.Read()

            If dtr.Item("cvv").Equals(txtCVV.Text) AndAlso dtr.Item("bank").Equals(ddlBank.SelectedItem.Text) AndAlso dtr.Item("expDate").Equals(calenderExpire.SelectedDate.ToShortDateString) Then

            Else
                MsgBox("Card number, cvv, bank, expiration date mismatch. Please enter again.")
                Return
            End If
        Else
            MsgBox("Card number does not exist. Please enter again.")
            Return
        End If
        dtr.Close()

        'Dim img As FileUpload = CType(DesignModule.design, FileUpload)
        'Dim imgByte As Byte() = Nothing
        'If img.HasFile AndAlso Not img.PostedFile Is Nothing Then
        '    'To create a PostedFile
        '    Dim File As HttpPostedFile = DesignModule.design.PostedFile
        '    'Create byte Array with file len
        '    imgByte = New Byte(File.ContentLength - 1) {}
        '    'force the control to load data in array
        '    File.InputStream.Read(imgByte, 0, File.ContentLength)
        'End If

        DesignModule.design.SaveAs(Server.MapPath("~/image/" + DesignModule.filename))

        Dim dt As New DataTable()
        Dim count As String = ""
        Dim sqlCmd As New SqlCommand("SELECT *  from Design", connection)
        Dim sqlDa As New SqlDataAdapter(sqlCmd)

        sqlDa.Fill(dt)
        If dt.Rows.Count > 0 Then
            count = dt.Rows.Count.ToString()
        End If

        Dim designID As String = ""
        If count.Equals("") Then
            designID = "D0"
        Else
            designID = "D" + count
        End If

        'Dim sql As String = "INSERT INTO Design(designID, designPattern, userName, designPath) VALUES(@designID, @designPattern, @userName, @designPath)"
        Dim sql As String = "INSERT INTO Design(designID, userName, designPath, status) VALUES(@designID, @userName, @designPath, @status)"
        Dim cmd As SqlCommand = New SqlCommand(sql, connection)
        cmd.Parameters.AddWithValue("@designID", designID)
        'cmd.Parameters.AddWithValue("@designPattern", imgByte)
        cmd.Parameters.AddWithValue("@userName", ClientModule.userName)
        cmd.Parameters.AddWithValue("@designPath", "~/image/" + filename)
        cmd.Parameters.AddWithValue("@status", "Pending")
        cmd.ExecuteNonQuery()

        ' Insert payment data into db        
        Dim dt2 As New DataTable()
        Dim count2 As String = ""
        Dim sqlCmd2 As New SqlCommand("SELECT *  from Payment", connection)
        Dim sqlDa2 As New SqlDataAdapter(sqlCmd2)

        sqlDa2.Fill(dt2)
        If dt2.Rows.Count > 0 Then
            count2 = dt2.Rows.Count.ToString()
        End If

        Dim paymentID As String = ""
        If count2.Equals("") Then
            paymentID = "P0"
        Else
            paymentID = "P" + count2
        End If

        Dim sql2 As String = "INSERT INTO Payment(paymentID, payDate, paymentTotal, paymentMethod) VALUES(@paymentID, @payDate, @paymentTotal, @paymentMethod)"
        Dim cmd2 As SqlCommand = New SqlCommand(sql2, connection)
        cmd2.Parameters.AddWithValue("@paymentID", paymentID)
        cmd2.Parameters.AddWithValue("@payDate", Today.Date)
        cmd2.Parameters.AddWithValue("@paymentTotal", Double.Parse(lblPaymentAmt.Text))
        cmd2.Parameters.AddWithValue("@paymentMethod", paymentMethod)
        Dim n2 As Integer = cmd2.ExecuteNonQuery()
        If (n2 > 0) Then
            MsgBox("Payment success!", , "Congratulation")
            Response.Redirect("~/Client/ClientHome.aspx")
        Else
            MsgBox("Payment failed. Please try again.", , "Important Note")
        End If

        connection.Close()
    End Sub

    Public Function ValidateCard(ByVal num As String) As Boolean
        Dim pattern As String = "^[0-9]{16}$"
        Dim check As New Regex(pattern)
        Dim valid As Boolean = False
        If Not String.IsNullOrEmpty(num) Then
            valid = check.IsMatch(num)
        Else
            valid = False
        End If
        Return valid
    End Function

    Public Function ValidateCVV(ByVal num As String) As Boolean
        Dim pattern As String = "^[0-9]{3}$"
        Dim check As New Regex(pattern)
        Dim valid As Boolean = False
        If Not String.IsNullOrEmpty(num) Then
            valid = check.IsMatch(num)
        Else
            valid = False
        End If
        Return valid
    End Function

    Protected Sub calenderExpire_DayRender(sender As Object, e As DayRenderEventArgs) Handles calenderExpire.DayRender
        If e.Day.Date < Date.Today Then
            e.Day.IsSelectable = False
            e.Cell.ForeColor = System.Drawing.Color.Gray
        End If
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        MsgBox("Payment Cancelled. Redirecting to home page.")
        Response.Redirect("~/Client/ClientHome.aspx")
    End Sub

End Class