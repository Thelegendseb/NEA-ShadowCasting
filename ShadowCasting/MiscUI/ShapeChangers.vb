Imports ClassLibrary1
Public Class ShapeChangers
    Public Event ShapeChanged(NewShape As String)

    ' // 6 Buttons -------

    Private WithEvents ToCube As Button
    Private WithEvents ToOctahedron As Button
    Private WithEvents ToPyramid As Button
    Private WithEvents ToHexagonalPrism As Button
    Private WithEvents ToCylinder As Button
    Private WithEvents ToIcosahedron As Button
    Private WithEvents ToRegularPrism As Button
    Private WithEvents ToOther As Button

    Private TT As ToolTip

    ' // 6 Buttons -------

    Sub New(Ptr As XWindow)
        InitializeButtons()
        InitializeToolTip()
        AddHandlers()
        PlaceButtons(Ptr)
    End Sub
    Private Sub InitializeButtons()
        Me.ToCube = New Button
        Me.ToOctahedron = New Button
        Me.ToPyramid = New Button
        Me.ToHexagonalPrism = New Button
        Me.ToCylinder = New Button
        Me.ToIcosahedron = New Button
        Me.ToRegularPrism = New Button
        Me.ToOther = New Button

        Me.ToCube.Name = "Cube"
        Me.ToOctahedron.Name = "Octahedron"
        Me.ToPyramid.Name = "Pyramid"
        Me.ToHexagonalPrism.Name = "HexagonalPrism"
        Me.ToCylinder.Name = "Cylinder"
        Me.ToIcosahedron.Name = "Icosahedron"
        Me.ToRegularPrism.Name = "RegularPrism"
        Me.ToOther.Name = "Other"

        Dim BtnSize As Size = New Size(100, 95)
        Me.ToCube.Size = BtnSize
        Me.ToOctahedron.Size = BtnSize
        Me.ToPyramid.Size = BtnSize
        Me.ToHexagonalPrism.Size = BtnSize
        Me.ToCylinder.Size = BtnSize
        Me.ToIcosahedron.Size = BtnSize
        Me.ToRegularPrism.Size = BtnSize
        Me.ToOther.Size = BtnSize

        Dim left As Integer = FormMain.ClientSize.Width - 110
        Me.ToCube.Left = left
        Me.ToOctahedron.Left = left
        Me.ToPyramid.Left = left
        Me.ToHexagonalPrism.Left = left
        Me.ToCylinder.Left = left
        Me.ToIcosahedron.Left = left
        Me.ToRegularPrism.Left = left
        Me.ToOther.Left = left

        Me.ToCube.Top = 10
        Me.ToOctahedron.Top = 10 + 103
        Me.ToPyramid.Top = 10 + 103 + 103
        Me.ToHexagonalPrism.Top = 10 + 103 + 103 + 103
        Me.ToCylinder.Top = 10 + 103 + 103 + 103 + 103
        Me.ToIcosahedron.Top = 10 + 103 + 103 + 103 + 103 + 103
        Me.ToRegularPrism.Top = 10 + 103 + 103 + 103 + 103 + 103 + 103
        Me.ToOther.Top = 10 + 103 + 103 + 103 + 103 + 103 + 103 + 103

        Me.ToCube.BackgroundImageLayout = ImageLayout.Stretch
        Me.ToOctahedron.BackgroundImageLayout = ImageLayout.Stretch
        Me.ToPyramid.BackgroundImageLayout = ImageLayout.Stretch
        Me.ToHexagonalPrism.BackgroundImageLayout = ImageLayout.Stretch
        Me.ToCylinder.BackgroundImageLayout = ImageLayout.Stretch
        Me.ToIcosahedron.BackgroundImageLayout = ImageLayout.Stretch
        Me.ToRegularPrism.BackgroundImageLayout = ImageLayout.Stretch
        Me.ToOther.BackgroundImageLayout = ImageLayout.Stretch

        Me.ToCube.BackgroundImage = My.Resources.Cube_Thumb
        Me.ToOctahedron.BackgroundImage = My.Resources.Octahedron_Thumb
        Me.ToPyramid.BackgroundImage = My.Resources.Pyramid_Thumb
        Me.ToHexagonalPrism.BackgroundImage = My.Resources.HexagonalPrism_Thumb
        Me.ToCylinder.BackgroundImage = My.Resources.Cylinder_Thumb
        Me.ToIcosahedron.BackgroundImage = My.Resources.Icosahedron_Thumb
        Me.ToRegularPrism.BackgroundImage = My.Resources.RegularPrism_Thumb
        Me.ToOther.BackgroundImage = My.Resources.FromFile_Thumb
    End Sub
    Private Sub AddHandlers()
        AddHandler Me.ToCube.MouseClick, AddressOf Me.TriggerShapeChanged
        AddHandler Me.ToOctahedron.MouseClick, AddressOf Me.TriggerShapeChanged
        AddHandler Me.ToPyramid.MouseClick, AddressOf Me.TriggerShapeChanged
        AddHandler Me.ToHexagonalPrism.MouseClick, AddressOf Me.TriggerShapeChanged
        AddHandler Me.ToCylinder.MouseClick, AddressOf Me.TriggerShapeChanged
        AddHandler Me.ToIcosahedron.MouseClick, AddressOf Me.TriggerShapeChanged
        AddHandler Me.ToRegularPrism.MouseClick, AddressOf Me.TriggerShapeChanged
        AddHandler Me.ToOther.MouseClick, AddressOf Me.TriggerShapeChanged
    End Sub
    Private Sub TriggerShapeChanged(sender As Button, e As MouseEventArgs)
        RaiseEvent ShapeChanged(sender.Name)
    End Sub
    Private Sub PlaceButtons(Window As XWindow)
        Window.Controls.Add(Me.ToCube)
        Window.Controls.Add(Me.ToOctahedron)
        Window.Controls.Add(Me.ToPyramid)
        Window.Controls.Add(Me.ToHexagonalPrism)
        Window.Controls.Add(Me.ToCylinder)
        Window.Controls.Add(Me.ToIcosahedron)
        Window.Controls.Add(Me.ToRegularPrism)
        Window.Controls.Add(Me.ToOther)
    End Sub
    Private Sub InitializeToolTip()
        Me.TT = New ToolTip
        Me.TT.SetToolTip(Me.ToCube, "Cube")
        Me.TT.SetToolTip(Me.ToOctahedron, "Octahedron")
        Me.TT.SetToolTip(Me.ToPyramid, "Pyramid")
        Me.TT.SetToolTip(Me.ToHexagonalPrism, "Hexagonal Prism")
        Me.TT.SetToolTip(Me.ToCylinder, "Cylinder")
        Me.TT.SetToolTip(Me.ToIcosahedron, "Icosahedron")
        Me.TT.SetToolTip(Me.ToRegularPrism, "Choose an amount of sides for a regular prism")
        Me.TT.SetToolTip(Me.ToOther, "Load a .OBJ file")
    End Sub
End Class
