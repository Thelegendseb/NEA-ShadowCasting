Public Class Wall
    Private Z As Decimal
    Sub New(SetZ As Decimal)
        Me.Z = SetZ
    End Sub
    Public Sub SetZ(Val As Decimal)
        Me.Z = Val
    End Sub
    Public Function GetZ() As Decimal
        Return Me.Z
    End Function
End Class
