Public Class frmGridWizard
    Private imageIdx = 0
    Private pen As Pen = New Pen(New SolidBrush(Color.HotPink))
    Private loaded As Boolean
    Private guide As Point = New Point(150, 150)
    Private rects As New List(Of Rectangle)

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
        rects.Clear()
        Dim img As Bitmap = New Bitmap(Files(imageIdx).FullName)
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
                    rects.Add(New Rectangle(guide.X + i * numXPitch.Value - Math.Sqrt(numArea.Value) / 2,
                                            guide.Y + j * numYPitch.Value - Math.Sqrt(numArea.Value) / 2,
                                            Math.Sqrt(numArea.Value), Math.Sqrt(numArea.Value)))
                End Using
            Next
        Next
        For Each rect In rects
            Using g As Graphics = Graphics.FromImage(img)
                g.DrawRectangle(pen, rect)
            End Using
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

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim dialog = New SaveFileDialog With {.Filter = "Entroptik Workspace|*.ew"}
        If dialog.ShowDialog() = DialogResult.OK Then
            Using sw As New IO.StreamWriter(dialog.FileName)
                sw.WriteLine(WorkspaceType)
                sw.WriteLine(BorderRectSize & vbCrLf & NullCap & vbCrLf & NullCapThreshold)
                For Each rect In rects
                    sw.WriteLine(String.Format("{0},{1},{2},{3},{4},0,1", rect.Left, rect.Top, rect.Right, rect.Bottom, rects.IndexOf(rect) + 1))
                Next
                sw.WriteLine(ImagesDir)
            End Using
            frmMain.lblStatus.BackColor = Color.LimeGreen
            frmMain.lblStatus.Text = Text & " Saved"
            WorkspacePath = dialog.FileName
            LoadWorkspace()
            frmMain.Proceed()
            Hide()
        Else
            Exit Sub
        End If
    End Sub
End Class