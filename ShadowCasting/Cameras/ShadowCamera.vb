Public MustInherit Class ShadowCamera
    Protected ShapePtr As Shape
    Protected Hull As List(Of Point)
    Protected LastShadowAreaCalculated As Double
    Sub New(ShapePtr As Shape)
        Me.ShapePtr = ShapePtr
        Me.Hull = New List(Of Point)
    End Sub
    Public Sub ChangeShapePtr(ByRef ShapeIn As Shape)
        Me.ShapePtr = ShapeIn
    End Sub
    Public Function GetLastShadowAreaCalculated() As Double
        Return Me.LastShadowAreaCalculated
    End Function
    Public MustOverride Function GetShadowHull() As List(Of Point)
End Class
