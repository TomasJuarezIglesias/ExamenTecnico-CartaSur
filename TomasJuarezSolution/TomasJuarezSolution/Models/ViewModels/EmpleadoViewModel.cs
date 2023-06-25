using System.ComponentModel.DataAnnotations;

namespace TomasJuarezSolution.Models.ViewModels
{
    public class EmpleadoViewModel
    {
        [Required(ErrorMessage = "El Legajo es requerido")]
        public string? Legajo { get; set; }
        [Required(ErrorMessage = "El Apellido es requerido")]
        public string? Apellido { get; set; }
        [Required(ErrorMessage = "El Nombre es requerido")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El Dni es requerido")]
        [StringLength(8, MinimumLength = 7, ErrorMessage = "Dni no valido")]
        public Int64 Dni { get; set; }
        [Required(ErrorMessage = "El Cuil es requerido")]
        [StringLength(11, MinimumLength = 10, ErrorMessage = "Cuil no valido")]
        public Int64 Cuil { get; set; }
        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        public DateTime FechaNacimiento { get; set; }
    }
}
