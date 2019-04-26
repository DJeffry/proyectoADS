using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    class InventarioAlimentos
    {
        private int id_Alimentos;
        private string nombre;
        private string unidades;
        private decimal cantidad;
        private decimal saldo;
        private DateTime fechaCaducidad;

        public int Id_Alimentos { get => id_Alimentos; set => id_Alimentos = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Unidades { get => unidades; set => unidades = value; }
        public decimal Cantidad { get => cantidad; set => cantidad = value; }
        public decimal Saldo { get => saldo; set => saldo = value; }
        public DateTime FechaCaducidad { get => fechaCaducidad; set => fechaCaducidad = value; }
    }
}
