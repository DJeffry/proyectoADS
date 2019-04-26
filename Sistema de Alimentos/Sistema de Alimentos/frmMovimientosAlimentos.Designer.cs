namespace Sistema_de_Alimentos
{
    partial class frmMovimientosAlimentos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label CodigoLabel;
            System.Windows.Forms.Label FechaMovimientoLabel;
            System.Windows.Forms.Label LoteLabel;
            System.Windows.Forms.Label CantidadAutorizadaLabel;
            System.Windows.Forms.Label EnvaseEmpaqueLabel;
            System.Windows.Forms.Label UnidadesCompletasLabel;
            System.Windows.Forms.Label UnidadesFraccionesLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.CodigoTextBox = new System.Windows.Forms.TextBox();
            this.FechaMovimientoDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.LoteTextBox = new System.Windows.Forms.TextBox();
            this.CantidadAutorizadaTextBox = new System.Windows.Forms.TextBox();
            this.EnvaseEmpaqueTextBox = new System.Windows.Forms.TextBox();
            this.UnidadesCompletasTextBox = new System.Windows.Forms.TextBox();
            this.UnidadesFraccionesTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvAlumnoAsistencias = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnCrearAlumno = new System.Windows.Forms.Button();
            CodigoLabel = new System.Windows.Forms.Label();
            FechaMovimientoLabel = new System.Windows.Forms.Label();
            LoteLabel = new System.Windows.Forms.Label();
            CantidadAutorizadaLabel = new System.Windows.Forms.Label();
            EnvaseEmpaqueLabel = new System.Windows.Forms.Label();
            UnidadesCompletasLabel = new System.Windows.Forms.Label();
            UnidadesFraccionesLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnoAsistencias)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(653, 26);
            this.panel1.TabIndex = 4;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = global::Sistema_de_Alimentos.Properties.Resources.Close;
            this.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCerrar.Location = new System.Drawing.Point(631, 3);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(16, 16);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.TabStop = false;
            // 
            // CodigoLabel
            // 
            CodigoLabel.AutoSize = true;
            CodigoLabel.Location = new System.Drawing.Point(21, 26);
            CodigoLabel.Name = "CodigoLabel";
            CodigoLabel.Size = new System.Drawing.Size(54, 17);
            CodigoLabel.TabIndex = 39;
            CodigoLabel.Text = "codigo:";
            // 
            // CodigoTextBox
            // 
            this.CodigoTextBox.Location = new System.Drawing.Point(154, 22);
            this.CodigoTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CodigoTextBox.Name = "CodigoTextBox";
            this.CodigoTextBox.Size = new System.Drawing.Size(284, 22);
            this.CodigoTextBox.TabIndex = 40;
            // 
            // FechaMovimientoLabel
            // 
            FechaMovimientoLabel.AutoSize = true;
            FechaMovimientoLabel.Location = new System.Drawing.Point(21, 61);
            FechaMovimientoLabel.Name = "FechaMovimientoLabel";
            FechaMovimientoLabel.Size = new System.Drawing.Size(121, 17);
            FechaMovimientoLabel.TabIndex = 41;
            FechaMovimientoLabel.Text = "fecha Movimiento:";
            // 
            // FechaMovimientoDateTimePicker
            // 
            this.FechaMovimientoDateTimePicker.Location = new System.Drawing.Point(154, 56);
            this.FechaMovimientoDateTimePicker.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FechaMovimientoDateTimePicker.Name = "FechaMovimientoDateTimePicker";
            this.FechaMovimientoDateTimePicker.Size = new System.Drawing.Size(284, 22);
            this.FechaMovimientoDateTimePicker.TabIndex = 42;
            // 
            // LoteLabel
            // 
            LoteLabel.AutoSize = true;
            LoteLabel.Location = new System.Drawing.Point(21, 94);
            LoteLabel.Name = "LoteLabel";
            LoteLabel.Size = new System.Drawing.Size(38, 17);
            LoteLabel.TabIndex = 43;
            LoteLabel.Text = "Lote:";
            // 
            // LoteTextBox
            // 
            this.LoteTextBox.Location = new System.Drawing.Point(154, 90);
            this.LoteTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LoteTextBox.Name = "LoteTextBox";
            this.LoteTextBox.Size = new System.Drawing.Size(284, 22);
            this.LoteTextBox.TabIndex = 44;
            // 
            // CantidadAutorizadaLabel
            // 
            CantidadAutorizadaLabel.AutoSize = true;
            CantidadAutorizadaLabel.Location = new System.Drawing.Point(21, 128);
            CantidadAutorizadaLabel.Name = "CantidadAutorizadaLabel";
            CantidadAutorizadaLabel.Size = new System.Drawing.Size(134, 17);
            CantidadAutorizadaLabel.TabIndex = 45;
            CantidadAutorizadaLabel.Text = "cantidad Autorizada:";
            // 
            // CantidadAutorizadaTextBox
            // 
            this.CantidadAutorizadaTextBox.Location = new System.Drawing.Point(154, 124);
            this.CantidadAutorizadaTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CantidadAutorizadaTextBox.Name = "CantidadAutorizadaTextBox";
            this.CantidadAutorizadaTextBox.Size = new System.Drawing.Size(284, 22);
            this.CantidadAutorizadaTextBox.TabIndex = 46;
            // 
            // EnvaseEmpaqueLabel
            // 
            EnvaseEmpaqueLabel.AutoSize = true;
            EnvaseEmpaqueLabel.Location = new System.Drawing.Point(21, 162);
            EnvaseEmpaqueLabel.Name = "EnvaseEmpaqueLabel";
            EnvaseEmpaqueLabel.Size = new System.Drawing.Size(114, 17);
            EnvaseEmpaqueLabel.TabIndex = 47;
            EnvaseEmpaqueLabel.Text = "envase Empaque:";
            // 
            // EnvaseEmpaqueTextBox
            // 
            this.EnvaseEmpaqueTextBox.Location = new System.Drawing.Point(154, 158);
            this.EnvaseEmpaqueTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EnvaseEmpaqueTextBox.Name = "EnvaseEmpaqueTextBox";
            this.EnvaseEmpaqueTextBox.Size = new System.Drawing.Size(284, 22);
            this.EnvaseEmpaqueTextBox.TabIndex = 48;
            // 
            // UnidadesCompletasLabel
            // 
            UnidadesCompletasLabel.AutoSize = true;
            UnidadesCompletasLabel.Location = new System.Drawing.Point(21, 196);
            UnidadesCompletasLabel.Name = "UnidadesCompletasLabel";
            UnidadesCompletasLabel.Size = new System.Drawing.Size(133, 17);
            UnidadesCompletasLabel.TabIndex = 49;
            UnidadesCompletasLabel.Text = "unidades Completas:";
            // 
            // UnidadesCompletasTextBox
            // 
            this.UnidadesCompletasTextBox.Location = new System.Drawing.Point(154, 192);
            this.UnidadesCompletasTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UnidadesCompletasTextBox.Name = "UnidadesCompletasTextBox";
            this.UnidadesCompletasTextBox.Size = new System.Drawing.Size(284, 22);
            this.UnidadesCompletasTextBox.TabIndex = 50;
            // 
            // UnidadesFraccionesLabel
            // 
            UnidadesFraccionesLabel.AutoSize = true;
            UnidadesFraccionesLabel.Location = new System.Drawing.Point(21, 230);
            UnidadesFraccionesLabel.Name = "UnidadesFraccionesLabel";
            UnidadesFraccionesLabel.Size = new System.Drawing.Size(133, 17);
            UnidadesFraccionesLabel.TabIndex = 51;
            UnidadesFraccionesLabel.Text = "unidades Fracciones:";
            // 
            // UnidadesFraccionesTextBox
            // 
            this.UnidadesFraccionesTextBox.Location = new System.Drawing.Point(154, 226);
            this.UnidadesFraccionesTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UnidadesFraccionesTextBox.Name = "UnidadesFraccionesTextBox";
            this.UnidadesFraccionesTextBox.Size = new System.Drawing.Size(284, 22);
            this.UnidadesFraccionesTextBox.TabIndex = 52;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(CodigoLabel);
            this.groupBox1.Controls.Add(this.CodigoTextBox);
            this.groupBox1.Controls.Add(this.UnidadesFraccionesTextBox);
            this.groupBox1.Controls.Add(FechaMovimientoLabel);
            this.groupBox1.Controls.Add(UnidadesFraccionesLabel);
            this.groupBox1.Controls.Add(this.FechaMovimientoDateTimePicker);
            this.groupBox1.Controls.Add(this.UnidadesCompletasTextBox);
            this.groupBox1.Controls.Add(LoteLabel);
            this.groupBox1.Controls.Add(UnidadesCompletasLabel);
            this.groupBox1.Controls.Add(this.LoteTextBox);
            this.groupBox1.Controls.Add(this.EnvaseEmpaqueTextBox);
            this.groupBox1.Controls.Add(CantidadAutorizadaLabel);
            this.groupBox1.Controls.Add(EnvaseEmpaqueLabel);
            this.groupBox1.Controls.Add(this.CantidadAutorizadaTextBox);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 265);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Formulario";
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.BackColor = System.Drawing.Color.White;
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.comboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 18);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(173, 243);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.Text = "buscar";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(462, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(179, 264);
            this.groupBox2.TabIndex = 54;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Grados creados";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgvAlumnoAsistencias);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(12, 304);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(629, 137);
            this.groupBox3.TabIndex = 55;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Movimientos";
            // 
            // dgvAlumnoAsistencias
            // 
            this.dgvAlumnoAsistencias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAlumnoAsistencias.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAlumnoAsistencias.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.dgvAlumnoAsistencias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAlumnoAsistencias.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.dgvAlumnoAsistencias.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAlumnoAsistencias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAlumnoAsistencias.ColumnHeadersHeight = 30;
            this.dgvAlumnoAsistencias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlumnoAsistencias.EnableHeadersVisualStyles = false;
            this.dgvAlumnoAsistencias.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvAlumnoAsistencias.Location = new System.Drawing.Point(3, 18);
            this.dgvAlumnoAsistencias.Name = "dgvAlumnoAsistencias";
            this.dgvAlumnoAsistencias.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAlumnoAsistencias.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAlumnoAsistencias.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgvAlumnoAsistencias.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAlumnoAsistencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAlumnoAsistencias.Size = new System.Drawing.Size(623, 116);
            this.dgvAlumnoAsistencias.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(251, 452);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 38);
            this.button1.TabIndex = 55;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(138, 452);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 38);
            this.button2.TabIndex = 54;
            this.button2.Text = "Eliminar";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // btnCrearAlumno
            // 
            this.btnCrearAlumno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCrearAlumno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.btnCrearAlumno.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnCrearAlumno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearAlumno.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearAlumno.Location = new System.Drawing.Point(12, 452);
            this.btnCrearAlumno.Name = "btnCrearAlumno";
            this.btnCrearAlumno.Size = new System.Drawing.Size(96, 38);
            this.btnCrearAlumno.TabIndex = 53;
            this.btnCrearAlumno.Text = "Guardar";
            this.btnCrearAlumno.UseVisualStyleBackColor = false;
            // 
            // frmMovimientosAlimentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.ClientSize = new System.Drawing.Size(653, 502);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnCrearAlumno);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMovimientosAlimentos";
            this.Text = "frmMovimientosAlimentos";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnoAsistencias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btnCerrar;
        internal System.Windows.Forms.TextBox CodigoTextBox;
        internal System.Windows.Forms.DateTimePicker FechaMovimientoDateTimePicker;
        internal System.Windows.Forms.TextBox LoteTextBox;
        internal System.Windows.Forms.TextBox CantidadAutorizadaTextBox;
        internal System.Windows.Forms.TextBox EnvaseEmpaqueTextBox;
        internal System.Windows.Forms.TextBox UnidadesCompletasTextBox;
        internal System.Windows.Forms.TextBox UnidadesFraccionesTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvAlumnoAsistencias;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnCrearAlumno;
    }
}