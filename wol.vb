Imports System
Imports System.Net
Imports System.Net.Sockets

Public Class wol

    Public Sub New(ByVal macAddress As Byte())
        Me.sendWOL(macAddress)
    End Sub


    Public Sub sendWOL(ByVal macAddress As Byte())

        Dim client As New UdpClient

        'Dim buf(101) As Char

        Dim sendBytes(101) As Byte '= System.Text.Encoding.ASCII.GetBytes(buf)

        For x As Integer = 0 To 5
            sendBytes(x) = CByte(&HFF)
        Next

        Dim i As Integer = 6

        For x As Integer = 1 To 16

            sendBytes(i) = CByte(macAddress(0))

            sendBytes(i + 1) = CByte(macAddress(1))

            sendBytes(i + 2) = CByte(macAddress(2))

            sendBytes(i + 3) = CByte(macAddress(3))

            sendBytes(i + 4) = CByte(macAddress(4))

            sendBytes(i + 5) = CByte(macAddress(5))

            i += 6

        Next
        client.Connect(IPAddress.Broadcast, 7)
        client.Send(sendBytes, sendBytes.Length)
    End Sub



End Class
