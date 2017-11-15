Public Class ClientSide
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If ClientModule.userName = "" Then
            userLogout.Text = "Sign In"
            userLogout.Visible = True
        Else
            userNickname.Text = "Welcome, " + ClientModule.nickname
            userNickname.Visible = True
            userLogout.Text = "Logout"
            userLogout.Visible = True
            btnProfile.Visible = True
            btnHistory.Visible = True
            btnReport.Visible = True
        End If
    End Sub

    Protected Sub userLogout_Click(sender As Object, e As EventArgs) Handles userLogout.Click
        If userLogout.Text = "Sign In" Then
            Response.Redirect("~/Client/Login.aspx")
        Else
            MsgBox("You have been logout.", , "Important Note")
            ClientModule.userName = ""
            ClientModule.email = ""
            ClientModule.nickname = ""
            OrderModule.designID = ""
            Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)
        End If
    End Sub

    Protected Sub btnDesign_Click(sender As Object, e As EventArgs) Handles btnDesign.Click
        If ClientModule.userName = "" Then
            MsgBox("Please login to continue")
        Else
            Response.Redirect("~/Client/UploadDesign.aspx")
        End If
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Response.Redirect("~/Client/Products.aspx")
    End Sub

    Protected Sub btnProfile_Click(sender As Object, e As EventArgs) Handles btnProfile.Click
        Response.Redirect("~/Client/DisplayProfile.aspx")
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("~/Client/AboutUs.aspx")
    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Response.Redirect("~/Client/ContactUs.aspx")
    End Sub

    Protected Sub btnHistory_Click(sender As Object, e As EventArgs) Handles btnHistory.Click
        Response.Redirect("~/Client/OrderHistory.aspx")
    End Sub

    Protected Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        Response.Redirect("~/Client/ClientReport.aspx")
    End Sub
End Class