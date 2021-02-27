Imports System.Drawing.Drawing2D

Public Class cFeature
    '''<summary>Larger rectangle for color coding features</summary>
    Public Property Rect As Rectangle
    '''<summary>Path of region determined from area</summary>
    Public Property Path As GraphicsPath
    '''<summary>Origin of feature in drawing</summary>
    Public Property Coordinates As String
    '''<summary>Name as seen in output log</summary>
    Public Property Name As String
    '''<summary>Training score determined by user</summary>
    Public Property Score As String = 0
    '''<summary>Last score value for quick reference</summary>
    Public Property LastScore As String = 0
    '''<summary>Acceptable difference from trained score</summary>
    Public Property Tolerance As Double = 1
    '''<summary>How to score the image</summary>
    Public Property ScoreType As Integer = 0
    Public Sub New(NWcorner As Point, SEcorner As Point, score As String, tolerance As String, scoreType As Integer, Optional name As String = "")
        Rect = New Rectangle(NWcorner.X, NWcorner.Y, SEcorner.X - NWcorner.X, SEcorner.Y - NWcorner.Y)
        Path = New GraphicsPath()
        Path.AddRectangle(Rect)
        Coordinates = "(" & Rect.X.ToString() & "," & Rect.Y.ToString() & ")"
        Me.Score = score
        Me.Tolerance = tolerance
        Me.ScoreType = scoreType
        Me.Name = name
    End Sub
End Class