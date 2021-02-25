For row = 1 To 8
    For col = 1 To 8
        Dim bmp As Bitmap = New Bitmap(1100, 1100)
        For i = 100 To 1000 Step 200
            For j = 100 To 1000 Step 200
                If Rnd() > 0.5 Then
                    For k = j To j + 100 Step 10
                        Using g As Graphics = Graphics.FromImage(bmp)
                            g.FillRectangle(New SolidBrush(Color.Black), New Rectangle(i, k, 100, 5))
                        End Using
                    Next
                End If
            Next
        Next
        bmp.Save("$MYDIR$/_R" & row & "_C" & col & ".png")
    Next
Next