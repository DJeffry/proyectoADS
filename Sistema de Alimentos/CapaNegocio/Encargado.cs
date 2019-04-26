using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CapaNegocio
{
    public class Encargado
    {

        private Conexion Conexion = new Conexion();
        private SqlDataReader leer;
        //variables
        private int id_Encargado;
        private string nombre;
        private string apellidos;
        private string rol;
        private string usuario;
        private string pass;
        private int fk_Grado;
        //Metdos GET y SET --> para manejo de variables
        public int Id_Encargado { get => id_Encargado; set => id_Encargado = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Rol { get => rol; set => rol = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Pass { get => pass; set => pass = value; }
        public int Fk_Grado { get => fk_Grado; set => fk_Grado = value; }

        //Mando a llamar el procedimiento almacenado para inicar sesion en la base de datos
        public SqlDataReader iniciarSesion(String user, String pass)
        {
            SqlCommand comando = new SqlCommand("parvularia.SPIniciarSesion", Conexion.AbrirConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@usuario", user);
            comando.Parameters.AddWithValue("@pass", pass);
            leer = comando.ExecuteReader();
            return leer;
        }
        public SqlDataReader IniciarSesion()
        {
            SqlDataReader Logear;
            Logear = iniciarSesion(Usuario, Pass);
            return Logear;
        }
    }
}
