Imports System.IO.Ports

Public Class Form1

    Dim port As SerialPort

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        port = New SerialPort("COM4", 9600) 'Set your board COM
        port.Open()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        port.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        On Error GoTo error1
        port.Write("1") 'character to send to COM port, wich the Arduino will expect.
        Label1.Text = Now() & " - Sent ""1"" on COM4 baud 9600 - Success!"
        Exit Sub

error1:
        Label1.Text = Now() & " - " & ErrorToString()
    End Sub
	
End Class