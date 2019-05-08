using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Alimentos
{

    public partial class frmInventarioAlimentos : Form
    {
        storedProcedure sp = new storedProcedure();
        public frmInventarioAlimentos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dgvInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvInventario.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvInventario.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvInventario.Rows[selectedrowindex];

                string nombre = Convert.ToString(selectedRow.Cells[0].Value);
                string unidades = Convert.ToString(selectedRow.Cells[1].Value);
                string cantidad = Convert.ToString(selectedRow.Cells[2].Value);
                string saldo = Convert.ToString(selectedRow.Cells[3].Value);
                string caducidad = Convert.ToString(selectedRow.Cells[4].Value);

                selectedName.Text = nombre;

                string tabla = "inventarioAlimentos where nombre = '" + nombre + "' and unidades = '" + unidades + "' and fechaCaducidad = '" + caducidad + "'";

                List<object[]> datos = sp.list(tabla, "id_Alimentos");

                foreach (string[] idlista in datos)
                {
                    selectedId.Text = idlista[0];
                }
            }
        }

        private void Inventario_Click(object sender, EventArgs e)
        {

        }


        /**funciones**/

        private int buscarInventarioPorDatos(string nombre, string unidades, string fecha)
        {
            string tabla = "inventarioAlimentos where nombre = '" + nombre + "' and unidades = '" + unidades + "' and fechaCaducidad = '" + fecha + "'";

            int retorno = 0;

            try
            {
                List<object[]> datos = sp.list(tabla, "id_Alimentos");
                if (datos.Count == 0)
                {
                    return 0;
                }
                else
                {

                    foreach (object[] idlista in datos)
                    {
                        retorno = Convert.ToInt32(idlista[0]);
                    }
                    return retorno;
                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        private int buscarInventarioPorDatos(string nombre)
        {
            string tabla = "inventarioAlimentos where nombre = '" + nombre + "'";

            int retorno = 0;

            try
            {
                List<object[]> datos = sp.list(tabla, "id_Alimentos");
                if (datos.Count == 0)
                {
                    return 0;
                }
                else
                {

                    foreach (object[] idlista in datos)
                    {
                        retorno = Convert.ToInt32(idlista[0]);
                    }
                    return retorno;
                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        private bool verificarInventario()
        {

            string nombre = txtProducto.Text;
            string unidades = txtUnidades.Text;
            string cantidad = numCant.Value.ToString();
            string saldo = numSaldo.Value.ToString();
            string caducidad = dtpCaducidad.Value.ToString("yyyy-MM-dd");

            string tabla = "inventarioAlimentos where nombre = '" + nombre + "' and unidades = '" + unidades + "' and fechaCaducidad = '" + caducidad + "'";

            try
            {
                List<object[]> datos = sp.list(tabla, "id_Alimentos");

                if (datos.Count == 0)
                {
                    return false;
                }
                else
                {
                    foreach (string[] idlista in datos)
                    {
                        if (idlista[0] == null)
                        {
                            return false;
                        }
                        else
                        {
                            if (selectedId.Text == idlista[0])
                            {
                                return true;
                            }
                            else
                            {
                                selectedId.Text = idlista[0];
                                return true;
                            }

                        }
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }


        }

        private void limpiarDatosInventario() {
            txtProducto.Text = "";
            txtUnidades.Text = "";
            numCant.Value = 0;
            numSaldo.Value = 0;
            dtpCaducidad.Value = DateTime.Today;
            selectedName.Text = "";
            selectedId.Text = "";
            lblNotificacion.Text = "";
        }


        private bool validar()
        {
            Regex exp = new Regex(@"^([A-Z][a-z]*)( [A-Z][a-z]+)?");

            if (!exp.IsMatch(txtProducto.Text))
            {
                errorProvider1.SetError(txtProducto, "Ingrese uno o dos nombres con letra inicial mayuscula, no ingrese numeros");
                return false;
            }
            
            else
            {
                return true;
            }

        }
        private void crearProducto()
        {
            errorProvider1.Clear();
            if (validar())
            {
                List<object[]> datos = sp.list("inventarioAlimentos where nombre = '" + txtProducto.Text + "'");

                //@nombre varchar(255),@apellido varchar(255), @sexo varchar(50), @fk_Grado int)as insert into parvularia.estudiante values(@nombre, @apellido, @sexo, @fk_Grado
                string[] invParametros = new string[5];
                
                invParametros[0] = "@nombre = " + txtProducto.Text;
                invParametros[1] = "@unidades = " + txtUnidades.Text;
                invParametros[2] = "@cantidad = " + numCant.Value.ToString();
                invParametros[3] = "@saldo = " + numSaldo.Value.ToString();
                invParametros[4] = "@caducidad  = " + dtpCaducidad.Value.ToString("yyyy-MM-dd");
                string[] invMParametros = new string[1];


                if (!verificarInventario() && selectedId.Text == "")
                {
                    if (sp.pb(invParametros, "insertarInventario"))
                    {
                            MessageBox.Show("Producto creado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            actualizarDatosInventario();
                            limpiarDatosInventario();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo guardar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    var result = MessageBox.Show("Desea sobreescribir?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {

                        string[] invParametros2 = new string[6];

                        invParametros2[1] = "@nombre = " + txtProducto.Text;
                        invParametros2[2] = "@unidades = " + txtUnidades.Text;
                        invParametros2[3] = "@cantidad = " + numCant.Value.ToString();
                        invParametros2[4] = "@saldo = " + numSaldo.Value.ToString();
                        invParametros2[5] = "@caducidad  = " + dtpCaducidad.Value.ToString("yyyy-MM-dd");

                        foreach (object[] grado in datos)
                        {
                            invParametros2[0] = "@id_Inventario = " + grado[0].ToString();
                        }

                        int busqueda2 = buscarInventarioPorDatos(txtProducto.Text, txtUnidades.Text, dtpCaducidad.Value.ToString("yyyy-MM-dd"));

                        if (sp.pb(invParametros2, "modificarInventario"))
                        {
                            if (busqueda2 > 0)
                            {
                                /*actualizar lista de asistencia*/


                                MessageBox.Show("Inventario actualizado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                actualizarDatosInventario();

                                limpiarDatosInventario();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        else
                        {
                            MessageBox.Show("No se pudo guardar el estudiante", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
            }
        }

/*private void crearMovimiento()
        {
            errorProvider1.Clear();
            if (validar())
            {
                List<object[]> datos = sp.list("movimientoAlimentos where nombre = '" + cboProductoMavimiento.SelectedItem.ToString() + "'");

                //@nombre varchar(255),@apellido varchar(255), @sexo varchar(50), @fk_Grado int)as insert into parvularia.estudiante values(@nombre, @apellido, @sexo, @fk_Grado
                string[] invParametros = new string[8];

                invParametros[0] = "@codigo = " + txtCodigo.Text;
                invParametros[1] = "@fechaMovimiento = " + dtpCaducidad.Value.ToString("yyyy-MM-dd");
                invParametros[2] = "@Lote = " + txtLote.Text;
                invParametros[3] = "@cantidadAutorizada = " + numCantidadAutorizada.Value.ToString();
                invParametros[4] = "@envaseEmpaque = " + cboContenedor.SelectedItem.ToString();
                invParametros[5] = "@unidadesCompletas= " + numCompletas.Value;
                invParametros[6] = "@unidadesFracciones= " + numFracciones.Value;

                int busqueda = buscarInventarioPorDatos(txtProducto.Text);

                foreach (object[] grado in datos)
                        {
                            invParametros[7] = "@fk_Alimentos = " + grado[0].ToString();
                        }
                if (!verificarInventario() && selectedId.Text == "")
                {
                    if (sp.pb(invParametros, "insertarMovimiento"))
                    {
                        MessageBox.Show("movimiento creado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        actualizarDatosInventario();
                        limpiarDatosInventario();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo guardar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    var result = MessageBox.Show("Desea sobreescribir?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {

                        string[] invParametros2 = new string[6];

                        invParametros2[1] = "@nombre = " + txtProducto.Text;
                        invParametros2[2] = "@unidades = " + txtUnidades.Text;
                        invParametros2[3] = "@cantidad = " + numCant.Value.ToString();
                        invParametros2[4] = "@saldo = " + numSaldo.Value.ToString();
                        invParametros2[5] = "@caducidad  = " + dtpCaducidad.Value.ToString("yyyy-MM-dd");

                        foreach (object[] grado in datos)
                        {
                            invParametros2[0] = "@id_Inventario = " + grado[0].ToString();
                        }

                        int busqueda2 = buscarInventarioPorDatos(txtProducto.Text, txtUnidades.Text, dtpCaducidad.Value.ToString("yyyy-MM-dd"));

                        if (sp.pb(invParametros2, "modificarInventario"))
                        {
                            if (busqueda2 > 0)
                            {


                                MessageBox.Show("Inventario actualizado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                actualizarDatosInventario();

                                limpiarDatosInventario();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        else
                        {
                            MessageBox.Show("No se pudo guardar el estudiante", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
            }
        }*/
        private void actualizarDatosInventario()
        {
            if (dgvInventario.Text == "")
            {
                dgvInventario.DataSource = sp.dt("inventarioAlimentos", "nombre Nombre, unidades Unidades, cantidad Cantidad, saldo Saldo, fechaCaducidad Caducidad");
                List<object[]> datos = sp.list("inventarioAlimentos");

                foreach (object[] grado in datos)
                {
                    cboInventario.Items.Add(grado[1].ToString());
                }
            }
            else if (dgvInventario.Text == " ")
            {
                dgvInventario.DataSource = sp.dt("inventarioAlimentos", "nombre Nombre, unidades Unidades, cantidad Cantidad, saldo Saldo, fechaCaducidad Caducidad");

            }
            else
            {
                dgvInventario.DataSource = sp.dt("inventarioAlimentos WHERE parvularia.inventarioAlimentos.nombre= '" + cboInventario.Text + "';", "nombre Nombre, unidades Unidades, cantidad Cantidad, saldo Saldo, fechaCaducidad Caducidad");
            }
            dgvInventario.Refresh();
        }

       /* private void actualizarDatosMovimiento()
        {
            if (dgvInventario.Text == "" || dgvInventario.Text == " ")
            {
                dgvInventario.DataSource = sp.dt("inventarioAlimentos  INNER JOIN parvularia.movimientoAlimentos ON parvularia.inventarioAlimentos.id_Alimentos = parvularia.movimientoAlimentos.fk_Alimentos;", "parvularia.inventarioAlimentos.nombre Producto, parvularia.movimientoAlimentos.unidadesCompletas Unidades, parvularia.movimientoAlimentos.unidadesFracciones Fracciones");
                List<object[]> datos = sp.list("movimientoAlimentos");

                foreach (object[] grado in datos)
                {
                    cboResumen.Items.Add(grado[1].ToString());
                }
            }
            else
            {
                dgvInventario.DataSource = sp.dt("inventarioAlimentos  INNER JOIN parvularia.movimientoAlimentos ON parvularia.inventarioAlimentos.id_Alimentos = parvularia.movimientoAlimentos.fk_Alimentos; WHERE parvularia.inventarioAlimentos.nombre= '" + cboInventario.Text + "';", "parvularia.inventarioAlimentos.nombre Producto, parvularia.movimientoAlimentos.unidadesCompletas Unidades, parvularia.movimientoAlimentos.unidadesFracciones Fracciones");
            }
            dgvInventario.Refresh();
        }
*/
        private void button4_Click(object sender, EventArgs e)
        {

            tabControl1.SelectTab(1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (selectedId.Text == "")
            {
                MessageBox.Show("No se ha seleccionado ningun producto para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string[] invParametros = new string[1];//creamos el array para mandar parametros
                                                       //creamos los parametros que enviaremos, en este caso si le pondremos comillas simples mas una coma, exceptuando el ultimo parametro a diferencia de la lista que no se les ponen
                invParametros[0] = "@id_Inventario= " + selectedId.Text;
                var result = MessageBox.Show("Esta seguro que desea eliminar a " + selectedName.Text + ".", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    if (sp.pb(invParametros, "borrarInventario"))//al mandar a llamar la funcion debolverá un valor booleano con eso podemos controlarlo
                    {


                        actualizarDatosInventario();//actualizamos el datagrid
                        dgvInventario.ClearSelection();
                        selectedId.Text = "";

                    }

                    else
                    {
                        MessageBox.Show("Ha ocurrido un problema, no se ha podido eliminar el Producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        actualizarDatosInventario();
                    }
                }
                else
                {
                    selectedId.Text = "";
                    actualizarDatosInventario();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string tabla = "inventarioAlimentos where id_Alimentos =" + selectedId.Text;
            if (selectedId.Text == "")
            {
                MessageBox.Show("No se ha seleccionado ningun producto para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                List<object[]> datos = sp.list(tabla, "nombre Producto, unidades Unidades, cantidad Cantidad, saldo Saldo, fechaCaducidad Caducidad");

                foreach (string[] idlista in datos)//cargamos los datos en nuestra lista
                {
                    txtProducto.Text = idlista[0];
                    lblNotificacion.Text = "Modificando informacion de " + idlista[0];
                    txtUnidades.Text = idlista[1];
                    numCant.Value = Convert.ToInt32(idlista[2]);
                    numSaldo.Value = Convert.ToInt32(idlista[3]);
                    dtpCaducidad.Value = Convert.ToDateTime(idlista[4]);
                }
                tabControl1.SelectTab(1);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarDatosInventario();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            button5_Click(sender, e);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            crearProducto();
        }

        private void frmInventarioAlimentos_Load(object sender, EventArgs e)
        {
            actualizarDatosInventario();
        }

        private void dgvInventario_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dgvInventario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvInventario_CellClick(sender, e);
            button3_Click(sender, e);

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void Movimiento_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboInventario_SelectedValueChanged(object sender, EventArgs e)
        {
            actualizarDatosInventario();
            dgvInventario.ClearSelection();
            selectedId.Text = "";
        }
    }
}
