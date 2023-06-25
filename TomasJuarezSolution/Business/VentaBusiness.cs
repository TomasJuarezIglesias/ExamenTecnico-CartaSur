using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class VentaBusiness
    {

        public Venta ObtenerDiaMayorVentas()
        {
            VentaDataAccess ventaDataAccess = new VentaDataAccess();
            return ventaDataAccess.GetFechaMayorVentas();
        }


    }
}
