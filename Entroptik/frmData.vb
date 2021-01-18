Public Class frmData
    Public Sub New(str As String)
        InitializeComponent()
        Text = str
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

        Dim dialog = New SaveFileDialog With {.Filter = "Comma Seperated Values|*.csv"}
        If dialog.ShowDialog() = DialogResult.OK Then
            Using sw As New IO.StreamWriter(dialog.FileName)
                sw.WriteLine(String.Join(",", headers))
                For Each r In rows
                    sw.WriteLine(String.Join(",", r))
                Next
            End Using

            frmMain.lblStatus.BackColor = Color.LimeGreen
            frmMain.lblStatus.Text = Text & " Saved"
        Else
            Exit Sub
        End If
    End Sub
End Class