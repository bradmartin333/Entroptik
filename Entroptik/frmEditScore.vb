Public Class frmEditScore
    Dim thisFeature As cFeature

    Public Sub New(ByRef feature As cFeature, ByVal pos As Point)
        InitializeComponent()
        thisFeature = feature
        Text = feature.Name
        numScore.Value = feature.Score
        Location = pos
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        thisFeature.Score = numScore.Value
    End Sub
End Class