﻿'Elliot Heiner
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
    Dim backgroundColor As Color = Color.LightBlue

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub




    Private Sub PictureBox_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox.MouseMove
        'update position

        If e.Button.ToString = "Left" Then
            DrawLine(Me.currentX, Me.currentY, e.X, e.Y)
        End If

        Me.currentX = e.X
        Me.currentY = e.Y
        Me.Text = $"({e.X},{e.Y}) Button:{e.Button}"

    End Sub

    Sub DrawLine(x1 As Integer, y1 As Integer, x2 As Integer, y2 As Integer)
        Dim g As Graphics = PictureBox.CreateGraphics
        Dim pen As New Pen(Me.currentColor) 'Pen(Color.FromArgb(255, 0, 0, 0))
        g.DrawLine(pen, x1, y1, x2, y2)
        pen.Dispose()
        g.Dispose()
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        ShakeErase()
        Dim g As Graphics = PictureBox.CreateGraphics
        g.Clear(Me.backgroundColor)
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

    Private Sub EtchASketchForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox.BackColor = Me.backgroundColor
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

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        ShakeErase()
        Dim g As Graphics = PictureBox.CreateGraphics
        g.Clear(Me.backgroundColor)
        g.Dispose()
    End Sub

    Private Sub SelectColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectColorToolStripMenuItem.Click
        ColorDialog.ShowDialog()
        Me.currentColor = ColorDialog.Color
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class
