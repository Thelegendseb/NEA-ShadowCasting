
Public Class PerspectiveShadowCamera
    Inherits ShadowCamera
    Protected LightSources As List(Of LightSource)
    Protected Wall As Wall
    Sub New(ByRef ShapePtr As Shape, ByRef LightSourcePtr As List(Of LightSource), ByRef WallIn As Wall)
        MyBase.New(ShapePtr)
        Me.LightSources = LightSourcePtr
        Me.Wall = WallIn
    End Sub
    Public Overrides Function GetShadowHull() As List(Of Point)

        Dim CState As List(Of Vector3) = Me.ShapePtr.CallState()

        Dim MappedCState As List(Of Vector3) = FormulateRays(CState)

        Dim Mapped2DState As List(Of Point) = ShapeMath.RemoveZComponent(MappedCState)

        Dim Hull As List(Of Point) = GrahamScan.GetCovexHull(Mapped2DState)

        Me.LastShadowAreaCalculated = ShapeMath.ShadowArea(Hull)

        Return Hull

    End Function
    Private Function FormulateRays(CState As List(Of Vector3)) As List(Of Vector3)

        Dim RayList As New List(Of List(Of Ray3D))

        For Each LightSource As LightSource In Me.LightSources
            Dim RayListForList As New List(Of Ray3D)
            For Each Vertex As Vector3 In CState
                Dim Ray As New Ray3D
                Ray.Position = LightSource.GetPosition
                Ray.Direction = New Vector3(Me.ShapePtr.GetTransform.Position.X + Vertex.X - Ray.Position.X,
                                            Me.ShapePtr.GetTransform.Position.Y + Vertex.Y - Ray.Position.Y,
                                            Me.ShapePtr.GetTransform.Position.Z + Vertex.Z - Ray.Position.Z)
                RayListForList.Add(Ray)
            Next
            RayList.Add(RayListForList)
        Next

        ' // Extend each Direction vertex to a given z value

        For i = 0 To Me.LightSources.Count - 1
            Dim LightSource As LightSource = Me.LightSources(i)
            Dim DiffZ As Decimal = Math.Abs(Me.Wall.GetZ - LightSource.GetPosition.Z)
            For Each Ray As Ray3D In RayList(i)
                Dim Multiplier As Decimal = DiffZ / Ray.Direction.Z

                Ray.Direction.X *= Multiplier
                Ray.Direction.Y *= Multiplier
                Ray.Direction.Z *= Multiplier

                Ray.Direction.X -= Me.ShapePtr.GetTransform.Position.X
                Ray.Direction.Y -= Me.ShapePtr.GetTransform.Position.Y
                Ray.Direction.Z -= Me.ShapePtr.GetTransform.Position.Z
            Next
        Next

        ' // Change into correct return type

        Dim R As New List(Of Vector3)

        For i = 0 To Me.LightSources.Count - 1
            For Each Ray As Ray3D In RayList(i)
                R.Add(Ray.Direction)
            Next
        Next
        Return R
    End Function
End Class
