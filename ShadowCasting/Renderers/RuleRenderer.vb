Imports ClassLibrary1
Public Class RuleRenderer
    Inherits XBase
    Private ShapePtr As Shape
    Private CamPtr As ShadowCamera
    Sub New(PtrS As Shape, PtrC As ShadowCamera)
        Me.SetDrawStatus(True)
        Me.ShapePtr = PtrS
        Me.CamPtr = PtrC
    End Sub
    Public Overrides Sub Update(Session As XSession)
        Throw New NotImplementedException()
    End Sub
    Public Sub ChangeShapePtr(ByRef ShapeIn As Shape)
        Me.ShapePtr = ShapeIn
    End Sub
    Public Overrides Sub Draw(ByRef g As Graphics)
        Dim F As New Font(FontFamily.GenericSansSerif, 15, FontStyle.Bold)
        g.DrawString("A: Increase light source X", F, Brushes.IndianRed, 20, 20)
        g.DrawString("D: Decrease light source X", F, Brushes.IndianRed, 20, 50)
        g.DrawString("W: Decrease light source Y", F, Brushes.IndianRed, 20, 80)
        g.DrawString("S: Increase light source Y", F, Brushes.IndianRed, 20, 110)
        g.DrawString("UP ARROW KEY: Decrease light source Z", F, Brushes.IndianRed, 20, 140)
        g.DrawString("DOWN ARROW KEY: Increase light source Z", F, Brushes.IndianRed, 20, 170)
        g.DrawString("LEFT MOUSE DOWN +- R: Rotate Shape", F, Brushes.IndianRed, 20, 200)

        ' ================================================================

        g.DrawString("Shape Rotation => Yaw: " & Math.Round(Me.ShapePtr.GetTransform.Rotation.YawToDegrees), F, Brushes.IndianRed, 20, 300)
        ' g.DrawString("Shape Rotation => Roll: " & Math.Round(Me.ShapePtr.GetTransform.Rotation.RollToDegrees), F, Brushes.IndianRed, 20, 330)
        g.DrawString("Shape Rotation => Roll: " & Math.Round(Me.ShapePtr.GetTransform.Rotation.RollToDegrees), F, Brushes.IndianRed, 20, 330)
        g.DrawString("Shape Rotation => Pitch: " & Math.Round(Me.ShapePtr.GetTransform.Rotation.PitchToDegrees), F, Brushes.IndianRed, 20, 360)

        ' ================================================================

        g.DrawString("NumPad 7: Increase Scale X", F, Brushes.IndianRed, 20, 460)
        g.DrawString("NumPad 9: Decrease Scale X", F, Brushes.IndianRed, 20, 490)
        g.DrawString("NumPad 4: Increase Scale Y", F, Brushes.IndianRed, 20, 520)
        g.DrawString("NumPad 6: Decrease Scale Y", F, Brushes.IndianRed, 20, 550)
        g.DrawString("NumPad 1: Increase Scale Z", F, Brushes.IndianRed, 20, 580)
        g.DrawString("NumPad 3: Decrease Scale Z", F, Brushes.IndianRed, 20, 610)

        ' ================================================================

        F = New Font(FontFamily.GenericSansSerif, F.Size * 2, FontStyle.Bold)
        g.DrawString("Area of Shadow: " & Math.Round(Me.CamPtr.GetLastShadowAreaCalculated / 1000), F, Brushes.WhiteSmoke, 20, 710)

        ' ================================================================

        F.Dispose()
    End Sub
End Class
