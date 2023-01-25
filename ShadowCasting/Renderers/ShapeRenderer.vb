Imports ClassLibrary1
Public Class ShapeRenderer
    Inherits XBase
    Private ShapePtr As Shape
    Sub New(ByRef Ptr As Shape)
        Me.ShapePtr = Ptr
        Me.SetDrawStatus(True)
    End Sub
    Public Overrides Sub Update(ByVal Session As XSession)
        Throw New NotImplementedException()
    End Sub

    Public Overrides Sub Draw(ByRef g As Graphics)

        Dim W2 As Integer = g.VisibleClipBounds.Width / 2
        Dim H2 As Integer = g.VisibleClipBounds.Height / 2

        Dim CState As List(Of Vector3) = Me.ShapePtr.CallState

        Dim CStateDisplaced As New List(Of Vector3)

        For Each Vertex As Vector3 In CState
            CStateDisplaced.Add(New Vector3(W2 - Vertex.X, H2 - Vertex.Y, Vertex.Z))
        Next
        CState.Clear()

        Dim CState2D As List(Of Point) = ShapeMath.RemoveZComponent(CStateDisplaced)

        Dim P As New Pen(Brushes.AntiqueWhite, 8)

        If Me.ShapePtr.GetFaces.Count = 0 Then
            CStateDisplaced = CStateDisplaced.OrderBy(Function(V) V.Z).Reverse.ToList
            DrawAllConnected(g, CStateDisplaced)
        Else
            DrawFaces(g, CStateDisplaced)
        End If

        P.Dispose()

    End Sub
    Public Sub ChangeShapePtr(ByRef ShapeIn As Shape)
        Me.ShapePtr = ShapeIn
    End Sub
    Private Sub DrawFaces(ByRef g As Graphics, ByVal CStateDisplaced As List(Of Vector3))
        Dim P As New Pen(Brushes.AntiqueWhite, 8)
        For Each Face As Face In Me.ShapePtr.GetFaces
            For i = 0 To Face.VertexIndexs.Length - 2
                Dim Vertex As Vector3 = CStateDisplaced(Face.VertexIndexs(i))
                Dim OtherVertex As Vector3 = CStateDisplaced(Face.VertexIndexs(i + 1))
                P.Color = GetColorOfLine(Vertex, OtherVertex)
                g.DrawLine(P, CInt(Vertex.X), CInt(Vertex.Y), CInt(OtherVertex.X), CInt(OtherVertex.Y))
            Next
            Dim EndVertex As Vector3 = CStateDisplaced(Face.VertexIndexs(0))
            Dim EndOtherVertex As Vector3 = CStateDisplaced(Face.VertexIndexs(Face.VertexIndexs.Length - 1))
            P.Color = GetColorOfLine(EndVertex, EndOtherVertex)
            g.DrawLine(P, CInt(EndVertex.X), CInt(EndVertex.Y), CInt(EndOtherVertex.X), CInt(EndOtherVertex.Y))
        Next
        P.Dispose()
    End Sub
    Private Sub DrawAllConnected(ByRef g As Graphics, ByVal CStateDisplaced As List(Of Vector3))
        Dim P As New Pen(Brushes.AntiqueWhite, 8)
        For Each Vertex As Vector3 In CStateDisplaced
            For Each OtherVertex As Vector3 In CStateDisplaced
                If Not Vertex.Equals(OtherVertex) Then
                    P.Color = GetColorOfLine(Vertex, OtherVertex)
                    g.DrawLine(P, CInt(Vertex.X), CInt(Vertex.Y), CInt(OtherVertex.X), CInt(OtherVertex.Y))
                End If
            Next
        Next
        P.Dispose()
    End Sub
    Private Function GetColorOfLine(ByVal Vertex As Vector3, ByVal OtherVertex As Vector3) As Color
        Dim C As Integer = XMath.Map((Vertex.Z + OtherVertex.Z) / 2, -100, 100, 0, 255)
        If C < 0 Then C = 0
        If C > 255 Then C = 255
        Return Color.FromArgb(0, C, 255)
    End Function
End Class
