Public Class Vector3
    Public X, Y, Z As Decimal
    Sub New()
        Me.X = 0
        Me.Y = 0
        Me.Z = 0
    End Sub
    Sub New(Xin As Decimal, yin As Decimal, zin As Decimal)
        Me.X = Xin
        Me.Y = yin
        Me.Z = zin
    End Sub
    Public Shared Function Zero() As Vector3
        Return New Vector3(0, 0, 0)
    End Function
    Public Shared Operator +(A As Vector3, B As Vector3) As Vector3
        Return New Vector3(A.X + B.X, A.Y + B.Y, A.Z + B.Z)
    End Operator
    Public Shared Operator -(A As Vector3, B As Vector3) As Vector3
        Return New Vector3(A.X - B.X, A.Y - B.Y, A.Z - B.Z)
    End Operator
    Public Shared Operator *(A As Vector3, B As Vector3) As Vector3
        Return New Vector3(A.X * B.X, A.Y * B.Y, A.Z * B.Z)
    End Operator
    Public Shared Operator /(A As Vector3, B As Vector3) As Vector3
        Return New Vector3(A.X / B.X, A.Y / B.Y, A.Z / B.Z)
    End Operator
End Class
