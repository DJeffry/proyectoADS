<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim ID_AlimentosLabel As System.Windows.Forms.Label
        Dim NombreLabel As System.Windows.Forms.Label
        Dim UnidadesLabel As System.Windows.Forms.Label
        Dim CantidadLabel As System.Windows.Forms.Label
        Dim SaldoLabel As System.Windows.Forms.Label
        Dim Fecha_de_caducidadLabel As System.Windows.Forms.Label
        Dim CódigoLabel As System.Windows.Forms.Label
        Dim Fecha_de_ingresoLabel As System.Windows.Forms.Label
        Dim LoteLabel As System.Windows.Forms.Label
        Dim Cantidad_AutorizadaLabel As System.Windows.Forms.Label
        Dim Envase_o_EmpaqueLabel As System.Windows.Forms.Label
        Dim Unidades_CompletasLabel As System.Windows.Forms.Label
        Dim Unidades_FracciónLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.sup = New System.Windows.Forms.Button()
        Me.search = New System.Windows.Forms.Button()
        Me.Add = New System.Windows.Forms.Button()
        Me.ID_AlimentosTextBox = New System.Windows.Forms.TextBox()
        Me.NombreTextBox = New System.Windows.Forms.TextBox()
        Me.UnidadesTextBox = New System.Windows.Forms.TextBox()
        Me.CantidadTextBox = New System.Windows.Forms.TextBox()
        Me.SaldoTextBox = New System.Windows.Forms.TextBox()
        Me.Fecha_de_caducidadDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Agregar = New System.Windows.Forms.Button()
        Me.Buscar = New System.Windows.Forms.Button()
        Me.Eliminar = New System.Windows.Forms.Button()
        Me.CódigoTextBox = New System.Windows.Forms.TextBox()
        Me.Fecha_de_ingresoDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.LoteTextBox = New System.Windows.Forms.TextBox()
        Me.Cantidad_AutorizadaTextBox = New System.Windows.Forms.TextBox()
        Me.Envase_o_EmpaqueTextBox = New System.Windows.Forms.TextBox()
        Me.Unidades_CompletasTextBox = New System.Windows.Forms.TextBox()
        Me.Unidades_FracciónTextBox = New System.Windows.Forms.TextBox()
        Me.Inventario_de_AlimentosBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Inventario_de_AlimentosBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.Inventario_de_AlimentosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ParvulariaDataSet = New Parvularia.ParvulariaDataSet()
        Me.Movimiento_de_alimentosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Inventario_de_AlimentosTableAdapter = New Parvularia.ParvulariaDataSetTableAdapters.Inventario_de_AlimentosTableAdapter()
        Me.TableAdapterManager = New Parvularia.ParvulariaDataSetTableAdapters.TableAdapterManager()
        Me.Movimiento_de_alimentosTableAdapter = New Parvularia.ParvulariaDataSetTableAdapters.Movimiento_de_alimentosTableAdapter()
        ID_AlimentosLabel = New System.Windows.Forms.Label()
        NombreLabel = New System.Windows.Forms.Label()
        UnidadesLabel = New System.Windows.Forms.Label()
        CantidadLabel = New System.Windows.Forms.Label()
        SaldoLabel = New System.Windows.Forms.Label()
        Fecha_de_caducidadLabel = New System.Windows.Forms.Label()
        CódigoLabel = New System.Windows.Forms.Label()
        Fecha_de_ingresoLabel = New System.Windows.Forms.Label()
        LoteLabel = New System.Windows.Forms.Label()
        Cantidad_AutorizadaLabel = New System.Windows.Forms.Label()
        Envase_o_EmpaqueLabel = New System.Windows.Forms.Label()
        Unidades_CompletasLabel = New System.Windows.Forms.Label()
        Unidades_FracciónLabel = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.Inventario_de_AlimentosBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Inventario_de_AlimentosBindingNavigator.SuspendLayout()
        CType(Me.Inventario_de_AlimentosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ParvulariaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Movimiento_de_alimentosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ID_AlimentosLabel
        '
        ID_AlimentosLabel.AutoSize = True
        ID_AlimentosLabel.Location = New System.Drawing.Point(27, 25)
        ID_AlimentosLabel.Name = "ID_AlimentosLabel"
        ID_AlimentosLabel.Size = New System.Drawing.Size(69, 13)
        ID_AlimentosLabel.TabIndex = 0
        ID_AlimentosLabel.Text = "ID Alimentos:"
        '
        'NombreLabel
        '
        NombreLabel.AutoSize = True
        NombreLabel.Location = New System.Drawing.Point(27, 51)
        NombreLabel.Name = "NombreLabel"
        NombreLabel.Size = New System.Drawing.Size(47, 13)
        NombreLabel.TabIndex = 2
        NombreLabel.Text = "Nombre:"
        '
        'UnidadesLabel
        '
        UnidadesLabel.AutoSize = True
        UnidadesLabel.Location = New System.Drawing.Point(27, 77)
        UnidadesLabel.Name = "UnidadesLabel"
        UnidadesLabel.Size = New System.Drawing.Size(55, 13)
        UnidadesLabel.TabIndex = 4
        UnidadesLabel.Text = "Unidades:"
        '
        'CantidadLabel
        '
        CantidadLabel.AutoSize = True
        CantidadLabel.Location = New System.Drawing.Point(27, 103)
        CantidadLabel.Name = "CantidadLabel"
        CantidadLabel.Size = New System.Drawing.Size(52, 13)
        CantidadLabel.TabIndex = 6
        CantidadLabel.Text = "Cantidad:"
        '
        'SaldoLabel
        '
        SaldoLabel.AutoSize = True
        SaldoLabel.Location = New System.Drawing.Point(27, 129)
        SaldoLabel.Name = "SaldoLabel"
        SaldoLabel.Size = New System.Drawing.Size(37, 13)
        SaldoLabel.TabIndex = 8
        SaldoLabel.Text = "Saldo:"
        '
        'Fecha_de_caducidadLabel
        '
        Fecha_de_caducidadLabel.AutoSize = True
        Fecha_de_caducidadLabel.Location = New System.Drawing.Point(27, 156)
        Fecha_de_caducidadLabel.Name = "Fecha_de_caducidadLabel"
        Fecha_de_caducidadLabel.Size = New System.Drawing.Size(108, 13)
        Fecha_de_caducidadLabel.TabIndex = 10
        Fecha_de_caducidadLabel.Text = "Fecha de caducidad:"
        '
        'CódigoLabel
        '
        CódigoLabel.AutoSize = True
        CódigoLabel.Location = New System.Drawing.Point(29, 27)
        CódigoLabel.Name = "CódigoLabel"
        CódigoLabel.Size = New System.Drawing.Size(43, 13)
        CódigoLabel.TabIndex = 0
        CódigoLabel.Text = "Código:"
        '
        'Fecha_de_ingresoLabel
        '
        Fecha_de_ingresoLabel.AutoSize = True
        Fecha_de_ingresoLabel.Location = New System.Drawing.Point(29, 54)
        Fecha_de_ingresoLabel.Name = "Fecha_de_ingresoLabel"
        Fecha_de_ingresoLabel.Size = New System.Drawing.Size(92, 13)
        Fecha_de_ingresoLabel.TabIndex = 2
        Fecha_de_ingresoLabel.Text = "Fecha de ingreso:"
        '
        'LoteLabel
        '
        LoteLabel.AutoSize = True
        LoteLabel.Location = New System.Drawing.Point(29, 79)
        LoteLabel.Name = "LoteLabel"
        LoteLabel.Size = New System.Drawing.Size(31, 13)
        LoteLabel.TabIndex = 4
        LoteLabel.Text = "Lote:"
        '
        'Cantidad_AutorizadaLabel
        '
        Cantidad_AutorizadaLabel.AutoSize = True
        Cantidad_AutorizadaLabel.Location = New System.Drawing.Point(29, 105)
        Cantidad_AutorizadaLabel.Name = "Cantidad_AutorizadaLabel"
        Cantidad_AutorizadaLabel.Size = New System.Drawing.Size(105, 13)
        Cantidad_AutorizadaLabel.TabIndex = 6
        Cantidad_AutorizadaLabel.Text = "Cantidad Autorizada:"
        '
        'Envase_o_EmpaqueLabel
        '
        Envase_o_EmpaqueLabel.AutoSize = True
        Envase_o_EmpaqueLabel.Location = New System.Drawing.Point(29, 131)
        Envase_o_EmpaqueLabel.Name = "Envase_o_EmpaqueLabel"
        Envase_o_EmpaqueLabel.Size = New System.Drawing.Size(103, 13)
        Envase_o_EmpaqueLabel.TabIndex = 8
        Envase_o_EmpaqueLabel.Text = "Envase o Empaque:"
        '
        'Unidades_CompletasLabel
        '
        Unidades_CompletasLabel.AutoSize = True
        Unidades_CompletasLabel.Location = New System.Drawing.Point(29, 157)
        Unidades_CompletasLabel.Name = "Unidades_CompletasLabel"
        Unidades_CompletasLabel.Size = New System.Drawing.Size(107, 13)
        Unidades_CompletasLabel.TabIndex = 10
        Unidades_CompletasLabel.Text = "Unidades Completas:"
        '
        'Unidades_FracciónLabel
        '
        Unidades_FracciónLabel.AutoSize = True
        Unidades_FracciónLabel.Location = New System.Drawing.Point(29, 183)
        Unidades_FracciónLabel.Name = "Unidades_FracciónLabel"
        Unidades_FracciónLabel.Size = New System.Drawing.Size(99, 13)
        Unidades_FracciónLabel.TabIndex = 12
        Unidades_FracciónLabel.Text = "Unidades Fracción:"
        '
        'TabControl1
        '
        Me.TabControl1.AccessibleName = ""
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(381, 409)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Transparent
        Me.TabPage1.Controls.Add(Me.sup)
        Me.TabPage1.Controls.Add(Me.search)
        Me.TabPage1.Controls.Add(Me.Add)
        Me.TabPage1.Controls.Add(ID_AlimentosLabel)
        Me.TabPage1.Controls.Add(Me.ID_AlimentosTextBox)
        Me.TabPage1.Controls.Add(NombreLabel)
        Me.TabPage1.Controls.Add(Me.NombreTextBox)
        Me.TabPage1.Controls.Add(UnidadesLabel)
        Me.TabPage1.Controls.Add(Me.UnidadesTextBox)
        Me.TabPage1.Controls.Add(CantidadLabel)
        Me.TabPage1.Controls.Add(Me.CantidadTextBox)
        Me.TabPage1.Controls.Add(SaldoLabel)
        Me.TabPage1.Controls.Add(Me.SaldoTextBox)
        Me.TabPage1.Controls.Add(Fecha_de_caducidadLabel)
        Me.TabPage1.Controls.Add(Me.Fecha_de_caducidadDateTimePicker)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(373, 383)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Inventario de Alimentos"
        '
        'sup
        '
        Me.sup.Location = New System.Drawing.Point(241, 333)
        Me.sup.Name = "sup"
        Me.sup.Size = New System.Drawing.Size(75, 23)
        Me.sup.TabIndex = 14
        Me.sup.Text = "Eliminar"
        Me.sup.UseVisualStyleBackColor = True
        '
        'search
        '
        Me.search.Location = New System.Drawing.Point(141, 333)
        Me.search.Name = "search"
        Me.search.Size = New System.Drawing.Size(75, 23)
        Me.search.TabIndex = 13
        Me.search.Text = "Buscar"
        Me.search.UseVisualStyleBackColor = True
        '
        'Add
        '
        Me.Add.Location = New System.Drawing.Point(30, 333)
        Me.Add.Name = "Add"
        Me.Add.Size = New System.Drawing.Size(75, 23)
        Me.Add.TabIndex = 12
        Me.Add.Text = "Agregar"
        Me.Add.UseVisualStyleBackColor = True
        '
        'ID_AlimentosTextBox
        '
        Me.ID_AlimentosTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Inventario_de_AlimentosBindingSource, "ID_Alimentos", True))
        Me.ID_AlimentosTextBox.Location = New System.Drawing.Point(141, 22)
        Me.ID_AlimentosTextBox.Name = "ID_AlimentosTextBox"
        Me.ID_AlimentosTextBox.Size = New System.Drawing.Size(200, 20)
        Me.ID_AlimentosTextBox.TabIndex = 1
        '
        'NombreTextBox
        '
        Me.NombreTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Inventario_de_AlimentosBindingSource, "Nombre", True))
        Me.NombreTextBox.Location = New System.Drawing.Point(141, 48)
        Me.NombreTextBox.Name = "NombreTextBox"
        Me.NombreTextBox.Size = New System.Drawing.Size(200, 20)
        Me.NombreTextBox.TabIndex = 3
        '
        'UnidadesTextBox
        '
        Me.UnidadesTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Inventario_de_AlimentosBindingSource, "Unidades", True))
        Me.UnidadesTextBox.Location = New System.Drawing.Point(141, 74)
        Me.UnidadesTextBox.Name = "UnidadesTextBox"
        Me.UnidadesTextBox.Size = New System.Drawing.Size(200, 20)
        Me.UnidadesTextBox.TabIndex = 5
        '
        'CantidadTextBox
        '
        Me.CantidadTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Inventario_de_AlimentosBindingSource, "Cantidad", True))
        Me.CantidadTextBox.Location = New System.Drawing.Point(141, 100)
        Me.CantidadTextBox.Name = "CantidadTextBox"
        Me.CantidadTextBox.Size = New System.Drawing.Size(200, 20)
        Me.CantidadTextBox.TabIndex = 7
        '
        'SaldoTextBox
        '
        Me.SaldoTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Inventario_de_AlimentosBindingSource, "Saldo", True))
        Me.SaldoTextBox.Location = New System.Drawing.Point(141, 126)
        Me.SaldoTextBox.Name = "SaldoTextBox"
        Me.SaldoTextBox.Size = New System.Drawing.Size(200, 20)
        Me.SaldoTextBox.TabIndex = 9
        '
        'Fecha_de_caducidadDateTimePicker
        '
        Me.Fecha_de_caducidadDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.Inventario_de_AlimentosBindingSource, "Fecha de caducidad", True))
        Me.Fecha_de_caducidadDateTimePicker.Location = New System.Drawing.Point(141, 152)
        Me.Fecha_de_caducidadDateTimePicker.Name = "Fecha_de_caducidadDateTimePicker"
        Me.Fecha_de_caducidadDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.Fecha_de_caducidadDateTimePicker.TabIndex = 11
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Transparent
        Me.TabPage2.Controls.Add(Me.Agregar)
        Me.TabPage2.Controls.Add(Me.Buscar)
        Me.TabPage2.Controls.Add(Me.Eliminar)
        Me.TabPage2.Controls.Add(CódigoLabel)
        Me.TabPage2.Controls.Add(Me.CódigoTextBox)
        Me.TabPage2.Controls.Add(Fecha_de_ingresoLabel)
        Me.TabPage2.Controls.Add(Me.Fecha_de_ingresoDateTimePicker)
        Me.TabPage2.Controls.Add(LoteLabel)
        Me.TabPage2.Controls.Add(Me.LoteTextBox)
        Me.TabPage2.Controls.Add(Cantidad_AutorizadaLabel)
        Me.TabPage2.Controls.Add(Me.Cantidad_AutorizadaTextBox)
        Me.TabPage2.Controls.Add(Envase_o_EmpaqueLabel)
        Me.TabPage2.Controls.Add(Me.Envase_o_EmpaqueTextBox)
        Me.TabPage2.Controls.Add(Unidades_CompletasLabel)
        Me.TabPage2.Controls.Add(Me.Unidades_CompletasTextBox)
        Me.TabPage2.Controls.Add(Unidades_FracciónLabel)
        Me.TabPage2.Controls.Add(Me.Unidades_FracciónTextBox)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(373, 383)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Movimiento de alimentos"
        '
        'Agregar
        '
        Me.Agregar.Location = New System.Drawing.Point(32, 317)
        Me.Agregar.Name = "Agregar"
        Me.Agregar.Size = New System.Drawing.Size(75, 23)
        Me.Agregar.TabIndex = 2
        Me.Agregar.Text = "Agregar"
        Me.Agregar.UseVisualStyleBackColor = True
        '
        'Buscar
        '
        Me.Buscar.Location = New System.Drawing.Point(142, 317)
        Me.Buscar.Name = "Buscar"
        Me.Buscar.Size = New System.Drawing.Size(75, 23)
        Me.Buscar.TabIndex = 3
        Me.Buscar.Text = "Buscar"
        Me.Buscar.UseVisualStyleBackColor = True
        '
        'Eliminar
        '
        Me.Eliminar.Location = New System.Drawing.Point(251, 317)
        Me.Eliminar.Name = "Eliminar"
        Me.Eliminar.Size = New System.Drawing.Size(75, 23)
        Me.Eliminar.TabIndex = 4
        Me.Eliminar.Text = "Eliminar"
        Me.Eliminar.UseVisualStyleBackColor = True
        '
        'CódigoTextBox
        '
        Me.CódigoTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Movimiento_de_alimentosBindingSource, "Código", True))
        Me.CódigoTextBox.Location = New System.Drawing.Point(142, 24)
        Me.CódigoTextBox.Name = "CódigoTextBox"
        Me.CódigoTextBox.Size = New System.Drawing.Size(200, 20)
        Me.CódigoTextBox.TabIndex = 1
        '
        'Fecha_de_ingresoDateTimePicker
        '
        Me.Fecha_de_ingresoDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.Movimiento_de_alimentosBindingSource, "Fecha de ingreso", True))
        Me.Fecha_de_ingresoDateTimePicker.Location = New System.Drawing.Point(142, 50)
        Me.Fecha_de_ingresoDateTimePicker.Name = "Fecha_de_ingresoDateTimePicker"
        Me.Fecha_de_ingresoDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.Fecha_de_ingresoDateTimePicker.TabIndex = 3
        '
        'LoteTextBox
        '
        Me.LoteTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Movimiento_de_alimentosBindingSource, "Lote", True))
        Me.LoteTextBox.Location = New System.Drawing.Point(142, 76)
        Me.LoteTextBox.Name = "LoteTextBox"
        Me.LoteTextBox.Size = New System.Drawing.Size(200, 20)
        Me.LoteTextBox.TabIndex = 5
        '
        'Cantidad_AutorizadaTextBox
        '
        Me.Cantidad_AutorizadaTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Movimiento_de_alimentosBindingSource, "Cantidad Autorizada", True))
        Me.Cantidad_AutorizadaTextBox.Location = New System.Drawing.Point(142, 102)
        Me.Cantidad_AutorizadaTextBox.Name = "Cantidad_AutorizadaTextBox"
        Me.Cantidad_AutorizadaTextBox.Size = New System.Drawing.Size(200, 20)
        Me.Cantidad_AutorizadaTextBox.TabIndex = 7
        '
        'Envase_o_EmpaqueTextBox
        '
        Me.Envase_o_EmpaqueTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Movimiento_de_alimentosBindingSource, "Envase o Empaque", True))
        Me.Envase_o_EmpaqueTextBox.Location = New System.Drawing.Point(142, 128)
        Me.Envase_o_EmpaqueTextBox.Name = "Envase_o_EmpaqueTextBox"
        Me.Envase_o_EmpaqueTextBox.Size = New System.Drawing.Size(200, 20)
        Me.Envase_o_EmpaqueTextBox.TabIndex = 9
        '
        'Unidades_CompletasTextBox
        '
        Me.Unidades_CompletasTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Movimiento_de_alimentosBindingSource, "Unidades Completas", True))
        Me.Unidades_CompletasTextBox.Location = New System.Drawing.Point(142, 154)
        Me.Unidades_CompletasTextBox.Name = "Unidades_CompletasTextBox"
        Me.Unidades_CompletasTextBox.Size = New System.Drawing.Size(200, 20)
        Me.Unidades_CompletasTextBox.TabIndex = 11
        '
        'Unidades_FracciónTextBox
        '
        Me.Unidades_FracciónTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Movimiento_de_alimentosBindingSource, "Unidades Fracción", True))
        Me.Unidades_FracciónTextBox.Location = New System.Drawing.Point(142, 180)
        Me.Unidades_FracciónTextBox.Name = "Unidades_FracciónTextBox"
        Me.Unidades_FracciónTextBox.Size = New System.Drawing.Size(200, 20)
        Me.Unidades_FracciónTextBox.TabIndex = 13
        '
        'Inventario_de_AlimentosBindingNavigator
        '
        Me.Inventario_de_AlimentosBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.Inventario_de_AlimentosBindingNavigator.BindingSource = Me.Inventario_de_AlimentosBindingSource
        Me.Inventario_de_AlimentosBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.Inventario_de_AlimentosBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.Inventario_de_AlimentosBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.Inventario_de_AlimentosBindingNavigatorSaveItem})
        Me.Inventario_de_AlimentosBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.Inventario_de_AlimentosBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.Inventario_de_AlimentosBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.Inventario_de_AlimentosBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.Inventario_de_AlimentosBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.Inventario_de_AlimentosBindingNavigator.Name = "Inventario_de_AlimentosBindingNavigator"
        Me.Inventario_de_AlimentosBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.Inventario_de_AlimentosBindingNavigator.Size = New System.Drawing.Size(522, 25)
        Me.Inventario_de_AlimentosBindingNavigator.TabIndex = 1
        Me.Inventario_de_AlimentosBindingNavigator.Text = "BindingNavigator1"
        Me.Inventario_de_AlimentosBindingNavigator.Visible = False
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Agregar nuevo"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(37, 22)
        Me.BindingNavigatorCountItem.Text = "de {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Número total de elementos"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Eliminar"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Mover primero"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Mover anterior"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Posición"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Posición actual"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Mover siguiente"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Mover último"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'Inventario_de_AlimentosBindingNavigatorSaveItem
        '
        Me.Inventario_de_AlimentosBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Inventario_de_AlimentosBindingNavigatorSaveItem.Image = CType(resources.GetObject("Inventario_de_AlimentosBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.Inventario_de_AlimentosBindingNavigatorSaveItem.Name = "Inventario_de_AlimentosBindingNavigatorSaveItem"
        Me.Inventario_de_AlimentosBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.Inventario_de_AlimentosBindingNavigatorSaveItem.Text = "Guardar datos"
        '
        'Inventario_de_AlimentosBindingSource
        '
        Me.Inventario_de_AlimentosBindingSource.DataMember = "Inventario de Alimentos"
        Me.Inventario_de_AlimentosBindingSource.DataSource = Me.ParvulariaDataSet
        '
        'ParvulariaDataSet
        '
        Me.ParvulariaDataSet.DataSetName = "ParvulariaDataSet"
        Me.ParvulariaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Movimiento_de_alimentosBindingSource
        '
        Me.Movimiento_de_alimentosBindingSource.DataMember = "Movimiento de alimentos"
        Me.Movimiento_de_alimentosBindingSource.DataSource = Me.ParvulariaDataSet
        '
        'Inventario_de_AlimentosTableAdapter
        '
        Me.Inventario_de_AlimentosTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Inventario_de_AlimentosTableAdapter = Me.Inventario_de_AlimentosTableAdapter
        Me.TableAdapterManager.Movimiento_de_alimentosTableAdapter = Me.Movimiento_de_alimentosTableAdapter
        Me.TableAdapterManager.UpdateOrder = Parvularia.ParvulariaDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'Movimiento_de_alimentosTableAdapter
        '
        Me.Movimiento_de_alimentosTableAdapter.ClearBeforeFill = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(407, 450)
        Me.Controls.Add(Me.Inventario_de_AlimentosBindingNavigator)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Form1"
        Me.Text = "Alimentos"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.Inventario_de_AlimentosBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Inventario_de_AlimentosBindingNavigator.ResumeLayout(False)
        Me.Inventario_de_AlimentosBindingNavigator.PerformLayout()
        CType(Me.Inventario_de_AlimentosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ParvulariaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Movimiento_de_alimentosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents ParvulariaDataSet As ParvulariaDataSet
    Friend WithEvents Inventario_de_AlimentosBindingSource As BindingSource
    Friend WithEvents Inventario_de_AlimentosTableAdapter As ParvulariaDataSetTableAdapters.Inventario_de_AlimentosTableAdapter
    Friend WithEvents TableAdapterManager As ParvulariaDataSetTableAdapters.TableAdapterManager
    Friend WithEvents Inventario_de_AlimentosBindingNavigator As BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As ToolStripSeparator
    Friend WithEvents Inventario_de_AlimentosBindingNavigatorSaveItem As ToolStripButton
    Friend WithEvents ID_AlimentosTextBox As TextBox
    Friend WithEvents NombreTextBox As TextBox
    Friend WithEvents UnidadesTextBox As TextBox
    Friend WithEvents CantidadTextBox As TextBox
    Friend WithEvents SaldoTextBox As TextBox
    Friend WithEvents Fecha_de_caducidadDateTimePicker As DateTimePicker
    Friend WithEvents Movimiento_de_alimentosTableAdapter As ParvulariaDataSetTableAdapters.Movimiento_de_alimentosTableAdapter
    Friend WithEvents Movimiento_de_alimentosBindingSource As BindingSource
    Friend WithEvents sup As Button
    Friend WithEvents search As Button
    Friend WithEvents Add As Button
    Friend WithEvents Agregar As Button
    Friend WithEvents Buscar As Button
    Friend WithEvents Eliminar As Button
    Friend WithEvents CódigoTextBox As TextBox
    Friend WithEvents Fecha_de_ingresoDateTimePicker As DateTimePicker
    Friend WithEvents LoteTextBox As TextBox
    Friend WithEvents Cantidad_AutorizadaTextBox As TextBox
    Friend WithEvents Envase_o_EmpaqueTextBox As TextBox
    Friend WithEvents Unidades_CompletasTextBox As TextBox
    Friend WithEvents Unidades_FracciónTextBox As TextBox
End Class
