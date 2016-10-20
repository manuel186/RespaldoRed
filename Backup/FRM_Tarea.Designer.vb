<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_Tarea
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage_General = New System.Windows.Forms.TabPage()
        Me.PANEL_userpasdomain = New System.Windows.Forms.Panel()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.txt2_password_workgen = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txt_password_workgen = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txt_domain_workgen = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txt_username_workgen = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.CB_userpasdomain = New System.Windows.Forms.CheckBox()
        Me.CB_usevsc_workgen = New System.Windows.Forms.CheckBox()
        Me.CB_splitbackup_workgen = New System.Windows.Forms.CheckBox()
        Me.CB_status_workgen = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GB_tipo_respaldo = New System.Windows.Forms.GroupBox()
        Me.RB_diferencial = New System.Windows.Forms.RadioButton()
        Me.RB_incremental = New System.Windows.Forms.RadioButton()
        Me.RB_completo = New System.Windows.Forms.RadioButton()
        Me.txt_id = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CB_GRUPOS = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_mac_workgen = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CB_TYPE = New System.Windows.Forms.ComboBox()
        Me.txt_user_workgen = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_ip_workgen = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_hostname = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_name = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage_Archivos = New System.Windows.Forms.TabPage()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.LB_destinations = New System.Windows.Forms.ListBox()
        Me.LB_sources = New System.Windows.Forms.ListBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TabPage_Filtros = New System.Windows.Forms.TabPage()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.LB_filters_dir = New System.Windows.Forms.ListBox()
        Me.CB_incluir_predef = New System.Windows.Forms.CheckBox()
        Me.LB_filters_masc = New System.Windows.Forms.ListBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.BT_CANCELA = New DevExpress.XtraEditors.SimpleButton()
        Me.BT_ACEPTA = New DevExpress.XtraEditors.SimpleButton()
        Me.TabControl1.SuspendLayout()
        Me.TabPage_General.SuspendLayout()
        Me.PANEL_userpasdomain.SuspendLayout()
        Me.GB_tipo_respaldo.SuspendLayout()
        Me.TabPage_Archivos.SuspendLayout()
        Me.TabPage_Filtros.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.TabControl1.Controls.Add(Me.TabPage_General)
        Me.TabControl1.Controls.Add(Me.TabPage_Archivos)
        Me.TabControl1.Controls.Add(Me.TabPage_Filtros)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(725, 438)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage_General
        '
        Me.TabPage_General.Controls.Add(Me.PANEL_userpasdomain)
        Me.TabPage_General.Controls.Add(Me.CB_userpasdomain)
        Me.TabPage_General.Controls.Add(Me.CB_usevsc_workgen)
        Me.TabPage_General.Controls.Add(Me.CB_splitbackup_workgen)
        Me.TabPage_General.Controls.Add(Me.CB_status_workgen)
        Me.TabPage_General.Controls.Add(Me.Label9)
        Me.TabPage_General.Controls.Add(Me.GB_tipo_respaldo)
        Me.TabPage_General.Controls.Add(Me.txt_id)
        Me.TabPage_General.Controls.Add(Me.Label8)
        Me.TabPage_General.Controls.Add(Me.Label7)
        Me.TabPage_General.Controls.Add(Me.CB_GRUPOS)
        Me.TabPage_General.Controls.Add(Me.Label6)
        Me.TabPage_General.Controls.Add(Me.txt_mac_workgen)
        Me.TabPage_General.Controls.Add(Me.Label4)
        Me.TabPage_General.Controls.Add(Me.CB_TYPE)
        Me.TabPage_General.Controls.Add(Me.txt_user_workgen)
        Me.TabPage_General.Controls.Add(Me.Label5)
        Me.TabPage_General.Controls.Add(Me.txt_ip_workgen)
        Me.TabPage_General.Controls.Add(Me.Label3)
        Me.TabPage_General.Controls.Add(Me.txt_hostname)
        Me.TabPage_General.Controls.Add(Me.Label2)
        Me.TabPage_General.Controls.Add(Me.txt_name)
        Me.TabPage_General.Controls.Add(Me.Label1)
        Me.TabPage_General.Location = New System.Drawing.Point(4, 25)
        Me.TabPage_General.Name = "TabPage_General"
        Me.TabPage_General.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_General.Size = New System.Drawing.Size(717, 409)
        Me.TabPage_General.TabIndex = 0
        Me.TabPage_General.Text = "General"
        Me.TabPage_General.UseVisualStyleBackColor = True
        '
        'PANEL_userpasdomain
        '
        Me.PANEL_userpasdomain.Controls.Add(Me.Button13)
        Me.PANEL_userpasdomain.Controls.Add(Me.txt2_password_workgen)
        Me.PANEL_userpasdomain.Controls.Add(Me.Label17)
        Me.PANEL_userpasdomain.Controls.Add(Me.txt_password_workgen)
        Me.PANEL_userpasdomain.Controls.Add(Me.Label16)
        Me.PANEL_userpasdomain.Controls.Add(Me.txt_domain_workgen)
        Me.PANEL_userpasdomain.Controls.Add(Me.Label15)
        Me.PANEL_userpasdomain.Controls.Add(Me.txt_username_workgen)
        Me.PANEL_userpasdomain.Controls.Add(Me.Label14)
        Me.PANEL_userpasdomain.Location = New System.Drawing.Point(11, 223)
        Me.PANEL_userpasdomain.Name = "PANEL_userpasdomain"
        Me.PANEL_userpasdomain.Size = New System.Drawing.Size(700, 75)
        Me.PANEL_userpasdomain.TabIndex = 32
        '
        'Button13
        '
        Me.Button13.Location = New System.Drawing.Point(615, 14)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(75, 43)
        Me.Button13.TabIndex = 40
        Me.Button13.Text = "Probar Conexión"
        Me.Button13.UseVisualStyleBackColor = True
        '
        'txt2_password_workgen
        '
        Me.txt2_password_workgen.Location = New System.Drawing.Point(412, 41)
        Me.txt2_password_workgen.Name = "txt2_password_workgen"
        Me.txt2_password_workgen.Size = New System.Drawing.Size(197, 20)
        Me.txt2_password_workgen.TabIndex = 39
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(300, 44)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(111, 13)
        Me.Label17.TabIndex = 38
        Me.Label17.Text = "Contraseña(Confirmar)"
        '
        'txt_password_workgen
        '
        Me.txt_password_workgen.Location = New System.Drawing.Point(93, 40)
        Me.txt_password_workgen.Name = "txt_password_workgen"
        Me.txt_password_workgen.Size = New System.Drawing.Size(197, 20)
        Me.txt_password_workgen.TabIndex = 37
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(8, 44)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(61, 13)
        Me.Label16.TabIndex = 36
        Me.Label16.Text = "Contraseña"
        '
        'txt_domain_workgen
        '
        Me.txt_domain_workgen.Location = New System.Drawing.Point(412, 14)
        Me.txt_domain_workgen.Name = "txt_domain_workgen"
        Me.txt_domain_workgen.Size = New System.Drawing.Size(197, 20)
        Me.txt_domain_workgen.TabIndex = 35
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(361, 17)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(45, 13)
        Me.Label15.TabIndex = 34
        Me.Label15.Text = "Dominio"
        '
        'txt_username_workgen
        '
        Me.txt_username_workgen.Location = New System.Drawing.Point(93, 14)
        Me.txt_username_workgen.Name = "txt_username_workgen"
        Me.txt_username_workgen.Size = New System.Drawing.Size(197, 20)
        Me.txt_username_workgen.TabIndex = 33
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(7, 17)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(83, 13)
        Me.Label14.TabIndex = 32
        Me.Label14.Text = "Nombre Usuario"
        '
        'CB_userpasdomain
        '
        Me.CB_userpasdomain.AutoSize = True
        Me.CB_userpasdomain.Checked = True
        Me.CB_userpasdomain.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CB_userpasdomain.Location = New System.Drawing.Point(12, 200)
        Me.CB_userpasdomain.Name = "CB_userpasdomain"
        Me.CB_userpasdomain.Size = New System.Drawing.Size(175, 17)
        Me.CB_userpasdomain.TabIndex = 23
        Me.CB_userpasdomain.Text = "Ejecutar tarea bajo otra cuenta:"
        Me.CB_userpasdomain.UseVisualStyleBackColor = True
        '
        'CB_usevsc_workgen
        '
        Me.CB_usevsc_workgen.AutoSize = True
        Me.CB_usevsc_workgen.Enabled = False
        Me.CB_usevsc_workgen.Location = New System.Drawing.Point(11, 162)
        Me.CB_usevsc_workgen.Name = "CB_usevsc_workgen"
        Me.CB_usevsc_workgen.Size = New System.Drawing.Size(361, 17)
        Me.CB_usevsc_workgen.TabIndex = 22
        Me.CB_usevsc_workgen.Text = "Sincronizar copia en red con Volumen Shadow Copy (Requiere Cliente)"
        Me.CB_usevsc_workgen.UseVisualStyleBackColor = True
        '
        'CB_splitbackup_workgen
        '
        Me.CB_splitbackup_workgen.AutoSize = True
        Me.CB_splitbackup_workgen.Enabled = False
        Me.CB_splitbackup_workgen.Location = New System.Drawing.Point(11, 139)
        Me.CB_splitbackup_workgen.Name = "CB_splitbackup_workgen"
        Me.CB_splitbackup_workgen.Size = New System.Drawing.Size(219, 17)
        Me.CB_splitbackup_workgen.TabIndex = 21
        Me.CB_splitbackup_workgen.Text = "Crea Respaldo separado usando Fechas"
        Me.CB_splitbackup_workgen.UseVisualStyleBackColor = True
        '
        'CB_status_workgen
        '
        Me.CB_status_workgen.AutoSize = True
        Me.CB_status_workgen.Location = New System.Drawing.Point(320, 13)
        Me.CB_status_workgen.Name = "CB_status_workgen"
        Me.CB_status_workgen.Size = New System.Drawing.Size(56, 17)
        Me.CB_status_workgen.TabIndex = 20
        Me.CB_status_workgen.Text = "Activa"
        Me.CB_status_workgen.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(239, 13)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 13)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Estado Tarea"
        '
        'GB_tipo_respaldo
        '
        Me.GB_tipo_respaldo.Controls.Add(Me.RB_diferencial)
        Me.GB_tipo_respaldo.Controls.Add(Me.RB_incremental)
        Me.GB_tipo_respaldo.Controls.Add(Me.RB_completo)
        Me.GB_tipo_respaldo.Location = New System.Drawing.Point(9, 304)
        Me.GB_tipo_respaldo.Name = "GB_tipo_respaldo"
        Me.GB_tipo_respaldo.Size = New System.Drawing.Size(332, 57)
        Me.GB_tipo_respaldo.TabIndex = 18
        Me.GB_tipo_respaldo.TabStop = False
        Me.GB_tipo_respaldo.Text = "Tipo de Respaldo"
        '
        'RB_diferencial
        '
        Me.RB_diferencial.AutoSize = True
        Me.RB_diferencial.Enabled = False
        Me.RB_diferencial.Location = New System.Drawing.Point(134, 24)
        Me.RB_diferencial.Name = "RB_diferencial"
        Me.RB_diferencial.Size = New System.Drawing.Size(75, 17)
        Me.RB_diferencial.TabIndex = 2
        Me.RB_diferencial.TabStop = True
        Me.RB_diferencial.Text = "Diferencial"
        Me.RB_diferencial.UseVisualStyleBackColor = True
        '
        'RB_incremental
        '
        Me.RB_incremental.AutoSize = True
        Me.RB_incremental.Location = New System.Drawing.Point(11, 24)
        Me.RB_incremental.Name = "RB_incremental"
        Me.RB_incremental.Size = New System.Drawing.Size(80, 17)
        Me.RB_incremental.TabIndex = 1
        Me.RB_incremental.TabStop = True
        Me.RB_incremental.Text = "Incremental"
        Me.RB_incremental.UseVisualStyleBackColor = True
        '
        'RB_completo
        '
        Me.RB_completo.AutoSize = True
        Me.RB_completo.Location = New System.Drawing.Point(247, 24)
        Me.RB_completo.Name = "RB_completo"
        Me.RB_completo.Size = New System.Drawing.Size(69, 17)
        Me.RB_completo.TabIndex = 0
        Me.RB_completo.TabStop = True
        Me.RB_completo.Text = "Completo"
        Me.RB_completo.UseVisualStyleBackColor = True
        '
        'txt_id
        '
        Me.txt_id.Enabled = False
        Me.txt_id.Location = New System.Drawing.Point(144, 11)
        Me.txt_id.Name = "txt_id"
        Me.txt_id.Size = New System.Drawing.Size(43, 20)
        Me.txt_id.TabIndex = 17
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(18, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "ID"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(514, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Grupo"
        '
        'CB_GRUPOS
        '
        Me.CB_GRUPOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_GRUPOS.FormattingEnabled = True
        Me.CB_GRUPOS.Location = New System.Drawing.Point(594, 34)
        Me.CB_GRUPOS.Name = "CB_GRUPOS"
        Me.CB_GRUPOS.Size = New System.Drawing.Size(117, 21)
        Me.CB_GRUPOS.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(348, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Tipo Equipo"
        '
        'txt_mac_workgen
        '
        Me.txt_mac_workgen.Location = New System.Drawing.Point(594, 66)
        Me.txt_mac_workgen.Name = "txt_mac_workgen"
        Me.txt_mac_workgen.Size = New System.Drawing.Size(117, 20)
        Me.txt_mac_workgen.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(513, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Dirección MAC"
        '
        'CB_TYPE
        '
        Me.CB_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_TYPE.FormattingEnabled = True
        Me.CB_TYPE.Location = New System.Drawing.Point(414, 97)
        Me.CB_TYPE.Name = "CB_TYPE"
        Me.CB_TYPE.Size = New System.Drawing.Size(90, 21)
        Me.CB_TYPE.TabIndex = 10
        '
        'txt_user_workgen
        '
        Me.txt_user_workgen.Location = New System.Drawing.Point(144, 98)
        Me.txt_user_workgen.Name = "txt_user_workgen"
        Me.txt_user_workgen.Size = New System.Drawing.Size(197, 20)
        Me.txt_user_workgen.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 101)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(134, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Nombre Usuario en Equipo"
        '
        'txt_ip_workgen
        '
        Me.txt_ip_workgen.Location = New System.Drawing.Point(414, 66)
        Me.txt_ip_workgen.MaxLength = 15
        Me.txt_ip_workgen.Name = "txt_ip_workgen"
        Me.txt_ip_workgen.Size = New System.Drawing.Size(90, 20)
        Me.txt_ip_workgen.TabIndex = 5
        Me.txt_ip_workgen.Text = "192.168.100.100"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(348, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Dirección IP"
        '
        'txt_hostname
        '
        Me.txt_hostname.Location = New System.Drawing.Point(144, 66)
        Me.txt_hostname.Name = "txt_hostname"
        Me.txt_hostname.Size = New System.Drawing.Size(197, 20)
        Me.txt_hostname.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nombre Equipo"
        '
        'txt_name
        '
        Me.txt_name.Location = New System.Drawing.Point(144, 39)
        Me.txt_name.Name = "txt_name"
        Me.txt_name.Size = New System.Drawing.Size(336, 20)
        Me.txt_name.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre Tarea"
        '
        'TabPage_Archivos
        '
        Me.TabPage_Archivos.Controls.Add(Me.Button4)
        Me.TabPage_Archivos.Controls.Add(Me.Button5)
        Me.TabPage_Archivos.Controls.Add(Me.Button6)
        Me.TabPage_Archivos.Controls.Add(Me.LB_destinations)
        Me.TabPage_Archivos.Controls.Add(Me.LB_sources)
        Me.TabPage_Archivos.Controls.Add(Me.Label11)
        Me.TabPage_Archivos.Controls.Add(Me.Label10)
        Me.TabPage_Archivos.Controls.Add(Me.Button3)
        Me.TabPage_Archivos.Controls.Add(Me.Button2)
        Me.TabPage_Archivos.Controls.Add(Me.Button1)
        Me.TabPage_Archivos.Location = New System.Drawing.Point(4, 25)
        Me.TabPage_Archivos.Name = "TabPage_Archivos"
        Me.TabPage_Archivos.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Archivos.Size = New System.Drawing.Size(717, 409)
        Me.TabPage_Archivos.TabIndex = 1
        Me.TabPage_Archivos.Text = "Archivos"
        Me.TabPage_Archivos.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(261, 361)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 23
        Me.Button4.Text = "Borrar"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(136, 361)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 22
        Me.Button5.Text = "Editar"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(17, 361)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 21
        Me.Button6.Text = "Agregar"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'LB_destinations
        '
        Me.LB_destinations.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.LB_destinations.FormattingEnabled = True
        Me.LB_destinations.ItemHeight = 16
        Me.LB_destinations.Location = New System.Drawing.Point(19, 222)
        Me.LB_destinations.Name = "LB_destinations"
        Me.LB_destinations.Size = New System.Drawing.Size(678, 132)
        Me.LB_destinations.TabIndex = 20
        '
        'LB_sources
        '
        Me.LB_sources.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.LB_sources.FormattingEnabled = True
        Me.LB_sources.ItemHeight = 16
        Me.LB_sources.Location = New System.Drawing.Point(19, 29)
        Me.LB_sources.Name = "LB_sources"
        Me.LB_sources.Size = New System.Drawing.Size(678, 132)
        Me.LB_sources.TabIndex = 19
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label11.Location = New System.Drawing.Point(17, 203)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 17)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Destino"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label10.Location = New System.Drawing.Point(16, 5)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 17)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Fuente"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(261, 173)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Borrar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(136, 173)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Editar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(17, 173)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Agregar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TabPage_Filtros
        '
        Me.TabPage_Filtros.Controls.Add(Me.Label13)
        Me.TabPage_Filtros.Controls.Add(Me.Button10)
        Me.TabPage_Filtros.Controls.Add(Me.Button11)
        Me.TabPage_Filtros.Controls.Add(Me.Button12)
        Me.TabPage_Filtros.Controls.Add(Me.LB_filters_dir)
        Me.TabPage_Filtros.Controls.Add(Me.CB_incluir_predef)
        Me.TabPage_Filtros.Controls.Add(Me.LB_filters_masc)
        Me.TabPage_Filtros.Controls.Add(Me.Label12)
        Me.TabPage_Filtros.Controls.Add(Me.Button7)
        Me.TabPage_Filtros.Controls.Add(Me.Button8)
        Me.TabPage_Filtros.Controls.Add(Me.Button9)
        Me.TabPage_Filtros.Location = New System.Drawing.Point(4, 25)
        Me.TabPage_Filtros.Name = "TabPage_Filtros"
        Me.TabPage_Filtros.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Filtros.Size = New System.Drawing.Size(717, 409)
        Me.TabPage_Filtros.TabIndex = 2
        Me.TabPage_Filtros.Text = "Filtros"
        Me.TabPage_Filtros.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(14, 216)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(117, 13)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "Excluir estos directorios"
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(228, 380)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(75, 23)
        Me.Button10.TabIndex = 29
        Me.Button10.Text = "Borrar"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(129, 380)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(75, 23)
        Me.Button11.TabIndex = 28
        Me.Button11.Text = "Editar"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Button12
        '
        Me.Button12.Location = New System.Drawing.Point(18, 380)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(75, 23)
        Me.Button12.TabIndex = 27
        Me.Button12.Text = "Agregar"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'LB_filters_dir
        '
        Me.LB_filters_dir.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.LB_filters_dir.FormattingEnabled = True
        Me.LB_filters_dir.ItemHeight = 16
        Me.LB_filters_dir.Location = New System.Drawing.Point(17, 232)
        Me.LB_filters_dir.MultiColumn = True
        Me.LB_filters_dir.Name = "LB_filters_dir"
        Me.LB_filters_dir.Size = New System.Drawing.Size(694, 148)
        Me.LB_filters_dir.TabIndex = 26
        '
        'CB_incluir_predef
        '
        Me.CB_incluir_predef.AutoSize = True
        Me.CB_incluir_predef.Location = New System.Drawing.Point(568, 29)
        Me.CB_incluir_predef.Name = "CB_incluir_predef"
        Me.CB_incluir_predef.Size = New System.Drawing.Size(148, 17)
        Me.CB_incluir_predef.TabIndex = 25
        Me.CB_incluir_predef.Text = "Inclir Extensiones defaults"
        Me.CB_incluir_predef.UseVisualStyleBackColor = True
        '
        'LB_filters_masc
        '
        Me.LB_filters_masc.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.LB_filters_masc.FormattingEnabled = True
        Me.LB_filters_masc.ItemHeight = 16
        Me.LB_filters_masc.Location = New System.Drawing.Point(18, 29)
        Me.LB_filters_masc.MultiColumn = True
        Me.LB_filters_masc.Name = "LB_filters_masc"
        Me.LB_filters_masc.Size = New System.Drawing.Size(546, 148)
        Me.LB_filters_masc.TabIndex = 24
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 12)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(98, 13)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Excluir extenciones"
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(227, 185)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(75, 23)
        Me.Button7.TabIndex = 22
        Me.Button7.Text = "Borrar"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(128, 185)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 23)
        Me.Button8.TabIndex = 21
        Me.Button8.Text = "Editar"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(17, 185)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(75, 23)
        Me.Button9.TabIndex = 20
        Me.Button9.Text = "Agregar"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'BT_CANCELA
        '
        Me.BT_CANCELA.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.BT_CANCELA.Image = Global.Backup.My.Resources.Resources.cancelar
        Me.BT_CANCELA.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.BT_CANCELA.Location = New System.Drawing.Point(654, 449)
        Me.BT_CANCELA.Name = "BT_CANCELA"
        Me.BT_CANCELA.Size = New System.Drawing.Size(57, 58)
        Me.BT_CANCELA.TabIndex = 21
        '
        'BT_ACEPTA
        '
        Me.BT_ACEPTA.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.BT_ACEPTA.Image = Global.Backup.My.Resources.Resources.aceptar
        Me.BT_ACEPTA.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.BT_ACEPTA.Location = New System.Drawing.Point(587, 448)
        Me.BT_ACEPTA.Name = "BT_ACEPTA"
        Me.BT_ACEPTA.Size = New System.Drawing.Size(61, 58)
        Me.BT_ACEPTA.TabIndex = 20
        '
        'FRM_Tarea
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(749, 509)
        Me.Controls.Add(Me.BT_CANCELA)
        Me.Controls.Add(Me.BT_ACEPTA)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FRM_Tarea"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage_General.ResumeLayout(False)
        Me.TabPage_General.PerformLayout()
        Me.PANEL_userpasdomain.ResumeLayout(False)
        Me.PANEL_userpasdomain.PerformLayout()
        Me.GB_tipo_respaldo.ResumeLayout(False)
        Me.GB_tipo_respaldo.PerformLayout()
        Me.TabPage_Archivos.ResumeLayout(False)
        Me.TabPage_Archivos.PerformLayout()
        Me.TabPage_Filtros.ResumeLayout(False)
        Me.TabPage_Filtros.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage_General As System.Windows.Forms.TabPage
    Friend WithEvents TabPage_Archivos As System.Windows.Forms.TabPage
    Friend WithEvents BT_ACEPTA As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BT_CANCELA As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txt_ip_workgen As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_hostname As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_name As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_mac_workgen As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CB_TYPE As System.Windows.Forms.ComboBox
    Friend WithEvents txt_user_workgen As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CB_GRUPOS As System.Windows.Forms.ComboBox
    Friend WithEvents txt_id As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GB_tipo_respaldo As System.Windows.Forms.GroupBox
    Friend WithEvents RB_incremental As System.Windows.Forms.RadioButton
    Friend WithEvents RB_completo As System.Windows.Forms.RadioButton
    Friend WithEvents CB_status_workgen As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents RB_diferencial As System.Windows.Forms.RadioButton
    Friend WithEvents CB_usevsc_workgen As System.Windows.Forms.CheckBox
    Friend WithEvents CB_splitbackup_workgen As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents LB_destinations As System.Windows.Forms.ListBox
    Friend WithEvents LB_sources As System.Windows.Forms.ListBox
    Friend WithEvents TabPage_Filtros As System.Windows.Forms.TabPage
    Friend WithEvents CB_incluir_predef As System.Windows.Forms.CheckBox
    Protected WithEvents LB_filters_masc As System.Windows.Forms.ListBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Protected WithEvents LB_filters_dir As System.Windows.Forms.ListBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents CB_userpasdomain As System.Windows.Forms.CheckBox
    Friend WithEvents PANEL_userpasdomain As System.Windows.Forms.Panel
    Friend WithEvents txt2_password_workgen As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txt_password_workgen As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txt_domain_workgen As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txt_username_workgen As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Button13 As System.Windows.Forms.Button
End Class
