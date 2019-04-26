using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    class Asistencia
    {
        private int id_Asistencia;
        private DateTime fecha;
        private bool consumo;
        private bool presente;
        private int fk_Estudiante;

        public int Id_Asistencia { get => id_Asistencia; set => id_Asistencia = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public bool Consumo { get => consumo; set => consumo = value; }
        public bool Presente { get => presente; set => presente = value; }
        public int Fk_Estudiante { get => fk_Estudiante; set => fk_Estudiante = value; }
    }
}
