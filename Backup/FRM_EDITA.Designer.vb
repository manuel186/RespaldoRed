<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_EDITA
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
        Me.BT_CANCELA = New DevExpress.XtraEditors.SimpleButton()
        Me.BT_ACEPTA = New DevExpress.XtraEditors.SimpleButton()
        Me.TB_EDITA = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'BT_CANCELA
        '
        Me.BT_CANCELA.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.BT_CANCELA.Image = Global.Backup.My.Resources.Resources.cancelar
        Me.BT_CANCELA.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.BT_CANCELA.Location = New System.Drawing.Point(369, 44)
        Me.BT_CANCELA.Name = "BT_CANCELA"
        Me.BT_CANCELA.Size = New System.Drawing.Size(57, 58)
        Me.BT_CANCELA.TabIndex = 23
        '
        'BT_ACEPTA
        '
        Me.BT_ACEPTA.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.BT_ACEPTA.Image = Global.Backup.My.Resources.Resources.aceptar
        Me.BT_ACEPTA.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.BT_ACEPTA.Location = New System.Drawing.Point(302, 44)
        Me.BT_ACEPTA.Name = "BT_ACEPTA"
        Me.BT_ACEPTA.Size = New System.Drawing.Size(61, 58)
        Me.BT_ACEPTA.TabIndex = 22
        '
        'TB_EDITA
        '
        Me.TB_EDITA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TB_EDITA.Location = New System.Drawing.Point(21, 12)
        Me.TB_EDITA.Name = "TB_EDITA"
        Me.TB_EDITA.Size = New System.Drawing.Size(684, 26)
        Me.TB_EDITA.TabIndex = 24
        '
        'FRM_EDITA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(742, 118)
        Me.Controls.Add(Me.TB_EDITA)
        Me.Controls.Add(Me.BT_CANCELA)
        Me.Controls.Add(Me.BT_ACEPTA)
        Me.Name = "FRM_EDITA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FRM_EDITA"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BT_CANCELA As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BT_ACEPTA As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TB_EDITA As System.Windows.Forms.TextBox
End Class
