Imports ClassLibrary1
Public Class ShapeScaleController
    Inherits ShapeController
    Sub New(ByRef Shape As Shape)
        MyBase.New(Shape)
        Me.SetUpdateStatus(True)
    End Sub
    Public Overrides Sub Update(Session As ClassLibrary1.XSession)
        If Session.KeyManager.IsDown(Keys.NumPad7) Then
            Me.ShapePtr.GetTransform.Scale.X += 5
        End If
        If Session.KeyManager.IsDown(Keys.NumPad9) Then
            Me.ShapePtr.GetTransform.Scale.X += -5
        End If
        If Session.KeyManager.IsDown(Keys.NumPad4) Then
            Me.ShapePtr.GetTransform.Scale.Y += 5
        End If
        If Session.KeyManager.IsDown(Keys.NumPad6) Then
            Me.ShapePtr.GetTransform.Scale.Y += -5
        End If
        If Session.KeyManager.IsDown(Keys.NumPad1) Then
            Me.ShapePtr.GetTransform.Scale.Z += 5
        End If
        If Session.KeyManager.IsDown(Keys.NumPad3) Then
            Me.ShapePtr.GetTransform.Scale.Z += -5
        End If
    End Sub
End Class
