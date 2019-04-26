using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace Sistema_de_Alimentos
{
    public partial class frmEstudiantes : Form
    {
        storedProcedure sp = new storedProcedure();
        private int edit_indice = -1;

        public frmEstudiantes()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void frmEstudiantes_Load(object sender, EventArgs e)
        {
            actualizarDatosGrado();
            actualizarDatosAsistenciasAlumno();
        }

        private void actualizarDatosGrado()
        {
            if (cboGrado.Text == "")
            {
                dgvGrados.DataSource = sp.dt("grado INNER JOIN parvularia.estudiante ON parvularia.grado.ID_grado = parvularia.estudiante.fk_Grado; ", "estudiante.nombre Nombres, Parvularia.estudiante.apellido Apellidos, parvularia.grado.turno Turno, parvularia.estudiante.sexo Sexo,parvularia.grado.grado Grado");
                List<object[]> datos = sp.list("grado");

                foreach (object[] grado in datos)
                {
                    cboGrado.Items.Add(grado[1].ToString());
                }
            }else if(cboGrado.Text == "Todos")
            {
                dgvGrados.DataSource = sp.dt("grado INNER JOIN parvularia.estudiante ON parvularia.grado.ID_grado = parvularia.estudiante.fk_Grado; ", "estudiante.nombre Nombre, Parvularia.estudiante.apellido Apellido, parvularia.grado.turno Turno, parvularia.estudiante.sexo Sexo, parvularia.grado.grado Grado");

            }
            else {
                dgvGrados.DataSource = sp.dt("grado INNER JOIN parvularia.estudiante ON parvularia.grado.ID_grado = parvularia.estudiante.fk_Grado  WHERE parvularia.grado.grado = '"+ cboGrado.Text+"';", "estudiante.nombre Nombres, Parvularia.estudiante.apellido Apellidos, parvularia.grado.turno Turno, parvularia.estudiante.sexo Sexo, parvularia.grado.grado Grado");
            }
            dgvGrados.Refresh();
        }

        private void actualizarDatosAsistencias()
        {
            cboGradoAsistencias.Items.Clear();
            dgvAsistenciasGrados.DataSource = sp.dt("grado INNER JOIN parvularia.estudiante ON parvularia.grado.ID_grado = parvularia.estudiante.fk_Grado; ", "estudiante.nombre Nombres, Parvularia.estudiante.apellidos Apellidos, parvularia.grado.turno Turno, parvularia.estudiante.sexo Sexo");
            
            List<object[]> datos = sp.list("grado");

            foreach (object[] grado in datos)
            {
                cboGradoAsistencias.Items.Add(grado[1].ToString());
            }
        }

        private void actualizarDatosAsistenciasAlumno()
        {
            cboGradoAlumno.Items.Clear();
            dgvAlumnoAsistencias.DataSource = sp.dt("grado INNER JOIN parvularia.estudiante ON parvularia.grado.ID_grado = parvularia.estudiante.fk_Grado; ", "estudiante.nombre Nombres, Parvularia.estudiante.apellidos Apellidos, parvularia.grado.turno Turno, parvularia.estudiante.sexo Sexo");
            List<object[]> datos = sp.list("grado");

            foreach (object[] grado in datos)
            {
                cboGradoAlumno.Items.Add(grado[1].ToString());
            }
        }

        private void btnCrearGrado_Click(object sender, EventArgs e)
        {
            //frmCrearGrado crear = new frmCrearGrado();
            //crear.Show();
            tabControl1.SelectTab(2);
            
        }
        private bool verificarAlumno() {

            string nombre = txtNombres.Text;
            string apellido = txtApellidos.Text;
            string turno = cboTurnoAlumno.SelectedItem.ToString();
            string sexo = cboSexoAlumno.SelectedItem.ToString();
            string grado = cboGradoAlumno.SelectedItem.ToString();

            string tabla = "estudiante inner join parvularia.grado grado on estudiante.fk_Grado = grado.id_Grado where Nombre = '" + nombre + "' and Apellido = '" + apellido + "' and sexo = '" + sexo + "' and grado = '"+ grado +"' and turno = '"+turno+"'";

            try
            {
                List<object[]> datos = sp.list(tabla, "id_Estudiante");

                foreach (string[] idlista in datos)
                {
                    if (idlista[0] == null) {
                        return false;
                    } else {
                        if (selectedId.Text == idlista[0])
                        {
                            return true;
                        }
                        else {
                            selectedId.Text = idlista[0];
                            return true;
                        }
                        
                    }
                }
                return true;
            }
            catch(Exception e) {
                return false;
            }


        }

        private void btnCrearAlumno_Click(object sender, EventArgs e)
        {
            List<object[]> datos = sp.list("grado where grado = '" + cboGradoAlumno.SelectedItem.ToString() + "'");

            //@nombre varchar(255),@apellido varchar(255), @sexo varchar(50), @fk_Grado int)as insert into parvularia.estudiante values(@nombre, @apellido, @sexo, @fk_Grado
            string[] gradoParametros = new string[4];
            gradoParametros[0] = "@nombre = " + txtNombres.Text;
            gradoParametros[1] = "@apellido = " + txtApellidos.Text;
            gradoParametros[2] = "@sexo = " + cboSexoAlumno.SelectedItem.ToString();
            gradoParametros[3] = "@id_Estudiante = " + selectedId.Text;
            foreach (object[] grado in datos)
            {
                gradoParametros[3] = "@fk_Grado = " + grado[0].ToString();
            }

            if (!verificarAlumno())
            {
                if(sp.pb(gradoParametros, "insertarEstudiante"))
                {
                    MessageBox.Show("Estudiante creado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    actualizarDatosGrado();
                    limpiarFomularioAlumnos();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el estudiante", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                var result = MessageBox.Show("Este estudiante ya existe, desea sobreescribir?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                if (result == DialogResult.Yes)
                {
                    if (sp.pb(gradoParametros, "modificarEstudiante"))
                    {
                        MessageBox.Show("Estudiante modificado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        actualizarDatosGrado();
                        limpiarFomularioAlumnos();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo guardar el estudiante", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void limpiarFomularioAlumnos() {
            txtNombres.Text = "";
            txtApellidos.Text = "";
            cboGradoAlumno.SelectedItem = 0;
            cboSexoAlumno.SelectedItem = 0;
            cboTurnoAlumno.SelectedItem = 0;
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            actualizarDatosGrado();
            actualizarDatosAsistencias();
            actualizarDatosAsistenciasAlumno();
        }

        


        private void cboGrado_SelectedValueChanged(object sender, EventArgs e)
        {
            actualizarDatosGrado();
            dgvGrados.ClearSelection();
            selectedId.Text = "";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dtpAsistencias.Enabled = true;
            }
            else {
                dtpAsistencias.Enabled = false; 
            }
            
        }

        private void dgvGrados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrados.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvGrados.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvGrados.Rows[selectedrowindex];

                string nombre = Convert.ToString(selectedRow.Cells[0].Value);
                string apellido = Convert.ToString(selectedRow.Cells[1].Value);
                string turno = Convert.ToString(selectedRow.Cells[2].Value);
                string sexo = Convert.ToString(selectedRow.Cells[3].Value);
                string grado = Convert.ToString(selectedRow.Cells[4].Value);

                selectedName.Text = nombre + " " + apellido;

                string tabla = "estudiante where Nombre = '" + nombre + "' and Apellido = '" + apellido + "' and sexo = '" + sexo + "'";

                List<object[]> datos = sp.list(tabla, "id_Estudiante");

                foreach (string[] idlista in datos)
                {
                    selectedId.Text = idlista[0];
                }
            }
        }

        private void btnEliminarGrado_Click(object sender, EventArgs e)
        {
            if (selectedId.Text == "")
            {
                MessageBox.Show("No se ha seleccionado ningun alumno para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                string[] docParametros = new string[1];//creamos el array para mandar parametros
                                                       //creamos los parametros que enviaremos, en este caso si le pondremos comillas simples mas una coma, exceptuando el ultimo parametro a diferencia de la lista que no se les ponen
                docParametros[0] = "@id_estudiante= " + selectedId.Text;
                var result = MessageBox.Show("Esta seguro que desea eliminar a " + selectedName.Text + ".", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                if (result == DialogResult.Yes)
                {
                    if (sp.pb(docParametros, "borrarEstudiante"))//al mandar a llamar la funcion debolverá un valor booleano con eso podemos controlarlo
                    {


                        actualizarDatosGrado();//actualizamos el datagrid
                        dgvGrados.ClearSelection();
                        selectedId.Text = "";

                    }

                    else
                    {
                        MessageBox.Show("Ha ocurrido un problema, no se ha podido eliminar el alumno.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        actualizarDatosGrado();
                    }
                }
                else
                {
                    selectedId.Text = "";
                    dgvGrados.ClearSelection();
                }
            }
        }

        private void actualizarAlumnoAsistencias(string id) {
            string tabla = "asistencia asistencias inner join parvularia.estudiante alumno on asistencias.fk_Estudiante = alumno.id_Estudiante where id_Estudiante="+id;           
            string calumnas = "Fecha, Consumo Refrigerio, presente asistencia";           

            cboGrado.Items.Clear();
            dgvAlumnoAsistencias.DataSource = sp.dt(tabla, calumnas);
            
        }

        private void btnActualizarGrado_Click(object sender, EventArgs e)
        {
            string tabla = "estudiante estudiante inner join parvularia.grado grado on estudiante.fk_Grado = grado.id_Grado where id_Estudiante = " + selectedId.Text;
            if (selectedId.Text == "")
            {
                MessageBox.Show("No se ha seleccionado ningun alumno para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                List<object[]> datos = sp.list(tabla, "Nombre, Apellido,sexo Sexo, grado Grado, turno Turno");

                foreach (string[] idlista in datos)//cargamos los datos en nuestra lista
                {
                    txtNombres.Text = idlista[0];
                    txtApellidos.Text = idlista[1];
                    cboSexoAlumno.SelectedIndex = cboSexoAlumno.Items.IndexOf(idlista[2]);
                    cboGradoAlumno.SelectedIndex = cboGradoAlumno.Items.IndexOf(idlista[3]);
                    cboTurnoAlumno.SelectedIndex = cboTurnoAlumno.Items.IndexOf(idlista[4]);
                }
                actualizarAlumnoAsistencias(selectedId.Text);
                tabControl1.SelectTab(2);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btnEliminarGrado_Click(sender, e);
        }
    }
}
