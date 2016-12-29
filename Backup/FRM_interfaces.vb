Public Class FRM_interfaces

    Private Sub FRM_interfaces_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = titulo_aplicacion & " Edita Interfaces de Red en equipo"

        Dim dt_interfaces As DataTable
        ''  Dim dts As New vworkgen
        Dim func As New fworkgen

        '' dt_interfaces.Clear()
        dt_interfaces = func.mostrar_interfaces_by_id(FRM_Principal.ID_SELECCIONADO)

        If dt_interfaces.Rows.Count <> 0 Then
            DG_interfaces.DataSource = dt_interfaces
        Else
            DG_interfaces.DataSource = Nothing
        End If


        DG_interfaces.Columns(0).Width = 20 ''Correl
        DG_interfaces.Columns(1).Width = 50  ''
        DG_interfaces.Columns(2).Width = 60 ''
        DG_interfaces.Columns(3).Width = 60 ''
        DG_interfaces.Columns(4).Width = 100 ''
        DG_interfaces.Columns(5).Width = 100 ''


        DG_interfaces.RowHeadersVisible = False  ''elimina la primera columna



    End Sub
End Class