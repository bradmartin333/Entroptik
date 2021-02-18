﻿Public Class frmEditParams
    Public Sub New()
        InitializeComponent()
        numBorderRectangleSize.Value = BorderRectSize
        numNullCap.Value = NullCap
        lblLastCropScore.Text = LastSourceScore.ToString()
        numNullThreshold.Value = NullCapThreshold
    End Sub

    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        BorderRectSize = numBorderRectangleSize.Value
        NullCap = numNullCap.Value
        NullCapThreshold = numNullThreshold.Value
        Save()
        Dispose()
    End Sub

    Private Sub Save()
        Dim data = IO.File.ReadAllLines(workspacePath)
        data(0) = BorderRectSize
        data(1) = NullCap
        data(2) = NullCapThreshold
        IO.File.WriteAllLines(workspacePath, data)
    End Sub
End Class