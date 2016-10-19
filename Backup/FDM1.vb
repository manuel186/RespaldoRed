Imports System.Threading 'para trabajar con subprocesos así que importo trabajo con Hilos
Imports System.Runtime.InteropServices
Imports System.Data.SqlClient
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
End Module
