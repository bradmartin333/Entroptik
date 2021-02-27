Public Class frmEditFeature
    Private thisFeature As cFeature
    Private loaded As Boolean

    Public Sub New(ByRef feature As cFeature, ByVal pos As Point)
        InitializeComponent()
        thisFeature = feature
        Text = feature.Coordinates
        numScore.Value = feature.Score
        Location = pos
        txtName.Text = feature.Name
        lblLastScoreValue.Text = feature.LastScore
        numTolerance.Value = feature.Tolerance
        cmbScoreType.DataSource = ScoreTypes
        cmbScoreType.SelectedIndex = feature.ScoreType
        loaded = True
    End Sub

    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        thisFeature.Score = numScore.Value
        thisFeature.Name = txtName.Text
        thisFeature.Tolerance = numTolerance.Value
        Save()
        Dispose()
    End Sub

    Private Sub Save()
        Dim data = IO.File.ReadAllLines(WorkspacePath)
        For i = 0 To Features.Count - 1
            If DoBatchTrain Then
                With Features(i)
                    .Score = thisFeature.Score
                    .Tolerance = thisFeature.Tolerance
                    .ScoreType = thisFeature.ScoreType
                End With
            End If
            ExportFeatures(data)
        Next
        IO.File.WriteAllLines(WorkspacePath, data)
        DoBatchTrain = False
    End Sub

    Private Sub cmbScoreType_SelectedIndexChanged(sender As ComboBox, e As EventArgs) Handles cmbScoreType.SelectedIndexChanged
        If Not loaded Then Exit Sub
        thisFeature.ScoreType = sender.SelectedIndex
    End Sub
End Class