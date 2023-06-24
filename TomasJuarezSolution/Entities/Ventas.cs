using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Ventas : IVentas
    {
        public int? Id_Venta { get; set; }
        public DateTime? Fecha_Venta { get; set; }
        public string? Dni_Cliente { get; set; }
        public string? Nombre_Empleado { get; set; }
        public string? Nombre_Cliente { get; set; }
        public decimal? Importe_Total { get; set; }
        public string? Direccion_Envio_Cliente { get; set; }
        public string? Direccion_Sucursal_Venta { get; set; }
        public string? Nombre_Sucursal_Venta { get; set; }
        public string? Producto { get; set; }
        public int? Cantidad { get; set; }
    }
}
