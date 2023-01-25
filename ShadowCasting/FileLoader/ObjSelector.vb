Public Class ObjSelector
    Public Shared Function SelectFromFileExplorer() As String
        Dim FD As New OpenFileDialog
        FD.Filter = "obj files (*.obj)|*.obj"
        If FD.ShowDialog = DialogResult.OK Then
            Return FD.FileName
        Else
            MsgBox("No File Selected. Loading Defualt Shape")
            Return "NULL"
        End If
    End Function
End Class
