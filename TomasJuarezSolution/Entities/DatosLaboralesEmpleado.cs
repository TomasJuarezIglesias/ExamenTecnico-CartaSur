using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DatosLaboralesEmpleado
    {
        public int? Id { get; set; }
        public int? IdEmpleado { get; set; }
        public int? IdPerfilLaboral { get; set; }
        public int? IdTarea { get; set; }
        public int? IdSector { get; set; }
        public int? IdGerencia { get; set; }
        public int? IdBanco { get; set; }
        public int? IdObraSocial { get; set; }
        public string? FechaIngreso { get; set; }
        public string? NumeroCuenta { get; set; }
        public string? Cbu { get; set; }
        public int? IdContratacion { get; set; }
        public string? ArchivoLaboral { get; set; }
        public string? FechaBaja { get; set; }
        public string? MotivoBaja { get; set; }
        public string? LegajoSupervisor { get; set; }
        public string? FechaVencimientoContrato { get; set; }
        public int? IdCategoria { get; set; }
        public int? IdJornada { get; set; }
    }
}
