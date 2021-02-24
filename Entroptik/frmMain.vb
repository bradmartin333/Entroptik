Public Class frmMain
    Private RunAll As Boolean

    Private Sub OpenWorkspace(sender As Object, e As EventArgs) Handles OpenWorkspaceToolStripMenuItem.Click
        Dim dialog = New OpenFileDialog With {.Filter = "Entroptik Workspace|*.ew"}
        If dialog.ShowDialog() = DialogResult.OK Then
            workspacePath = dialog.FileName
        Else
            Exit Sub
        End If

        LoadWorkspace()
    End Sub

    Private Sub OpenImagesFolder(sender As Object, e As EventArgs) Handles OpenImagesDirToolStripMenuItem.Click
        Dim dialog = New FolderBrowserDialog With {.Description = "Choose folder containing images"}
        If dialog.ShowDialog() = DialogResult.OK Then
            imagesDir = dialog.SelectedPath
            LoadImages()
        Else
            Exit Sub
        End If

        If workspacePath = "" Then
            Dim result As DialogResult = MessageBox.Show("Is this a 5x5 Grid-Type Workspace?", "Entroptik", MessageBoxButtons.YesNo)
            If result.Equals(result.Yes) Then
                WorkspaceType = WorkspaceTypes.Grid
            Else
                WorkspaceType = WorkspaceTypes.Standard
            End If

            Wizard = New frmData("Entroptik Workspace Wizard")
            Wizard.Show()
        Else
            Dim data = IO.File.ReadAllLines(workspacePath)
            data(data.Length - 1) = dialog.SelectedPath
            IO.File.WriteAllLines(workspacePath, data)
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
        Text = files(fileIdx).Name

        Dim scoreData(features.Count() + 2) As String
        scoreData(0) = Text
        Dim logData(features.Count() + 2) As String
        logData(0) = Text

        Dim src = Image.FromFile(files(fileIdx).FullName)
        pbx.Image = src
        Dim nullScore = CalcEntropy(src) ' Entropy of source image
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

        For Each feature As cFeature In features
            Dim featureBuffer As New Bitmap(feature.Rect.Width, feature.Rect.Height)
            Using g As Graphics = Graphics.FromImage(featureBuffer)
                g.DrawImage(src, New Rectangle(0, 0, feature.Rect.Width, feature.Rect.Height), feature.Rect, GraphicsUnit.Pixel)
            End Using

            Dim thisScore = CalcEntropy(featureBuffer) ' Entropy of feature
            feature.LastScore = thisScore.ToString()
            scoreData(features.IndexOf(feature) + 2) = thisScore


            Using g As Graphics = Graphics.FromImage(src)
                If Math.Abs(thisScore - feature.Score) > feature.Tolerance Then
                    If Not RunAll Then g.DrawRectangle(New Pen(Color.Red, BorderRectSize), feature.Rect)
                    logData(features.IndexOf(feature) + 2) = 0
                Else
                    If Not RunAll Then g.DrawRectangle(New Pen(Color.Green, BorderRectSize), feature.Rect)
                    logData(features.IndexOf(feature) + 2) = 1
                End If
            End Using
        Next

        Scores.DataGridView.Rows.Add(scoreData)
        Log.DataGridView.Rows.Add(logData)

        Refresh()
    End Sub

    Private Sub ScoreGridImage()
        Text = files(fileIdx).Name
        Dim row As Integer = CInt(Text.ToArray(Text.IndexOf("R") + 1).ToString()) - 1
        Dim col As Integer = CInt(Text.ToArray(Text.IndexOf("C") + 1).ToString()) - 1

        Dim src = Image.FromFile(files(fileIdx).FullName)
        pbx.Image = src

        Dim i, j As Integer
        For Each feature As cFeature In features
            Dim featureBuffer As New Bitmap(feature.Rect.Width, feature.Rect.Height)
            Using g As Graphics = Graphics.FromImage(featureBuffer)
                g.DrawImage(src, New Rectangle(0, 0, feature.Rect.Width, feature.Rect.Height), feature.Rect, GraphicsUnit.Pixel)
            End Using

            Dim thisScore = CalcEntropy(featureBuffer) ' Entropy of feature
            feature.LastScore = thisScore.ToString()

            Using g As Graphics = Graphics.FromImage(src)
                If Math.Abs(thisScore - feature.Score) > feature.Tolerance Then
                    If Not RunAll Then g.DrawRectangle(New Pen(Color.Red, BorderRectSize), feature.Rect)
                    GridData(row * 5 + j, col * 5 + i) = 0
                Else
                    If Not RunAll Then g.DrawRectangle(New Pen(Color.Green, BorderRectSize), feature.Rect)
                    GridData(row * 5 + j, col * 5 + i) = 1
                End If
            End Using

            i += 1
            If i = 5 Then
                i = 0
                j += 1
            End If
        Next

        Log.DataGridView.Rows.Clear()
        For i = 0 To GridRows - 1
            Dim logData(GridCols - 1) As String
            For j = 0 To GridCols - 1
                logData(j) = GridData(i, j)
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
        fileIdx = -1
        Scores.DataGridView.Rows.Clear()
        Log.DataGridView.Rows.Clear()
        NextStripMenuItem.Enabled = True
        RunAllStripMenuItem.Enabled = True
        Proceed()
    End Sub

    Public Function Proceed()
        fileIdx += 1
        If fileIdx > files.Count - 1 Then
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
        fileIdx = -1
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
        If fileIdx = -1 Then Exit Sub

        If Application.OpenForms().OfType(Of frmEditFeature).Any Then
            Application.OpenForms().OfType(Of frmEditFeature).First.Dispose()
        End If

        If Application.OpenForms().OfType(Of frmEditParams).Any Then
            Application.OpenForms().OfType(Of frmEditParams).First.Dispose()
        End If

        ' Scale click to proportions of background image
        Dim click As New PointF(e.X / pbx.Width * pbx.Image.Width, e.Y / pbx.Height * pbx.Image.Height)
        Dim featureClicked As Boolean
        For Each feature As cFeature In features ' Check if click overlaps with paths
            If feature.Path.IsVisible(click) Then
                featureClicked = True
                Dim editScore As New frmEditFeature(feature, MousePosition())
                editScore.Show()
            End If
        Next

        If Not featureClicked And WorkspaceType = WorkspaceTypes.Standard Then
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
            workspacePath = My.Application.CommandLineArgs.First.ToString()
            LoadWorkspace()
        End If
    End Sub
End Class