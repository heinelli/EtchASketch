'Elliot Heiner
'RCET 0265
'Fall 2021
'Etch a Sketch
'https://github.com/heinelli/EtchASketch.git

Option Strict On
Option Explicit On
Public Class EtchASketchForm
    Dim x As Integer
    Dim y As Integer

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub
End Class
