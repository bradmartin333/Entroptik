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
    '''<summary>User determined crop rect</summary>

    Public files As New List(Of IO.FileInfo)
    Public fileIdx As Integer = -1
    Public features As New List(Of cFeature)
    Public Scores, Log, Wizard As frmData
    Public ImageExtensions() As String = {".JPG", ".JPE", ".BMP", ".GIF", ".PNG"}
    Public workspacePath = ""
    Public imagesDir = ""

    Public Function CalcEntropy(ByVal img As Bitmap)
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
        Else
            With frm.DataGridView
                .ColumnCount = features.Count() + 2
                .Columns(0).Name = "FileName"
                .Columns(1).Name = "Source"
                For i As Integer = 0 To features.Count - 1
                    If features(i).Name = "" Then
                        .Columns(i + 2).Name = features(i).Coordinates
                    Else
                        .Columns(i + 2).Name = features(i).Name
                    End If
                Next
            End With
        End If
    End Sub

    Public Sub LoadWorkspace()
        Scores = New frmData("Scores")
        Log = New frmData("Log")

        Try
            Dim data = IO.File.ReadAllLines(workspacePath)
            BorderRectSize = data(0)
            NullCap = data(1)
            NullCapThreshold = data(2)

            For i = 3 To data.Length - 2
                Dim featureData = data(i).Split(",")
                features.Add(New cFeature(New Point(featureData(0), featureData(1)), New Point(featureData(2), featureData(3)), featureData(5), featureData(6), featureData(4)))
            Next

            imagesDir = data(data.Length - 1)

            If Not IO.Directory.Exists(imagesDir) Then
                frmMain.lblStatus.BackColor = Color.Yellow
                frmMain.lblStatus.Text = "Invalid Entroptik Workspace (0)"
                Exit Sub
            End If
        Catch ex As Exception
            frmMain.lblStatus.BackColor = Color.Yellow
            frmMain.lblStatus.Text = "Invalid Entroptik Workspace (1)"
            Exit Sub
        End Try

        If files.Count = 0 Then LoadImages()

        EnableTools()
        frmMain.Proceed()
    End Sub

    Public Sub LoadImages()
        files.Clear()

        Try
            Dim di As New IO.DirectoryInfo(imagesDir)
            Dim aryFi As IO.FileInfo() = di.GetFiles
            Dim fi As IO.FileInfo
            For Each fi In aryFi
                If ImageExtensions.Contains(fi.Extension.ToUpperInvariant()) Then files.Add(fi)
            Next
        Catch ex As Exception
            frmMain.lblStatus.BackColor = Color.Yellow
            frmMain.lblStatus.Text = "Invalid Entroptik Workspace (2)"
            Exit Sub
        End Try

        If files.Count = 0 Then
            frmMain.lblStatus.BackColor = Color.Yellow
            frmMain.lblStatus.Text = "Invalid Directory: No Photos Found"
            Exit Sub
        End If

        frmMain.lblStatus.BackColor = Color.LimeGreen
        frmMain.lblStatus.Text = files.Count.ToString() & " Photos Loaded"
    End Sub

    Public Sub EnableTools()
        fileIdx = -1
        MakeGridColumns(Scores)
        MakeGridColumns(Log)
        frmMain.ViewToolStripMenuItem.Enabled = True
        frmMain.ToolsToolStripMenuItem.Enabled = True
    End Sub
End Module
