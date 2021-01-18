Public Class frmEditFeature
    Dim thisFeature As cFeature

    Public Sub New(ByRef feature As cFeature, ByVal pos As Point)
        InitializeComponent()
        thisFeature = feature
        Text = feature.Coordinates
        numScore.Value = feature.Score
        Location = pos
        txtName.Text = feature.Name
        lblLastScoreValue.Text = feature.LastScore
        numTolerance.Value = feature.Tolerance
    End Sub

    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        thisFeature.Score = numScore.Value
        thisFeature.Name = txtName.Text
        thisFeature.Tolerance = numTolerance.Value
        Dispose()
    End Sub
End Class