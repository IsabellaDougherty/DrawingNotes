Public Class Form1
    Dim currentColor As Color
    Sub testDraw()
        Dim g As Graphics = Me.CreateGraphics
        Dim myPen As Pen = New Pen(Me.currentColor)

        g.DrawLine(myPen, 0, 0, 500, 100)
        myPen.Color = Color.Green
        myPen.Width = 10
        g.DrawEllipse(myPen, 200, 200, 400, 400)
        'g.FillEllipse(mybrush, 300, 300, 350, 350)



        g.Dispose()
        myPen.Dispose()
    End Sub
    Sub DrawLineSegment(x1%, y1%, x2%, y2%)
        Dim g As Graphics = PictureBox1.CreateGraphics
        Dim myPen = New Pen(Me.currentColor)

        g.DrawLine(myPen, x1, y1, x2, y2)

        myPen.Dispose()
        g.Dispose()
    End Sub

    Sub UpdateColor()
        ColorDialog1.ShowDialog()
        Me.currentColor = ColorDialog1.Color
    End Sub
    Sub Clear()
        PictureBox1.Refresh()
        'PictureBox.BackColor = Color.White
    End Sub

    ' event handlers

    Private Sub GraphicsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        currentColor = Color.Black
    End Sub

    Private Sub GraphicsForm_Click(sender As Object, e As EventArgs) Handles Me.Click
        'testDraw()
    End Sub

    Private Sub PictureBox_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove, PictureBox1.MouseDown
        Static lastX%, lastY%
        Select Case e.Button.ToString
            Case "Left"
                DrawLineSegment(lastX, lastY, e.X, e.Y)
            Case "Middle"
                UpdateColor()
        End Select
        Me.Text = $"({e.X},{e.Y}) button: {e.Button.ToString} Color: {Me.currentColor.ToString}"
        lastX = e.X
        lastY = e.Y
    End Sub

    Private Sub ChooseColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChooseColorToolStripMenuItem.Click
        UpdateColor()
    End Sub
    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        Clear()
    End Sub
End Class
