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
    Dim mainPen As Pen
    Dim currentColor As Color

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub



    Sub Sketch()
        Dim pictureGraphics As Graphics = Me.CreateGraphics
        Static previousX As Integer
        Static previousY As Integer

        If previousX = 0 And previousY = 0 Then
            previousX = Me.currentX
            previousY = Me.currentY
        End If

        pictureGraphics.DrawLine(mainPen, previousX, previousY, currentX, currentY)
        previousX = Me.currentX
        previousY = Me.currentY
        pictureGraphics.Dispose()
    End Sub


    Private Sub PictureBox_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox.MouseMove
        Me.currentX = e.X
        Me.currentY = e.Y
        If e.Button.ToString = "Left" Then
            Sketch()
        End If
    End Sub


End Class
