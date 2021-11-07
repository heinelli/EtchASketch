'Elliot Heiner
'RCET 0265
'Fall 2021
'Etch a Sketch
'https://github.com/heinelli/EtchASketch.git

Option Strict On
Option Explicit On
Public Class EtchASketchForm
    Dim currentX As Integer = 0
    Dim currentY As Integer = 0
    Dim currentColor As Color = Color.Black
    Dim backgroundColor As Color = Color.LightGray

    Private Sub EtchASketchForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox.BackColor = Me.backgroundColor
    End Sub

    Private Sub PictureBox_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox.MouseMove
        If e.Button.ToString = "Left" Then
            DrawLine(Me.currentX, Me.currentY, e.X, e.Y)
        End If
        Me.currentX = e.X
        Me.currentY = e.Y
        Me.Text = $"({e.X},{e.Y}) Button:{e.Button}"
    End Sub

    Sub DrawLine(x1 As Integer, y1 As Integer, x2 As Integer, y2 As Integer)
        Dim g As Graphics = PictureBox.CreateGraphics
        Dim pen As New Pen(Me.currentColor)
        g.DrawLine(pen, x1, y1, x2, y2)
        pen.Dispose()
        g.Dispose()
    End Sub

    Private Sub PictureBox_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox.MouseDown
        If e.Button.ToString = "Middle" Then
            ColorDialog.ShowDialog()
            Me.currentColor = ColorDialog.Color
        End If
    End Sub

    Private Sub SelectColorButton_Click(sender As Object, e As EventArgs) Handles SelectColorButton.Click
        ColorDialog.ShowDialog()
        Me.currentColor = ColorDialog.Color
    End Sub

    Private Sub SelectColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectColorToolStripMenuItem.Click
        ColorDialog.ShowDialog()
        Me.currentColor = ColorDialog.Color
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        ShakeErase()
        Dim g As Graphics = PictureBox.CreateGraphics
        g.Clear(Me.backgroundColor)
        g.Dispose()
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        ShakeErase()
        Dim g As Graphics = PictureBox.CreateGraphics
        g.Clear(Me.backgroundColor)
        g.Dispose()
    End Sub

    Sub ShakeErase()
        Dim offset As Integer = 50
        For i = 1 To 16
            offset *= -1
            Me.Top += offset
            Me.Left += offset
            System.Threading.Thread.Sleep(150)
        Next
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("Welcome to the Etcha-A-Sketch simulator!
Draw on the gray box by pressing the left mouse button.
Select a pen color by pressing the SelectColor button or by clicking the center mouse button.
Erase the image by pressing the Clear button.
Have fun!")
    End Sub

    Private Sub DrawWaveformsButton_Click(sender As Object, e As EventArgs) Handles DrawWaveformsButton.Click
        Dim g As Graphics = PictureBox.CreateGraphics
        Dim pen As New Pen(Me.currentColor)
        Dim previousX As Integer = 0
        Dim previousY As Integer = 209
        Dim pi As Double = 3.14159265
        Dim grid As Integer = 40

        pen.Width = 2.0F
        pen.Color = Color.Black
        For i = 0 To 8
            g.DrawLine(pen, grid, 0, grid, 400)
            g.DrawLine(pen, 0, grid, 400, grid)
            grid += 40
        Next

        pen.Color = Color.Red
        pen.Width = 4.0F
        currentX = 1
        For i = 0 To 399
            currentY = 200 + (-1 * CInt(200 * Math.Sin(2 * pi * 0.005 * currentX)))
            g.DrawLine(pen, previousX, previousY, currentX, currentY)
            previousX = currentX
            previousY = currentY
            currentX += 1
        Next

        previousX = 0
        previousY = 200
        currentX = 1
        pen.Color = Color.White
        For i = 0 To 399
            currentY = 200 + CInt(200 * Math.Cos(2 * pi * 0.005 * currentX))
            g.DrawLine(pen, previousX, previousY, currentX, currentY)
            previousX = currentX
            previousY = currentY
            currentX += 1
        Next

        previousX = 0
        previousY = 200
        currentX = 1
        pen.Color = Color.Orange
        For i = 0 To 399
            currentY = 200 + CInt(200 * Math.Sin(2 * pi * 0.005 * currentX))
            g.DrawLine(pen, previousX, previousY, currentX, currentY)
            previousX = currentX
            previousY = currentY
            currentX += 1
        Next




        pen.Dispose()
        g.Dispose()
    End Sub
End Class
