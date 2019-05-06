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
            } else if (cboGrado.Text == " ")
            {
                dgvGrados.DataSource = sp.dt("grado INNER JOIN parvularia.estudiante ON parvularia.grado.ID_grado = parvularia.estudiante.fk_Grado; ", "estudiante.nombre Nombre, Parvularia.estudiante.apellido Apellido, parvularia.grado.turno Turno, parvularia.estudiante.sexo Sexo, parvularia.grado.grado Grado");

            }
            else {
                dgvGrados.DataSource = sp.dt("grado INNER JOIN parvularia.estudiante ON parvularia.grado.ID_grado = parvularia.estudiante.fk_Grado  WHERE parvularia.grado.grado = '" + cboGrado.Text + "';", "estudiante.nombre Nombres, Parvularia.estudiante.apellido Apellidos, parvularia.grado.turno Turno, parvularia.estudiante.sexo Sexo, parvularia.grado.grado Grado");
            }
            dgvGrados.Refresh();
        }

        private void actualizarDatosAsistencias()
        {
        }

        private void actualizarDatosAsistenciasAlumno()
        {


            cboGradoAlumno.Items.Clear();
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
            tabControl1.SelectTab(1);

        }
        private bool verificarAlumno() {

            string nombre = txtNombres.Text;
            string apellido = txtApellidos.Text;
            string turno = cboTurnoAlumno.SelectedItem.ToString();
            string sexo = cboSexoAlumno.SelectedItem.ToString();
            string grado = cboGradoAlumno.SelectedItem.ToString();

            string tabla = "estudiante inner join parvularia.grado grado on estudiante.fk_Grado = grado.id_Grado where Nombre = '" + nombre + "' and Apellido = '" + apellido + "'";

            try
            {
                List<object[]> datos = sp.list(tabla, "id_Estudiante");

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
            catch (Exception e) {
                return false;
            }


        }

        private int buscarGradoPorDatos(string nombre, string turno) {
            string tabla = "grado where grado = '" + nombre + "' and turno = '" + turno + "'";

            int retorno = 0;

            try
            {
                List<object[]> datos = sp.list(tabla, "id_Grado");
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
            catch (Exception e) {
                return 0;
            }
        }

        private void btnCrearAlumno_Click(object sender, EventArgs e)
        {
            alumno();
        }

        private void limpiarFomularioAlumnos() {
            txtNombres.Text = "";
            txtApellidos.Text = "";
            cboGradoAlumno.Text = "";
            cboSexoAlumno.Text = "";
            cboTurnoAlumno.Text = "";
            lblNotificacion.Text = "";
            dgvAlumnoAsistencias.Columns.Clear();

            errorProvider1.Clear();
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
            string tabla = "asistencia asistencias inner join parvularia.estudiante alumno on asistencias.fk_Estudiante = alumno.id_Estudiante where id_Estudiante=" + id;
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
                    lblNotificacion.Text = "Modificando informacion de " + idlista[0];
                    txtApellidos.Text = idlista[1];
                    cboSexoAlumno.SelectedIndex = cboSexoAlumno.Items.IndexOf(idlista[2]);
                    cboGradoAlumno.SelectedIndex = cboGradoAlumno.Items.IndexOf(idlista[3]);
                    cboTurnoAlumno.SelectedIndex = cboTurnoAlumno.Items.IndexOf(idlista[4]);
                }


                actualizarAlumnoAsistencias(selectedId.Text);
                tabControl1.SelectTab(1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btnEliminarGrado_Click(sender, e);
            limpiarFomularioAlumnos();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            cboGrado.Items.Clear();
            actualizarDatosGrado();
        }

        private void cboGradoAlumno_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboTurnoAlumno.Items.Clear();
            List<object[]> datos = sp.list("grado where grado = '" + cboGradoAlumno.SelectedItem.ToString() + "'");

            foreach (object[] grado in datos)
            {
                cboTurnoAlumno.Items.Add(grado[2].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiarFomularioAlumnos();
        }

        private void dgvGrados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvGrados_CellClick(sender, e);
            btnActualizarGrado_Click(sender, e);
        }

        private void txtBuscarAlumno_Click(object sender, EventArgs e)
        {

        }


        //**Funciones**//


        private bool validar()
        {
            Regex exp = new Regex(@"^([A-Z][a-z]*)( [A-Z][a-z]+)?");

            if (!exp.IsMatch(txtNombres.Text))
            {
                errorProvider1.SetError(txtNombres, "Ingrese uno o dos nombres con letra inicial mayuscula, no ingrese numeros");
                return false;
            }
            else if (!exp.IsMatch(txtApellidos.Text))
            {
                errorProvider1.SetError(txtApellidos, "Ingrese uno o dos apellidos con letra inicial mayuscula, no ingrese numeros");
                return false;
            }
            else if (cboSexoAlumno.Text == " " || cboSexoAlumno.Text == "")
            {
                errorProvider1.SetError(cboSexoAlumno, "Ingrese un genero");
                return false;
            }
            else if (cboGradoAlumno.Text == " " || cboGradoAlumno.Text == "")
            {
                errorProvider1.SetError(cboGradoAlumno, "Ingrese un Grado");
                return false;
            }
            else if (cboTurnoAlumno.Text == " " || cboTurnoAlumno.Text == "")
            {
                errorProvider1.SetError(cboTurnoAlumno, "Ingrese un turno");
                return false;
            }
            else {
                return true;
            }

        }

        private void alumno() {
            errorProvider1.Clear();
            if (validar())
            {
                List<object[]> datos = sp.list("grado where grado = '" + cboGradoAlumno.SelectedItem.ToString() + "'");

                //@nombre varchar(255),@apellido varchar(255), @sexo varchar(50), @fk_Grado int)as insert into parvularia.estudiante values(@nombre, @apellido, @sexo, @fk_Grado
                string[] gradoParametros = new string[4];
                string[] gradoEstudianteParametros = new string[5];
                string[] estudianteParametros = new string[5];

                gradoParametros[0] = "@nombre = " + txtNombres.Text;
                gradoParametros[1] = "@apellido = " + txtApellidos.Text;
                gradoParametros[2] = "@sexo = " + cboSexoAlumno.SelectedItem.ToString();

                gradoEstudianteParametros[0] = cboGradoAlumno.SelectedItem.ToString();
                gradoEstudianteParametros[1] = cboTurnoAlumno.SelectedItem.ToString();

                int busqueda = buscarGradoPorDatos(gradoEstudianteParametros[0], gradoEstudianteParametros[1]);

                foreach (object[] grado in datos)
                {
                    gradoParametros[3] = "@fk_Grado = " + grado[0].ToString();
                }

                if (!verificarAlumno() && selectedId.Text == "")
                {
                    if (sp.pb(gradoParametros, "insertarEstudiante"))
                    {

                        if (busqueda > 0)
                        {
                            asistencias(0);
                            MessageBox.Show("Estudiante creado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            actualizarDatosGrado();
                            limpiarFomularioAlumnos();
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
                else
                {
                    var result = MessageBox.Show("Desea sobreescribir?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        string[] gradoEstudianteParametros2 = new string[5];
                        string[] estudianteParametros2 = new string[5];
                        estudianteParametros2[0] = "@id_Estudiante = " + selectedId.Text;
                        estudianteParametros2[1] = "@nombre = " + txtNombres.Text;
                        estudianteParametros2[2] = "@apellido = " + txtApellidos.Text;
                        estudianteParametros2[3] = "@sexo = " + cboSexoAlumno.SelectedItem.ToString();

                        gradoEstudianteParametros2[0] = cboGradoAlumno.SelectedItem.ToString();
                        gradoEstudianteParametros2[1] = cboTurnoAlumno.SelectedItem.ToString();

                        int busqueda2 = buscarGradoPorDatos(gradoEstudianteParametros2[0], gradoEstudianteParametros2[1]);

                        foreach (object[] grado in datos)
                        {
                            estudianteParametros2[4] = "@fk_Grado = " + busqueda.ToString();
                        }

                        if (sp.pb(estudianteParametros2, "modificarEstudiante"))
                        {
                            if (busqueda2 > 0)
                            {

                                /*actualizar lista de asistencia*/
                                asistencias(1);
                                

                                MessageBox.Show("Estudiante modificado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                actualizarDatosGrado();

                                limpiarFomularioAlumnos();
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

        private void asistencias(int op) {

            if (op == 0)
            {
                /** insertar asistencias **/
                //1. saber el grado de procedencia y alumno al cual se asignara

                string tabla0 = "estudiante where nombre = '" + txtNombres.Text + "' and apellido = '" + txtApellidos.Text + "'";

                int idAlumno = 0;

                List<object[]> datos0 = sp.list(tabla0, "*");
                if (datos0.Count == 0)
                {

                }
                else
                {

                    foreach (object[] idlista in datos0)
                    {
                        idAlumno= Convert.ToInt32(idlista[0]);
                    }
                }
                //2. saber cuantos dias lectivos tiene hasta el dia de hoy
                string tabla1 = "grado where grado = '" + cboGradoAlumno.Text + "' and turno = '" + cboTurnoAlumno.Text + "'";

                int lectivos = 0;
                DateTime fecha = DateTime.Today;

                List<object[]> datos1 = sp.list(tabla1, "*");
                if (datos1.Count == 0)
                {

                }
                else
                {

                    foreach (object[] idlista in datos1)
                    {
                        lectivos = Convert.ToInt32(idlista[3]);
                        fecha = Convert.ToDateTime(idlista[5]);
                    }
                }


                //3. en un while crear la asistencia, y si es sabado o domingo no restar los lectivos
                int diaSemana = Convert.ToInt32(fecha.DayOfWeek);
                double dias = 0;

                while (lectivos > 1)
                {
                    if (diaSemana < 6)
                    {
                        //insertar asistencia
                        string[] asistenciaParametros = new string[4];
                        asistenciaParametros[0] = "@fecha  = " + Convert.ToString(fecha.AddDays(dias));
                        asistenciaParametros[1] = "@consumo  = true";
                        asistenciaParametros[2] = "@presente = true";
                        asistenciaParametros[3] = "@fk_estudiante = " + idAlumno.ToString();
                        sp.pb(asistenciaParametros, "insertarAsistencia");
                        lectivos--;
                        dias++;
                        diaSemana++;
                    }
                    else if (diaSemana == 7)
                    {
                        diaSemana = 1;
                        dias++;
                    }
                    else
                    {
                        diaSemana++;
                        dias++;
                    }
                }

                //4. si no se pudo actualizar la asistencia decir que se pudo ingresar la asistencia pero si el estudiante, y eliminar el estudiante.
            }
            else {
                /*actualizar lista de asistencia*/
                
                //primero con un for comparar si está diferente los dias de asistencia
                int countCells = dgvAlumnoAsistencias.RowCount;

                DataGridViewRowCollection filas = dgvAlumnoAsistencias.Rows;
                try
                {
                    foreach (DataGridViewRow celda in filas)
                    {
                        string tabla1 = "asistencia where Fecha = '" + celda.Cells[0].Value + "' and fk_Estudiante = " + selectedId.Text;
                        string[] asistenciaParametros = new string[4];

                        List<object[]> datos1 = sp.list(tabla1, "*");

                        foreach (object[] data in datos1) {
                            asistenciaParametros[0] = "@id_Asistencia  = " + data[0];
                        }

                        asistenciaParametros[1] = "@consumo  = "+ celda.Cells[1].Value;
                        asistenciaParametros[2] = "@presente = "+ celda.Cells[2].Value;
                        asistenciaParametros[3] = "@fk_estudiante = " + selectedId.Text;

                        sp.pb(asistenciaParametros, "modificarAsistencia");
                    }
                }
                catch(Exception e)
                {
                    System.Console.Write("Error***---------------" + e);
                }

            }
        }
    }
    
}
