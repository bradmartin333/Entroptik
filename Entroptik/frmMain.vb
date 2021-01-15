Imports MathNet.Numerics.Statistics

Public Class frmMain
    Dim ImagesFolder = "C:\"
    Dim files As New List(Of String)
    Dim fileIdx As Integer
    Dim drawing As Bitmap
    Dim drawingLoaded = False
    Dim crop As Rectangle
    Dim features As New List(Of Rectangle)
    Dim displayScores As Form
    Dim scoresDisplayed = False
    Dim scoreStr = "Crop" & vbTab

    Private Sub OpenFolder(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        If Not drawingLoaded Then
            MsgBox("A drawing must be loaded first.",, "Entroptik")
            Exit Sub
        End If

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
        End If

        lblStatus.BackColor = Color.LimeGreen
        lblStatus.Text = files.Count.ToString() & "Photos Loaded"

        Proceed()
    End Sub

    Private Sub OpenDrawing(sender As Object, e As EventArgs) Handles DrawingToolStripMenuItem.Click
        Dim dialog = New OpenFileDialog With {.Filter = "Bitmap|*.bmp"}
        If dialog.ShowDialog() = DialogResult.OK Then
            drawing = New Bitmap(dialog.FileName)
            drawingLoaded = True
            MakeRects()
        Else
            Exit Sub
        End If

        lblStatus.BackColor = Color.LimeGreen
        lblStatus.Text = "Drawing Loaded"
    End Sub

    Private Sub ViewDrawing(sender As Object, e As EventArgs) Handles ViewDrawingToolStripMenuItem.Click
        Dim displayDrawing As New Form With {.FormBorderStyle = FormBorderStyle.FixedToolWindow, .Text = "Current Drawing"}
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
        Dim featureNWCorners, featureSECorners As New List(Of Point)

        For y = 0 To yMax
            For x = 0 To xMax ' Iterate through all of the drawing's pixels
                Dim thisColor = drawing.GetPixel(x, y) ' Get color of pixel
                If CompareColors(thisColor, Color.White) Then ' Add all unique white pixel coordinates
                    If Not cropX.Contains(x) Then cropX.Add(x)
                    If Not cropY.Contains(y) Then cropY.Add(y)
                ElseIf CompareColors(thisColor, Color.Black) AndAlso x <> 0 AndAlso y <> 0 AndAlso x <> xMax AndAlso y <> yMax Then
                    ' Add pixel coordinates for NW and SE corners
                    If CompareColors(drawing.GetPixel(x - 1, y), Color.White) AndAlso CompareColors(drawing.GetPixel(x, y - 1), Color.White) Then featureNWCorners.Add(New Point(x, y))
                    If CompareColors(drawing.GetPixel(x + 1, y), Color.White) AndAlso CompareColors(drawing.GetPixel(x, y + 1), Color.White) Then featureSECorners.Add(New Point(x, y))
                End If
            Next x
        Next y

        For i = 0 To featureNWCorners.Count - 1 ' Make rectangles from corners
            features.Add(New Rectangle(featureNWCorners(i).X, featureNWCorners(i).Y, featureSECorners(i).X - featureNWCorners(i).X, featureSECorners(i).Y - featureNWCorners(i).Y))
        Next

        For Each feature As Rectangle In features ' Make header for output string
            scoreStr += "(" & feature.X.ToString & "," & feature.Y.ToString & ")" & vbTab
        Next

        crop = New Rectangle(cropX.Min, cropY.Min, cropX.Max - cropX.Min, cropY.Max - cropY.Min) ' The white pixels are the crop region
    End Sub

    Private Function CompareColors(ByVal pixel As Color, ByVal test As Color)
        If pixel.R = test.R And pixel.G = test.G And pixel.B = test.B Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub IterateImages()
        Text = files(fileIdx).Split("\").Last() ' Get short name of file

        Dim src = Image.FromFile(files(fileIdx))
        Dim target = New Bitmap(crop.Width, crop.Height)
        BitmapCrop(src, target)
        pbxCrop.Image = target

        Dim nullScore = CalcEntropy(target) ' Entropy of cropped image
        scoreStr += vbCrLf & nullScore.ToString() & vbTab

        Dim srcFeatures = New Bitmap(src.Width, src.Height)
        Dim targetFeatures = New Bitmap(crop.Width, crop.Height)
        For Each feature As Rectangle In features
            Dim featureBuffer As New Bitmap(feature.Width, feature.Height)
            Using g As Graphics = Graphics.FromImage(featureBuffer)
                g.DrawImage(src, New Rectangle(0, 0, feature.Width, feature.Height), feature, GraphicsUnit.Pixel)
            End Using

            Dim featureScore = CalcEntropy(featureBuffer) ' Entropy of feature
            scoreStr += featureScore.ToString() & vbTab

            Using g As Graphics = Graphics.FromImage(srcFeatures)
                g.DrawImage(src, feature, feature, GraphicsUnit.Pixel)
            End Using
        Next
        BitmapCrop(srcFeatures, targetFeatures)
        pbxFeatures.Image = targetFeatures

        If scoresDisplayed Then
            displayScores.Controls.Item(0).Text = scoreStr
        End If
    End Sub

    Private Sub BitmapCrop(ByVal src As Bitmap, ByRef target As Bitmap)
        Using g As Graphics = Graphics.FromImage(target)
            g.DrawImage(src, New Rectangle(0, 0, crop.Width, crop.Height), crop, GraphicsUnit.Pixel)
        End Using
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
        fileIdx = 0
        lblStatus.BackColor = Color.LawnGreen
        lblStatus.Text = "All Photos Scored"
    End Sub

    Private Function CalcEntropy(ByVal img As Bitmap)
        Dim pixels As New List(Of Double)
        For i = 0 To img.Width - 1
            For j = 0 To img.Height - 1
                pixels.Add(img.GetPixel(i, j).ToArgb)
            Next
        Next
        Dim pixelsEnum = pixels.AsEnumerable
        Dim score = Statistics.Entropy(pixelsEnum)
        Return Math.Round(score, 3)
    End Function

    Private Sub ViewScores(sender As Object, e As EventArgs) Handles ViewScoresToolStripMenuItem.Click
        scoresDisplayed = True
        displayScores = New Form With {.FormBorderStyle = FormBorderStyle.SizableToolWindow, .Text = "Current Scores"}
        Dim scores As New RichTextBox With {.Dock = DockStyle.Fill, .Text = scoreStr}
        displayScores.Controls.Add(scores)
        displayScores.Show()
    End Sub
End Class