Public Class frmEditParams
    Public Sub New()
        InitializeComponent()
        numBorderRectangleSize.Value = BorderRectSize
        numNullCap.Value = NullCap
        lblLastCropScore.Text = LastCropScore.ToString()
        numNullThreshold.Value = NullCapThreshold
    End Sub

    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        BorderRectSize = numBorderRectangleSize.Value
        NullCap = numNullCap.Value
        NullCapThreshold = numNullThreshold.Value
        Dispose()
    End Sub
End Class