﻿Imports Finisar.SQLite
Imports System.Data.SqlClient

Public Class fworkgen
    Inherits conexion


    Dim cmd As New SqlCommand


    Public Function insertar_workgen(ByVal dts As vworkgen) As Boolean
        Try
            conectado()
            Dim consulta As String
            Dim ID

            consulta = "insert into Workgen (id_workgen,status_workgen,typework_workgen,name_workgen,user_workgen,type_workgen, "
            consulta = consulta & " groups_workgen,hostname_workgen,ip_workgen,mac_workgen,useownaccount_workgen,domain_workgen, "
            consulta = consulta & " username_workgen,password_workgen,splitbackup_workgen,usevsc_workgen)"
            consulta = consulta & " values(" & dts.gid_workgen & "," & dts.gstatus_workgen & ",'" & dts.gtypework_workgen & "','" & dts.gname_workgen & "',"
            consulta = consulta & "'" & dts.guser_workgen & "','" & dts.gtype_workgen & "'," & dts.ggroups_workgen & ",'" & dts.ghostname_workgen & "',"
            consulta = consulta & "'" & dts.gip_workgen & "','" & dts.gmac_workgen & "'," & dts.guseownaccount_workgen & ",'" & dts.gdomain_workgen & "',"
            consulta = consulta & "'" & dts.gusername_workgen & "','" & dts.gpassword_workgen & "'," & dts.gsplitbackup_workgen & "," & dts.gusevsc_workgen & ") "
        

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








    Public Function carga_grupo() As DataTable
        Try
            conectado()
            Dim consulta As String
            consulta = "SELECT 1 as Grupo, id_groups, descri_groups FROM   groups  UNION ALL  SELECT 0 as Grupo, 0 AS id_Groups, 'Seleccione Grupo' AS descri_groups ORDER BY Grupo, descri_groups "

            Dim command As New SQLiteCommand(consulta, cnn)
            Dim da As New SQLiteDataAdapter


            '  If command.ExecuteNonQuery Then
            da.SelectCommand = command
            Dim dt As New DataTable
            dt.Clear()
            da.Fill(dt)

            Return dt


        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function



    Public Function carga_tipo() As DataTable
        Try
            conectado()
            Dim consulta As String
            consulta = "SELECT 1 as Tipo, id_type, descri_type FROM   type  UNION ALL  SELECT 0 as Grupo, 0 AS id_type, 'Seleccione Tipo' AS descri_type ORDER BY Grupo, descri_type "

            Dim command As New SQLiteCommand(consulta, cnn)
            Dim da As New SQLiteDataAdapter


            '  If command.ExecuteNonQuery Then
            da.SelectCommand = command
            Dim dt As New DataTable
            dt.Clear()
            da.Fill(dt)

            Return dt


        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function

    Public Function mostrar_workgen_by_id(ID As Integer) As DataTable
        Try
            conectado()
            Dim consulta As String
            consulta = "select case when status_workgen=1 then 'Activa' else 'Inactiva' end as Estado, "
            consulta = consulta & "id_workgen as ID,hostname_workgen as Equipo,user_workgen as 'User PC', "
            consulta = consulta & "name_workgen as Usuario, descri_groups as Grupo,ip_workgen as IP, descri_type as Tipo, "
            consulta = consulta & "'Detectando' as 'Estado en Red',' ' as 'Tamaño',  "
            consulta = consulta & "ifnull( (select   CAST((julianday('now') - julianday(date_workdet)) as integer) from workdet "
            consulta = consulta & "where id_workdet = id_workgen order by correl_workdet desc  LIMIT 1),99) as 'Respaldo' "
            ''  consulta = consulta & "(select size_workdet from workdet order by id_workdet desc  LIMIT 1 )  as 'Ul. Respaldo'"
            consulta = consulta & " from workgen"

            consulta = consulta & " left join groups on groups_workgen=id_groups "
            consulta = consulta & " left join type on type_workgen = id_type "

            consulta = consulta & " where id_workgen= " & ID


            Dim command As New SQLiteCommand(consulta, cnn)
            Dim da As New SQLiteDataAdapter


            '  If command.ExecuteNonQuery Then
            da.SelectCommand = command
            Dim dt As New DataTable
            dt.Clear()
            da.Fill(dt)

            Return dt

            '   Else
            ''    Return Nothing
            '  End If


        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function


    Public Function mostrar_workgen() As DataTable
        Try
            conectado()
            Dim consulta As String
            consulta = "select case when status_workgen=1 then 'Activa' else 'Inactiva' end as Estado, "
            consulta = consulta & "id_workgen as ID,hostname_workgen as Equipo,user_workgen as 'User PC', "
            consulta = consulta & "name_workgen as Usuario, descri_groups as Grupo,ip_workgen as IP, descri_type as Tipo, "
            consulta = consulta & "'Detectando' as 'Estado en Red',' ' as 'Tamaño',  "
            consulta = consulta & "ifnull( (select   CAST((julianday('now') - julianday(date_workdet)) as integer) from workdet "
            consulta = consulta & "where id_workdet = id_workgen order by correl_workdet desc  LIMIT 1),99) as 'Respaldo' "
            ''  consulta = consulta & "(select size_workdet from workdet order by id_workdet desc  LIMIT 1 )  as 'Ul. Respaldo'"
            consulta = consulta & " from workgen"

            consulta = consulta & " left join groups on groups_workgen=id_groups "
            consulta = consulta & " left join type on type_workgen = id_type "




            Dim command As New SQLiteCommand(consulta, cnn)
            Dim da As New SQLiteDataAdapter


            '  If command.ExecuteNonQuery Then
            da.SelectCommand = command
            Dim dt As New DataTable
            dt.Clear()
            da.Fill(dt)

            Return dt

            '   Else
            ''    Return Nothing
            '  End If


        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function

    Public Function ver_workgen_by_id(ByVal dts As vworkgen, ID As Integer) As Boolean
        Try
            conectado()
            Dim consulta As String = ""
            
            consulta = "select * ,ifnull( (select   CAST((julianday('now') - julianday(date_workdet)) as integer) from workdet "
            consulta = consulta & " where id_workdet = id_workgen order by correl_workdet desc  LIMIT 1),99) as 'Respaldo'"
            consulta = consulta & " from workgen"
            consulta = consulta & " left join groups on groups_workgen=id_groups "
            consulta = consulta & " left join type on type_workgen = id_type "

            consulta = consulta & " where id_workgen= " & ID


            Dim command As New SQLiteCommand(consulta, cnn)
            Dim da As New SQLiteDataAdapter


            '  If command.ExecuteNonQuery Then
            '  If command.ExecuteNonQuery Then
            da.SelectCommand = command
            Dim dt As New DataTable
            dt.Clear()
            da.Fill(dt)


            If (dt.Rows.Count > 0) Then


                dts.gid_workgen = dt.Rows(0).Item(0)

                If IsDBNull(dt.Rows(0).Item(1)) Then
                    dts.gstatus_workgen = False
                Else
                    dts.gstatus_workgen = dt.Rows(0).Item(1)
                End If


                dts.gtypework_workgen = dt.Rows(0).Item(2)
                dts.gname_workgen = dt.Rows(0).Item(3)
                dts.guser_workgen = dt.Rows(0).Item(4)
                dts.gtype_workgen = dt.Rows(0).Item(5)
                dts.ggroups_workgen = dt.Rows(0).Item(6)
                dts.ghostname_workgen = dt.Rows(0).Item(7)
                dts.gip_workgen = dt.Rows(0).Item(8)
                dts.gmac_workgen = dt.Rows(0).Item(9)

                If IsDBNull(dt.Rows(0).Item(10)) Then
                    dts.guseownaccount_workgen = False
                Else
                    dts.guseownaccount_workgen = dt.Rows(0).Item(10)
                End If

                dts.gdomain_workgen = dt.Rows(0).Item(11)
                dts.gusername_workgen = dt.Rows(0).Item(12)
                dts.gpassword_workgen = dt.Rows(0).Item(13)
                dts.gsplitbackup_workgen = dt.Rows(0).Item(14)
                dts.gusevsc_workgen = dt.Rows(0).Item(15)
                dts.gfchbackup_workgen = dt.Rows(0).Item(16)
                Return True
            End If

            ''  Else
            '' Return Nothing
            ''End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function


    Public Function mostrar_workdet(id) As DataTable
        Try
            conectado()
            Dim consulta As String = ""
            ''consulta = "select type_workdet as 'Tipo de Respaldo',strftime('%d-%m-%Y %H:%M:%S', date_workdet) as Fecha,"
            consulta = "select type_workdet as 'Tipo de Respaldo',strftime('%d-%m-%Y  %H:%M:%S', date_workdet) as Fecha,"
            consulta = consulta & "size_workdet as Tamaño, correl_workdet as ID"
            consulta = consulta & " from workdet"
            consulta = consulta & " where id_workdet = " & id
            consulta = consulta & " order by correl_workdet desc "

            Dim command As New SQLiteCommand(consulta, cnn)
            Dim da As New SQLiteDataAdapter


            '  If command.ExecuteNonQuery Then
            da.SelectCommand = command
            Dim dt As New DataTable
            dt.Clear()
            da.Fill(dt)

            Return dt

            '   Else
            ''    Return Nothing
            '  End If


        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function

    Public Function mostrar_filtros_mascaras(id) As DataTable
        Try
            conectado()
            Dim consulta As String = ""
            consulta = "select descri_filters from filters"
            consulta = consulta & " where workgen_filters = " & id & " and type_filters='Mascara'"

              Dim command As New SQLiteCommand(consulta, cnn)
            Dim da As New SQLiteDataAdapter


            '  If command.ExecuteNonQuery Then
            da.SelectCommand = command
            Dim dt As New DataTable
            dt.Clear()
            da.Fill(dt)

            Return dt

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function
    Public Function mostrar_filtros_mascaras_default() As DataTable
        Try
            conectado()
            Dim consulta As String = ""
            consulta = "select descri_filters "
            consulta = consulta & " from filters"
            consulta = consulta & " where workgen_filters = 0 and type_filters='Mascara'"

            Dim command As New SQLiteCommand(consulta, cnn)
            Dim da As New SQLiteDataAdapter

            da.SelectCommand = command
            Dim dt As New DataTable
            dt.Clear()
            da.Fill(dt)

            ''If dt.Rows.Count > 0 Then

            Return dt
            ''  Else
            ''    Return Nothing
            ''  End If


        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function

    Public Function mostrar_filtros_carpeta(id) As DataTable
        Try
            conectado()
            Dim consulta As String
            consulta = "select descri_filters from filters"
            ''consulta = consulta & " "
            consulta = consulta & " where workgen_filters = " & id & " and type_filters='Carpeta'"

            Dim command As New SQLiteCommand(consulta, cnn)
            Dim da As New SQLiteDataAdapter

            da.SelectCommand = command
            Dim dt As New DataTable
            dt.Clear()
            da.Fill(dt)
            '' If dt.Rows.Count > 0 Then

            Return dt
            '' Else
            '' Return Nothing
            '' End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function


    Public Function inserta_workdet(ID, correl, typework, size) As Boolean

        Try

            conectado()
            ''    Dim fecha = System.DateTime.Now.ToString()
            Dim consulta As String
            consulta = "insert into Workdet (id_workdet,correl_workdet,type_workdet,date_workdet,size_workdet)"
            consulta = consulta & " values(" & ID & ", " & correl & " , '" & typework & "',DATETIME('now','localtime') , '" & size & "')"

            Dim da As New SQLiteDataAdapter
            Dim command As New SQLiteCommand(consulta, cnn)
            command.CommandType = CommandType.Text

            ''  If command.ExecuteNonQuery Then
            da.SelectCommand = command
            Dim dt As New DataTable
            dt.Clear()
            da.Fill(dt)
            Return True
            '' Else
            ''  Return False
            '' End If



        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try



    End Function

    Public Function elimina_workdet(ID) As Boolean

        Try

            conectado()
            ''    Dim fecha = System.DateTime.Now.ToString()
            Dim consulta As String
            consulta = "delete  from workdet where  id_workdet =" & ID

            Dim da As New SQLiteDataAdapter
            Dim command As New SQLiteCommand(consulta, cnn)
            command.CommandType = CommandType.Text

            ''  If command.ExecuteNonQuery Then
            da.SelectCommand = command
            Dim dt As New DataTable
            dt.Clear()
            da.Fill(dt)
            Return True
            '' Else
            ''  Return False
            '' End If



        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try



    End Function


    Public Function elimina_workgen(ID) As Boolean

        Try

            conectado()
            ''    Dim fecha = System.DateTime.Now.ToString()
            Dim consulta As String
            consulta = "delete  from Workgen where id_workgen =" & ID

            Dim da As New SQLiteDataAdapter
            Dim command As New SQLiteCommand(consulta, cnn)
            command.CommandType = CommandType.Text

            ''  If command.ExecuteNonQuery Then
            da.SelectCommand = command
            Dim dt As New DataTable
            dt.Clear()
            da.Fill(dt)
            Return True
            '' Else
            ''  Return False
            '' End If



        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try



    End Function

    Public Function ver_correl_workdet(ID As Integer) As Integer
        Try
            Dim correl As Integer

            conectado()
            Dim consulta As String
            consulta = "select ifnull(max(correl_workdet),0)+1 from workdet where id_workdet=" & ID

            Dim command As New SQLiteCommand(consulta, cnn)
            Dim da As New SQLiteDataAdapter
            da.SelectCommand = command

            Dim dt As New DataTable
            da.Fill(dt)


            If (dt.Rows.Count > 0) Then
                correl = dt.Rows(0).Item(0)
                Return correl


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

    Public Function ver_correl_workgen() As Integer
        Try
            Dim correl As Integer

            conectado()
            Dim consulta As String
            consulta = "select ifnull(max(id_workgen),0)+1 from workgen "

            Dim command As New SQLiteCommand(consulta, cnn)
            Dim da As New SQLiteDataAdapter
            da.SelectCommand = command

            Dim dt As New DataTable
            da.Fill(dt)


            If (dt.Rows.Count > 0) Then
                correl = dt.Rows(0).Item(0)
                Return correl


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
    Public Function carga_sources(id) As DataTable
        Try
            conectado()
            Dim consulta As String
            ''consulta = "select type_workdet as 'Tipo de Respaldo',strftime('%d-%m-%Y %H:%M:%S', date_workdet) as Fecha,"
            consulta = "select * from sources"

            consulta = consulta & " where workgen_sources = " & id

            Dim command As New SQLiteCommand(consulta, cnn)
            Dim da As New SQLiteDataAdapter


            '  If command.ExecuteNonQuery Then
            da.SelectCommand = command
            Dim dt As New DataTable
            dt.Clear()
            da.Fill(dt)

            Return dt

            '   Else
            ''    Return Nothing
            '  End If


        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function


    Public Function carga_destinations(id) As DataTable
        Try
            conectado()
            Dim consulta As String
            ''consulta = "select type_workdet as 'Tipo de Respaldo',strftime('%d-%m-%Y %H:%M:%S', date_workdet) as Fecha,"
            consulta = "select * from destinations"
            consulta = consulta & " where workgen_destination = " & id

            Dim command As New SQLiteCommand(consulta, cnn)
            Dim da As New SQLiteDataAdapter


            '  If command.ExecuteNonQuery Then
            da.SelectCommand = command
            Dim dt As New DataTable
            dt.Clear()
            da.Fill(dt)

            Return dt

            '   Else
            ''    Return Nothing
            '  End If


        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function
    Public Function cambia_estadocom(empresa As Integer, ano As Integer, mes As Integer, movgen As Integer, estado As String) As Boolean
        Try

            conectado()
            conectado()
            cmd = New SqlCommand("[cambia_estado_movgen]")
            cmd.CommandType = CommandType.StoredProcedure

            ''  cmd.Connection = cnn
            ''cmd.Parameters.AddWithValue("@tipoop", tipoop)
            cmd.Parameters.AddWithValue("@empresa", empresa)
            cmd.Parameters.AddWithValue("@ano", ano)
            cmd.Parameters.AddWithValue("@mes", mes)
            cmd.Parameters.AddWithValue("@id", movgen)
            cmd.Parameters.AddWithValue("@estado", estado)

            '' cmd.Connection = cnn

            If cmd.ExecuteNonQuery Then
                Return True
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



    Public Function calcula_ventas_totales(empresa As Integer, ano As Integer, mes As Integer, mesano As Integer) As DataTable
        Try
            conectado()
            cmd = New SqlCommand("[calcula_ventas_totales]")
            cmd.CommandType = CommandType.StoredProcedure

            '' cmd.Connection = cnn
            cmd.Parameters.AddWithValue("@empresa_movgen", empresa)
            cmd.Parameters.AddWithValue("@ano_movgen", ano)
            cmd.Parameters.AddWithValue("@mes_movgen", mes)
            cmd.Parameters.AddWithValue("@mesano", mesano)

            ''  cmd.Connection = cnn

            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                If (dt.Rows.Count > 0) Then
                    Return dt
                Else
                    Return Nothing
                End If
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try



    End Function

    Public Function calcula_peso_total(empresa As Integer, ano As Integer, mes As Integer, mesano As Integer) As DataTable
        Try
            conectado()
            cmd = New SqlCommand("[calcula_peso_total]")
            cmd.CommandType = CommandType.StoredProcedure

            ''  cmd.Connection = cnn
            cmd.Parameters.AddWithValue("@empresa_movgen", empresa)
            cmd.Parameters.AddWithValue("@ano_movgen", ano)
            cmd.Parameters.AddWithValue("@mes_movgen", mes)
            cmd.Parameters.AddWithValue("@mesano", mesano)

            '' cmd.Connection = cnn

            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                If (dt.Rows.Count > 0) Then
                    Return dt
                Else
                    Return Nothing
                End If
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try



    End Function

    Public Function actualiza_inventario(tipoop As String, empresa As Integer, ano As Integer, mes As Integer, movdet As Integer, producto As Integer) As Boolean
        Try

            conectado()
            conectado()
            cmd = New SqlCommand("[actualiza_inventario_por_producto]")
            cmd.CommandType = CommandType.StoredProcedure

            '' cmd.Connection = cnn
            cmd.Parameters.AddWithValue("@tipoop", tipoop)
            cmd.Parameters.AddWithValue("@empresa", empresa)
            cmd.Parameters.AddWithValue("@ano", ano)
            cmd.Parameters.AddWithValue("@mes", mes)
            cmd.Parameters.AddWithValue("@movdet", movdet)
            cmd.Parameters.AddWithValue("@producto", producto)

            ''  cmd.Connection = cnn

            If cmd.ExecuteNonQuery Then
                Return True
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







    Public Function ver_correl_pagos(emp As Integer, ano As Integer, mes As Integer, id As Integer) As Integer
        Try
            Dim correl As Integer

            conectado()
            cmd = New SqlCommand("select isnull(max(correl_pago),0)+1 from pagos where empresa_pago=" & emp & " and ano_pago=" & ano & " and mes_pago=" & mes & " and movgen_pago=" & id)
            cmd.CommandType = CommandType.Text

            ''  cmd.Connection = cnn

            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)


                If (dt.Rows.Count > 0) Then
                    correl = dt.Rows(0).Item(0)
                    Return correl


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

    Public Function mostrar_movdet(ByVal dtsd As vworkgen) As DataTable
        Try
            conectado()
            cmd = New SqlCommand("mostrar_movdet")
            cmd.CommandType = CommandType.StoredProcedure

            '' cmd.Connection = cnn
            '    cmd.Parameters.AddWithValue("@empresa_movdet", dtsd.gempresa_movdet)
            '    cmd.Parameters.AddWithValue("@ano_movdet", dtsd.gano_movdet)
            '    cmd.Parameters.AddWithValue("@mes_movdet", dtsd.gmes_movdet)
            ''    cmd.Parameters.AddWithValue("@id_movdet", dtsd.gid_movdet)

            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt
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





    Public Function actualiza_movgen(ByVal dts As vworkgen) As Boolean
        Try
            conectado()
            cmd = New SqlCommand("editar_movgen")
            cmd.CommandType = CommandType.StoredProcedure
            '' cmd.Connection = cnn

            '  cmd.Parameters.AddWithValue("@empresa_movgen", dts.gempresa_movgen)
            '  cmd.Parameters.AddWithValue("@ano_movgen", dts.gano_movgen)
            '  cmd.Parameters.AddWithValue("@mes_movgen", dts.gmes_movgen)
            '' cmd.Parameters.AddWithValue("@id_movgen", dts.gid_movgen) '
            ' cmd.Parameters.AddWithValue("@cliente_movgen", dts.gcliente_movgen)
            ' cmd.Parameters.AddWithValue("@conoc_movgen", dts.gconoc_movgen)
            ' cmd.Parameters.AddWithValue("@numdoc_movgen", dts.gnumdoc_movgen)
            ''cmd.Parameters.AddWithValue("@bodega_movgen", dts.gbodega_movgen)
            'cmd.Parameters.AddWithValue("@vende_movgen", dts.gvende_movgen)
            '  cmd.Parameters.AddWithValue("@forpag_movgen", dts.gforpag_movgen)
            '  cmd.Parameters.AddWithValue("@rutret_movgen", dts.grutret_movgen)
            '  cmd.Parameters.AddWithValue("@nombreret_movgen", dts.gnombreret_movgen)
            '  cmd.Parameters.AddWithValue("@comentario_movgen", dts.gcomentario_movgen)

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



End Class

