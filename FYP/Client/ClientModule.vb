Imports System.Drawing

Module ClientModule
    Public userName As String
    Public email As String
    Public nickname As String
End Module

Module DesignModule
    Public design As FileUpload
    Public filename As String
    Public designID As String
End Module

Module OrderModule
    Public colour As String
    Public size As String
    Public material As String
    Public type As String
    Public designID As String
    Public customizeDesign As FileUpload
    Public customizePath As String
    Public clothID As String
    Public machineID As String
    Public quantity As Integer
    Public priceEach As Double
    Public stock As Integer
    Public qrID As String
    Public machineLocation As String
End Module
