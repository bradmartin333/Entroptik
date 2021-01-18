Public Class frmMain
    Dim files As New List(Of String)
    Dim fileIdx As Integer = -1
    Dim drawing As Bitmap
    Dim crop As Rectangle
    Dim features As New List(Of cFeature)
    Dim displayScores As Form
    Dim scoreStr As String = "Filename" & vbTab & "Crop" & vbTab
    Dim drawingLoaded, scoresDisplayed, featuresLoaded, parametersLoaded As Boolean

    Private Sub OpenProjectFolder(sender As Object, e As EventArgs) Handles OpenProjectToolStripMenuItem.Click
        Dim dialog = New FolderBrowserDialog With {.Description = "Choose a project folder"}
        If dialog.ShowDialog() = DialogResult.OK Then
            LoadImages(dialog.SelectedPath)
            Dim di As New IO.DirectoryInfo(dialog.SelectedPath)
            Dim aryFi As IO.FileInfo() = di.GetFiles
            Dim fi As IO.FileInfo
            For Each fi In aryFi
                If fi.Name.Contains(".bmp") Then
                    LoadDrawing(fi.FullName)
                End If
                If fi.Name.Contains(".efs") Then
                    LoadFeatureSheet(fi.FullName)
                End If
                If fi.Name.Contains(".eprm") Then
                    LoadParameters(fi.FullName)
                End If
            Next
        Else
            Exit Sub
        End If

        If Not drawingLoaded OrElse Not featuresLoaded OrElse files.Count = 0 Then
            lblStatus.BackColor = Color.Yellow
            lblStatus.Text = "Invalid Directory"
            Exit Sub
        End If

        lblStatus.BackColor = Color.LimeGreen
        lblStatus.Text = "Project Loaded"

        Proceed()
    End Sub

    Private Sub OpenImagesFolder(sender As Object, e As EventArgs) Handles OpenImagesToolStripMenuItem.Click
        If Not drawingLoaded Then
            MsgBox("A drawing must be loaded first.",, "Entroptik")
            Exit Sub
        End If

        Dim dialog = New FolderBrowserDialog With {.Description = "Choose folder containing images"}
        If dialog.ShowDialog() = DialogResult.OK Then
            LoadImages(dialog.SelectedPath)
        Else
            Exit Sub
        End If

        lblStatus.BackColor = Color.LimeGreen
        lblStatus.Text = files.Count.ToString() & " Photos Loaded"

        Proceed()
    End Sub

    Private Sub OpenFeatureSheet(sender As Object, e As EventArgs) Handles OpenFeatureSheetToolStripMenuItem.Click
        If Not drawingLoaded Then
            MsgBox("A drawing must be loaded first.",, "Entroptik")
            Exit Sub
        End If

        Dim dialog = New OpenFileDialog With {.Filter = "Feature Sheet|*.efs"}
        If dialog.ShowDialog() = DialogResult.OK Then
            LoadFeatureSheet(dialog.FileName)
        Else
            Exit Sub
        End If

        lblStatus.BackColor = Color.LimeGreen
        lblStatus.Text = "Scores Loaded"
    End Sub

    Private Sub OpenParameters(sender As Object, e As EventArgs) Handles OpenParametersToolStripMenuItem.Click
        Dim dialog = New OpenFileDialog With {.Filter = "Parameters|*.eprm"}
        If dialog.ShowDialog() = DialogResult.OK Then
            LoadParameters(dialog.FileName)
        Else
            Exit Sub
        End If

        lblStatus.BackColor = Color.LimeGreen
        lblStatus.Text = "Parameters Loaded"
    End Sub

    Private Sub OpenDrawing(sender As Object, e As EventArgs) Handles OpenDrawingToolStripMenuItem.Click
        Dim dialog = New OpenFileDialog With {.Filter = "Bitmap|*.bmp"}
        If dialog.ShowDialog() = DialogResult.OK Then
            LoadDrawing(dialog.FileName)
        Else
            Exit Sub
        End If

        lblStatus.BackColor = Color.LimeGreen
        lblStatus.Text = "Drawing Loaded"
    End Sub

    Private Sub LoadImages(ByVal ImagesFolder)
        files.Clear()

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
    End Sub

    Private Sub LoadFeatureSheet(ByVal FeatureSheet)
        Dim reader = My.Computer.FileSystem.ReadAllText(FeatureSheet)
        If reader = "" Then Exit Sub

        Dim data = reader.Split(vbCrLf)
        For Each d In data
            Dim values = d.Split(vbTab)
            If values(0) = "" Then Exit For
            Dim coordinates = values(0)
            Dim name = values(1)
            Dim score = values(2)
            Dim tolerance = values(3)
            For Each feature As cFeature In features
                If feature.Coordinates = coordinates Then
                    feature.Name = name
                    feature.Score = score
                    feature.Tolerance = tolerance
                End If
            Next
        Next

        featuresLoaded = True
    End Sub

    Private Sub LoadParameters(ByVal Parameters)
        Dim reader = My.Computer.FileSystem.ReadAllText(Parameters)
        If reader = "" Then Exit Sub

        Dim values = reader.Split(vbTab)
        BorderRectSize = CInt(values(0))
        NullCap = CDbl(values(1))
        NullCapThreshold = CDbl(values(2))

        parametersLoaded = True
    End Sub

    Private Sub LoadDrawing(ByVal DrawingPath As String)
        drawing = New Bitmap(DrawingPath)
        drawingLoaded = True
        MakeRects()
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

    Private Sub ViewScores(sender As Object, e As EventArgs) Handles ViewScoresToolStripMenuItem.Click
        scoresDisplayed = True
        displayScores = New Form With {.FormBorderStyle = FormBorderStyle.SizableToolWindow, .Text = "Current Scores"}
        Dim scores As New RichTextBox With {.Dock = DockStyle.Fill, .Text = scoreStr}
        displayScores.Controls.Add(scores)
        displayScores.Show()
    End Sub

    Private Sub SaveFeatureSheet(sender As Object, e As EventArgs) Handles SaveFeatureSheetToolStripMenuItem.Click
        Dim dialog = New SaveFileDialog With {.Filter = "Feature Sheet|*.efs"}
        If dialog.ShowDialog() = DialogResult.OK Then
            Dim outputStr = ""
            For Each feature As cFeature In features
                outputStr += feature.Coordinates & vbTab & feature.Name & vbTab & feature.Score & vbTab & feature.Tolerance & vbCrLf
            Next
            My.Computer.FileSystem.WriteAllText(dialog.FileName, outputStr, False)
        Else
            Exit Sub
        End If

        lblStatus.BackColor = Color.LimeGreen
        lblStatus.Text = "Feature Sheet Saved"
    End Sub

    Private Sub SaveParameters(sender As Object, e As EventArgs) Handles SaveParametersToolStripMenuItem.Click
        Dim dialog = New SaveFileDialog With {.Filter = "Parameters|*.eprm"}
        If dialog.ShowDialog() = DialogResult.OK Then
            Dim outputStr = BorderRectSize.ToString() & vbTab & NullCap.ToString() & vbTab & NullCapThreshold
            My.Computer.FileSystem.WriteAllText(dialog.FileName, outputStr, False)
        Else
            Exit Sub
        End If

        lblStatus.BackColor = Color.LimeGreen
        lblStatus.Text = "Parameters Saved"
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
            features.Add(New cFeature(featureNWCorners(i), featureSECorners(i)))
        Next

        For Each feature As cFeature In features ' Make header for output string
            scoreStr += feature.Name & vbTab
        Next

        crop = New Rectangle(cropX.Min, cropY.Min, cropX.Max - cropX.Min, cropY.Max - cropY.Min) ' The white pixels are the crop region
    End Sub

    Private Sub IterateImages()
        Text = files(fileIdx).Split("\").Last() ' Get short name of file

        Dim src = Image.FromFile(files(fileIdx))
        Dim target = New Bitmap(crop.Width, crop.Height)
        BitmapCrop(crop, src, target)
        pbxCrop.Image = target

        Dim nullScore = CalcEntropy(target) ' Entropy of cropped image
        LastCropScore = nullScore
        scoreStr += vbCrLf & Text & vbTab & nullScore.ToString() & vbTab

        If parametersLoaded AndAlso nullScore + NullCapThreshold < NullCap Then
            pbxFeatures.BackColor = Color.Yellow
        Else
            pbxFeatures.BackColor = SystemColors.Control
        End If

        Dim srcFeatures = New Bitmap(src.Width, src.Height)
        Dim targetFeatures = New Bitmap(crop.Width, crop.Height)
        For Each feature As cFeature In features
            Dim featureBuffer As New Bitmap(feature.Rect.Width, feature.Rect.Height)
            Using g As Graphics = Graphics.FromImage(featureBuffer)
                g.DrawImage(src, New Rectangle(0, 0, feature.Rect.Width, feature.Rect.Height), feature.Rect, GraphicsUnit.Pixel)
            End Using

            Dim thisScore = CalcEntropy(featureBuffer) ' Entropy of feature
            feature.LastScore = thisScore.ToString()
            scoreStr += thisScore.ToString() & vbTab

            Using g As Graphics = Graphics.FromImage(srcFeatures)
                If Math.Abs(thisScore - feature.Score) > feature.Tolerance Then
                    g.FillRectangle(New SolidBrush(Color.Red), feature.BorderRect)
                Else
                    g.FillRectangle(New SolidBrush(Color.Green), feature.BorderRect)
                End If

                g.DrawImage(src, feature.Rect, feature.Rect, GraphicsUnit.Pixel)
            End Using
        Next
        BitmapCrop(crop, srcFeatures, targetFeatures)
        pbxFeatures.Image = targetFeatures

        If scoresDisplayed Then
            displayScores.Controls.Item(0).Text = scoreStr
        End If
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
        fileIdx = -1
        lblStatus.BackColor = Color.LawnGreen
        lblStatus.Text = "All Photos Scored"
    End Sub

    Private Sub lblStatus_Click(sender As Object, e As EventArgs) Handles lblStatus.Click
        lblStatus.Text = ""
        lblStatus.BackColor = Color.White
    End Sub

    Private Sub pbxCrop_Click(sender As Object, e As EventArgs) Handles pbxCrop.Click
        If Application.OpenForms().OfType(Of frmEditParams).Any Then
            Application.OpenForms().OfType(Of frmEditFeature).First.BringToFront()
        Else
            Dim editParams As New frmEditParams()
            editParams.Show()
        End If
    End Sub

    Private Sub pbxFeatures_Click(sender As Object, e As MouseEventArgs) Handles pbxFeatures.Click
        If Application.OpenForms().OfType(Of frmEditFeature).Any Then
            Application.OpenForms().OfType(Of frmEditFeature).First.Dispose()
        End If

        ' Scale click to proportions of background image
        Dim click As New PointF((e.X / pbxCrop.Width * pbxCrop.Image.Width) + crop.X, (e.Y / pbxCrop.Height * pbxCrop.Image.Height) + crop.Y)
        For Each feature As cFeature In features ' Check if click overlaps with paths
            If feature.Path.IsVisible(click) Then
                Dim editScore As New frmEditFeature(feature, MousePosition())
                editScore.Show()
            End If
        Next
    End Sub
End Class