Imports ClassLibrary1
Public Class SplashScreen
    Inherits XBase
    Private Counter As Decimal
    Private Switch As Boolean
    Sub New()
        Me.SetDrawStatus(True)
    End Sub
    Public Overrides Sub Draw(ByRef g As System.Drawing.Graphics)

        If Me.Counter > 255 Then
            Me.SetDisposeStatus(True)
        Else
            Dim B As New SolidBrush(Color.FromArgb(255 - Me.Counter, 0, 0, 0))
            g.FillRectangle(B, 0, 0, g.VisibleClipBounds.Width, g.VisibleClipBounds.Height)
            Dim FTitle As New Font(FontFamily.GenericSansSerif, 40, FontStyle.Bold)
            Dim FSub As New Font(FontFamily.GenericSansSerif, 20, FontStyle.Bold)
            Dim BF As New SolidBrush(Color.FromArgb(255 - Me.Counter, Color.White))
            g.DrawString("Shadow Casting Demo", FTitle, BF, 400, 350)
            BF = New SolidBrush(Color.FromArgb(255 - Me.Counter, Color.IndianRed))
            g.DrawString("Created By Sebastian Clarke", FSub, BF, 750, 450)
            B.Dispose()
            BF.Dispose()
            FTitle.Dispose()
            FSub.Dispose()
            If Switch Then
                Me.Counter += 2.5
                Switch = False
            Else
                Switch = True
            End If
        End If
    End Sub

    Public Overrides Sub Update(Session As ClassLibrary1.XSession)
        Throw New NotImplementedException()
    End Sub
End Class
