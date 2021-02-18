﻿Public Class frmEditFeature
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
        Save()
        Dispose()
    End Sub

    Private Sub Save()
        Dim data = IO.File.ReadAllLines(workspacePath)
        For i = 0 To features.Count - 1
            With features(i)
                data(i + 3) = .Rect.Left & "," &
                              .Rect.Top & "," &
                              .Rect.Right & "," &
                              .Rect.Bottom & "," &
                              .Name & "," &
                              .Score & "," &
                              .Tolerance
            End With
        Next
        IO.File.WriteAllLines(workspacePath, data)
    End Sub
End Class