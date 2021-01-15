Imports System.Drawing.Drawing2D

Public Class cFeature
    Private myRect As Rectangle ' Area of region determined from NW and SE corners
    '''<summary>Rectangle for drawing zone</summary>
    Public Property Rect As Rectangle
        Get
            Return myRect
        End Get
        Set(ByVal value As Rectangle)
            myRect = value
        End Set
    End Property
    '''<summary>Path of region determined from area</summary>
    Public Property Path As GraphicsPath
    '''<summary>Name as seen in output log</summary>
    Public Property Name As String
    '''<summary>Training score determined by user</summary>
    Public Property Score As String = 0
    Public Sub New(ByVal NWcorner As Point, ByVal SEcorner As Point)
        myRect = New Rectangle(NWcorner.X, NWcorner.Y, SEcorner.X - NWcorner.X, SEcorner.Y - NWcorner.Y)
        Path = New GraphicsPath()
        Path.AddEllipse(myRect)
        Name = "(" & myRect.X.ToString() & "," & myRect.Y.ToString() & ")"
    End Sub
End Class