using System.ComponentModel.DataAnnotations;

namespace TomasJuarezSolution.Models.ViewModels
{
    public class EmpleadoViewModel
    {
        [Required]
        public string? Legajo { get; set; }
        [Required]
        public string? Apellido { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 8)]
        public Int64 Dni { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 11)]
        public Int64 Cuil { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
    }
}
