Public Class ObjParser
    Public Shared Function FromFile(DirIn As String) As Shape
        If DirIn <> "NULL" Then
            Dim ShapeOut As New Shape
            ShapeOut.GetVertices.AddRange(RetreiveCoreVertices(DirIn))
            ShapeOut.GetTransform.Scale.SetAll(100)
            Return ShapeOut
        Else
            Return DefualtShapes.Cube
        End If
    End Function

    Private Shared Function RetreiveCoreVertices(DirIn As String) As List(Of Vector3)
        Dim R As New List(Of Vector3)
        FileOpen(1, DirIn, OpenMode.Input)
        Do
            Dim Line As String = LineInput(1)
            Dim Split() As String = Line.Split(" ")
            If Split(0) = "v" Then
                If Split.Length <> 4 Then Throw New Exception("Parser only accepts [X,Y,Z] Vertices")
                Dim X As Decimal = Val(Split(1))
                Dim Y As Decimal = Val(Split(2))
                Dim Z As Decimal = Val(Split(3))
                R.Add(New Vector3(X, Y, Z))
            ElseIf Split(0) = "f" Then
            End If
        Loop Until EOF(1)
        FileClose(1)
        Return R
    End Function
End Class
