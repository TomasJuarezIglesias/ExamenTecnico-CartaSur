using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class VentaDataAccess
    {
        ExamenTecnicoDBConnection conn;

        public VentaDataAccess()
        {
            conn = ExamenTecnicoDBConnection.GetInstance;
        }

        // Envia el StoredProcedure al metodo leer y recibe un DataTable con el resultado
        public Venta GetFechaMayorVentas()
        {
            DataTable dataTable = conn.Leer("GetFechaMayoresVentas", null);

            string? fechaSql = dataTable.Rows[0][0].ToString();

            if(fechaSql is null) throw new NullReferenceException("No se encontro ninguna fecha");

            DateTime? fecha = DateTime.Parse(fechaSql);

            return new Venta() { Fecha_Venta = fecha };
        }



    }
}
