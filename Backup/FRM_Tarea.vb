Imports System.Xml
Imports System.Threading

Public Class FRM_Tarea
    Public Const MAC_ADDR_BYTES As Integer = 6
    Private Const PORT_BROADCAST = 2304

    Private X, Y
    Private Sub FRM_USUARIOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Me.Text = titulo_aplicacion + "Tareas"
        LB_detectando.Text = ""
        ''elimina los eventos de los combobox para que carge la grilla sin errores
        RemoveHandler CB_wol_workgen.CheckedChanged, AddressOf CB_wol_workgen_CheckedChanged

        '' CB_userpasdomain.Checked = True
        carga_grupos()
        carga_tipo()

        Dim cbinterface
        Dim cambiainterface As New fworkgen
        cbinterface = cambiainterface.ver_interfaces_equipo(FRM_Principal.ID_SELECCIONADO)


        If (cbinterface > 1) Then
            SB_change.Enabled = True
        Else
            SB_change.Enabled = False
        End If

        If FRM_Principal.ID_SELECCIONADO = 0 Then
            txt_id.Text = ""
            CB_status_workgen.Checked = True
            txt_name.Text = ""
            txt_hostname.Text = ""
            txt_user_workgen.Text = ""
            txt_ip_workgen.Text = ""
            txt_mac_workgen.Text = ""
            RB_incremental.Checked = True
            CB_GRUPOS.SelectedValue = 0
            CB_TYPE.SelectedValue = 0
            CB_userpasdomain.Checked = False
            txt_username_workgen.Text = ""
            txt_domain_workgen.Text = ""

            LB_filters_masc.Items.Clear()
            LB_filters_dir.Items.Clear()
            LB_sources.Items.Clear()
            LB_destinations.Items.Clear()

            If (cbinterface = 0) Then
                SB_change.Enabled = False
            Else
                SB_change.Enabled = True
            End If

            CB_Interface.SelectedIndex = 0
        Else


            Dim dts As New vworkgen
            Dim func As New fworkgen

            If func.ver_workgen_by_id(dts, FRM_Principal.ID_SELECCIONADO) Then
                txt_id.Text = dts.gid_workgen
                If dts.gstatus_workgen = True Then
                    CB_status_workgen.Checked = True
                Else
                    CB_status_workgen.Checked = False
                End If

                txt_name.Text = dts.gname_workgen
                txt_hostname.Text = dts.ghostname_workgen
                txt_user_workgen.Text = dts.guser_workgen

                CB_Interface.SelectedItem = dts.ginterface_workgen

                txt_ip_workgen.Text = dts.gip_workgen
                txt_mac_workgen.Text = dts.gmac_workgen
                If dts.gtypework_workgen = "Incremental" Then
                    RB_incremental.Checked = True
                End If
                If dts.gtypework_workgen = "Completo" Then
                    RB_completo.Checked = True
                End If

                CB_GRUPOS.SelectedValue = dts.ggroups_workgen

                CB_TYPE.SelectedValue = dts.gtype_workgen

                If dts.gwol_workgen = True Then
                    CB_wol_workgen.Checked = True
                Else
                    CB_wol_workgen.Checked = False
                End If


                If dts.guseownaccount_workgen = True Then
                    CB_userpasdomain.Checked = True
                    txt_username_workgen.Text = dts.gusername_workgen
                    txt_domain_workgen.Text = dts.gdomain_workgen


                    Dim des As New EncriptarDesencriptar

                    txt_password_workgen.Text = des.desencriptar128BitRijndael(dts.gpassword_workgen, dts.gdomain_workgen + "\" + dts.guser_workgen)
                    txt_password_workgen2.Text = des.desencriptar128BitRijndael(dts.gpassword_workgen, dts.gdomain_workgen + "\" + dts.guser_workgen)
                    PANEL_userpasdomain.Enabled = True
                Else
                    CB_userpasdomain.Checked = False
                    PANEL_userpasdomain.Enabled = False
                End If


            End If



            carga_filtros_masc()
            carga_filtros_dir()

            carga_sources()
            carga_destinations()

            TabControl1.SelectTab(0)



            If txt_ip_workgen.Text <> "" Then
                If ValidaIPv4(txt_ip_workgen.Text) Then

                    Me.SUBPping = New Threading.Thread(AddressOf Me.ping_ip_en_tarea)
                    If Me.SUBPping.ThreadState <> Threading.ThreadState.Running Then
                        Me.SUBPping.Start()
                    End If

                End If
            End If

        End If


        AddHandler CB_wol_workgen.CheckedChanged, AddressOf CB_wol_workgen_CheckedChanged
    End Sub

    Private Sub carga_sources()
        Dim j As Integer

        Dim funcSOURCES As New fworkgen
        Dim TablaSOURCES As New DataTable
        TablaSOURCES = funcSOURCES.carga_sources(FRM_Principal.ID_SELECCIONADO)
        Dim i, total
        total = TablaSOURCES.Rows.Count - 1

        j = 0
        LB_sources.Items.Clear()
        For i = 0 To total Step 1
            LB_sources.Items.Add(TablaSOURCES.Rows(i).Item(3).ToString)
            j = j + 1
        Next
    End Sub





    Private Function valida_tarea()
        Dim swok As Integer = 0

        swok = 1

        If (swok = 1) And (Trim(txt_name.Text) = "") And (Len(txt_name.Text) < 5) Then

            msg_box("Debe ingresar un nombre a la tarea", estilo_msgbox_informacion, titulo_aplicacion)
            txt_name.Focus()
            swok = 0
        End If

        If (swok = 1) And (CB_GRUPOS.SelectedValue = 0) Then
            msg_box("Debe seleccionar un grupo", estilo_msgbox_informacion, titulo_aplicacion)
            CB_GRUPOS.Focus()
            swok = 0
        End If

        If (swok = 1) And (Trim(txt_hostname.Text) = "") And (Len(txt_hostname.Text) < 5) Then
            msg_box("Debe ingresar el nombre del equipo a respaldar", estilo_msgbox_informacion, titulo_aplicacion)
            txt_hostname.Focus()
            swok = 0
        End If

        If (swok = 1) And (Trim(txt_ip_workgen.Text) = "") And (Len(txt_ip_workgen.Text) < 5) Then
            msg_box("Debe ingresar al IP del equipo a respaldar", estilo_msgbox_informacion, titulo_aplicacion)
            txt_ip_workgen.Focus()
            swok = 0
        End If


        If (swok = 1) And (CB_Interface.SelectedIndex = 0) Then
            msg_box("Debe seleccionar el tipo de interface", estilo_msgbox_informacion, titulo_aplicacion)
            CB_Interface.Focus()
            swok = 0
        End If



        If (Trim(txt_ip_workgen.Text) <> "") Then


            If (swok = 1) And ValidaIPv4(Trim(txt_ip_workgen.Text)) = False Then
                msg_box("La dirección Ip Ingresada no es valida", estilo_msgbox_informacion, titulo_aplicacion)
                txt_ip_workgen.Focus()
                swok = 0
            End If
        End If

        If (swok = 1) And (Trim(txt_mac_workgen.Text) = "") And (Len(txt_mac_workgen.Text) < 5) Then
            msg_box("Debe ingresar la MAC del equipo a respaldar", estilo_msgbox_informacion, titulo_aplicacion)
            txt_mac_workgen.Focus()
            swok = 0
        End If


        If (swok = 1) And (Trim(txt_user_workgen.Text) = "") And (Len(txt_user_workgen.Text) < 5) Then
            msg_box("Debe ingresar el nombre de usuario que respaldará del equipo", estilo_msgbox_informacion, titulo_aplicacion)
            txt_user_workgen.Focus()
            swok = 0
        End If


        If (swok = 1) And (CB_TYPE.SelectedValue = 0) Then
            msg_box("Debe seleccionar un tipo de equipo a respaldar", estilo_msgbox_informacion, titulo_aplicacion)
            CB_TYPE.Focus()
            swok = 0
        End If


        If CB_userpasdomain.Checked = True Then
            If (swok = 1) And (Trim(txt_username_workgen.Text) = "") And (Len(txt_username_workgen.Text) < 5) Then
                msg_box("Debe ingresar el nombre de usuario", estilo_msgbox_informacion, titulo_aplicacion)
                txt_username_workgen.Focus()
                swok = 0
            End If

            If (swok = 1) And (Trim(txt_domain_workgen.Text) = "") And (Len(txt_domain_workgen.Text) < 5) Then
                msg_box("Debe ingresar el dominio", estilo_msgbox_informacion, titulo_aplicacion)
                txt_domain_workgen.Focus()
                swok = 0
            End If

            If (swok = 1) And (Trim(txt_password_workgen.Text) = "") And (Len(txt_password_workgen.Text) < 5) Then
                msg_box("Debe ingresar la contraseña", estilo_msgbox_informacion, titulo_aplicacion)
                txt_password_workgen.Focus()
                swok = 0
            End If


            If (swok = 1) And (Trim(txt_password_workgen.Text) = "") And (Len(txt_password_workgen.Text) < 5) Then
                If Not (txt_password_workgen.Text = txt_password_workgen2.Text) Then
                    msg_box("Las contraseñas no son iguales", estilo_msgbox_informacion, titulo_aplicacion)
                    txt_password_workgen2.Focus()
                    swok = 0
                End If


            End If


        End If


        If (swok = 1) And (LB_sources.Items.Count < 1) Then
            msg_box("Debe ingresar al menos una fuente de datos", estilo_msgbox_informacion, titulo_aplicacion)
            TabControl1.SelectTab(1)
            LB_sources.Focus()
            swok = 0
        End If

        If (swok = 1) And (LB_destinations.Items.Count < 1) Then
            msg_box("Debe ingresar al menos una ruta de destino", estilo_msgbox_informacion, titulo_aplicacion)
            TabControl1.SelectTab(1)
            LB_destinations.Focus()
            swok = 0
        End If


        If swok = 1 Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub carga_destinations()
        Dim j As Integer

        Dim funcDESTINATIONS As New fworkgen
        Dim TablaDESTINATIONS As New DataTable
        TablaDESTINATIONS = funcDESTINATIONS.carga_destinations(FRM_Principal.ID_SELECCIONADO)
        Dim i, total
        total = TablaDESTINATIONS.Rows.Count - 1

        j = 0
        LB_destinations.Items.Clear()
        For i = 0 To total Step 1
            LB_destinations.Items.Add(TablaDESTINATIONS.Rows(i).Item(3).ToString)
            j = j + 1
        Next
    End Sub


    Private Sub carga_filtros_masc()
        Dim j As Integer

        Dim funcFILMAS As New fworkgen
        Dim TablaFILMAS As New DataTable
        TablaFILMAS = funcFILMAS.mostrar_filtros_mascaras(FRM_Principal.ID_SELECCIONADO)
        Dim i, total
        total = TablaFILMAS.Rows.Count - 1

        j = 0
        LB_filters_masc.Items.Clear()
        For i = 0 To total Step 1
            LB_filters_masc.Items.Add(TablaFILMAS.Rows(i).Item(0).ToString)
            j = j + 1
        Next
    End Sub


    Private Sub carga_filtros_dir()
        Dim j2 As Integer
        Dim funcFILDIR As New fworkgen
        Dim TablaFILDIR As New DataTable
        TablaFILDIR = funcFILDIR.mostrar_filtros_carpeta(FRM_Principal.ID_SELECCIONADO)

        Dim i2, total2
        total2 = TablaFILDIR.Rows.Count - 1

        j2 = 0
        LB_filters_dir.Items.Clear()
        For i2 = 0 To total2 Step 1
            LB_filters_dir.Items.Add(TablaFILDIR.Rows(i2).Item(0).ToString)
            j2 = j2 + 1
        Next
    End Sub









    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BT_CANCELA.Click
        Me.Dispose()
        Me.Close()

    End Sub

    Sub carga_grupos()
        Try
            Dim dt_grupo As DataTable
            Dim func As New fworkgen
            dt_grupo = func.carga_grupo
            If dt_grupo.Rows.Count <> 0 Then
                CB_GRUPOS.DataSource = dt_grupo

                CB_GRUPOS.ValueMember = "id_groups"
                CB_GRUPOS.DisplayMember = "descri_groups"
            Else
                CB_GRUPOS.DataSource = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub


    Sub carga_tipo()
        Try
            Dim dt_tipo As DataTable
            Dim func As New fworkgen
            dt_tipo = func.carga_tipo
            If dt_tipo.Rows.Count <> 0 Then
                CB_TYPE.DataSource = dt_tipo

                CB_TYPE.ValueMember = "id_type"
                CB_TYPE.DisplayMember = "descri_type"
            Else
                CB_TYPE.DataSource = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub





    Private Sub CB_incluir_predef_CheckedChanged(sender As Object, e As EventArgs) Handles CB_incluir_predef.CheckedChanged

        If CB_incluir_predef.Checked = True Then
            ''carga las extensions por defaults
            Dim j As Integer
            Dim funcFILMAS As New fworkgen
            Dim TablaFILMAS As New DataTable
            TablaFILMAS = funcFILMAS.mostrar_filtros_mascaras_default

            Dim i, total
            total = TablaFILMAS.Rows.Count - 1

            j = 0
            For i = 0 To total Step 1

                LB_filters_masc.Items.Add(TablaFILMAS.Rows(i).Item(0).ToString)

                j = j + 1
            Next

        Else
            LB_filters_masc.Items.Clear()
            carga_filtros_masc()
        End If

    End Sub

    Private Sub CB_userpasdomain_CheckedChanged(sender As Object, e As EventArgs) Handles CB_userpasdomain.CheckedChanged
        If CB_userpasdomain.Checked = True Then
            PANEL_userpasdomain.Enabled = True
            txt_username_workgen.Focus()
        Else
            PANEL_userpasdomain.Enabled = False
            txt_domain_workgen.Text = ""
            txt_username_workgen.Text = ""
            txt_password_workgen.Text = ""
            txt_password_workgen2.Text = ""
        End If
    End Sub

    Private Sub FRM_Tarea_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
        Me.Dispose()
        Me.Close()
    End Sub


    Private Sub inserta_workgen()
        Try
            Try
                Dim estado
                Dim dts As New vworkgen
                Dim func As New fworkgen

                Dim correl = func.ver_correl_workgen
                dts.gid_workgen = correl

                If CB_status_workgen.Checked = True Then
                    dts.gstatus_workgen = 1
                    estado = "Activa"
                Else
                    dts.gstatus_workgen = 0
                    estado = "Inactiva"
                End If

                If CB_wol_workgen.Checked = True Then
                    estado = "Activa"
                    dts.gwol_workgen = 1
                Else
                    estado = "Inactiva"
                    dts.gwol_workgen = 0
                End If


                dts.gname_workgen = txt_name.Text
                dts.ghostname_workgen = txt_hostname.Text
                dts.guser_workgen = txt_user_workgen.Text
                If RB_incremental.Checked = True Then
                    dts.gtypework_workgen = "Incremental"
                End If

                If RB_completo.Checked = True Then
                    dts.gtypework_workgen = "Completo"
                End If

                If RB_diferencial.Checked = True Then
                    dts.gtypework_workgen = "Diferencial"
                End If

                dts.ggroups_workgen = CB_GRUPOS.SelectedValue

                dts.gtype_workgen = CB_TYPE.SelectedValue


                If CB_userpasdomain.Checked = True Then
                    dts.guseownaccount_workgen = 1

                    dts.gusername_workgen = txt_username_workgen.Text
                    dts.gdomain_workgen = txt_domain_workgen.Text

                    Dim des As New EncriptarDesencriptar
                    dts.gpassword_workgen = des.encriptar128BitRijndael(txt_password_workgen.Text, dts.gdomain_workgen + "\" + dts.guser_workgen)
                    ''dts.gpassword_workgen = des.desencriptar128BitRijndael(txt2_password_workgen.Text, dts.gdomain_workgen + "\" + dts.guser_workgen)

                Else
                    dts.guseownaccount_workgen = 0

                End If

                If CB_splitbackup_workgen.Checked = True Then
                    dts.gsplitbackup_workgen = 1
                Else
                    dts.gsplitbackup_workgen = 0
                End If

                If CB_usevsc_workgen.Checked = True Then
                    dts.gusevsc_workgen = 1
                Else
                    dts.gusevsc_workgen = 0
                End If


                Dim ip = txt_ip_workgen.Text
                Dim mac = txt_mac_workgen.Text

                If func.insertar_workgen(dts) Then
                    MessageBox.Show("Tarea  fue registrado correctamente", "Guardando registros", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Dim func2 As New fworkgen
                    func2.inserta_interfaz(correl, 1, CB_Interface.SelectedItem, "IPV4", ip, mac)


                    txt_id.Text = correl

                    agrega_tarea_a_grilla(correl)




                Else
                    MessageBox.Show("Tarea  no fue registrado intente de nuevo", "Guardando registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '  mostrar()
                    ' limpiar()
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BT_ACEPTA_Click(sender As Object, e As EventArgs) Handles BT_ACEPTA.Click


        If TabControl1.TabIndex = 0 Then
            ''tarea nueva 
            If (txt_id.Text) = "" And (Len(txt_id.Text) = 0) Then
                If valida_tarea() Then
                    inserta_workgen()
                End If
            Else

                actualiza_workgen()
                ''actualiza la tarea en pantalla
                FRM_Principal.Actualiza_Tarea_por_id(txt_id.Text)

            End If


        End If




        If TabControl1.TabIndex = 1 Then
            ''tarea nueva 
            If (txt_id.Text) = "" And (Len(txt_id.Text) = 0) Then
                If valida_tarea() Then
                    inserta_workgen()
                    Dim i





                End If
            Else

                actualiza_workgen()
                ''actualiza la tarea en pantalla
                FRM_Principal.Actualiza_Tarea_por_id(txt_id.Text)

            End If


        End If


    End Sub

    Private Sub inserta_souces_y_destinatios(ID, lugarinsercion, tipo, valor)

        Dim estado
        Dim func As New fworkgen

        If func.inserta_destinos(ID, lugarinsercion, tipo, valor) Then
            ''   MessageBox.Show("Tarea  fue Actualizada correctamente", "Actualizando Registros", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ''    txt_id.Text = correl
            ''   agrega_tarea_a_grilla(correl)
        Else
            MessageBox.Show("Tarea  no fue Actualizanda intente de nuevo", "Actualizando registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub actualiza_workgen()
        Try


            Dim estado
            Dim dts As New vworkgen
            Dim func As New fworkgen

            dts.gid_workgen = txt_id.Text

            If CB_status_workgen.Checked = True Then
                dts.gstatus_workgen = 1
                estado = "Activa"
            Else
                dts.gstatus_workgen = 0
                estado = "Inactiva"
            End If

            If CB_wol_workgen.Checked = True Then
                estado = "Activa"
                dts.gwol_workgen = 1
            Else
                estado = "Inactiva"
                dts.gwol_workgen = 0
            End If


            dts.gname_workgen = txt_name.Text
            dts.ghostname_workgen = txt_hostname.Text
            dts.guser_workgen = txt_user_workgen.Text
            dts.gip_workgen = txt_ip_workgen.Text
            dts.gmac_workgen = txt_mac_workgen.Text

            If RB_incremental.Checked = True Then
                dts.gtypework_workgen = "Incremental"
            End If

            If RB_completo.Checked = True Then
                dts.gtypework_workgen = "Completo"
            End If

            If RB_diferencial.Checked = True Then
                dts.gtypework_workgen = "Diferencial"
            End If

            dts.ggroups_workgen = CB_GRUPOS.SelectedValue

            dts.gtype_workgen = CB_TYPE.SelectedValue


            If CB_userpasdomain.Checked = True Then
                dts.guseownaccount_workgen = 1

                dts.gusername_workgen = txt_username_workgen.Text
                dts.gdomain_workgen = txt_domain_workgen.Text

                Dim des As New EncriptarDesencriptar
                dts.gpassword_workgen = des.encriptar128BitRijndael(txt_password_workgen.Text, dts.gdomain_workgen + "\" + dts.guser_workgen)
                ''dts.gpassword_workgen = des.desencriptar128BitRijndael(txt2_password_workgen.Text, dts.gdomain_workgen + "\" + dts.guser_workgen)

            Else
                dts.guseownaccount_workgen = 0

            End If

            If CB_splitbackup_workgen.Checked = True Then
                dts.gsplitbackup_workgen = 1
            Else
                dts.gsplitbackup_workgen = 0
            End If

            If CB_usevsc_workgen.Checked = True Then
                dts.gusevsc_workgen = 1
            Else
                dts.gusevsc_workgen = 0
            End If


            If func.actualiza_workgen(dts) Then
                MessageBox.Show("Tarea  fue Actualizada correctamente", "Actualizando Registros", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ''    txt_id.Text = correl
                ''   agrega_tarea_a_grilla(correl)

            Else
                MessageBox.Show("Tarea  no fue Actualizanda intente de nuevo", "Actualizando registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '  mostrar()
                ' limpiar()
            End If


        Catch ex As Exception

        End Try
    End Sub


    Private Sub agrega_tarea_a_grilla(ID As Integer)
        Try
            ' Referenciamos el objeto DataTable enlazado
            ' con el control DataGridView
            Dim dt As DataTable = DirectCast(FRM_Principal.DBG_TAREAS.DataSource, DataTable)
            ' Creamos una nueva fila u objeto DataRow.
            Dim row As DataRow = dt.NewRow()

            Dim dt_workgen2 As DataTable
            Dim dts As New vworkgen
            Dim funcID As New fworkgen

            dt_workgen2 = funcID.mostrar_workgen_by_id(ID)

            ' Asignamos los valores de la columnas
            row(0) = dt_workgen2.Rows(0).Item(0) ''estado
            row(1) = dt_workgen2.Rows(0).Item(1)   ''Id
            row(2) = dt_workgen2.Rows(0).Item(2)  ''equipo
            row(3) = dt_workgen2.Rows(0).Item(3)  ''user
            row(4) = dt_workgen2.Rows(0).Item(4) ''usuario
            row(5) = dt_workgen2.Rows(0).Item(5) ''grupo
            row(6) = dt_workgen2.Rows(0).Item(6) '' tipo
            row(7) = dt_workgen2.Rows(0).Item(7) '' ip
            row(8) = dt_workgen2.Rows(0).Item(8) '' interface
            row(9) = "Detectando" ''estado en red
            row(10) = "0" ''tamaña
            row(11) = dt_workgen2.Rows(0).Item(11) '' ultimo resp

            ' Añadimos la fila al objeto DataTable
            dt.Rows.Add(row)

        Catch ex As Exception
            ' Se ha producido un error
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub CB_splitbackup_workgen_CheckedChanged(sender As Object, e As EventArgs) Handles CB_splitbackup_workgen.CheckedChanged
        If CB_splitbackup_workgen.Checked = True Then
            If RB_completo.Checked = False Then
                Dim response
                response = MsgBox("Esta opción solo se aplica a respaldo completo, desea ocuparla y cambiar la tarea a respaldo completo?", vbYesNo, titulo_aplicacion)

                If response = vbYes Then
                    RB_completo.Checked = True
                Else
                    CB_splitbackup_workgen.Checked = False
                End If


            End If

        End If

    End Sub

    Private Sub RB_incremental_CheckedChanged(sender As Object, e As EventArgs) Handles RB_incremental.CheckedChanged
        If RB_completo.Checked = False Then
            If CB_splitbackup_workgen.Checked = True Then
                CB_splitbackup_workgen.Checked = False
            End If
        End If


    End Sub

    Private Sub RB_diferencial_CheckedChanged(sender As Object, e As EventArgs) Handles RB_diferencial.CheckedChanged
        If RB_completo.Checked = False Then
            If CB_splitbackup_workgen.Checked = True Then
                CB_splitbackup_workgen.Checked = False
            End If
        End If

    End Sub


    Private Sub BT_TEST_CONEX_Click(sender As Object, e As EventArgs) Handles BT_TEST_CONEX.Click

        If txt_ip_workgen.Text <> "" Then
            If ValidaIPv4(txt_ip_workgen.Text) Then

                Me.SUBPping = New Threading.Thread(AddressOf Me.ping_ip_en_tarea)
                If Me.SUBPping.ThreadState <> Threading.ThreadState.Running Then
                    Me.SUBPping.Start()
                End If

            End If
        End If


        If LB_detectando.Text = "Online" Then

            '''
            '    Dim ImpersonatorTEST As New clsAuthenticator
            '   Dim pas
            '   Dim des As New EncriptarDesencriptar
            '   pas = des.encriptar128BitRijndael(txt_password_workgen.Text, txt_domain_workgen.Text + "\" + txt_username_workgen.Text)
            '   Try
            ' ImpersonatorTEST.Impersonator(txt_domain_workgen.Text, txt_username_workgen.Text, pas)
            ' msg_box("Conexión establecida con equipo", estilo_msgbox_informacion, titulo_aplicacion)
            ' Catch ex As Exception
            ' msg_box(ex.ToString, estilo_msgbox_informacion, titulo_aplicacion)
            ' End Try


            '       ImpersonatorTEST.Undo()
            '


        Else
            msg_box("No se puede probar esta conexión ya que el equipo no se encuentra Online", estilo_msgbox_informacion, titulo_aplicacion)
        End If


      
    End Sub


    Private Sub CB_wol_workgen_CheckedChanged(sender As Object, e As EventArgs) Handles CB_wol_workgen.CheckedChanged
        If CB_wol_workgen.Checked = True Then
            Dim campo As String
            Dim funtipye As New fworkgen
            campo = funtipye.lee_typework(CB_TYPE.SelectedValue.ToString)

            If (campo) <> "PC" Then
                msg_box("Solo se puede ocupar esta opción con equipos de escritorio", estilo_msgbox_informacion, titulo_aplicacion)
                CB_wol_workgen.Checked = False
            End If
        End If

    End Sub


    Private Sub BT_AGREGA_DESTINATIONS_Click(sender As Object, e As EventArgs) Handles BT_AGREGA_DESTINATIONS.Click
        If FolderBrowser_Destinations.ShowDialog() = DialogResult.OK Then
            LB_destinations.Items.Add(FolderBrowser_Destinations.SelectedPath)
        End If
    End Sub

    Private Sub BT_EDITA_SOURCE_Click(sender As Object, e As EventArgs) Handles BT_EDITA_SOURCE.Click

        Dim i As Integer = LB_sources.SelectedIndex
        If i = -1 Then
            msg_box("Debe seleccionar un item a modificar", estilo_msgbox_informacion, titulo_aplicacion)


        Else

            FRM_EDITA.TB_EDITA.Text = ""
            FRM_EDITA.TB_EDITA.Text = LB_sources.Items(i).ToString
            FRM_EDITA.ShowDialog()
            If FRM_EDITA.PASA Then
                LB_sources.Items(i) = FRM_EDITA.VALOR

                '''MODIFCA EL VALOR EN LA BASE DE DATOS
            End If

        End If
    End Sub

    Private Sub BT_EDITA_DESTINATIONS_Click(sender As Object, e As EventArgs) Handles BT_EDITA_DESTINATIONS.Click
        Dim i As Integer = LB_destinations.SelectedIndex
        If i = -1 Then
            msg_box("Debe seleccionar un item a modificar", estilo_msgbox_informacion, titulo_aplicacion)


        Else

            FRM_EDITA.TB_EDITA.Text = ""
            FRM_EDITA.TB_EDITA.Text = LB_destinations.Items(i).ToString
            FRM_EDITA.ShowDialog()
            If FRM_EDITA.PASA Then
                LB_destinations.Items(i) = FRM_EDITA.VALOR

                '''MODIFCA EL VALOR EN LA BASE DE DATOS
            End If

        End If
    End Sub

    Private Sub BT_ELIMINA_SOURCE_Click(sender As Object, e As EventArgs) Handles BT_ELIMINA_SOURCE.Click
        Dim i As Integer = LB_sources.SelectedIndex
        If i = -1 Then
            msg_box("Debe seleccionar un item a eliminar ", estilo_msgbox_informacion, titulo_aplicacion)
        Else
            Dim knt As Integer = LB_sources.SelectedIndices.Count
            Dim i2 As Integer
            For i2 = 0 To knt - 1
                LB_sources.Items.RemoveAt(LB_sources.SelectedIndex)
            Next


            ''ejecuta la eliminarcion en en base de dataos 
        End If

    End Sub

    Private Sub BT_ELIMINA_DESTINATIONS_Click(sender As Object, e As EventArgs) Handles BT_ELIMINA_DESTINATIONS.Click
        Dim i As Integer = LB_destinations.SelectedIndex
        If i = -1 Then
            msg_box("Debe seleccionar un item a eliminar ", estilo_msgbox_informacion, titulo_aplicacion)
        Else
            Dim knt As Integer = LB_destinations.SelectedIndices.Count
            Dim i2 As Integer
            For i2 = 0 To knt - 1
                LB_destinations.Items.RemoveAt(LB_destinations.SelectedIndex)
            Next

            ''ejecuta la eliminarcion en en base de dataos 
        End If
    End Sub


    Private Sub BT_ADITA_EXTENSION_Click(sender As Object, e As EventArgs) Handles BT_ADITA_EXTENSION.Click
        Dim i As Integer = LB_filters_masc.SelectedIndex
        If i = -1 Then
            msg_box("Debe seleccionar un item a modificar", estilo_msgbox_informacion, titulo_aplicacion)


        Else

            FRM_EDITA.TB_EDITA.Text = ""
            FRM_EDITA.TB_EDITA.Text = LB_filters_masc.Items(i).ToString
            FRM_EDITA.ShowDialog()
            If FRM_EDITA.PASA Then
                LB_filters_masc.Items(i) = FRM_EDITA.VALOR

                '''MODIFCA EL VALOR EN LA BASE DE DATOS
            End If

        End If
    End Sub

    Private Sub BT_BORRA_EXTENSION_Click(sender As Object, e As EventArgs) Handles BT_BORRA_EXTENSION.Click
        Dim i As Integer = LB_filters_masc.SelectedIndex
        If i = -1 Then
            msg_box("Debe seleccionar un item a eliminar ", estilo_msgbox_informacion, titulo_aplicacion)
        Else
            Dim knt As Integer = LB_filters_masc.SelectedIndices.Count
            Dim i2 As Integer
            For i2 = 0 To knt - 1
                LB_filters_masc.Items.RemoveAt(LB_filters_masc.SelectedIndex)
            Next


            ''ejecuta la eliminarcion en en base de dataos 
        End If
    End Sub


    Private Sub BT_ELIMINA_DIR_Click(sender As Object, e As EventArgs) Handles BT_ELIMINA_DIR.Click
        Dim i As Integer = LB_filters_dir.SelectedIndex()
        If i = -1 Then
            msg_box("Debe seleccionar un item a eliminar ", estilo_msgbox_informacion, titulo_aplicacion)
        Else
            Dim knt As Integer = LB_filters_dir.SelectedIndices.Count
            Dim i2 As Integer
            For i2 = 0 To knt - 1
                LB_filters_dir.Items.RemoveAt(LB_filters_dir.SelectedIndex)
            Next


            ''ejecuta la eliminarcion en en base de dataos 
        End If
    End Sub

    Private Sub BT_AGREGA_DIR_Click(sender As Object, e As EventArgs) Handles BT_AGREGA_DIR.Click
        If FolderBrowser_Dir.ShowDialog() = DialogResult.OK Then
            LB_filters_dir.Items.Add(FolderBrowser_Source.SelectedPath)
        End If
    End Sub

    Private Sub BT_AGREGA_EXTENSION_Click(sender As Object, e As EventArgs) Handles BT_AGREGA_EXTENSION.Click
        FRM_EDITA.TB_EDITA.Text = ""

        FRM_EDITA.ShowDialog()
        If FRM_EDITA.PASA Then
            LB_filters_masc.Items.Add(FRM_EDITA.VALOR)

        End If
    End Sub

    Private Sub BT_EDITA_DIR_Click(sender As Object, e As EventArgs) Handles BT_EDITA_DIR.Click
        Dim i As Integer = LB_filters_masc.SelectedIndex
        If i = -1 Then
            msg_box("Debe seleccionar un item a modificar", estilo_msgbox_informacion, titulo_aplicacion)


        Else

            FRM_EDITA.TB_EDITA.Text = ""
            FRM_EDITA.TB_EDITA.Text = LB_filters_dir.Items(i).ToString
            FRM_EDITA.ShowDialog()
            If FRM_EDITA.PASA Then
                LB_filters_dir.Items(i) = FRM_EDITA.VALOR

                '''MODIFCA EL VALOR EN LA BASE DE DATOS
            End If

        End If
    End Sub

    Private Sub TabPage_General_Click(sender As Object, e As EventArgs) Handles TabPage_General.Click

    End Sub

    Private Sub SB_change_Click(sender As Object, e As EventArgs) Handles SB_change.Click
        '' ID_SELECCIONADO = DBG_TAREAS(COL_ID, DBG_TAREAS.CurrentCell.RowIndex).Value.ToString()
        FRM_interfaces.ShowDialog()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If LB_sources.Items.Count > 0 Then
            For i = 0 To LB_sources.Items.Count - 1 Step 1
                Dim larce As Integer = Len(LB_sources.Items(i).ToString)
                Dim valor = LB_sources.Items(i).Substring(5, larce)
                inserta_souces_y_destinatios(6, "sources", LB_sources.Items(i).Substring(0, 3), valor)
                ''sources nombre de tabla
            Next
        End If

        If LB_destinations.Items.Count > 0 Then
            For i = 0 To LB_destinations.Items.Count - 1 Step 1

                Dim largodestination = Len(LB_destinations.Items(i).ToString)
                inserta_souces_y_destinatios(6, "destinations", LB_destinations.Items(i).Substring(0, 3), LB_destinations.Items(i).Substring(4, largodestination)) ''destinations nombre de tabla
            Next
        End If
    End Sub


    Private Sub Sources_ToolStripMenuItem_directorios_Click(sender As Object, e As EventArgs) Handles Sources_ToolStripMenuItem_directorios.Click
        If FolderBrowser_Source.ShowDialog() = DialogResult.OK Then
            LB_sources.Items.Add("DIR " & FolderBrowser_Source.SelectedPath)
        End If
    End Sub

    Private Sub BT_AGREGA_SOURCE_Click(sender As Object, e As EventArgs) Handles BT_AGREGA_SOURCE.Click

        '       If LB_AGREGA_SOURCE.Visible = True Then
        'LB_AGREGA_SOURCE.Visible = False
        ' End If

        ' If LB_AGREGA_SOURCE.Visible = False Then
        ' LB_AGREGA_SOURCE.Visible = True
        ' End If
        ''Return
      

        If Windows.Forms.MouseButtons.Right Then
            ''  Dim P As Point
            ''    P = FRM_Tarea.ClientToScreen(New Point)
            X = X + FRM_Principal.Location.X
            Y = Y + FRM_Principal.Location.Y

            Menu_Agrega_sources.Show(X, Y)

        End If
        '' Menu_Agrega_sources.Show()

     
    End Sub

    'Estructura de coordenadas para el api GetCursorPos  
    Private Structure POINTAPI
        Dim X As Long
        Dim Y As Long
    End Structure

    Private Declare Function GetCursorPos Lib "user32" (lpPoint As POINTAPI) As Long

    Private Sub Menu_Agrega_sources_MouseDown(sender As Object, e As MouseEventArgs) Handles Menu_Agrega_sources.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then

            'ContextMenuFavorites.Show(e.Location)

            Menu_Agrega_sources.Show(DirectCast(sender, ToolStripMenuItem).GetCurrentParent.PointToScreen(e.Location))

        End If
    End Sub
    Private SUBPping As Thread = Nothing

    Private Sub txt_ip_workgen_Validated(sender As Object, e As EventArgs) Handles txt_ip_workgen.Validated
        If txt_ip_workgen.Text <> "" Then
            If ValidaIPv4(txt_ip_workgen.Text) Then

                Me.SUBPping = New Threading.Thread(AddressOf Me.ping_ip_en_tarea)
                If Me.SUBPping.ThreadState <> Threading.ThreadState.Running Then
                    Me.SUBPping.Start()
                End If

            End If
        End If
    End Sub



    Function ping_ip_en_tarea()  ''determina el estado de red de la ip existente en la tarea
        Try
            Dim IP As String
            IP = txt_ip_workgen.Text
            Dim timeout = 3000
            Dim sw = New Stopwatch()
            Try
                Dim ping As Long = -1
                sw.Start()
                If My.Computer.Network.Ping(IP, timeout) Then
                    sw.Stop()
                    ping = sw.ElapsedMilliseconds
                End If
                If ping < 0 Then
                    LB_detectando.ForeColor = Color.Red
                    LB_detectando.Text = "OFFLINE"
                ElseIf ping < 200 Then
                    LB_detectando.ForeColor = Color.Green '
                    LB_detectando.Text = "Online"
                ElseIf ping < 400 Then
                    LB_detectando.ForeColor = Color.Green
                    LB_detectando.Text = "Online"
                Else
                    LB_detectando.ForeColor = Color.Red
                    LB_detectando.Text = "OFFLINE"
                End If
            Catch ex As Exception
                ''  Label2.Text = ""
            End Try


        Catch ex As Exception

        End Try
    End Function

    Private Sub LB_AGREGA_SOURCE_Click(sender As Object, e As EventArgs) Handles LB_AGREGA_SOURCE.Click
        LB_AGREGA_SOURCE.Visible = False

    End Sub



End Class