Public Class LightSource
    Protected Position As Vector3
    Sub New()
        Me.Position = Vector3.Zero
    End Sub
    Sub New(Pos As Vector3)
        Me.Position = Pos
    End Sub
    Public Function GetPosition() As Vector3
        Return Me.Position
    End Function
    Public Sub MoveForwardBy(val As Decimal)
        Me.Position.Z += val
    End Sub
    Public Sub MoveBackwardBy(val As Decimal)
        Me.Position.Z -= val
    End Sub
    Public Sub MoveLeftBy(val As Decimal)
        Me.Position.X -= val
    End Sub
    Public Sub MoveRightBy(val As Decimal)
        Me.Position.X += val
    End Sub
    Public Sub MoveUpBy(val As Decimal)
        Me.Position.Y -= val
    End Sub
    Public Sub MoveDownBy(val As Decimal)
        Me.Position.Y += val
    End Sub
End Class
