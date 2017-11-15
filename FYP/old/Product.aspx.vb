Public Class Product
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        If ClientModule.userName = "" Then
            MsgBox("Please login to continue.")
            Response.Redirect("~/Client/Login.aspx")
        Else
            Response.Redirect("~/Client/Order.aspx")
        End If

    End Sub

    Protected Sub Image1_Click(sender As Object, e As ImageClickEventArgs) Handles Image1.Click
        If ClientModule.userName = "" Then
            MsgBox("Please login to continue.")
            Response.Redirect("~/Client/Login.aspx")
        Else
            OrderModule.colour = "Black"
            Response.Redirect("~/Client/Order.aspx")
        End If
    End Sub

    Protected Sub Image2_Click(sender As Object, e As ImageClickEventArgs) Handles Image2.Click
        If ClientModule.userName = "" Then
            MsgBox("Please login to continue.")
            Response.Redirect("~/Client/Login.aspx")
        Else
            OrderModule.colour = "Grey"
            Response.Redirect("~/Client/Order.aspx")
        End If
    End Sub

    Protected Sub Image3_Click(sender As Object, e As ImageClickEventArgs) Handles Image3.Click
        If ClientModule.userName = "" Then
            MsgBox("Please login to continue.")
            Response.Redirect("~/Client/Login.aspx")
        Else
            OrderModule.colour = "Green"
            Response.Redirect("~/Client/Order.aspx")
        End If
    End Sub

    Protected Sub Image5_Click(sender As Object, e As ImageClickEventArgs) Handles Image5.Click
        If ClientModule.userName = "" Then
            MsgBox("Please login to continue.")
            Response.Redirect("~/Client/Login.aspx")
        Else
            OrderModule.colour = "Blue"
            Response.Redirect("~/Client/Order.aspx")
        End If
    End Sub

    Protected Sub Image4_Click(sender As Object, e As ImageClickEventArgs) Handles Image4.Click
        If ClientModule.userName = "" Then
            MsgBox("Please login to continue.")
            Response.Redirect("~/Client/Login.aspx")
        Else
            OrderModule.colour = "Red"
            Response.Redirect("~/Client/Order.aspx")
        End If
    End Sub
End Class