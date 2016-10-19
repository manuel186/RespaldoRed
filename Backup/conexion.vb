Imports System.Threading 'para trabajar con subprocesos así que importo trabajo con Hilos
Imports Finisar.SQLite
Imports System.Runtime.InteropServices
Imports System.Data.SqlClient
Imports System.IO  ' para acceder a la carpeta de icono


Public Class conexion
    Dim cadena_de_conexion = "Data Source=config.s3db;Version=3;"

    Public cnn As New SQLiteConnection
    Dim coman As New SqlCommand

    Protected Function conectado()
        Try
            cnn = New SQLiteConnection(cadena_de_conexion)
            cnn.Open()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Protected Function desconectado()
        Try
            If cnn.State = ConnectionState.Open Then
                cnn.Close()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function valida_conexion() As Boolean

        Try

            ''      cnn = New SqlConnection("data source=" & FRM_Login.TB_SERVIDOR.Text & ",1433;initial catalog=" & FRM_Login.TB_SERVIDOR_DATABASE.Text & ";Integrated Security=false;User ID=" & FRM_Login.TB_SERVIDOR_USER.Text & ";Password=" & FRM_Login.TB_SERVIDOR_CLAVE.Text & ";")

            cnn.Open()
            Return True
        Catch ex As Exception

            Return False
        End Try


    End Function


    Public Function Validar(usuario As String, password As String) As Boolean
        Try


            conectado()
            coman = New SqlCommand("Login")
            coman.CommandType = CommandType.StoredProcedure

            '   coman.Connection = cnn

            coman.Parameters.AddWithValue("@id", usuario)
            coman.Parameters.AddWithValue("@password", password)

            If coman.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(coman)
                da.Fill(dt)


                If (dt.Rows.Count > 0) Then
                    '    FRM_Principal.LOGIN = UCase(usuario)
                    '       FRM_Principal.EMPRESA = FRM_Login.txtempresa.Text
                    '
                    '    FRM_Principal.NOMBRE_USUARIO = dt.Rows(0).Item(0)


                    Return True
                End If

            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try



    End Function

    Public Function ver_empresa(emp As Integer) As Boolean
        Try
            conectado()
            coman = New SqlCommand("Select nfanta_empresa from adm_empresa where id_empresa=" & emp)
            coman.CommandType = CommandType.Text

            ' coman.Connection = cnn

            '    coman.Parameters.AddWithValue("@id", usuario)
            ' coman.Parameters.AddWithValue("@password", password)

            If coman.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(coman)
                da.Fill(dt)


                If (dt.Rows.Count > 0) Then

                    ''FRM_Principal.NOMBRE_EMPRESA = dt.Rows(0).Item(0)
                    ''  FRM_Login.TX_empresa.Text = dt.Rows(0).Item(0)

                    Return True
                End If

            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try



    End Function


    Public Function ver_usuario(usuario As String) As Boolean
        Try
            conectado()
            coman = New SqlCommand("Select login_usuario,nombre_usuario from adm_usuario where login_usuario=" & "'" & usuario & "'")
            coman.CommandType = CommandType.Text

            ''     coman.Connection = cnn

            If coman.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(coman)
                da.Fill(dt)


                If (dt.Rows.Count > 0) Then

                    ''  FRM_Principal.LOGIN = UCase(dt.Rows(0).Item(0))
                    ''  FRM_Principal.NOMBRE_USUARIO = dt.Rows(0).Item(1)
                    ''  FRM_Login.Txt_usuario.Text = dt.Rows(0).Item(1)

                    Return True
                End If

            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try



    End Function
End Class
