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
using System.IO;
using System.Runtime.InteropServices;

namespace Sistema_de_Alimentos
{
    public partial class menuPrincipal : Form
    {
        //variables Globales para el control de menuprincipal recuerden ponerle :Menuvertical despues del nombre de la clase para que su clase herede las variables

        /*con estas variables van a poder acceder a caracteristicas del menu principal*/
        public static string usuarioSesion;//pueden usar esta variable para saber el id del usuario que se ha logeado, no le asignen valores por que se le asigna desde el login
        public static string nombreSesion;
        public static string rolSesionNombre;

        public menuPrincipal()
        {
            InitializeComponent();
        }


        #region Funcionalidades del formulario
        /**
         *RESIZE METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO EN TIEMPO DE EJECUCION
         **/
        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(sizeGripRectangle);
            this.panelContenedor.Region = region;
            this.Invalidate();
        }

        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(244, 244, 244));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //capturar pocision y tamaño de maximiazar para restaurar
        int lx, ly;
        int sw, sh;
        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);

        }


        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //METODO PARA ARRASTRAR EL FORMULARIO---------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();



        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            menuToggle();
        }

        private void panelBarraTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        #endregion

        //METODO PARA ABRIR FORMULARIOS DENTRO DEL PANEL

        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelFormularios.Controls.OfType<MiForm>().FirstOrDefault();//busca en la coleccion el formulario
            //si el formulario o instancia no existe
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelFormularios.Controls.Add(formulario);
                panelFormularios.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
                formulario.FormClosed += new FormClosedEventHandler(closeForm);
            }
            else
            {
                formulario.BringToFront();
            }
        }

        private void btnMessages_Click(object sender, EventArgs e)
        {
            mensagesToggle();
        }

        private void menuPrincipal_Load(object sender, EventArgs e)
        {
            cargarVariables();
            lbNombreUsuario.Text = nombreSesion;
            lblCargo.Text = rolSesionNombre;
        }

        private void menuToggle()
        {
            if (panelMenu.Size.Width == 225)
            {
                panelMenu.Width = 40;
            }
            else
            {
                panelMenu.Width = 225;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmMovimientosAlimentos>();
            
        }

        private void btnAlimentosDesplegable_Click(object sender, EventArgs e)
        {
            if (panelMenuAlimentosDesplegable.Height == 75)
            {
                panelMenuAlimentosDesplegable.Height = 0;
            }
            else
            {
                panelMenuAlimentosDesplegable.Height = 75;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            btnAlimentosDesplegable_Click(null, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (panelGradosDesplegable.Height == 112)
            {
                panelGradosDesplegable.Height = 0;
            }
            else
            {
                panelGradosDesplegable.Height = 112;
            }
        }

        private void btnEstudiantes_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmEstudiantes>();
            estudiantesLight.BackColor = Color.FromArgb(54, 127, 169);
        }

        private void mensagesToggle()
        {
            if (panelMensajes.Visible == true)
            {
                panelMensajes.Visible = false;
            }
            else
            {
                panelMensajes.Visible = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGestion_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmCrearGrado>();
            gestionLight.BackColor = Color.FromArgb(54, 127, 169);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmInventarioAlimentos>();
            inventarioLight.BackColor = Color.FromArgb(54, 127, 169);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            btnEstudiantes_Click(sender, e);
        }

        private void btnEncargados_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            btnGestion_Click(sender, e);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            button7_Click(sender, e);
        }

        //carga variables locales
        public static void cargarVariables()
        {
            try
            {

                storedProcedure sp = new storedProcedure();
                string[] docParametros = new string[1];//creamos un string para los parametros
                docParametros[0] = "@usuario = " + menuPrincipal.usuarioSesion + "";//guardamos los parametros que queremos, no le ponemos las comillas simples al parametro, dará error
                List<object[]> usuarios = sp.lt(docParametros, "verEncargadosPorUsuario");//mandamos a llamar la clase sp con la funcion lt

                foreach (object[] usuario in usuarios)//cargamos los datos en nuestra lista
                {
                    menuPrincipal.nombreSesion = (usuario[2]).ToString();
                    menuPrincipal.rolSesionNombre  = (usuario[3]).ToString();
                }
            }
            catch
            {

            }
        }

        private void closeForm(object sender, EventArgs e) {
            if (Application.OpenForms["frmEstudiantes"] == null) {
                estudiantesLight.BackColor = Color.FromArgb(34, 45, 50);
            }
            if (Application.OpenForms["frmCrearGrado"] == null)
            {
                gestionLight.BackColor = Color.FromArgb(34, 45, 50);
            }
            if (Application.OpenForms["frmInventarioAlimentos"] == null)
            {
                gestionLight.BackColor = Color.FromArgb(34, 45, 50);
            }
            if (Application.OpenForms["frmMovimientoAlimentos"] == null)
            {
                gestionLight.BackColor = Color.FromArgb(34, 45, 50);
            }
        }
    }
}
