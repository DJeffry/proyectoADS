using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    class Estudiante
    {
        private int id_Estudiante;
        private string nombre;
        private string apellidos;
        private string sexo;
        private int fk_Grado;

        public int Id_Estudiante { get => id_Estudiante; set => id_Estudiante = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public int Fk_Grado { get => fk_Grado; set => fk_Grado = value; }
    }
}
