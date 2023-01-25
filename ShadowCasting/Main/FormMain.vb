Imports ClassLibrary1
Public Class FormMain
    Private App As XApp
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.App = New Program(Me)
    End Sub
    Private Sub Form1_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        Me.App.Run()
    End Sub
    Private Sub Form1_Closing(sender As System.Object, e As System.EventArgs) Handles MyBase.FormClosing
        Me.App.Halt()
    End Sub
End Class
