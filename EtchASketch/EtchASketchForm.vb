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
    Dim penColor As Color = Color.Black
    Dim backgroundColor As Color = Color.LightGray

    Private Sub EtchASketchForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load form with gray background
        PictureBox.BackColor = Me.backgroundColor
    End Sub

    Private Sub PictureBox_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox.MouseMove
        'Constantly check coordinates and call DrawLine function if left mouse button is clicked
        If e.Button.ToString = "Left" Then
            DrawLine(Me.currentX, Me.currentY, e.X, e.Y)
        End If
        Me.currentX = e.X
        Me.currentY = e.Y
    End Sub

    Sub DrawLine(x1 As Integer, y1 As Integer, x2 As Integer, y2 As Integer)
        'Draw line from previous coordinate to current coordinate
        Dim g As Graphics = PictureBox.CreateGraphics
        Dim pen As New Pen(Me.penColor)
        g.DrawLine(pen, x1, y1, x2, y2)
        pen.Dispose()
        g.Dispose()
    End Sub

    Private Sub PictureBox_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox.MouseDown
        'Choose pen color by clicking middle mouse button
        If e.Button.ToString = "Middle" Then
            ColorDialog.ShowDialog()
            Me.penColor = ColorDialog.Color
        End If
    End Sub

    Private Sub SelectColorButton_Click(sender As Object, e As EventArgs) Handles SelectColorButton.Click,
                                                                                  SelectColorToolStripMenuItem.Click
        ColorDialog.ShowDialog()
        Me.penColor = ColorDialog.Color
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click,
                                                                            ClearToolStripMenuItem.Click
        ShakeErase()
        Dim g As Graphics = PictureBox.CreateGraphics
        g.Clear(Me.backgroundColor)
        g.Dispose()
    End Sub

    Sub ShakeErase()
        'Shake display and clear all drawing data
        Dim offset As Integer = 50
        For i = 1 To 16
            offset *= -1
            Me.Top += offset
            Me.Left += offset
            System.Threading.Thread.Sleep(150)
        Next
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click,
                                                                           ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        'Display message to give user general instructions
        MsgBox("Welcome to the Etcha-A-Sketch simulator!
Draw on the gray box by pressing the left mouse button.
Select a pen color by pressing the SelectColor button or by clicking the center mouse button.
Erase the image by pressing the Clear button.
Have fun!")
    End Sub

    Private Sub DrawWaveformsButton_Click(sender As Object, e As EventArgs) Handles DrawWaveformsButton.Click,
                                                                                    DrawWaveformsToolStripMenuItem.Click
        Dim g As Graphics = PictureBox.CreateGraphics
        Dim pen As New Pen(Me.penColor)
        Dim previousX As Integer = 0
        Dim previousY As Integer = 209
        Dim pi As Double = 3.14159265
        Dim gridSpace As Integer = 40

        'Draw 10x10 grid in black
        pen.Width = 2.0F
        pen.Color = Color.Black
        For i = 0 To 8
            g.DrawLine(pen, gridSpace, 0, gridSpace, 400)
            g.DrawLine(pen, 0, gridSpace, 400, gridSpace)
            gridSpace += 40
        Next

        'Draw single cycle sine wave in red
        pen.Color = Color.Red
        pen.Width = 4.0F
        currentX = 1
        For i = 0 To 399
            currentY = 200 + CInt(200 * Math.Sin(2 * pi * 0.0025 * currentX))
            g.DrawLine(pen, previousX, previousY, currentX, currentY)
            previousX = currentX
            previousY = currentY
            currentX += 1
        Next

        'Draw single cycle cosine wave in white
        previousX = 0
        previousY = 400
        currentX = 1
        pen.Color = Color.White
        For i = 0 To 399
            currentY = 200 + CInt(200 * Math.Cos(2 * pi * 0.0025 * currentX))
            g.DrawLine(pen, previousX, previousY, currentX, currentY)
            previousX = currentX
            previousY = currentY
            currentX += 1
        Next

        'Draw single cycle tangent wave in orange
        previousX = 0
        previousY = 200
        currentX = 1
        pen.Color = Color.Orange
        For i = 0 To 399
            currentY = 200 + (-1 * (CInt(200 * Math.Sin(2 * pi * 0.0025 * currentX))))
            g.DrawLine(pen, previousX, previousY, currentX, currentY)
            previousX = currentX
            previousY = currentY
            currentX += 1
        Next
        pen.Dispose()
        g.Dispose()
    End Sub
End Class
