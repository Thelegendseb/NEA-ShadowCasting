Public Class Transform

    Public Position As Vector3
    ' // A 3D point representing the centre of a shape

    Public Rotation As RotationComponent
    ' // An object representing the rotation of a shape

    Public Scale As ScaleComponent
    ' // An object representing the scale of a shape
    Sub New()
        ' // Initialize Attributes

        Me.Position = Vector3.Zero
        Me.Rotation = New RotationComponent
        Me.Scale = New ScaleComponent
    End Sub

End Class
