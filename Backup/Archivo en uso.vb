Public Class Archivo_en_uso
    Private Declare Function CreateFile Lib "kernel32" Alias _
    "CreateFileA" (ByVal lpFileName As String, _
    ByVal dwDesiredAccess As Long, _
    ByVal dwShareMode As Long, _
    ByVal lpSecurityAttributes As Long, _
    ByVal dwCreationDisposition As Long, _
    ByVal dwFlagsAndAttributes As Long, _
    ByVal hTemplateFile As Long) As Long

    Private Declare Function CloseHandle Lib "kernel32" _
        (ByVal hObject As Long) As Long

    Private Const FILE_SHARE_READ = &H1
    Private Const FILE_SHARE_WRITE = &H2
    Private Const OPEN_EXISTING = &H3
    Private Const GENERIC_WRITE = &H40000000
    Private Const INVALID_HANDLE_VALUE = -1


    Public Function ArchivoEnUso(ByVal sFileName As String) As Boolean

        Dim hFile As Long

        On Error GoTo ExitGetFileInfo

        ' Obtenemos el manipulador del archivo. Para ello indicamos
        ' que vamos a permitir el acceso de lectura
        ''  hFile = CreateFile(sFileName, GENERIC_WRITE,     FILE_SHARE_READ Or FILE_SHARE_WRITE, ByVal 0&, OPEN_EXISTING, 0&, 0&)

        ' Si hay un error es porque el archivo está siendo utilizado
        If hFile = INVALID_HANDLE_VALUE Then
            ArchivoEnUso = True
        End If

ExitGetFileInfo:
        ' Cerramos el manipulador del archivo
        hFile = CloseHandle(hFile)
    End Function
End Class
