Imports System.Data.SqlClient

Public Class Order
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If ClientModule.userName = "" Then
            Response.Redirect("~/Client/ClientHome.aspx")
        End If
        btnBlack.ImageUrl = "~/image/btnBlack.png"
        btnBlue.ImageUrl = "~/image/btnBlue.png"
        btnGrey.ImageUrl = "~/image/btnGrey.png"
        btnRed.ImageUrl = "~/image/btnRed.png"
        btnGreen.ImageUrl = "~/image/btnGreen.png"
        If IsPostBack = False Then
            If OrderModule.colour = "" Then

            Else
                If OrderModule.colour = "Black" Then
                    btnBlack.ImageUrl = "~/image/selectBlack.png"
                    imgDisplay.Visible = True
                    imgDisplay.ImageUrl = "~/image/black.jpg"
                ElseIf OrderModule.colour = "Grey" Then
                    btnGrey.ImageUrl = "~/image/selectGrey.png"
                    imgDisplay.Visible = True
                    imgDisplay.ImageUrl = "~/image/grey.jpg"
                ElseIf OrderModule.colour = "Red" Then
                    btnRed.ImageUrl = "~/image/selectRed.png"
                    imgDisplay.Visible = True
                    imgDisplay.ImageUrl = "~/image/red.jpg"
                ElseIf OrderModule.colour = "Green" Then
                    btnGreen.ImageUrl = "~/image/selectGreen.png"
                    imgDisplay.Visible = True
                    imgDisplay.ImageUrl = "~/image/green.jpg"
                ElseIf OrderModule.colour = "Blue" Then
                    btnBlue.ImageUrl = "~/image/selectBlue.png"
                    imgDisplay.Visible = True
                    imgDisplay.ImageUrl = "~/image/blue.jpg"
                End If


                If OrderModule.size = "" Then
                Else
                    If OrderModule.size = "S" Then
                        radSize.SelectedIndex = 0
                    ElseIf OrderModule.size = "M" Then
                        radSize.SelectedIndex = 1
                    ElseIf OrderModule.size = "L" Then
                        radSize.SelectedIndex = 2
                    End If
                End If

                If OrderModule.material = "" Then
                Else
                    If OrderModule.material = "Cotton" Then
                        radMaterial.SelectedIndex = 0
                    ElseIf OrderModule.material = "Polyester" Then
                        radMaterial.SelectedIndex = 1
                    End If
                End If
            End If
        End If


    End Sub

    Protected Sub btnBlack_Click(sender As Object, e As ImageClickEventArgs) Handles btnBlack.Click
        imgDisplay.Visible = True
        imgDisplay.ImageUrl = "~/image/black.jpg"
        btnBlack.ImageUrl = "~/image/selectBlack.png"
        OrderModule.colour = "Black"
    End Sub

    Protected Sub btnGrey_Click(sender As Object, e As ImageClickEventArgs) Handles btnGrey.Click
        imgDisplay.Visible = True
        imgDisplay.ImageUrl = "~/image/grey.jpg"
        btnGrey.ImageUrl = "~/image/selectGrey.png"
        OrderModule.colour = "Grey"
    End Sub

    Protected Sub btnGreen_Click(sender As Object, e As ImageClickEventArgs) Handles btnGreen.Click
        imgDisplay.Visible = True
        imgDisplay.ImageUrl = "~/image/green.jpg"
        btnGreen.ImageUrl = "~/image/selectGreen.png"
        OrderModule.colour = "Green"
    End Sub

    Protected Sub btnRed_Click(sender As Object, e As ImageClickEventArgs) Handles btnRed.Click
        imgDisplay.Visible = True
        imgDisplay.ImageUrl = "~/image/red.jpg"
        btnRed.ImageUrl = "~/image/selectRed.png"
        OrderModule.colour = "Red"
    End Sub

    Protected Sub btnBlue_Click(sender As Object, e As ImageClickEventArgs) Handles btnBlue.Click
        imgDisplay.Visible = True
        imgDisplay.ImageUrl = "~/image/blue.jpg"
        btnBlue.ImageUrl = "~/image/selectBlue.png"
        OrderModule.colour = "Blue"
    End Sub

    Protected Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim err As New StringBuilder()
        Dim ctr As Control = Nothing
        Dim size As String
        Dim material As String

        If imgDisplay.ImageUrl = "" Then
            err.AppendLine("- Please select colour.")
            ctr = If(ctr, imgDisplay)
        End If

        If radSize.SelectedIndex = 0 Then
            size = "S"
        ElseIf radSize.SelectedIndex = 1 Then
            size = "M"
        ElseIf radSize.SelectedIndex = 2 Then
            size = "L"
        Else
            err.AppendLine("- Please select size.")
            ctr = If(ctr, radSize)
        End If

        If radMaterial.Text.Equals("Cotton") Then
            material = "Cotton"
        ElseIf radMaterial.Text.Equals("Polyester") Then
            material = "Polyester"
        Else
            err.AppendLine("- Please select material.")
            ctr = If(ctr, radMaterial)
        End If

        'show error message
        If err.Length > 0 Then
            MsgBox(err.ToString(), , "Input Error")
            ctr.Focus()
            Return
        End If

        OrderModule.size = size
        OrderModule.material = material
        Response.Redirect("~/Client/OrderDesign.aspx")

    End Sub
End Class