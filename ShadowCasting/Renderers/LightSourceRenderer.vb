Imports ClassLibrary1
Public Class LightSourceRenderer
    Inherits XBase
    Private LightSourcePtr As List(Of LightSource)
    Sub New(ByRef Ptr As List(Of LightSource))
        Me.LightSourcePtr = Ptr
        Me.SetDrawStatus(True)
    End Sub
    Public Overrides Sub Update(Session As XSession)
        Throw New NotImplementedException()
    End Sub

    Public Overrides Sub Draw(ByRef g As Graphics)

        Dim W2 As Integer = g.VisibleClipBounds.Width / 2
        Dim H2 As Integer = g.VisibleClipBounds.Height / 2

        For Each LightSource As LightSource In Me.LightSourcePtr
            Dim LightPos As Vector3 = LightSource.GetPosition
            Dim ZAbs As Integer = Math.Abs(LightPos.Z) / 30
            Dim ZAbsInverse As Integer = 1 / ZAbs
            Dim ZAbs2 As Integer = ZAbs / 2
            g.FillEllipse(Brushes.Beige, CInt(W2 - LightPos.X - ZAbs2), CInt(H2 - LightPos.Y - ZAbs2), CInt(ZAbs), CInt(ZAbs))
        Next

    End Sub
End Class
