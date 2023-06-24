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
    public class VentasDataAccess
    {
        DBConnection conn;

        public VentasDataAccess()
        {
            conn = DBConnection.GetInstance;
        }

        // Envia el StoredProcedure al metodo leer y recibe un DataTable
        public Ventas GetFechaMayorVentas()
        {
            DataTable dataTable = conn.Leer("GetFechaMayoresVentas", null);

            // Aqui se hace el tryparse de tan solo la primer columna y primera fila ya que se sabe que tan solo devuelve un valor
            DateTime? fecha;
            if (!DateTime.TryParse(dataTable.Rows[0][0].ToString(), out DateTime result))
            {
                return new Ventas();
            }

            fecha = result;
            return new Ventas() { Fecha_Venta = fecha };
        }



    }
}
