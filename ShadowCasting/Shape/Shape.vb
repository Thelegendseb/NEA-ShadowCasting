Imports WindowsApplication1.ShapeMath
Public Class Shape
    Protected Transform As Transform
    Protected Vertices As List(Of Vector3)
    Protected Faces As List(Of Face)
    Sub New()
        Me.InitializeAttributes()
    End Sub
    Private Sub InitializeAttributes()
        Me.Transform = New Transform
        Me.Vertices = New List(Of Vector3)
        Me.Faces = New List(Of Face)
    End Sub
    Public Function CallState() As List(Of Vector3)
        Dim CurrentState As New List(Of Vector3)

        ' // Rotate each vertex by the transform and return the new list of points

        For Each Vertex As Vector3 In Me.Vertices

            ' // Apply scale from transform

            Dim StateVertex As New Vector3(Vertex.X * Me.Transform.Scale.X, Vertex.Y * Me.Transform.Scale.Y, Vertex.Z * Me.Transform.Scale.Z)

            ' Rotation Matrix Multiplication

            StateVertex = Matrix.Multiply(MatrixType("X", Me.Transform.Rotation.Pitch), StateVertex)
            StateVertex = Matrix.Multiply(MatrixType("Y", Me.Transform.Rotation.Yaw), StateVertex)
            StateVertex = Matrix.Multiply(MatrixType("Z", Me.Transform.Rotation.Roll), StateVertex)

            ' Projection Matrix Multiplication

            Dim ProjZ As Single = 900 / (700 + StateVertex.Z - (Me.Transform.Position.Z * 3))

            Dim ProjMatrix(,) As Single = {{ProjZ, 0, 0},
                                           {0, ProjZ, 0}}

            StateVertex = Matrix.Multiply(ProjMatrix, StateVertex)

            ' // Add to CurrentState List

            CurrentState.Add(StateVertex)
        Next

        Return CurrentState
    End Function
    '=============================
    Public Function GetTransform() As Transform
        Return Me.Transform
    End Function
    Public Function GetVertices() As List(Of Vector3)
        Return Me.Vertices
    End Function
    Public Function GetFaces() As List(Of Face)
        Return Me.Faces
    End Function
End Class
