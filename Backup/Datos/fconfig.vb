Imports Finisar.SQLite
Imports System.Data.SqlClient

Public Class fconfig
    Inherits conexion


    Dim cmd As New SqlCommand


    Public Function actualiza_config(ID As Integer, valor As String) As Boolean
        Try
            conectado()
            Dim consulta As String

            consulta = "update config set value_config ='" & valor & "'"
            consulta = consulta & " where id_config=" & ID


            Dim command As New SQLiteCommand(consulta, cnn)
            Dim da As New SQLiteDataAdapter


            '  If command.ExecuteNonQuery Then
            da.SelectCommand = command
            Dim dt As New DataTable
            dt.Clear()
            da.Fill(dt)

            Return True


            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectado()
        End Try
    End Function


    Public Function ver_config(ID As Integer) As String
        Try
            conectado()
            Dim consulta, valor As String

            consulta = "select  value_config from config where id_config=" & ID


            Dim command As New SQLiteCommand(consulta, cnn)
            Dim da As New SQLiteDataAdapter


            '  If command.ExecuteNonQuery Then
            da.SelectCommand = command
            Dim dt As New DataTable
            dt.Clear()
            da.Fill(dt)

            valor = dt.Rows(0).Item(0)
            Return valor


            If cmd.ExecuteNonQuery Then
                Return valor
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectado()
        End Try
    End Function




End Class

