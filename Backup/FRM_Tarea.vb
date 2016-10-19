Imports System.Xml

Public Class FRM_Tarea

    Private Sub FRM_USUARIOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = titulo_aplicacion + "Tareas"

        carga_grupos()
        carga_tipo()




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


            If dts.guseownaccount_workgen = True Then
                CB_userpasdomain.Checked = True
                txt_username_workgen.Text = dts.gusername_workgen
                txt_domain_workgen.Text = dts.gdomain_workgen


                Dim des As New EncriptarDesencriptar

                txt_password_workgen.Text = des.desencriptar128BitRijndael(dts.gpassword_workgen, dts.gdomain_workgen + "\" + dts.guser_workgen)
                txt2_password_workgen.Text = des.desencriptar128BitRijndael(dts.gpassword_workgen, dts.gdomain_workgen + "\" + dts.guser_workgen)
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


   






    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
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
            txt2_password_workgen.Text = ""
        End If
    End Sub

    Private Sub FRM_Tarea_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
        Me.Dispose()
        Me.Close()
    End Sub
End Class