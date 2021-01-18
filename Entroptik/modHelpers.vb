Imports MathNet.Numerics.Statistics

Module modHelpers
    Public Function CompareColors(ByVal pixel As Color, ByVal test As Color)
        If pixel.R = test.R And pixel.G = test.G And pixel.B = test.B Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub BitmapCrop(crop As Rectangle, src As Bitmap, ByRef target As Bitmap)
        Using g As Graphics = Graphics.FromImage(target)
            g.DrawImage(src, New Rectangle(0, 0, crop.Width, crop.Height), crop, GraphicsUnit.Pixel)
        End Using
    End Sub

    Public Function CalcEntropy(ByVal img As Bitmap)
        Dim pixels As New List(Of Double)
        For i = 0 To img.Width - 1
            For j = 0 To img.Height - 1
                pixels.Add(img.GetPixel(i, j).ToArgb)
            Next
        Next
        Dim pixelsEnum = pixels.AsEnumerable
        Dim score = Statistics.Entropy(pixelsEnum)
        Return Math.Round(score, 3)
    End Function
End Module
