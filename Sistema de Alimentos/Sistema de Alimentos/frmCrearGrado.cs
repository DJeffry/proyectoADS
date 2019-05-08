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
    public partial class frmCrearGrado : Form
    {
        storedProcedure sp = new storedProcedure();
        private int edit_indice = -1;

        public frmCrearGrado()
        {
            InitializeComponent();
        }

        private void frmCrearGrado_Load(object sender, EventArgs e)
        {
            actualizarDatosGrado();
            dtpInicioClases.MaxDate = DateTime.Today.AddDays(62);
            dtpInicioClases.Value = DateTime.Today;
        }

        private void frmCrearGrado_Leave(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int calcLectivos(DateTime d1)
        {
            DateTime ahorita = Convert.ToDateTime(DateTime.Today.ToString());
            int resta = Convert.ToInt32((ahorita - d1).TotalDays);
            int diasSemana = Convert.ToInt32(resta - DateTime.Now.DayOfWeek) / 7;
            int lectivos = resta - diasSemana - 1;
            return lectivos;
        }

        private void btnCrearGrado_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                if (verificarGrado())
                {
                    ModificarDatosGrados();
                    Limpiar();
                }
                else
                {
                    insertarDatosGrado();
                    Limpiar();
                }
            }
        }

        private void actualizarDatosGrado()
        {
            if (lstGrados.Items.Count == 0)
            {

                List<object[]> datos = sp.list("grado");

                foreach (object[] grado in datos)
                {
                    lstGrados.Items.Add(grado[1].ToString() + " " + grado[2].ToString());
                }
            }
            dgvDatosGrado.Refresh();
        }

        private void insertarDatosGrado() {
            if (!validar())
            {
                errorProvider1.SetError(dtpInicioClases, "No se puede iniciar clases en dia de semana");
            }
            else
            {
                string grado = "";
                string[] words = new string[30];
                words = txtGrado.Text.Split(' ');
                foreach (string dato in words) {
                    grado += dato;
                }
                DateTime inicio = Convert.ToDateTime(dtpInicioClases.Value.ToString());
                int lectivos = calcLectivos(inicio);
                if (lectivos < 0) { lectivos = 0; }
                int refrigerio = lectivos; 
                string theDate = dtpInicioClases.Value.ToString("yyyy-MM-dd");
                string[] docParametros = new string[5];//creamos el array para mandar parametros
                                                       //create procedure parvularia.insertarGrado(@grado varchar(255), @turno varchar(50), @lectivos int, @refrigerio int, @inicioClasesdate)as insert into parvularia.grado values(@grado, @turno, @lectivos, @refrigerio, @inicioClases);
                docParametros[0] = "@grado = " + grado;
                docParametros[1] = "@turno = " + cboTurno.SelectedItem.ToString();
                docParametros[2] = "@lectivos = " + lectivos.ToString();
                docParametros[3] = "@refrigerio = " + lectivos.ToString();
                docParametros[4] = "@inicioClases = " + theDate + "";


                if (sp.pb(docParametros, "insertarGrado"))//al mandar a llamar la funcion debolverá un valor booleano con eso podemos controlarlo
                {
                    MessageBox.Show("Grado creado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else//si tira false, quiere decir que intentamos actualizar los datos por que los datos ya existen
                {
                    MessageBox.Show("Grado no se pudo crear", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        public void ModificarDatosGrados() {
            if (validar())
            {

                string grado = "";
                string[] words = new string[30];
                words = txtGrado.Text.Split(' ');
                foreach (string dato in words)
                {
                    grado += dato;
                }
                DateTime inicio = Convert.ToDateTime(dtpInicioClases.Value.ToString());
                int lectivos = calcLectivos(inicio);
                if (lectivos < 0) { lectivos = 0; }
                int refrigerio = lectivos;
                string theDate = dtpInicioClases.Value.ToString("yyyy-MM-dd");
                string[] docParametros = new string[6];//creamos el array para mandar parametros
                                                       //create procedure parvularia.insertarGrado(@grado varchar(255), @turno varchar(50), @lectivos int, @refrigerio int, @inicioClasesdate)as insert into parvularia.grado values(@grado, @turno, @lectivos, @refrigerio, @inicioClases);
                docParametros[0] = "@id_grado = " + lblSelectedId.Text;
                docParametros[1] = "@grado = " + grado;
                docParametros[2] = "@turno = " + cboTurno.SelectedItem.ToString();
                docParametros[3] = "@lectivos = " + lectivos.ToString();
                docParametros[4] = "@refrigerio = " + lectivos.ToString();
                docParametros[5] = "@inicioClases = " + theDate;
                

                if (sp.pb(docParametros, "modificarGrado"))//al mandar a llamar la funcion debolverá un valor booleano con eso podemos controlarlo
                {
                    MessageBox.Show("Grado modificado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else//si tira false, quiere decir que intentamos actualizar los datos por que los datos ya existen
                {
                    MessageBox.Show("Grado no se pudo crear", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private bool verificarGrado() {

            string grado = txtGrado.Text;
            string turno= cboTurno.SelectedItem.ToString();

            string tabla = "grado where grado = '" + grado + "' and turno = '" + turno + "'";

            try
            {
                List<object[]> datos = sp.list(tabla, "id_Grado");

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
                            if (lblSelectedId.Text == idlista[0])
                            {
                                return true;
                            }
                            else
                            {
                                lblSelectedId.Text = idlista[0];
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
        private void cboGrados_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstGrados_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valor = lstGrados.SelectedItem.ToString();

            if (valor == "  " || valor == " " || valor == "" || valor == null)
            {
                Limpiar();
            }
            else {
                actualizarListaGrados();
            }
        }

        private void Limpiar()
        {
            txtGrado.Text = "";
            cboTurno.Text = "";
            dtpInicioClases.Value = DateTime.Now;
            lblModificandoA.Text = "";
            lblSelectedId.Text = "";
            lstGrados.Items.Clear();
            dgvDatosGrado.Columns.Clear();
            actualizarDatosGrado();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void dtpInicioClases_ValueChanged(object sender, EventArgs e)
        {

        }


        //**Funciones**//

        private void actualizarListaGrados() {
            string p = lstGrados.SelectedItem.ToString();
            if (p == " ")
            {

            }
            else
            {
                string[] words = new string[2];//creamos un array para separar el nombre del parametro con el parametro en sí
                words = p.Split(' ');//le decimos que nos separe nuestro parametro, el nombre del parametro se almacenará en word[0] y el parametro en word[1]

                txtGrado.Text = words[0];
                cboTurno.Text = words[1];

                dgvDatosGrado.DataSource = sp.dt("grado where grado = '" + words[0]+"'", "grado Grado, turno Turno, lectivos Lectivos, refrigerios Refrigerios, inicioClases Inicio");

                lblModificandoA.Text = "Modificando a: " + words[0];
                List<object[]> datos = sp.list("grado where grado = '" + txtGrado.Text + "' and turno = '" + words[1] + "'");

                foreach (object[] grado in datos)
                {
                    lblSelectedId.Text = grado[0].ToString();
                    dtpInicioClases.Value = Convert.ToDateTime(grado[5]);
                }
            }
        }

        private bool validar()
        {
            Regex exp = new Regex(@"^([A-z]*)?");
            string diaSemana = dtpInicioClases.Value.DayOfWeek.ToString();
            errorProvider1.Clear();
            if (!exp.IsMatch(txtGrado.Text))
            {
                errorProvider1.SetError(txtGrado, "Ingrese un nombre para el grado, no ingrese numeros, sin espacios");
                return false;
            }
            else if (cboTurno.Text == "")
            {
                errorProvider1.SetError(cboTurno, "Ingrese un turno para el grado");
                return false;
            }
            else if (diaSemana == "Sunday" || diaSemana == "Saturday")
            {
                errorProvider1.SetError(dtpInicioClases, "Ingrese un día de semana para iniciar clases");
                return false;
            }
            else
            {
                
                return true;
            }

        }

        private void btnEliminarGrado_Click(object sender, EventArgs e)
        {
            if (lblSelectedId.Text == "")
            {
                MessageBox.Show("No se ha seleccionado ningun grado para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string[] docParametros = new string[1];//creamos el array para mandar parametros
                                                       //creamos los parametros que enviaremos, en este caso si le pondremos comillas simples mas una coma, exceptuando el ultimo parametro a diferencia de la lista que no se les ponen
                docParametros[0] = "@id_grado = " + lblSelectedId.Text;
                var result = MessageBox.Show("Esta seguro que desea eliminar a " + txtGrado.Text + ".", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    if (sp.pb(docParametros, "borrarGrado"))//al mandar a llamar la funcion debolverá un valor booleano con eso podemos controlarlo
                    {


                        actualizarDatosGrado();//actualizamos el datagrid
                        Limpiar();

                    }

                    else
                    {
                        MessageBox.Show("Ha ocurrido un problema, no se ha podido eliminar el alumno.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        actualizarDatosGrado();
                    }
                }
                else
                {
                    Limpiar();
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblModificandoA_Click(object sender, EventArgs e)
        {

        }
    }
}
