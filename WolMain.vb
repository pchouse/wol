Module WolMain

    Sub Main(ByVal args As String())

        Try
            Dim macAddress(6) As Byte
            If args.Length = 1 Then
                Dim mac() As String = args(0).Split(":")
                If mac.Length <> 6 Then
                    Throw New Exception("MAC address should be in format 00:00:00:00:00:00")
                End If

                For n As Integer = 0 To 5 Step 1
                    macAddress(n) = CByte("&H" + mac(n))
                Next
                Dim w As New wol(macAddress)
            Else
                Throw New Exception("You must specifie the MAC address")
            End If

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try



    End Sub

End Module
