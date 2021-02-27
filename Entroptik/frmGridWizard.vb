Public Class frmGridWizard
    Private imageIdx = 0
    Private pen As Pen = New Pen(New SolidBrush(Color.HotPink))
    Private loaded As Boolean
    Private guide As Point = New Point(150, 150)

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub frmGridWizard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DrawGrid()
    End Sub

    Private Sub btnNextImage_Click(sender As Object, e As EventArgs) Handles btnNextImage.Click
        imageIdx += 1
        DrawGrid()
    End Sub

    Private Sub DrawGrid()
        Dim img As Bitmap = New Bitmap(files(imageIdx).FullName)
        pen.Width = img.Width / 250
        For i As Integer = 0 To numX.Value - 1
            Using g As Graphics = Graphics.FromImage(img)
                g.DrawLine(pen, New Point(guide.X + i * numXPitch.Value, 0), New Point(guide.X + i * numXPitch.Value, img.Height))
            End Using
        Next
        For j As Integer = 0 To numY.Value - 1
            Using g As Graphics = Graphics.FromImage(img)
                g.DrawLine(pen, New Point(0, guide.Y + j * numYPitch.Value), New Point(img.Width, guide.Y + j * numYPitch.Value))
            End Using
        Next
        For i As Integer = 0 To numX.Value - 1
            For j As Integer = 0 To numY.Value - 1
                Using g As Graphics = Graphics.FromImage(img)
                    g.DrawRectangle(pen, New Rectangle(guide.X + i * numXPitch.Value - Math.Sqrt(numArea.Value) / 2,
                                                       guide.Y + j * numYPitch.Value - Math.Sqrt(numArea.Value) / 2,
                                                       Math.Sqrt(numArea.Value), Math.Sqrt(numArea.Value)))
                End Using
            Next
        Next
        pbxGridPhoto.Image = img
        loaded = True
        Refresh()
    End Sub

    Private Sub pbx_Click(sender As Object, e As MouseEventArgs) Handles pbxGridPhoto.Click
        Dim click As New Point(e.X, e.Y)
        Dim correctedClick As Point = ZoomMousePos(click, sender)
        guide = correctedClick
        DrawGrid()
    End Sub

    Private Sub numValueChanged(sender As Object, e As EventArgs) Handles numX.ValueChanged, numY.ValueChanged, numArea.ValueChanged, numXPitch.ValueChanged, numYPitch.ValueChanged
        If loaded Then DrawGrid()
    End Sub
End Class