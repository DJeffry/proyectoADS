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
            
        }

        private void frmCrearGrado_Leave(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int calcLectivos(DateTime d1) {
            DateTime ahorita = Convert.ToDateTime(DateTime.Today.ToString());
            int resta = Convert.ToInt32((ahorita - d1).TotalDays);
            int diasSemana = Convert.ToInt32(resta - DateTime.Now.DayOfWeek) / 7;
            int lectivos = resta - diasSemana - 1;
            return lectivos;
        }

        private void btnCrearGrado_Click(object sender, EventArgs e)
        {
            DateTime inicio = Convert.ToDateTime(dtpInicioClases.Value.ToString());
            int lectivos = calcLectivos(inicio);
            int refrigerio = lectivos;
             string theDate = dtpInicioClases.Value.ToString("yyyy-MM-dd");
             string[] docParametros = new string[5];//creamos el array para mandar parametros
             //create procedure parvularia.insertarGrado(@grado varchar(255), @turno varchar(50), @lectivos int, @refrigerio int, @inicioClasesdate)as insert into parvularia.grado values(@grado, @turno, @lectivos, @refrigerio, @inicioClases);
             docParametros[0] = "@grado = " + txtGrado.Text;
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
}
