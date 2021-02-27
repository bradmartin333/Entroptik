Public Class frmData
    Dim filter = ""

    Public Sub New(str As String)
        InitializeComponent()
        Text = str

        If str.Contains("Wizard") Then
            filter = "Entroptik Workspace|*.ew"
            MakeGridColumns(Me)
        Else
            filter = "Comma Seperated Values|*.csv"
        End If
    End Sub

    Private Sub frmClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason <> CloseReason.FormOwnerClosing Then
            Hide()
            e.Cancel = True
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim headers = (From header As DataGridViewColumn In DataGridView.Columns.Cast(Of DataGridViewColumn)()
                       Select header.HeaderText).ToArray
        Dim rows = From row As DataGridViewRow In DataGridView.Rows.Cast(Of DataGridViewRow)()
                   Where Not row.IsNewRow
                   Select Array.ConvertAll(row.Cells.Cast(Of DataGridViewCell).ToArray, Function(c) If(c.Value IsNot Nothing, c.Value.ToString, ""))

        Dim dialog = New SaveFileDialog With {.Filter = filter}
        If dialog.ShowDialog() = DialogResult.OK Then
            Using sw As New IO.StreamWriter(dialog.FileName)
                sw.WriteLine(workspaceType)
                If Text.Contains("Wizard") Then
                    sw.WriteLine(BorderRectSize & vbCrLf & NullCap & vbCrLf & NullCapThreshold)
                Else
                    sw.WriteLine(String.Join(",", headers))
                End If
                For Each r In rows
                    Dim outputBuffer = (String.Join(",", r))
                    If Text.Contains("Wizard") Then
                        sw.WriteLine(outputBuffer & ",0,1")
                    Else
                        sw.WriteLine(outputBuffer)
                    End If
                Next
                If Text.Contains("Wizard") Then
                    sw.WriteLine(ImagesDir)
                End If
            End Using

            frmMain.lblStatus.BackColor = Color.LimeGreen
            frmMain.lblStatus.Text = Text & " Saved"

            If Text.Contains("Wizard") Then
                WorkspacePath = dialog.FileName
                LoadWorkspace()
                frmMain.Proceed()
                Hide()
            End If
        Else
            Exit Sub
        End If
    End Sub
End Class