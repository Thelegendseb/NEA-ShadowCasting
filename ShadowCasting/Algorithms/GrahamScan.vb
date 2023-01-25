Public Class GrahamScan
    Public Shared Function GetCovexHull(Points As List(Of Point)) As List(Of Point)

        Dim HullPoints As New List(Of Point)

        'Return object for this function

        '============

        ' // -- Graham Scan Convex Hull algorithm--

        '============

        ' // Sort by Y value

        Points = Points.OrderBy(Function(pt As Point) pt.Y).ToList()

        ' // Get PointZero

        Dim PointZero As Point = GetPointZero(Points)

        ' // Sort by polar angle in counterclockwise order around PointZero

        Points = Points.OrderBy(Function(pt As Point) Math.Atan2(pt.Y - PointZero.Y, pt.X - PointZero.X)).ToList

        ' // Begin algorithm and obtain hull points

        While Points.Count > 0
            RunAlgorithm(Points, HullPoints)
        End While

        ' // Reorder Hull for polygon to be drawn correctly

        HullPoints = HullPoints.OrderBy(Function(pt As Point) Math.Atan2(pt.Y - PointZero.Y, pt.X - PointZero.X)).ToList

        Return HullPoints
    End Function
    Private Shared Sub RunAlgorithm(ByRef Points As List(Of Point), HullPoints As List(Of Point))

        If Points.Count > 0 Then
            Dim TopPoint As Point = Points(0)
            If HullPoints.Count <= 1 Then
                HullPoints.Add(TopPoint)
                Points.RemoveAt(0)
            Else
                Dim BackPoint1 As Point = HullPoints(HullPoints.Count - 1)
                Dim BackPoint2 As Point = HullPoints(HullPoints.Count - 2)

                Dim dir1 As New Point(BackPoint1.X - BackPoint2.X, BackPoint1.Y - BackPoint2.Y)
                Dim dir2 As New Point(TopPoint.X - BackPoint1.X, TopPoint.Y - BackPoint1.Y)

                Dim Cross As Decimal = CrossProduct_Z(dir1, dir2)

                If Cross < 0 Then
                    HullPoints.RemoveAt(HullPoints.Count - 1)
                Else
                    HullPoints.Add(TopPoint)
                    Points.RemoveAt(0)
                End If

            End If
        End If

    End Sub
    '========================================
    Private Shared Function CrossProduct_Z(A As Point, B As Point) As Decimal
        Return A.X * B.Y - A.Y * B.X
    End Function
    Private Shared Function GetPointZero(PointList As List(Of Point)) As Point
        Dim temp As Point
        For Each Val As Point In PointList
            If Val.Y > temp.Y Then
                temp = Val
            ElseIf Val.Y = temp.Y Then
                If Val.X < temp.X Then
                    temp = Val
                End If
            End If
        Next
        Return temp
    End Function
End Class
