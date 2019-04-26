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

        private void btnCrearGrado_Click(object sender, EventArgs e)
        {
            string theDate = dtpInicioClases.Value.ToString("yyyy-MM-dd");
            string[] docParametros = new string[3];//creamos el array para mandar parametros
            //create procedure parvularia.insertarGrado(@grado varchar(255), @turno varchar(50), @lectivos int, @refrigerio int, @inicioClasesdate)as insert into parvularia.grado values(@grado, @turno, @lectivos, @refrigerio, @inicioClases);
            docParametros[0] = "@grado = '" + txtGrado.Text + "',";
            docParametros[1] = "@turno = '" + txtTurno.Text + "',";
            docParametros[2] = "@inicioClases= '" + theDate + "'";


            if (sp.pb(docParametros, "insertarGrado"))//al mandar a llamar la funcion debolverá un valor booleano con eso podemos controlarlo
            {
                MenuVertical.errores = "Datos creados correctamente";//si tira true, pondremos que todo esta bien
                actualizarDatos();//actualizamos el datagrid
            }
            else//si tira false, quiere decir que intentamos actualizar los datos por que los datos ya existen
            {
                if (sp.pb(docParametros, "actualizarDoctor"))//mandamos a llamar de nuebo el pb, pero en este caso le diremos que queremos actualizar
                {
                    MenuVertical.errores = "Datos alterados correctamente";//si tira true diremos que todo esta bien
                    actualizarDatos();
                }
                else
                {
                    MenuVertical.errores = "No se alterar alterar los datos, verifique bien los campos";//quiere decir que no estamos enviando bien los parametros
                }
            }
        }
    }
}
