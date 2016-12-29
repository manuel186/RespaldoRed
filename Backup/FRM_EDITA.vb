Public Class FRM_EDITA
    Public PASA As Boolean
    Public VALOR As String

    Private Sub BT_CANCELA_Click(sender As Object, e As EventArgs) Handles BT_CANCELA.Click
        PASA = False
        Me.Close()
    End Sub

    Private Sub FRM_EDITA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = titulo_aplicacion & " Edita "
        PASA = False
        TB_EDITA.Focus()
    End Sub

    Private Sub BT_ACEPTA_Click(sender As Object, e As EventArgs) Handles BT_ACEPTA.Click
        PASA = True
        VALOR = TB_EDITA.Text
        Me.Close()

    End Sub
End Class