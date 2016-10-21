<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_Principal
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_Principal))
        Me.Menu_Estado = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EjecutarTareaAhoraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevaTareaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarTareaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClonarTareaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BorrarTareaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer_Ping = New System.Windows.Forms.Timer(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ProgressBar_archivo = New System.Windows.Forms.ToolStripProgressBar()
        Me.ProgressBar_total = New System.Windows.Forms.ToolStripProgressBar()
        Me.TBcontrol1 = New System.Windows.Forms.TabControl()
        Me.TB_principal = New System.Windows.Forms.TabPage()
        Me.DBG_Det = New System.Windows.Forms.DataGridView()
        Me.DBG_TAREAS = New System.Windows.Forms.DataGridView()
        Me.TB_Config = New System.Windows.Forms.TabPage()
        Me.TXT_CLAVE_DOMINIO = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.TXT_USUARIO_DOMINIO = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.TXT_NOMBRE_DOMINIO = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.BT_MINIMIZAR = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenu_Abrir = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenu_configurar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenu_Salir = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.LB_log = New System.Windows.Forms.ListBox()
        Me.BT_STOP = New DevExpress.XtraEditors.SimpleButton()
        Me.BT_PLAY = New DevExpress.XtraEditors.SimpleButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Timer_Actualiza_Tareas = New System.Windows.Forms.Timer(Me.components)
        Me.Button4 = New System.Windows.Forms.Button()
        Me.BT_CERRAR = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Menu_Estado.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.TBcontrol1.SuspendLayout()
        Me.TB_principal.SuspendLayout()
        CType(Me.DBG_Det, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DBG_TAREAS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TB_Config.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Menu_Estado
        '
        Me.Menu_Estado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EjecutarTareaAhoraToolStripMenuItem, Me.ToolStripMenuItem2, Me.NuevaTareaToolStripMenuItem, Me.EditarTareaToolStripMenuItem1, Me.ClonarTareaToolStripMenuItem, Me.BorrarTareaToolStripMenuItem})
        Me.Menu_Estado.Name = "Menu_Estado"
        Me.Menu_Estado.Size = New System.Drawing.Size(184, 136)
        '
        'EjecutarTareaAhoraToolStripMenuItem
        '
        Me.EjecutarTareaAhoraToolStripMenuItem.Name = "EjecutarTareaAhoraToolStripMenuItem"
        Me.EjecutarTareaAhoraToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.EjecutarTareaAhoraToolStripMenuItem.Text = "Ejecutar Tarea Ahora"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(183, 22)
        Me.ToolStripMenuItem2.Text = "_______________"
        '
        'NuevaTareaToolStripMenuItem
        '
        Me.NuevaTareaToolStripMenuItem.Name = "NuevaTareaToolStripMenuItem"
        Me.NuevaTareaToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.NuevaTareaToolStripMenuItem.Text = "Nueva Tarea"
        '
        'EditarTareaToolStripMenuItem1
        '
        Me.EditarTareaToolStripMenuItem1.Name = "EditarTareaToolStripMenuItem1"
        Me.EditarTareaToolStripMenuItem1.Size = New System.Drawing.Size(183, 22)
        Me.EditarTareaToolStripMenuItem1.Text = "Editar Tarea"
        '
        'ClonarTareaToolStripMenuItem
        '
        Me.ClonarTareaToolStripMenuItem.Name = "ClonarTareaToolStripMenuItem"
        Me.ClonarTareaToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.ClonarTareaToolStripMenuItem.Text = "Clonar Tarea"
        '
        'BorrarTareaToolStripMenuItem
        '
        Me.BorrarTareaToolStripMenuItem.Name = "BorrarTareaToolStripMenuItem"
        Me.BorrarTareaToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.BorrarTareaToolStripMenuItem.Text = "Borrar Tarea"
        '
        'Timer_Ping
        '
        Me.Timer_Ping.Enabled = True
        Me.Timer_Ping.Interval = 1000
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ProgressBar_archivo, Me.ProgressBar_total})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 709)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1350, 31)
        Me.StatusStrip1.TabIndex = 15
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.AutoSize = False
        Me.ToolStripStatusLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(1000, 26)
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ProgressBar_archivo
        '
        Me.ProgressBar_archivo.Name = "ProgressBar_archivo"
        Me.ProgressBar_archivo.Size = New System.Drawing.Size(150, 25)
        '
        'ProgressBar_total
        '
        Me.ProgressBar_total.Name = "ProgressBar_total"
        Me.ProgressBar_total.Size = New System.Drawing.Size(150, 25)
        '
        'TBcontrol1
        '
        Me.TBcontrol1.Controls.Add(Me.TB_principal)
        Me.TBcontrol1.Controls.Add(Me.TB_Config)
        Me.TBcontrol1.Location = New System.Drawing.Point(-1, 53)
        Me.TBcontrol1.Name = "TBcontrol1"
        Me.TBcontrol1.SelectedIndex = 0
        Me.TBcontrol1.Size = New System.Drawing.Size(1364, 410)
        Me.TBcontrol1.TabIndex = 16
        '
        'TB_principal
        '
        Me.TB_principal.Controls.Add(Me.DBG_Det)
        Me.TB_principal.Controls.Add(Me.DBG_TAREAS)
        Me.TB_principal.Location = New System.Drawing.Point(4, 22)
        Me.TB_principal.Name = "TB_principal"
        Me.TB_principal.Padding = New System.Windows.Forms.Padding(3)
        Me.TB_principal.Size = New System.Drawing.Size(1356, 384)
        Me.TB_principal.TabIndex = 0
        Me.TB_principal.Text = "Principal"
        Me.TB_principal.UseVisualStyleBackColor = True
        '
        'DBG_Det
        '
        Me.DBG_Det.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DBG_Det.Location = New System.Drawing.Point(983, 6)
        Me.DBG_Det.Name = "DBG_Det"
        Me.DBG_Det.Size = New System.Drawing.Size(351, 372)
        Me.DBG_Det.TabIndex = 20
        '
        'DBG_TAREAS
        '
        Me.DBG_TAREAS.AllowUserToDeleteRows = False
        Me.DBG_TAREAS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DBG_TAREAS.ContextMenuStrip = Me.Menu_Estado
        Me.DBG_TAREAS.Location = New System.Drawing.Point(6, 6)
        Me.DBG_TAREAS.Name = "DBG_TAREAS"
        Me.DBG_TAREAS.ReadOnly = True
        Me.DBG_TAREAS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DBG_TAREAS.Size = New System.Drawing.Size(965, 372)
        Me.DBG_TAREAS.TabIndex = 1
        '
        'TB_Config
        '
        Me.TB_Config.Controls.Add(Me.TXT_CLAVE_DOMINIO)
        Me.TB_Config.Controls.Add(Me.Label45)
        Me.TB_Config.Controls.Add(Me.TXT_USUARIO_DOMINIO)
        Me.TB_Config.Controls.Add(Me.Label31)
        Me.TB_Config.Controls.Add(Me.TXT_NOMBRE_DOMINIO)
        Me.TB_Config.Controls.Add(Me.Label21)
        Me.TB_Config.Location = New System.Drawing.Point(4, 22)
        Me.TB_Config.Name = "TB_Config"
        Me.TB_Config.Padding = New System.Windows.Forms.Padding(3)
        Me.TB_Config.Size = New System.Drawing.Size(1356, 384)
        Me.TB_Config.TabIndex = 1
        Me.TB_Config.Text = "Configuración"
        Me.TB_Config.UseVisualStyleBackColor = True
        '
        'TXT_CLAVE_DOMINIO
        '
        Me.TXT_CLAVE_DOMINIO.Location = New System.Drawing.Point(149, 114)
        Me.TXT_CLAVE_DOMINIO.Name = "TXT_CLAVE_DOMINIO"
        Me.TXT_CLAVE_DOMINIO.Size = New System.Drawing.Size(178, 20)
        Me.TXT_CLAVE_DOMINIO.TabIndex = 7
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(6, 117)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(133, 13)
        Me.Label45.TabIndex = 6
        Me.Label45.Text = "Clave cuenta de Respaldo"
        '
        'TXT_USUARIO_DOMINIO
        '
        Me.TXT_USUARIO_DOMINIO.Location = New System.Drawing.Point(149, 84)
        Me.TXT_USUARIO_DOMINIO.Name = "TXT_USUARIO_DOMINIO"
        Me.TXT_USUARIO_DOMINIO.Size = New System.Drawing.Size(178, 20)
        Me.TXT_USUARIO_DOMINIO.TabIndex = 5
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(6, 88)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(104, 13)
        Me.Label31.TabIndex = 4
        Me.Label31.Text = "Cuenta de Respaldo"
        '
        'TXT_NOMBRE_DOMINIO
        '
        Me.TXT_NOMBRE_DOMINIO.Location = New System.Drawing.Point(149, 58)
        Me.TXT_NOMBRE_DOMINIO.Name = "TXT_NOMBRE_DOMINIO"
        Me.TXT_NOMBRE_DOMINIO.Size = New System.Drawing.Size(178, 20)
        Me.TXT_NOMBRE_DOMINIO.TabIndex = 3
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 61)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(45, 13)
        Me.Label21.TabIndex = 2
        Me.Label21.Text = "Dominio"
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(437, 32)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 23)
        Me.Button8.TabIndex = 22
        Me.Button8.Text = "Actualiza Tabla"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'BT_MINIMIZAR
        '
        Me.BT_MINIMIZAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.BT_MINIMIZAR.Location = New System.Drawing.Point(1247, -1)
        Me.BT_MINIMIZAR.Name = "BT_MINIMIZAR"
        Me.BT_MINIMIZAR.Size = New System.Drawing.Size(32, 26)
        Me.BT_MINIMIZAR.TabIndex = 21
        Me.BT_MINIMIZAR.Text = "-"
        Me.BT_MINIMIZAR.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenu_Abrir, Me.ToolStripMenu_configurar, Me.ToolStripMenu_Salir})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(151, 70)
        '
        'ToolStripMenu_Abrir
        '
        Me.ToolStripMenu_Abrir.Name = "ToolStripMenu_Abrir"
        Me.ToolStripMenu_Abrir.Size = New System.Drawing.Size(150, 22)
        Me.ToolStripMenu_Abrir.Text = "Abrir"
        '
        'ToolStripMenu_configurar
        '
        Me.ToolStripMenu_configurar.Name = "ToolStripMenu_configurar"
        Me.ToolStripMenu_configurar.Size = New System.Drawing.Size(150, 22)
        Me.ToolStripMenu_configurar.Text = "Configuración"
        '
        'ToolStripMenu_Salir
        '
        Me.ToolStripMenu_Salir.Name = "ToolStripMenu_Salir"
        Me.ToolStripMenu_Salir.Size = New System.Drawing.Size(150, 22)
        Me.ToolStripMenu_Salir.Text = "Salir"
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'LB_log
        '
        Me.LB_log.FormattingEnabled = True
        Me.LB_log.Location = New System.Drawing.Point(1, 468)
        Me.LB_log.Name = "LB_log"
        Me.LB_log.Size = New System.Drawing.Size(1349, 212)
        Me.LB_log.TabIndex = 18
        '
        'BT_STOP
        '
        Me.BT_STOP.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.BT_STOP.Image = Global.Backup.My.Resources.Resources._stop
        Me.BT_STOP.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.BT_STOP.Location = New System.Drawing.Point(84, 2)
        Me.BT_STOP.Name = "BT_STOP"
        Me.BT_STOP.Size = New System.Drawing.Size(45, 45)
        Me.BT_STOP.TabIndex = 20
        '
        'BT_PLAY
        '
        Me.BT_PLAY.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.BT_PLAY.Image = Global.Backup.My.Resources.Resources.Play
        Me.BT_PLAY.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.BT_PLAY.Location = New System.Drawing.Point(23, 2)
        Me.BT_PLAY.Name = "BT_PLAY"
        Me.BT_PLAY.Size = New System.Drawing.Size(45, 45)
        Me.BT_PLAY.TabIndex = 19
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(451, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 26
        Me.Button1.Text = "Ping"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(558, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Label5"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(558, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Label3"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(558, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Label2"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(206, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Label4"
        '
        'Timer_Actualiza_Tareas
        '
        Me.Timer_Actualiza_Tareas.Interval = 1000
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(325, 7)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 18
        Me.Button4.Text = "Tamaña dce carpeta"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'BT_CERRAR
        '
        Me.BT_CERRAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.BT_CERRAR.Location = New System.Drawing.Point(1285, -1)
        Me.BT_CERRAR.Name = "BT_CERRAR"
        Me.BT_CERRAR.Size = New System.Drawing.Size(32, 26)
        Me.BT_CERRAR.TabIndex = 32
        Me.BT_CERRAR.Text = "X"
        Me.BT_CERRAR.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(199, 37)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 33
        Me.Button2.Text = "Tamaña dce carpeta"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'FRM_Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1350, 740)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.BT_CERRAR)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.BT_MINIMIZAR)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.BT_STOP)
        Me.Controls.Add(Me.BT_PLAY)
        Me.Controls.Add(Me.LB_log)
        Me.Controls.Add(Me.TBcontrol1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FRM_Principal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.Menu_Estado.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TBcontrol1.ResumeLayout(False)
        Me.TB_principal.ResumeLayout(False)
        CType(Me.DBG_Det, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DBG_TAREAS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TB_Config.ResumeLayout(False)
        Me.TB_Config.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer_Ping As System.Windows.Forms.Timer
    Friend WithEvents Menu_Estado As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EjecutarTareaAhoraToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevaTareaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ProgressBar_archivo As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ProgressBar_total As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents TBcontrol1 As System.Windows.Forms.TabControl
    Friend WithEvents TB_principal As System.Windows.Forms.TabPage
    Friend WithEvents TB_Config As System.Windows.Forms.TabPage
    Friend WithEvents DBG_TAREAS As System.Windows.Forms.DataGridView
    Friend WithEvents DBG_Det As System.Windows.Forms.DataGridView
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenu_Abrir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenu_configurar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenu_Salir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents BT_MINIMIZAR As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents LB_log As System.Windows.Forms.ListBox
    Friend WithEvents BT_PLAY As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BT_STOP As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents EditarTareaToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TXT_CLAVE_DOMINIO As System.Windows.Forms.TextBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents TXT_USUARIO_DOMINIO As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents TXT_NOMBRE_DOMINIO As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ClonarTareaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BorrarTareaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer_Actualiza_Tareas As System.Windows.Forms.Timer
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents BT_CERRAR As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button



End Class
