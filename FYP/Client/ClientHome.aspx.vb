Imports System.Drawing
Imports System.IO

Public Class ClientHome
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Image5_Click(sender As Object, e As ImageClickEventArgs) Handles Image5.Click
        Response.Redirect("~/Client/UploadDesign.aspx")
    End Sub

    Protected Sub Image3_Click(sender As Object, e As ImageClickEventArgs) Handles Image3.Click
        Response.Redirect("~/Client/Products.aspx")
    End Sub

    Protected Sub Image4_Click(sender As Object, e As ImageClickEventArgs) Handles Image4.Click
        Response.Redirect("~/Client/ContactUs.aspx")
    End Sub
End Class