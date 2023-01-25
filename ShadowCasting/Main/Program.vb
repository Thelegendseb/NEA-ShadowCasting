Imports ClassLibrary1

Public Class Program
    Inherits XApp

    Private Shape As Shape
    Private Camera As ShadowCamera
    Private Lights As List(Of LightSource)
    Private Wall As Wall

    Private RotationController As ShapeRotationController
    Private ScaleController As ShapeScaleController

    Private Shadow_r As ShadowRenderer
    Private Shape_r As ShapeRenderer
    Private LightSource_r As LightSourceRenderer
    Private Rule_r As RuleRenderer

    Private ShapeChanger_ As ShapeChangers

    Sub New(FormIn As Form)
        MyBase.New(FormIn)
        FormIn.Text = "Convex Polyhedron Shadow Visualizer"
        Me.Session.Window.SetClearColor(Color.FromArgb(10, 20, 30))

        ' // Initialize Attributes

        Me.Lights = New List(Of LightSource)

        Me.Lights.Add(New OmniDirectionalLightSource(New Vector3(0, 0, -600)))

        Me.Wall = New Wall(300)

        Me.Shape = DefualtShapes.Cube

        Me.Camera = New PerspectiveShadowCamera(Me.Shape, Me.Lights, Me.Wall)

        ' // Add Controllers

        Me.RotationController = New ShapeRotationController(Me.Shape, Me.Session.Window)
        Me.ScaleController = New ShapeScaleController(Me.Shape)
        Me.Session.AddObj(Me.RotationController)
        Me.Session.AddObj(Me.ScaleController)

        ' // Add Renderers

        Me.Shadow_r = New ShadowRenderer(Me.Camera)
        Me.Shape_r = New ShapeRenderer(Me.Shape)
        Me.LightSource_r = New LightSourceRenderer(Me.Lights)
        Me.Rule_r = New RuleRenderer(Me.Shape, Me.Camera)
        Me.Session.AddObj(Me.Shadow_r)
        Me.Session.AddObj(Me.Shape_r)
        Me.Session.AddObj(Me.LightSource_r)
        Me.Session.AddObj(Me.Rule_r)

        Me.Session.AddObj(New SplashScreen)

        ' // Initialize Final Attribute (UI)

        Me.ShapeChanger_ = New ShapeChangers(Me.Session.Window)

        ' // Add Handler from Shape Changer

        AddHandler Me.ShapeChanger_.ShapeChanged, AddressOf Me.ShapeChanged

        ' // Finalize

        Me.Session.Window.Select()
        Me.Session.QueueRelease()

    End Sub
    Private Sub ShapeChanged(NewShape As String)

        ' // Change shape in relation to NewShape as String

        Select Case NewShape
            Case "Cube"
                Me.ChangeShape(DefualtShapes.Cube)
            Case "Octahedron"
                Me.ChangeShape(DefualtShapes.Octahedron)
            Case "Pyramid"
                Me.ChangeShape(DefualtShapes.Pyramid)
            Case "HexagonalPrism"
                Me.ChangeShape(DefualtShapes.HexagonalPrism)
            Case "Cylinder"
                Me.ChangeShape(DefualtShapes.Cylinder)
            Case "Icosahedron"
                Me.ChangeShape(DefualtShapes.Icosahedron)
            Case "RegularPrism"
                Try
                    Dim value As Integer = CInt(InputBox("Enter a number of sides to create an 'N' - sided prism."))
                    Me.ChangeShape(DefualtShapes.N_SidedRegularPrism(value))
                Catch ex As Exception
                    MsgBox("Invalid Input")
                End Try
            Case "Other"
                Me.ChangeShape(ObjParser.FromFile(ObjSelector.SelectFromFileExplorer()))
        End Select
    End Sub
    Public Overrides Sub UpdateOccured()
        InputChecks()
        ' // Check the shapes rotation and keep in bounds of 0 < angle < 2 * Math.PI
        Me.Shape.GetTransform.Rotation.LetClampAll()
    End Sub
    Private Sub ChangeShape(NewShape As Shape)
        Me.Shape = Nothing
        Me.Shape = NewShape

        Me.Camera.ChangeShapePtr(Me.Shape)

        Me.RotationController.ChangeShapePtr(Me.Shape)
        Me.ScaleController.ChangeShapePtr(Me.Shape)

        Me.Shape_r.ChangeShapePtr(Me.Shape)
        Me.Rule_r.ChangeShapePtr(Me.Shape)

        ' // - - - - - - - -

        Me.RotationController.Stop()

        Me.Session.Window.Select()
    End Sub
    Private Sub InputChecks()
        If Me.Session.KeyManager.IsDown(Keys.A) Then
            Me.Lights(0).MoveLeftBy(-5)
        End If
        If Me.Session.KeyManager.IsDown(Keys.D) Then
            Me.Lights(0).MoveRightBy(-5)
        End If
        If Me.Session.KeyManager.IsDown(Keys.W) Then
            Me.Lights(0).MoveUpBy(-5)
        End If
        If Me.Session.KeyManager.IsDown(Keys.S) Then
            Me.Lights(0).MoveDownBy(-5)
        End If
        If Me.Session.KeyManager.IsDown(Keys.Up) Then
            Me.Lights(0).MoveForwardBy(-10)
        End If
        If Me.Session.KeyManager.IsDown(Keys.Down) Then
            Me.Lights(0).MoveBackwardBy(-10)
        End If
    End Sub
    Public Overrides Sub KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        MyBase.KeyUp(sender, e)
        Me.RotationController.KeyUpHandle(sender, e)
    End Sub
    Public Overrides Sub KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        MyBase.KeyDown(sender, e)
        Me.RotationController.KeyDownHandle(sender, e)
    End Sub
End Class

