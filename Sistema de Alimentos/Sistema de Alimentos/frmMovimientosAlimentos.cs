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
    public partial class frmMovimientosAlimentos : Form
    {
        storedProcedure sp = new storedProcedure();
        public frmMovimientosAlimentos()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMovimientosAlimentos_Load(object sender, EventArgs e)
        {
            actualizarGrados();
        }
        //**funciones**//

        private void actualizarGrados()
        {
            lstGrados.Items.Clear();
            if (lstGrados.Items.Count == 0)
            {

                List<object[]> datos = sp.list("grado");

                foreach (object[] grado in datos)
                {
                    lstGrados.Items.Add(grado[1].ToString() + " " + grado[2].ToString());
                }
            }
            lstGrados.Refresh();
        }

        private void EnvaseEmpaqueTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dgvAlumnoAsistencias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
