using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace Sistema_de_Alimentos
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void BtnBoton_Click(object sender, EventArgs e)
        {
            /*Bucle que hace que inicie session*/
            //el siguiente bucle comentado puede ser reutilizado
            //creo un objeto de tipo encargado(clase que se crea en la capa de negocios) para eso mando a llamar la capa (parte superior, "using capaNegocios;")
            Encargado objEncargado = new Encargado();           //mando a llamar el procedimiento almacenado
            SqlDataReader Logear;
            //asigno variables al objeto (getters y setters creados en la clase de negocios)
            objEncargado.Usuario = txtUsuario.Text;
            menuPrincipal.usuarioSesion = txtUsuario.Text;
            objEncargado.Pass = txtPass.Text;
            //de aqui en adelante juego con las variables seteadas en la capa negocios para la programacion del login

            if (objEncargado.Usuario == txtUsuario.Text)
            {
                if (objEncargado.Pass == txtPass.Text)
                {
                    Logear = objEncargado.IniciarSesion();
                    if (Logear.Read() == true)
                    {
                        lblErrores.ForeColor = Color.White;
                        menuPrincipal panel = new menuPrincipal();
                        this.Hide();
                        panel.Visible = true;
                    }
                    else
                    {

                        lblErrores.Text = "Usuario o contraseña invalidos";
                        txtPass.Text = "";
                        lblErrores.ForeColor = Color.Red;
                        txtPass_Leave(null, e);
                        txtUsuario.Focus();
                    }
                }
                else
                {
                    lblErrores.Text = objEncargado.Pass;
                    lblErrores.ForeColor = Color.Red;
                }
            }
            else
            {
                lblErrores.Text = objEncargado.Usuario;
                lblErrores.ForeColor = Color.Red;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.White;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "CONTRASEÑA")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.White;
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "CONTRASEÑA";
                txtPass.ForeColor = Color.DimGray;
                txtPass.UseSystemPasswordChar = false;
            }
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnBoton_Click(null, e);
            }
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnBoton_Click(null, e);
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnBoton_Click(null, e);
            }
        }
    }
}
