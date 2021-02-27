Imports MathNet.Numerics.Statistics

Module modHelpers
    '''<summary>Size of border rectangle offset</summary>
    Public Property BorderRectSize As Integer = 5
    '''<summary>Training value for cropped image</summary>
    Public Property NullCap As Double = 0
    '''<summary>Acceptable difference from trained score</summary>
    Public Property NullCapThreshold As Double = 1
    '''<summary>Last score value for quick reference</summary>
    Public Property LastSourceScore As Double
    '''<summary>Grid or Not</summary>
    Public Property WorkspaceType As Double

    Public Enum WorkspaceTypes
        Standard
        Grid
    End Enum

    Public Files As New List(Of IO.FileInfo)
    Public FileIdx As Integer = -1
    Public RunAll As Boolean
    Public Features As New List(Of cFeature)
    Public Scores, Log, Wizard As frmData
    Public GridWizard As frmGridWizard
    Public ImageExtensions() As String = {".JPG", ".JPE", ".BMP", ".GIF", ".PNG"}
    Public WorkspacePath = ""
    Public ImagesDir = ""
    Public GridData
    Public GridRows, GridCols As Integer
    Public SubGridRows, SubGridCols As Integer
    Public DoBatchTrain As Boolean

    Public ScoreTypes As String() = {"ARGB Entropy", "Lux Entropy", "Hue Entropy",
                                     "Red Entropy", "Red Average", "Red Median", "Red Std Dev",
                                     "Green Entropy", "Green Average", "Green Median", "Green Std Dev",
                                     "Blue Entropy", "Blue Average", "Blue Median", "Blue Std Dev"}

    Public Function CalcScore(ByVal img As Bitmap, Optional scoreType As Integer = 0)
        Select Case scoreType
            Case 0
                Return CalcARGBEntropy(img)
            Case 1
                Return LuxEntropy(img)
            Case 2
                Return HueEntropy(img)
            Case 3
                Return RedEntropy(img)
            Case 4
                Return RedAverage(img)
            Case 5
                Return RedMedian(img)
            Case 6
                Return RedStdDev(img)
            Case 7
                Return GreenEntropy(img)
            Case 8
                Return GreenAverage(img)
            Case 9
                Return GreenMedian(img)
            Case 10
                Return GreenStdDev(img)
            Case 11
                Return BlueEntropy(img)
            Case 12
                Return BlueAverage(img)
            Case 13
                Return BlueMedian(img)
            Case 14
                Return BlueStdDev(img)
        End Select
        Return 0
    End Function

    Private Function GetRedPixels(img As Bitmap) As List(Of Double)
        Dim pixels As New List(Of Double)
        For i = 0 To img.Width - 1
            For j = 0 To img.Height - 1
                pixels.Add(img.GetPixel(i, j).R)
            Next
        Next
        Return pixels.AsEnumerable
    End Function

    Private Function GetGreenPixels(img As Bitmap) As List(Of Double)
        Dim pixels As New List(Of Double)
        For i = 0 To img.Width - 1
            For j = 0 To img.Height - 1
                pixels.Add(img.GetPixel(i, j).G)
            Next
        Next
        Return pixels.AsEnumerable
    End Function

    Private Function GetBluePixels(img As Bitmap) As List(Of Double)
        Dim pixels As New List(Of Double)
        For i = 0 To img.Width - 1
            For j = 0 To img.Height - 1
                pixels.Add(img.GetPixel(i, j).B)
            Next
        Next
        Return pixels.AsEnumerable
    End Function

    Private Function GetLuxPixels(img As Bitmap) As List(Of Double)
        Dim pixels As New List(Of Double)
        For i = 0 To img.Width - 1
            For j = 0 To img.Height - 1
                pixels.Add(img.GetPixel(i, j).GetBrightness)
            Next
        Next
        Return pixels.AsEnumerable
    End Function

    Private Function GetHuePixels(img As Bitmap) As List(Of Double)
        Dim pixels As New List(Of Double)
        For i = 0 To img.Width - 1
            For j = 0 To img.Height - 1
                pixels.Add(img.GetPixel(i, j).GetHue)
            Next
        Next
        Return pixels.AsEnumerable
    End Function

    Private Function GetARGBPixels(img As Bitmap) As List(Of Double)
        Dim pixels As New List(Of Double)
        For i = 0 To img.Width - 1
            For j = 0 To img.Height - 1
                pixels.Add(img.GetPixel(i, j).ToArgb)
            Next
        Next
        Return pixels.AsEnumerable
    End Function

    Private Function BlueStdDev(img As Bitmap) As Double
        Dim score = Statistics.StandardDeviation(GetBluePixels(img))
        Return Math.Round(score, 3)
    End Function

    Private Function BlueMedian(img As Bitmap) As Double
        Dim score = Statistics.Median(GetBluePixels(img))
        Return Math.Round(score, 3)
    End Function

    Private Function BlueAverage(img As Bitmap) As Double
        Dim score = Statistics.Mean(GetBluePixels(img))
        Return Math.Round(score, 3)
    End Function

    Private Function BlueEntropy(img As Bitmap) As Double
        Dim score = Statistics.Entropy(GetBluePixels(img))
        Return Math.Round(score, 3)
    End Function

    Private Function GreenStdDev(img As Bitmap) As Double
        Dim score = Statistics.StandardDeviation(GetGreenPixels(img))
        Return Math.Round(score, 3)
    End Function

    Private Function GreenMedian(img As Bitmap) As Double
        Dim score = Statistics.Median(GetGreenPixels(img))
        Return Math.Round(score, 3)
    End Function

    Private Function GreenAverage(img As Bitmap) As Double
        Dim score = Statistics.Mean(GetGreenPixels(img))
        Return Math.Round(score, 3)
    End Function

    Private Function GreenEntropy(img As Bitmap) As Double
        Dim score = Statistics.Entropy(GetGreenPixels(img))
        Return Math.Round(score, 3)
    End Function

    Private Function RedStdDev(img As Bitmap) As Double
        Dim score = Statistics.StandardDeviation(GetRedPixels(img))
        Return Math.Round(score, 3)
    End Function

    Private Function RedMedian(img As Bitmap) As Double
        Dim score = Statistics.Median(GetRedPixels(img))
        Return Math.Round(score, 3)
    End Function

    Private Function RedAverage(img As Bitmap) As Double
        Dim score = Statistics.Mean(GetRedPixels(img))
        Return Math.Round(score, 3)
    End Function

    Private Function RedEntropy(img As Bitmap) As Double
        Dim score = Statistics.Entropy(GetRedPixels(img))
        Return Math.Round(score, 3)
    End Function

    Private Function HueEntropy(img As Bitmap) As Double
        Dim score = Statistics.Entropy(GetHuePixels(img))
        Return Math.Round(score, 3)
    End Function

    Private Function LuxEntropy(img As Bitmap) As Double
        Dim score = Statistics.Entropy(GetLuxPixels(img))
        Return Math.Round(score, 3)
    End Function

    Public Function CalcARGBEntropy(ByVal img As Bitmap) As Double
        Dim score = Statistics.Entropy(GetARGBPixels(img))
        Return Math.Round(score, 3)
    End Function

    Public Sub MakeGridColumns(frm As frmData)
        If frm.Text.Contains("Wizard") Then
            With frm.DataGridView
                .ColumnCount = 5
                .Columns(0).Name = "NW Corner X"
                .Columns(1).Name = "NW Corner Y"
                .Columns(2).Name = "SE Corner X"
                .Columns(3).Name = "SE Corner Y"
                .Columns(4).Name = "Name (Optional)"
            End With
        ElseIf WorkspaceType = WorkspaceTypes.Standard Then
            With frm.DataGridView
                .ColumnCount = Features.Count() + 2
                .Columns(0).Name = "FileName"
                .Columns(1).Name = "Source"
                For i As Integer = 0 To Features.Count - 1
                    If Features(i).Name = "" Then
                        .Columns(i + 2).Name = Features(i).Coordinates
                    Else
                        .Columns(i + 2).Name = Features(i).Name
                    End If
                Next
            End With
        ElseIf WorkspaceType = WorkspaceTypes.Grid Then
            frm.DataGridView.ColumnCount = GridCols
        End If
    End Sub

    Public Sub LoadWorkspace()
        UnloadWorkspace()

        Try
            Dim data = IO.File.ReadAllLines(WorkspacePath)

            WorkspaceType = data(0)
            BorderRectSize = data(1)
            NullCap = data(2)
            NullCapThreshold = data(3)

            For i = 4 To data.Length - 2
                Dim featureData = data(i).Split(",")
                Features.Add(New cFeature(New Point(featureData(0), featureData(1)), New Point(featureData(2), featureData(3)), featureData(5), featureData(6), featureData(7), featureData(4)))
            Next

            ImagesDir = data(data.Length - 1)

            If Not IO.Directory.Exists(ImagesDir) Then
                frmMain.lblStatus.BackColor = Color.Yellow
                frmMain.lblStatus.Text = "Images Directory Not Found"
                Exit Sub
            End If
        Catch ex As Exception
            frmMain.lblStatus.BackColor = Color.Yellow
            frmMain.lblStatus.Text = "Invalid Entroptik Workspace E000"
            Exit Sub
        End Try

        LoadImages()
        EnableTools()
        frmMain.Proceed()
    End Sub

    Public Sub UnloadWorkspace()
        Scores = New frmData("Scores")
        Log = New frmData("Log")
        FileIdx = -1
        RunAll = True
        Features.Clear()
        GridData = Nothing
        GridRows = 0
        GridCols = 0
        SubGridRows = 0
        SubGridCols = 0
    End Sub

    Public Sub LoadImages()
        Files.Clear()

        Try
            Dim di As New IO.DirectoryInfo(ImagesDir)
            Dim aryFi As IO.FileInfo() = di.GetFiles
            Dim fi As IO.FileInfo
            For Each fi In aryFi
                If ImageExtensions.Contains(fi.Extension.ToUpperInvariant()) Then Files.Add(fi)
            Next
        Catch ex As Exception
            frmMain.lblStatus.BackColor = Color.Yellow
            frmMain.lblStatus.Text = "Invalid Entroptik Workspace E001"
            Exit Sub
        End Try

        If Files.Count = 0 Then
            frmMain.lblStatus.BackColor = Color.Yellow
            frmMain.lblStatus.Text = "Invalid Directory: No Photos Found"
            Exit Sub
        End If

        frmMain.lblStatus.BackColor = Color.LimeGreen
        frmMain.lblStatus.Text = Files.Count.ToString() & " Photos Loaded"

        If WorkspaceType = WorkspaceTypes.Grid Then CreateGrid()
    End Sub

    Public Sub CreateGrid()
        Dim rows, cols As Integer
        For Each fi As IO.FileInfo In Files
            Dim row As Integer = CInt(fi.Name.ToArray(fi.Name.IndexOf("R") + 1).ToString())
            Dim col As Integer = CInt(fi.Name.ToArray(fi.Name.IndexOf("C") + 1).ToString())
            If row > rows Then rows = row
            If col > cols Then cols = col
        Next
        Dim posX, posY As New List(Of Integer)
        For Each feature In Features
            If Not posX.Contains(feature.Rect.X) Then posX.Add(feature.Rect.X)
            If Not posY.Contains(feature.Rect.Y) Then posY.Add(feature.Rect.Y)
        Next
        SubGridRows = posY.Count
        SubGridCols = posX.Count
        GridRows = rows * SubGridRows
        GridCols = cols * SubGridCols
        Dim data(GridRows - 1, GridCols - 1) As Integer
        GridData = data
    End Sub

    Public Sub EnableTools()
        FileIdx = -1
        MakeGridColumns(Scores)
        MakeGridColumns(Log)
        frmMain.ViewToolStripMenuItem.Enabled = True
        frmMain.ImageToolStripMenuItem.Enabled = True
        frmMain.ToolsStripMenuItem.Enabled = True
        frmMain.ViewScoresToolStripMenuItem.Enabled = Not CBool(WorkspaceType)
        frmMain.NextStripMenuItem.Enabled = True
        frmMain.RunAllStripMenuItem.Enabled = True
    End Sub

    Public Function ZoomMousePos(click As Point, pbx As PictureBox)
        Dim imageAspect As Double = pbx.Image.Width / pbx.Image.Height
        Dim controlAspect As Double = pbx.Width / pbx.Height
        Dim pos As Point = click
        If imageAspect > controlAspect Then
            Dim ratioWidth As Double = pbx.Image.Width / pbx.Width
            pos.X *= ratioWidth
            Dim scale As Double = pbx.Width / pbx.Image.Width
            Dim displayHeight As Double = scale * pbx.Image.Height
            Dim diffHeight As Double = pbx.Height - displayHeight
            diffHeight /= 2
            pos.Y -= diffHeight
            pos.Y /= scale
        Else
            Dim ratioHeight As Double = pbx.Image.Height / pbx.Height
            pos.Y *= ratioHeight
            Dim scale As Double = pbx.Height / pbx.Image.Height
            Dim displayWidth As Double = scale * pbx.Image.Width
            Dim diffWidth As Double = pbx.Width - displayWidth
            diffWidth /= 2
            pos.X -= diffWidth
            pos.X /= scale
        End If
        Return pos
    End Function

    Public Function ExportFeatures(data As String())
        For i = 0 To Features.Count - 1
            With Features(i)
                data(i + 4) = .Rect.Left & "," &
                              .Rect.Top & "," &
                              .Rect.Right & "," &
                              .Rect.Bottom & "," &
                              .Name & "," &
                              .Score & "," &
                              .Tolerance & "," &
                              .ScoreType
            End With
        Next
        Return data
    End Function
End Module

