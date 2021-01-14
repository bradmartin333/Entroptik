Public Class frmMain
    Dim ImagesFolder = "C:\"
    Dim files As New List(Of String)
    Dim fileIdx As Integer

    Private Sub btnOpenFolder_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
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