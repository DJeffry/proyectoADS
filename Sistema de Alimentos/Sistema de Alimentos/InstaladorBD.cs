using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Alimentos
{
    public partial class InstaladorBD : Form
    {

        public string baseDeDatos = "master";
        public string security = "Integrated security = SSPI;";
        public string server = "localhost;";

        public static List<string> lista;
        public static int porcentaje;
        public static bool actualizar = false;
        public SqlConnection cnn;
        public bool bandera = false;
        public string sql;
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();



        public InstaladorBD()
        {
            InitializeComponent();
            generarConexion();
        }

        public void generarConexion()
        {
            SetText("Generando conexion: Server = " + server + security + "database = " + baseDeDatos);
            cnn = new SqlConnection("Server=" + server + security + "database=" + baseDeDatos);
        }

        private void instaladorBD_Load(object sender, EventArgs e)
        {
            t.Interval = 1000;

            t.Tick += new EventHandler(this.t_Tick);

            t.Start();
        }

        private void t_Tick(Object sender, EventArgs e)
        {
            lblConexion.Text = cnn.ConnectionString;
            if (progressBar1.Value == 100)
            {
                button1.Enabled = true;
                string cnns = cnn.ConnectionString;
                escribirConneccion(cnns);
            }
            try
            {
                if (actualizar)
                {
                    //listBox1.Items.Clear();
                    foreach (string item in lista)
                    {
                        listBox1.Items.Add(item);
                    }
                    actualizar = false;
                }
            }
            catch (Exception exe)
            {
            }
        }
        private void CrearBD()
        {


            SetText("----------Creando Base de datos----------");
            sql = "CREATE DATABASE gestorDeAlimentosDB";
            if (exeConexion(sql))
            {
                //exeConexion(sql);
                SetPorc("1");
            }
            else
            {
                var op = MessageBox.Show("Al pacerer la base de datos ya existe, ¿Desea borrarla y reescribir los datos?", "Base de datos ya existe", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (op.ToString() == "Yes")
                {
                    sql = "use master; DROP DATABASE gestorDeAlimentosDB";
                    SetPorc("2");
                }
                else
                {
                    SetPorc("2");
                    Application.Exit();
                }
                if (exeConexion(sql))
                {
                    SetText("--Base de datos eliminada");
                    sql = "CREATE DATABASE gestorDeAlimentosDB";
                    if (exeConexion(sql))
                    {
                        SetText("--Base de datos creada");
                        generarConexion();
                        SetPorc("3");
                    }
                    else
                    { SetText("--No se pudo crear la Base de datos"); SetPorc("0"); }
                }
                else
                {
                    SetText("--No se pudo eliminar la base de datos");
                    SetPorc("0");
                }
            }

            SetText("----------Creando Login administrador----------");
            sql = "use gestorDeAlimentosDB; Create Login adminParvularia with PASSWORD = 'admin123'";
            if (exeConexion(sql))
            {
                SetText("--[BD] usuario Creado");
                SetPorc("4");
                generarConexion();
            }
            else
            {
                SetText("--[BD Error] probablemente ya esté creado el login");
                generarConexion();
                SetPorc("4");
            }
            SetText("----------Creando Usuario----------");
            sql = "use gestorDeAlimentosDB; CREATE USER adminParvularia FOR LOGIN adminParvularia;";
            if (exeConexion(sql))
            {
                SetText("--[Permiso de usuario] Se creó con exito");
                baseDeDatos = "gestorDeAlimentosDB";
                generarConexion();
                SetPorc("5");
            }
            else
            {
                SetText("--[Permiso de usuario] No se pudo crear");
                baseDeDatos = "gestorDeAlimentosDB";
                generarConexion();
                SetPorc("5");
            }
            SetText("----------Creando esquema parvularia----------");
            sql = "create schema parvularia AUTHORIZATION adminParvularia;";
            if (exeConexion(sql))
            {
                SetPorc("6");
            }
            else
            {
                SetText("--[BD Error] No se Encontro la base de datos");
                SetPorc("100");
            }

            SetText("----------asignando esquema a user y asignar permisos----------");
            sql = "use gestorDeAlimentosDB; ALTER USER adminParvularia WITH DEFAULT_SCHEMA = parvularia; GRANT SELECT ON SCHEMA :: parvularia to adminpParvularia with GRANT OPTION; GRANT INSERT ON SCHEMA :: parvularia to adminParvularia with GRANT OPTION; GRANT UPDATE ON SCHEMA :: parvularia to adminParvularia with GRANT OPTION; GRANT DELETE ON SCHEMA :: parvularia to adminParvularia with GRANT OPTION; GRANT exec ON SCHEMA :: parvularia to adminParvularia with GRANT OPTION;";
            if (exeConexion(sql))
            {
                SetText("--[Permiso de usuario] Se creó con exito");
                security = "Uid = adminParvularia; " + "Pwd = admin123;";
                baseDeDatos = "gestorDeAlimentosDB";
                SetPorc("7");
            }
            else
            {
                SetText("--[Permiso de usuario] No se pudo crear");
                security = "Uid = adminParvularia; " + "Pwd = admin123;";
                baseDeDatos = "gestorDeAlimentosDB";
                SetPorc("7");
            }





            SetText("----------Creando Tabla Grado----------");
            sql = "use gestorDeAlimentosDB; Create table parvularia.grado(id_Grado int identity not null primary key,grado varchar(255) not null,turno varchar(50),lectivos int, refrigerios int,inicioClases date)";
            if (exeConexion(sql))
            {
                SetText("--[Tabla Grado] Se creó con exito");
                SetPorc("8");
            }
            else
            {
                SetText("--[Tabla Grado] No se pudo crear");
            }
            SetText("----------Creando Tabla InventarioAlimentos----------");
            sql = "use gestorDeAlimentosDB; create table parvularia.inventarioAlimentos(id_Alimentos int identity not null primary key,nombre varchar(255),unidades varchar(255),cantidad decimal,saldo decimal,fechaCaducidad date)";
            if (exeConexion(sql))
            {
                SetText("--[Tabla inventarioAlimentos] Se creó con exito");
                SetPorc("9");
            }
            else
            {
                SetText("--[Tabla inventarioAlimentos] No se pudo crear");
            }

            SetText("----------Creando Tabla movimientoAlimentos----------");
            sql = "use gestorDeAlimentosDB; create table parvularia.movimientoAlimentos(id_Movimiento int identity not null primary key,codigo char(4) not null,fechaMovimiento date,Lote varchar(255),cantidadAutorizada decimal,envaseEmpaque varchar(255),unidadesCompletas int,unidadesFracciones int,fk_Alimentos int not null foreign key (fk_Alimentos) references parvularia.inventarioAlimentos(id_Alimentos))";
            if (exeConexion(sql))
            {
                SetText("--[Tabla movimientoAlimentos] Se creó con exito");
                SetPorc("10");
            }
            else
            {
                SetText("--[Tabla movimientoAlimentos] No se pudo crear");
            }
            SetText("----------Creando Tabla estudiante----------");
            sql = "use gestorDeAlimentosDB; create table parvularia.estudiante(id_Estudiante int identity not null primary key,Nombre varchar(255),Apellido varchar(255),sexo varchar(50),fk_Grado int not null foreign key (fk_grado) references parvularia.grado(id_Grado) On Delete Cascade On update cascade)";
            if (exeConexion(sql))
            {
                SetText("--[Tabla estudiante] Se creó con exito");
                SetPorc("11");
            }
            else
            {
                SetText("--[Tabla estudiante] No se pudo crear");
            }

            SetText("----------Creando Tabla asistencia----------");
            sql = "use gestorDeAlimentosDB; create table parvularia.asistencia(id_Asistencia int identity not null primary key,Fecha date,Consumo bit,presente bit,fk_Estudiante int not null foreign key (fk_Estudiante) references parvularia.estudiante(id_Estudiante) On Delete Cascade On update cascade)";
            if (exeConexion(sql))
            {
                SetText("--[Tabla asistencia] Se creó con exito");
                SetPorc("12");
            }
            else
            {
                SetText("--[Tabla asistencia] No se pudo crear");
            }
            SetText("----------Creando Tabla encargado----------");
            sql = "use gestorDeAlimentosDB; create table parvularia.encargado(id_Encargado int identity not null primary key,nombre varchar(255),Apellidos varchar(255),rol varchar(255),usuario varchar(255) not null,pass varchar(255),fk_Grado int not null foreign key (fk_grado) references parvularia.grado(id_Grado)On Delete Cascade On update cascade)";
            if (exeConexion(sql))
            {
                SetText("--[Tabla encargado] Se creó con exito");
                SetPorc("13");
            }
            else
            {
                SetText("--[Tabla encargado] No se pudo crear");
            }
            SetText("----------Creando Tabla informe----------");
            sql = "use gestorDeAlimentosDB; create table parvularia.informe(id_Informe int identity not null primary key,fk_Alimentos int foreign key (fk_Alimentos) references parvularia.inventarioAlimentos(id_Alimentos)On Delete Cascade On update cascade,fk_Grado int foreign key (fk_Grado) references parvularia.grado(id_Grado)On Delete Cascade On update cascade,fk_Encargado int foreign key (fk_Encargado) references parvularia.encargado(id_Encargado)On Delete Cascade On update cascade,fecha date)";
            if (exeConexion(sql))
            {
                SetText("--[Tabla informe] Se creó con exito");
                SetPorc("14");
            }
            else
            {
                SetText("--[Tabla informe] No se pudo crear");
            }
            SetText("----------Insertando datos de usuario----------");
            sql = "INSERT INTO parvularia.grado values(' ',null,null,null,null);INSERT INTO parvularia.encargado values('admin','admin', 'administrador','adminP', 'admin123',1)";
            SetPorc("19");
            if (exeConexion(sql))
            {
                SetText("--[Insertando datos] Se creó con exito");
                SetPorc("19");
            }
            else
            {
                SetText("--[Insertando datos] No se pudo crear");
            }
            SetText("----------Creando Procedimientos almacenados----------");
            leerProcedimientos();
        }

        private bool exeConexion(string cmd)
        {

            try
            {
                cnn.Close();
                SqlCommand cm = new SqlCommand(cmd, cnn);
                cnn.Open();
                SetText("--[Ejecutando] " + cmd);
                cm.ExecuteNonQuery();
                SetText("--[Exito]");
                cnn.Close();
                bandera = true;
                return true;

            }
            catch (Exception exe)
            {
                if (!bandera)
                {
                    try
                    {
                        cnn.Close();
                        string pcName = Environment.MachineName;
                        server = pcName + ";";
                        generarConexion();
                        SqlCommand cm = new SqlCommand(cmd, cnn);
                        cnn.Open();
                        InstaladorBD.actualizar = true;
                        cm.ExecuteNonQuery();
                        cnn.Close();
                        bandera = true;
                        return true;
                    }
                    catch (Exception exex)
                    {
                        try
                        {

                            try
                            {
                                string pcName = Environment.MachineName;
                                cnn.Close();
                                server = pcName + "\\SQLEXPRESS;";
                                generarConexion();
                                SqlCommand cm = new SqlCommand(cmd, cnn);

                                cnn.Open();

                                cm.ExecuteNonQuery();

                                cnn.Close();
                                bandera = true;
                                return true;
                            }
                            catch (Exception exexx)
                            {
                                string pcName = Environment.MachineName;
                                server = "(localdb)\\" + pcName + ";";
                                generarConexion();
                                SqlCommand cm = new SqlCommand(cmd, cnn);
                                cnn.Open();
                                cm.ExecuteNonQuery();
                                cnn.Close();
                                bandera = true;
                                return true;
                            }
                        }
                        catch (Exception exexxx)
                        {
                            try
                            {
                                cnn.Close();
                                string pcName = Environment.MachineName;
                                server = pcName + "\\sqlexpress;";
                                generarConexion();
                                SqlCommand cm = new SqlCommand(cmd, cnn);
                                cnn.Open();
                                cm.ExecuteNonQuery();
                                cnn.Close();
                                bandera = true;
                                return true;
                            }
                            catch (Exception exexxxx)
                            {
                                SetText("--[Error] Hubo un error al ejecutar" + cmd);
                                return false;
                            }
                        }
                    }
                }
                else
                {

                    SetText("--[Error] " + exe);
                    return false;

                }
            }
        }

        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void StringArgReturningVoidDelegate(string text);

        public void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.listBox1.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {

                this.listBox1.Items.Add(text);
            }
        }

        public void SetPorc(string p)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.listBox1.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(SetPorc);
                this.Invoke(d, new object[] { p });
            }
            else
            {

                progressBar1.Value = (Convert.ToInt32(p) * 100) / 45;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ThreadStart childref = new ThreadStart(CrearBD);
            Thread childThread = new Thread(childref);
            button2.Enabled = false;
            childThread.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void leerProcedimientos()
        {
            StreamReader objReader = new StreamReader("...\\..\\..\\..\\Base de datos\\procedimientos almacenados.txt");
            string sLine = "";
            ArrayList arrText = new ArrayList();
            int p = 20;
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                    arrText.Add(sLine);
            }
            objReader.Close();

            foreach (string sOutput in arrText)
            {
                exeConexion(sOutput);
                SetPorc(p++.ToString());
            }
        }

        public void escribirConneccion(string conexionStr)
        {
            System.IO.File.WriteAllText("...\\..\\..\\..\\Base de datos\\conexion.txt", conexionStr);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ThreadStart childref = new ThreadStart(CrearBD);
            Thread childThread = new Thread(childref);
            button2.Enabled = false;
            button3.Enabled = false;
            childThread.Start();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void InstaladorBD_Load_1(object sender, EventArgs e)
        {
            t.Interval = 1000;

            t.Tick += new EventHandler(this.t_Tick);

            t.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
