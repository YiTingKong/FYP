Imports System.Data.SqlClient

Public Class OrderPayments
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If ClientModule.userName = "" Then
            Response.Redirect("~/Client/ClientHome.aspx")
        End If
        Dim amount As Double = Double.Parse(OrderModule.quantity * OrderModule.priceEach)
        lblPaymentAmt.Text = amount.ToString()
    End Sub

    Protected Sub btnPay_Click(sender As Object, e As EventArgs) Handles btnPay.Click
        Dim err As New StringBuilder()
        Dim ctr As Control = Nothing
        Dim paymentMethod As String

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

        ' Insert data into db
        Dim connection As SqlConnection = Nothing
        Dim conn As String = ConfigurationManager.ConnectionStrings("FYPDBConnectionString").ConnectionString
        connection = New SqlConnection(conn)
        connection.Open()

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

        If OrderModule.designID = "" Then
            Dim img As FileUpload = CType(OrderModule.customizeDesign, FileUpload)
            Dim imgByte As Byte() = Nothing
            If img.HasFile AndAlso Not img.PostedFile Is Nothing Then
                'To create a PostedFile
                Dim File As HttpPostedFile = OrderModule.customizeDesign.PostedFile
                'Create byte Array with file len
                imgByte = New Byte(File.ContentLength - 1) {}
                'force the control to load data in array
                File.InputStream.Read(imgByte, 0, File.ContentLength)
            End If

            'OrderModule.customizeDesign.SaveAs(Server.MapPath("~/image/" + OrderModule.customizePath))

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

            Dim sql As String = "INSERT INTO Design(designID, type, userName, designPath) VALUES(@designID, @type, @userName, @designPath)"
            Dim cmd As SqlCommand = New SqlCommand(sql, connection)
            cmd.Parameters.AddWithValue("@designID", designID)
            cmd.Parameters.AddWithValue("@type", "Customize")
            'cmd.Parameters.AddWithValue("@designPattern", imgByte)
            cmd.Parameters.AddWithValue("@userName", ClientModule.userName)
            cmd.Parameters.AddWithValue("@designPath", "~/image/" + OrderModule.customizePath)
            cmd.ExecuteNonQuery()

            'order
            Dim Orderdt As New DataTable()
            Dim Ordercount As String = ""
            Dim OrdersqlCmd As New SqlCommand("select * from Orders", connection)
            Dim OrdersqlDa As New SqlDataAdapter(OrdersqlCmd)
            OrdersqlDa.Fill(Orderdt)

            If Orderdt.Rows.Count > 0 Then
                Ordercount = Orderdt.Rows.Count.ToString()
            End If

            Dim orderID As String = ""
            If Ordercount.Equals("") Then
                orderID = "O0"
            Else
                orderID = "O" + Ordercount
            End If

            'Payment
            Dim Paymentdt As New DataTable()
            Dim Paymentcount As String = ""
            Dim PaymentsqlCmd As New SqlCommand("SELECT *  from Payment", connection)
            Dim PaymentsqlDa As New SqlDataAdapter(PaymentsqlCmd)

            PaymentsqlDa.Fill(Paymentdt)
            If Paymentdt.Rows.Count > 0 Then
                Paymentcount = Paymentdt.Rows.Count.ToString()
            End If

            Dim paymentID As String = ""
            If Paymentcount.Equals("") Then
                paymentID = "P0"
            Else
                paymentID = "P" + Paymentcount
            End If
            OrderModule.qrID = paymentID
            Dim Ordersql As String = "INSERT INTO Orders(orderID, userName, machineID, paymentID) VALUES(@orderID, @userName, @machineID, @paymentID)"
            Dim Ordercmd As SqlCommand = New SqlCommand(Ordersql, connection)
            Ordercmd.Parameters.AddWithValue("@orderID", orderID)
            Ordercmd.Parameters.AddWithValue("@userName", ClientModule.userName)
            Ordercmd.Parameters.AddWithValue("@machineID", OrderModule.machineID)
            Ordercmd.Parameters.AddWithValue("@paymentID", paymentID)
            Try
                Ordercmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString())
            End Try


            'order details
            Dim ODdt As New DataTable()
            Dim ODcount As String = ""
            Dim ODsqlCmd As New SqlCommand("SELECT *  from OrderDetails", connection)
            Dim ODsqlDa As New SqlDataAdapter(ODsqlCmd)

            ODsqlDa.Fill(ODdt)
            If ODdt.Rows.Count > 0 Then
                ODcount = ODdt.Rows.Count.ToString()
            End If

            Dim orderDetailsID As String = ""
            If ODcount.Equals("") Then
                orderDetailsID = "OD0"
            Else
                orderDetailsID = "OD" + ODcount
            End If

            Dim ODsql As String = "INSERT INTO OrderDetails(orderDetailsID, clothID, qty, designID, orderID) VALUES(@orderDetailsID, @clothID, @qty, @designID, @orderID)"
            Dim ODcmd As SqlCommand = New SqlCommand(ODsql, connection)
            ODcmd.Parameters.AddWithValue("@orderDetailsID", orderDetailsID)
            ODcmd.Parameters.AddWithValue("@clothID", OrderModule.clothID)
            ODcmd.Parameters.AddWithValue("@qty", OrderModule.quantity)
            ODcmd.Parameters.AddWithValue("@designID", designID)
            ODcmd.Parameters.AddWithValue("@orderID", orderID)
            ODcmd.ExecuteNonQuery()

            'payment
            Dim Paymentsql As String = "INSERT INTO Payment(paymentID, payDate, paymentTotal, paymentMethod, orderID) VALUES(@paymentID, @payDate, @paymentTotal, @paymentMethod, @orderID)"
            Dim Paymentcmd As SqlCommand = New SqlCommand(Paymentsql, connection)
            Paymentcmd.Parameters.AddWithValue("@paymentID", paymentID)
            Paymentcmd.Parameters.AddWithValue("@payDate", Today.Date)
            Paymentcmd.Parameters.AddWithValue("@paymentTotal", Double.Parse(lblPaymentAmt.Text))
            Paymentcmd.Parameters.AddWithValue("@paymentMethod", paymentMethod)
            Paymentcmd.Parameters.AddWithValue("@orderID", orderID)
            Paymentcmd.ExecuteNonQuery()

            'product details
            Dim updatesql As String = "Update ProductDetail SET qty = @qty WHERE machineID = @machineID AND clothID = @clothID"
            Dim updatecmd As SqlCommand = New SqlCommand(updatesql, connection)
            updatecmd.Parameters.AddWithValue("@qty", OrderModule.stock - OrderModule.quantity)
            updatecmd.Parameters.AddWithValue("@machineID", OrderModule.machineID)
            updatecmd.Parameters.AddWithValue("@clothID", OrderModule.clothID)
            Dim n As Integer = updatecmd.ExecuteNonQuery()
            If (n > 0) Then
                MsgBox("Payment success!", , "Congratulation")
                Response.Redirect("~/Client/OrderSuccess.aspx")
            Else
                MsgBox("Payment failed. Please try again.", , "Important Note")
            End If

        Else
            'order
            Dim Orderdt As New DataTable()
            Dim Ordercount As String = ""
            Dim OrdersqlCmd As New SqlCommand("select * from Orders", connection)
            Dim OrdersqlDa As New SqlDataAdapter(OrdersqlCmd)
            Try
                OrdersqlDa.Fill(Orderdt)
            Catch ex As Exception
                MsgBox(ex.ToString())
            End Try


            If Orderdt.Rows.Count > 0 Then
                Ordercount = Orderdt.Rows.Count.ToString()
            End If

            Dim orderID As String = ""
            If Ordercount.Equals("") Then
                orderID = "O0"
            Else
                orderID = "O" + Ordercount
            End If

            'Payment
            Dim Paymentdt As New DataTable()
            Dim Paymentcount As String = ""
            Dim PaymentsqlCmd As New SqlCommand("SELECT *  from Payment", connection)
            Dim PaymentsqlDa As New SqlDataAdapter(PaymentsqlCmd)

            PaymentsqlDa.Fill(Paymentdt)
            If Paymentdt.Rows.Count > 0 Then
                Paymentcount = Paymentdt.Rows.Count.ToString()
            End If

            Dim paymentID As String = ""
            If Paymentcount.Equals("") Then
                paymentID = "P0"
            Else
                paymentID = "P" + Paymentcount
            End If
            OrderModule.qrID = paymentID

            Dim Ordersql As String = "INSERT INTO Orders(orderID, userName, machineID, paymentID) VALUES(@orderID, @userName, @machineID, @paymentID)"
            Dim Ordercmd As SqlCommand = New SqlCommand(Ordersql, connection)
            Ordercmd.Parameters.AddWithValue("@orderID", orderID)
            Ordercmd.Parameters.AddWithValue("@userName", ClientModule.userName)
            Ordercmd.Parameters.AddWithValue("@machineID", OrderModule.machineID)
            Ordercmd.Parameters.AddWithValue("@paymentID", paymentID)
            Try
                Ordercmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString())
            End Try


            'order details
            Dim ODdt As New DataTable()
            Dim ODcount As String = ""
            Dim ODsqlCmd As New SqlCommand("SELECT *  from OrderDetails", connection)
            Dim ODsqlDa As New SqlDataAdapter(ODsqlCmd)

            ODsqlDa.Fill(ODdt)
            If ODdt.Rows.Count > 0 Then
                ODcount = ODdt.Rows.Count.ToString()
            End If

            Dim orderDetailsID As String = ""
            If ODcount.Equals("") Then
                orderDetailsID = "OD0"
            Else
                orderDetailsID = "OD" + ODcount
            End If

            Dim ODsql As String = "INSERT INTO OrderDetails(orderDetailsID, clothID, qty, designID, orderID) VALUES(@orderDetailsID, @clothID, @qty, @designID, @orderID)"
            Dim ODcmd As SqlCommand = New SqlCommand(ODsql, connection)
            ODcmd.Parameters.AddWithValue("@orderDetailsID", orderDetailsID)
            ODcmd.Parameters.AddWithValue("@clothID", OrderModule.clothID)
            ODcmd.Parameters.AddWithValue("@qty", OrderModule.quantity)
            ODcmd.Parameters.AddWithValue("@designID", OrderModule.designID)
            ODcmd.Parameters.AddWithValue("@orderID", orderID)
            ODcmd.ExecuteNonQuery()

            'payment
            Dim Paymentsql As String = "INSERT INTO Payment(paymentID, payDate, paymentTotal, paymentMethod, orderID) VALUES(@paymentID, @payDate, @paymentTotal, @paymentMethod, @orderID)"
            Dim Paymentcmd As SqlCommand = New SqlCommand(Paymentsql, connection)
            Paymentcmd.Parameters.AddWithValue("@paymentID", paymentID)
            Paymentcmd.Parameters.AddWithValue("@payDate", Today.Date)
            Paymentcmd.Parameters.AddWithValue("@paymentTotal", Double.Parse(lblPaymentAmt.Text))
            Paymentcmd.Parameters.AddWithValue("@paymentMethod", paymentMethod)
            Paymentcmd.Parameters.AddWithValue("@orderID", orderID)
            Paymentcmd.ExecuteNonQuery()

            'product details
            Dim updatesql As String = "Update ProductDetail SET qty = @qty WHERE machineID = @machineID AND clothID = @clothID"
            Dim updatecmd As SqlCommand = New SqlCommand(updatesql, connection)
            updatecmd.Parameters.AddWithValue("@qty", OrderModule.stock - OrderModule.quantity)
            updatecmd.Parameters.AddWithValue("@machineID", OrderModule.machineID)
            updatecmd.Parameters.AddWithValue("@clothID", OrderModule.clothID)
            Dim n As Integer = updatecmd.ExecuteNonQuery()
            If (n > 0) Then
                MsgBox("Payment success!", , "Congratulation")
                Response.Redirect("~/Client/OrderSuccess.aspx")
            Else
                MsgBox("Payment failed. Please try again.", , "Important Note")
            End If
        End If

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