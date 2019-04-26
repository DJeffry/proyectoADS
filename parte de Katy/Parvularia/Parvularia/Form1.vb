Public Class Form1
    Private Sub Inventario_de_AlimentosBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles Inventario_de_AlimentosBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.Inventario_de_AlimentosBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.ParvulariaDataSet)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'ParvulariaDataSet.Movimiento_de_alimentos' Puede moverla o quitarla según sea necesario.
        Me.Movimiento_de_alimentosTableAdapter.Fill(Me.ParvulariaDataSet.Movimiento_de_alimentos)
        'TODO: esta línea de código carga datos en la tabla 'ParvulariaDataSet.Inventario_de_Alimentos' Puede moverla o quitarla según sea necesario.
        Me.Inventario_de_AlimentosTableAdapter.Fill(Me.ParvulariaDataSet.Inventario_de_Alimentos)

    End Sub

    Private Sub Add_Click(sender As Object, e As EventArgs) Handles Add.Click
        Me.Inventario_de_AlimentosTableAdapter.AgregarAlimentos(ID_AlimentosTextBox.Text, NombreTextBox.Text, UnidadesTextBox.Text, CantidadTextBox.Text, SaldoTextBox.Text, Fecha_de_caducidadDateTimePicker.Text)



    End Sub

    Private Sub Agregar_Click(sender As Object, e As EventArgs) Handles Agregar.Click
        Me.Movimiento_de_alimentosTableAdapter.AgregarMovimiento(CódigoTextBox.Text, Fecha_de_ingresoDateTimePicker.Text, LoteTextBox.Text, Cantidad_AutorizadaTextBox.Text, Envase_o_EmpaqueTextBox.Text, Unidades_CompletasTextBox.Text, Unidades_FracciónTextBox.Text)
    End Sub
End Class
