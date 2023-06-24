using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public sealed class Empleado : Entity
    {
        public string? Legajo { get; set; }
        public string? Apellido { get; set; }
        public string? Nombre { get; set; }
        public Int64? Dni { get; set; }
        public Int64? Cuil { get; set; }
        public string? FechaNacimiento { get; set; }
        public string? Domicilio { get; set; }
        public Int64? IdLocalidad { get; set; }
        public int? IdProvincia { get; set; }
        public string? Email { get; set; }
        public string? TelefonoPrincipal { get; set; }
        public string? TelefonoOpcional { get; set; }
        public string? UsuarioDominio { get; set; }
        public string? Imei { get; set; }
        public bool? Activo { get; set; }
        public DatosLaboralesEmpleado? DatosLaborales { get; set; }
        public GerenciaEmpleado? Gerencia { get; set; }
        public PerfilLaboralEmpleado? PerfilLaboral { get; set; }
        public SectorEmpleado? Sector { get; set; }
        public TareaEmpleado? Tarea { get; set; }

    }
}
