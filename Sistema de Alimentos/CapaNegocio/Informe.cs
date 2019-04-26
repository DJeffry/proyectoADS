using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    class Informe
    {
        private int id_Informe;
        private int fk_Alimentos;
        private int fk_Grado;
        private int fk_Encargado;
        private DateTime fecha;

        public int Id_Informe { get => id_Informe; set => id_Informe = value; }
        public int Fk_Alimentos { get => fk_Alimentos; set => fk_Alimentos = value; }
        public int Fk_Grado { get => fk_Grado; set => fk_Grado = value; }
        public int Fk_Encargado { get => fk_Encargado; set => fk_Encargado = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
    }
}
