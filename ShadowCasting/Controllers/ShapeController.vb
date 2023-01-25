Imports ClassLibrary1
Public Class ShapeController
    Inherits XBase
    Protected ShapePtr As Shape
    Sub New(ByRef Shape As Shape)
        Me.ShapePtr = Shape
    End Sub
    Public Sub ChangeShapePtr(ByRef ShapeIn As Shape)
        Me.ShapePtr = ShapeIn
    End Sub
    Public Overrides Sub Draw(ByRef g As System.Drawing.Graphics)
        Throw New NotImplementedException()
    End Sub
    Public Overrides Sub Update(Session As ClassLibrary1.XSession)
        Throw New NotImplementedException()
    End Sub
End Class
