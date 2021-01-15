Public Class frmMain
    Dim ImagesFolder = "C:\"
    Dim files As New List(Of String)
    Dim fileIdx As Integer
    Dim drawing As Bitmap
    Dim crop As Rectangle
    Dim features As List(Of Rectangle)

    Private Sub OpenFolder(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Dim dialog = New FolderBrowserDialog With {.Description = "Choose folder containing images"}
        If dialog.ShowDialog() = DialogResult.OK Then
            ImagesFolder = dialog.SelectedPath
        Else
            Exit Sub
        End If

        Dim di As New IO.DirectoryInfo(ImagesFolder)
        Dim aryFi As IO.FileInfo() = di.GetFiles
        Dim fi As IO.FileInfo
        For Each fi In aryFi
            If fi.Name.Contains(".png") Or fi.Name.Contains(".jpg") Then files.Add(fi.FullName)
        Next

        If files.Count = 0 Then
            lblStatus.BackColor = Color.Yellow
            lblStatus.Text = "Invalid Directory"
            Exit Sub
        Else
            Dim response = MsgBox("This action will analyze " & files.Count.ToString() & " photos", MsgBoxStyle.OkCancel, "Load Images")
            If response = MsgBoxResult.Cancel Then
                Exit Sub
            End If
        End If

        lblStatus.BackColor = Color.LimeGreen
        lblStatus.Text = "Photos Loaded"
    End Sub

    Private Sub OpenDrawing(sender As Object, e As EventArgs) Handles DrawingToolStripMenuItem.Click
        Dim dialog = New OpenFileDialog With {.DefaultExt = "bmp"}
        If dialog.ShowDialog() = DialogResult.OK Then
            drawing = New Bitmap(dialog.FileName)
            MakeRects()
        Else
            Exit Sub
        End If

        lblStatus.BackColor = Color.LimeGreen
        lblStatus.Text = "Drawing Loaded"
    End Sub

    Private Sub ViewDrawing(sender As Object, e As EventArgs) Handles ViewDrawingToolStripMenuItem.Click
        Dim displayDrawing As New Form With {.FormBorderStyle = FormBorderStyle.FixedToolWindow, .Name = "Current Drawing"}
        Dim picture = New PictureBox With {
            .BackColor = Color.Blue,
            .Dock = DockStyle.Fill,
            .BackgroundImageLayout = ImageLayout.Zoom,
            .BackgroundImage = drawing
        }
        displayDrawing.Controls.Add(picture)
        displayDrawing.Show()
    End Sub

    Private Sub MakeRects()
        Dim xMax = drawing.Width - 1
        Dim yMax = drawing.Height - 1
        Dim cropX, cropY As New List(Of Integer)
        For y = 0 To yMax
            For x = 0 To xMax
                Dim thisColor = drawing.GetPixel(x, y)
                If CompareColors(thisColor, Color.White) Then
                    If Not cropX.Contains(x) Then cropX.Add(x)
                    If Not cropY.Contains(y) Then cropY.Add(y)
                    'ElseIf CompareColors(thisColor, Color.Black) Then
                End If
            Next x
        Next y

        crop = New Rectangle(cropX.Min, cropY.Min, cropX.Max - cropX.Min, cropY.Max - cropY.Min)
    End Sub

    Private Function CompareColors(ByVal pixel As Color, ByVal test As Color)
        If pixel.R = test.R And pixel.G = test.G And pixel.B = test.B Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub IterateImages()
        lblStatus.BackColor = Color.SkyBlue
        lblStatus.Text = "Scoring photo " & files(fileIdx).Split("\").Last()
        Dim src = Image.FromFile(files(fileIdx))
        pbxImg.Image = src
        Refresh()
    End Sub

    Private Sub NextImage(sender As Object, e As EventArgs) Handles NextStripMenuItem.Click
        Proceed()
    End Sub

    Private Sub AllImages(sender As Object, e As EventArgs) Handles RunAllStripMenuItem.Click
        While True
            If Proceed() = 1 Then Exit Sub
        End While
    End Sub

    Private Function Proceed()
        fileIdx += 1
        If fileIdx > files.Count - 1 Then
            Finish()
            Return 1
        End If
        IterateImages()
        Return 0
    End Function

    Private Sub Finish()
        Enabled = True
        fileIdx = 0
        lblStatus.BackColor = Color.LawnGreen
        lblStatus.Text = "All Photos Scored"
    End Sub
End Class