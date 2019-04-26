using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    class Grado
    {
        private int id_Grado;
        private int numGrado;
        private string turno;
        private int lectivos;
        private int refrigerios;
        private DateTime inicioClases;

        public int Id_Grado { get => id_Grado; set => id_Grado = value; }
        public int NumGrado { get => numGrado; set => numGrado = value; }
        public string Turno { get => turno; set => turno = value; }
        public int Lectivos { get => lectivos; set => lectivos = value; }
        public int Refrigerios { get => refrigerios; set => refrigerios = value; }
        public DateTime InicioClases { get => inicioClases; set => inicioClases = value; }
    }
}
