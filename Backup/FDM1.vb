Imports System.Threading 'para trabajar con subprocesos así que importo trabajo con Hilos
Imports System.Runtime.InteropServices
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Module FDM1

    Public titulo_aplicacion As String = "Backups V1.0"

    'estilos botones
    Public estilo_msgbox_informacion As String = MsgBoxStyle.Information
    '  Public estilo_msgbox_exclamacion As String = MsgBoxStyle.Excladmation



    Public Sub msg_box(ByVal contenido, ByVal estilo, ByVal titulo_aplicacion)
        Dim response
        response = MsgBox(contenido, estilo, titulo_aplicacion)

        Return

    End Sub


    Public Function ValidaIPv4(ByVal ipAddress As String)
        Dim count As Byte
        Dim dotcount As Byte


        'check for illegal charaters
        For count = 1 To Len(ipAddress)
            If InStr("1234567890.", LCase(Mid(ipAddress, count, 1))) > 0 Then
            Else
                '   MsgBox("There are illegal characters")
                Return False
            End If
        Next
        'check if first character is "."

        If InStr(ipAddress, ".") = 1 Then
            ' MsgBox("First Character is '.'")
            Return False
        End If

        'check if there are consecutive ".."

        If InStr(ipAddress, "..") > 0 Then
            '  MsgBox("There are consecutive '.'")
            Return False
        End If


        'check for number of dots
        For count = 1 To Len(ipAddress)
            If Mid(ipAddress, count, 1) = "." Then

                dotcount += 1
                If dotcount > 3 Then
                    ' MsgBox("There are two many '.'")
                    Return False
                End If

            End If
        Next

        'check for values of ip address components 
        Dim num() = Split(ipAddress, ".")

        If num.Count() < 4 Then '' si tiene menos de 4 partes la ip esta incompleta
            Return False

        Else
            For count = 0 To 3
                If (num(count)) > 255 Then
                    ' MsgBox("IP address is invalid")
                    Return False

                End If

                'checks if last split is = 255
                If num(3) = 255 Then
                    ' MsgBox("IP address is invalid")
                    Return False
                End If
            Next
        End If

        




        '  MsgBox("Valid IP address")
        Return True
        'if all of these things are true return true


    End Function

End Module
