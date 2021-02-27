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

    Public files As New List(Of IO.FileInfo)
    Public fileIdx As Integer = -1
    Public features As New List(Of cFeature)
    Public Scores, Log, Wizard As frmData
    Public GridWizard As frmGridWizard
    Public ImageExtensions() As String = {".JPG", ".JPE", ".BMP", ".GIF", ".PNG"}
    Public workspacePath = ""
    Public imagesDir = ""
    Public GridData
    Public GridRows, GridCols As Integer

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
        ElseIf WorkspaceType = WorkspaceTypes.Standard Then
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
        ElseIf WorkspaceType = WorkspaceTypes.Grid Then
            frm.DataGridView.ColumnCount = GridCols
        End If
    End Sub

    Public Sub LoadWorkspace()
        Scores = New frmData("Scores")
        Log = New frmData("Log")

        Try
            Dim data = IO.File.ReadAllLines(workspacePath)

            WorkspaceType = data(0)
            BorderRectSize = data(1)
            NullCap = data(2)
            NullCapThreshold = data(3)

            For i = 4 To data.Length - 2
                Dim featureData = data(i).Split(",")
                features.Add(New cFeature(New Point(featureData(0), featureData(1)), New Point(featureData(2), featureData(3)), featureData(5), featureData(6), featureData(4)))
            Next

            imagesDir = data(data.Length - 1)

            If Not IO.Directory.Exists(imagesDir) Then
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
            frmMain.lblStatus.Text = "Invalid Entroptik Workspace E001"
            Exit Sub
        End Try

        If files.Count = 0 Then
            frmMain.lblStatus.BackColor = Color.Yellow
            frmMain.lblStatus.Text = "Invalid Directory: No Photos Found"
            Exit Sub
        End If

        frmMain.lblStatus.BackColor = Color.LimeGreen
        frmMain.lblStatus.Text = files.Count.ToString() & " Photos Loaded"

        If WorkspaceType = WorkspaceTypes.Grid Then CreateGrid()
    End Sub

    Public Sub CreateGrid()
        Dim rows, cols As Integer
        For Each fi As IO.FileInfo In files
            Dim row As Integer = CInt(fi.Name.ToArray(fi.Name.IndexOf("R") + 1).ToString())
            Dim col As Integer = CInt(fi.Name.ToArray(fi.Name.IndexOf("C") + 1).ToString())
            If row > rows Then rows = row
            If col > cols Then cols = col
        Next
        GridRows = rows * 5
        GridCols = cols * 5
        Dim data(GridRows - 1, GridCols - 1) As Integer
        GridData = data
    End Sub

    Public Sub EnableTools()
        fileIdx = -1
        MakeGridColumns(Scores)
        MakeGridColumns(Log)
        frmMain.ViewToolStripMenuItem.Enabled = True
        frmMain.ToolsToolStripMenuItem.Enabled = True
        frmMain.ViewScoresToolStripMenuItem.Enabled = Not CBool(WorkspaceType)
    End Sub
End Module
