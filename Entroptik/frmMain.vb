Public Class frmMain
    Private Sub OpenWorkspace(sender As Object, e As EventArgs) Handles OpenWorkspaceToolStripMenuItem.Click
        Dim dialog = New OpenFileDialog With {.Filter = "Entroptik Workspace|*.ew"}
        If dialog.ShowDialog() = DialogResult.OK Then
            WorkspacePath = dialog.FileName
        Else
            Exit Sub
        End If

        LoadWorkspace()
    End Sub

    Private Sub OpenImagesFolder(sender As Object, e As EventArgs) Handles OpenImagesDirToolStripMenuItem.Click
        Dim dialog = New FolderBrowserDialog With {.Description = "Choose folder containing images"}
        If dialog.ShowDialog() = DialogResult.OK Then
            ImagesDir = dialog.SelectedPath
            LoadImages()
        Else
            Exit Sub
        End If

        If WorkspacePath = "" Then
            Dim result = MsgBox("Is this a Grid Workspace?", MsgBoxStyle.YesNo, "Entroptik")
            If result = vbYes Then
                WorkspaceType = WorkspaceTypes.Grid
                GridWizard = New frmGridWizard()
                GridWizard.Show()
            Else
                WorkspaceType = WorkspaceTypes.Standard
                Wizard = New frmData("Entroptik Workspace Wizard")
                Wizard.Show()
            End If
        Else
            Dim data = IO.File.ReadAllLines(WorkspacePath)
            data(data.Length - 1) = dialog.SelectedPath
            IO.File.WriteAllLines(WorkspacePath, data)
            EnableTools()
            Proceed()
        End If
    End Sub

    Private Sub ViewScores(sender As Object, e As EventArgs) Handles ViewScoresToolStripMenuItem.Click
        Scores.Show()
    End Sub

    Private Sub ViewLog(sender As Object, e As EventArgs) Handles ViewLogToolStripMenuItem.Click
        Log.Show()
    End Sub

    Private Sub ScoreImage()
        Text = Files(FileIdx).Name

        Dim scoreData(Features.Count() + 2) As String
        scoreData(0) = Text
        Dim logData(Features.Count() + 2) As String
        logData(0) = Text

        Dim src = Image.FromFile(Files(FileIdx).FullName)
        pbx.Image = src
        Dim nullScore = CalcScore(src) ' Entropy of source image
        LastSourceScore = nullScore
        scoreData(1) = nullScore

        If nullScore + NullCapThreshold < NullCap Then
            BackColor = Color.Red
            lblStatus.Text = "Null Photo"
            logData(1) = 0
        Else
            BackColor = SystemColors.Control
            logData(1) = 1
        End If

        For Each feature As cFeature In Features
            Dim featureBuffer As New Bitmap(feature.Rect.Width, feature.Rect.Height)
            Using g As Graphics = Graphics.FromImage(featureBuffer)
                g.DrawImage(src, New Rectangle(0, 0, feature.Rect.Width, feature.Rect.Height), feature.Rect, GraphicsUnit.Pixel)
            End Using

            Dim thisScore = CalcScore(featureBuffer, feature.ScoreType) ' Entropy of feature
            feature.LastScore = thisScore.ToString()
            scoreData(Features.IndexOf(feature) + 2) = thisScore


            Using g As Graphics = Graphics.FromImage(src)
                If Math.Abs(thisScore - feature.Score) > feature.Tolerance Then
                    g.DrawRectangle(New Pen(Color.Red, BorderRectSize), feature.Rect)
                    logData(Features.IndexOf(feature) + 2) = 0
                Else
                    g.DrawRectangle(New Pen(Color.Green, BorderRectSize), feature.Rect)
                    logData(Features.IndexOf(feature) + 2) = 1
                End If
            End Using
        Next

        Scores.DataGridView.Rows.Add(scoreData)
        Log.DataGridView.Rows.Add(logData)

        Refresh()
    End Sub

    Private Sub ScoreGridImage()
        Text = Files(FileIdx).Name
        Dim row As Integer = CInt(Text.ToArray(Text.IndexOf("R") + 1).ToString()) - 1
        Dim col As Integer = CInt(Text.ToArray(Text.IndexOf("C") + 1).ToString()) - 1

        Dim src = Image.FromFile(Files(FileIdx).FullName)
        pbx.Image = src

        Dim i, j As Integer
        For Each feature As cFeature In Features
            Dim featureBuffer As New Bitmap(feature.Rect.Width, feature.Rect.Height)
            Using g As Graphics = Graphics.FromImage(featureBuffer)
                g.DrawImage(src, New Rectangle(0, 0, feature.Rect.Width, feature.Rect.Height), feature.Rect, GraphicsUnit.Pixel)
            End Using

            Dim thisScore = CalcScore(featureBuffer, feature.ScoreType) ' Entropy of feature
            feature.LastScore = thisScore.ToString()

            Using g As Graphics = Graphics.FromImage(src)
                If Math.Abs(thisScore - feature.Score) > feature.Tolerance Then
                    g.DrawRectangle(New Pen(Color.Red, BorderRectSize), feature.Rect)
                    GridData(row * SubGridRows + j, col * SubGridCols + i) = 0
                Else
                    g.DrawRectangle(New Pen(Color.Green, BorderRectSize), feature.Rect)
                    GridData(row * SubGridRows + j, col * SubGridCols + i) = 1
                End If
            End Using

            i += 1
            If i = SubGridCols Then
                i = 0
                j += 1
            End If
        Next

        Log.DataGridView.Rows.Clear()
        For i = 0 To GridCols - 1
            Dim logData(GridRows - 1) As String
            For j = 0 To GridRows - 1
                logData(j) = GridData(j, i)
            Next
            Log.DataGridView.Rows.Add(logData)
        Next

        Refresh()
    End Sub

    Private Sub NextImage(sender As Object, e As EventArgs) Handles NextStripMenuItem.Click
        ClearStatus()
        Proceed()
    End Sub

    Private Sub AllImages(sender As Object, e As EventArgs) Handles RunAllStripMenuItem.Click
        ClearStatus()
        RunAll = True
        While True
            If Proceed() = 1 Then Exit Sub
        End While
    End Sub

    Private Sub StartOver(sender As Object, e As EventArgs) Handles StartOverToolStripMenuItem.Click
        ClearStatus()
        FileIdx = -1
        Scores.DataGridView.Rows.Clear()
        Log.DataGridView.Rows.Clear()
        NextStripMenuItem.Enabled = True
        RunAllStripMenuItem.Enabled = True
        Proceed()
    End Sub

    Public Function Proceed()
        FileIdx += 1
        If FileIdx > Files.Count - 1 Then
            Finish()
            Return 1
        End If

        Select Case WorkspaceType
            Case WorkspaceTypes.Standard
                ScoreImage()
            Case WorkspaceTypes.Grid
                ScoreGridImage()
        End Select

        Return 0
    End Function

    Private Sub Finish()
        FileIdx = -1
        lblStatus.BackColor = Color.LawnGreen
        lblStatus.Text = "All Photos Scored"
        NextStripMenuItem.Enabled = False
        RunAllStripMenuItem.Enabled = False
        RunAll = False
    End Sub

    Private Sub lblStatus_Click(sender As Object, e As EventArgs) Handles lblStatus.Click
        ClearStatus()
    End Sub

    Private Sub ClearStatus()
        lblStatus.Text = ""
        lblStatus.BackColor = Color.White
    End Sub

    Private Sub pbx_Click(sender As Object, e As MouseEventArgs) Handles pbx.Click
        If FileIdx = -1 Then Exit Sub

        If Application.OpenForms().OfType(Of frmEditFeature).Any Then
            Application.OpenForms().OfType(Of frmEditFeature).First.Dispose()
        End If

        If Application.OpenForms().OfType(Of frmEditParams).Any Then
            Application.OpenForms().OfType(Of frmEditParams).First.Dispose()
        End If

        Dim click As Point = ZoomMousePos(New Point(e.X, e.Y), sender)
        Dim featureClicked As Boolean
        For Each feature As cFeature In Features ' Check if click overlaps with paths
            If feature.Path.IsVisible(click) Then
                featureClicked = True
                Dim editScore As New frmEditFeature(feature, MousePosition())
                editScore.Show()
            End If
        Next

        If Not featureClicked Then
            Dim editParams As New frmEditParams()
            editParams.Show()
        End If
    End Sub

    Private Sub ShowTips(sender As Object, e As EventArgs) Handles TipsToolStripMenuItem.Click
        Dim tips As New Form With {.FormBorderStyle = FormBorderStyle.SizableToolWindow, .Text = "Entroptik Tips", .Width = 600}
        Dim rtb = New RichTextBox With {.Dock = DockStyle.Fill}
        tips.Controls.Add(rtb)

        rtb.Text = IO.File.ReadAllText("Tips.txt")

        tips.Show()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        If My.Application.CommandLineArgs.Count > 0 Then
            WorkspacePath = My.Application.CommandLineArgs.First.ToString()
            LoadWorkspace()
        End If
    End Sub

    Private Sub BatchEdit(sender As Object, e As EventArgs) Handles BatchEditToolStripMenuItem.Click
        DoBatchTrain = True
        Dim editScore As New frmEditFeature(Features(0), PointToScreen(Location))
        editScore.Show()
    End Sub

    Private Sub AutoTrain(sender As Object, e As EventArgs) Handles AutoTrainToolStripMenuItem.Click

    End Sub
End Class