using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    class MovimientoAlimentos
    {
        private int id_Movimiento;
        private string codigo;
        private DateTime fechaMovimiento;
        private string lote;
        private decimal cantidadAutorizada;
        private string envaseEmpaque;
        private int unidadesCompletas;
        private int unidadesFracciones;
        private int fk_Alimentos;

        public int Id_Movimiento { get => id_Movimiento; set => id_Movimiento = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public DateTime FechaMovimiento { get => fechaMovimiento; set => fechaMovimiento = value; }
        public string Lote { get => lote; set => lote = value; }
        public decimal CantidadAutorizada { get => cantidadAutorizada; set => cantidadAutorizada = value; }
        public string EnvaseEmpaque { get => envaseEmpaque; set => envaseEmpaque = value; }
        public int UnidadesCompletas { get => unidadesCompletas; set => unidadesCompletas = value; }
        public int UnidadesFracciones { get => unidadesFracciones; set => unidadesFracciones = value; }
        public int Fk_Alimentos { get => fk_Alimentos; set => fk_Alimentos = value; }
    }
}
