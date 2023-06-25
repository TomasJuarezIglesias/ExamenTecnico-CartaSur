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
    public class EmpleadoPendienteDataAccess
    {
        ExamenTecnicoDBConnection conn;

        public EmpleadoPendienteDataAccess()
        {
            conn = ExamenTecnicoDBConnection.GetInstance;
        }

        // Se ingresa un Empleado
        public void IngresarEmpleado(Empleado empleadoPendiente)
        {
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@Legajo", empleadoPendiente.Legajo),
                new SqlParameter("@Apellido", empleadoPendiente.Apellido),
                new SqlParameter("@Nombre", empleadoPendiente.Nombre),
                new SqlParameter("@Dni", empleadoPendiente.Dni),
                new SqlParameter("@Cuil", empleadoPendiente.Cuil),
                new SqlParameter("@Fecha_nacimiento", empleadoPendiente.FechaNacimiento)
            };

            // En este caso no se utiliza el booleano retornado,
            // ya que se va a ejecutar el metodo si y solo si la respuesta del post es positiva(esperando aprobacion)
            conn.Ingresar("IngresarEmpleadoPendiente", sqlParameters);
        }


        public List<Empleado> ObtenerEmpleadosPendientes()
        {
            List<Empleado> EmpleadosPendientes = new();

            DataTable dataTable = conn.Leer("ObtenerEmpleadosPendientes", null);



            foreach (DataRow row in dataTable.Rows)
            {
                Empleado Empleado = new Empleado
                {
                    Legajo = row["Legajo"].ToString(),
                    Apellido = row["Apellido"].ToString(),
                    Nombre = row["Nombre"].ToString(),
                    Dni = Int64.Parse(row["Dni"].ToString()),
                    Cuil = Int64.Parse(row["Cuil"].ToString()),
                    FechaNacimiento = row["Fecha_nacimiento"].ToString()
                };

                EmpleadosPendientes.Add(Empleado);
                
            }

            return EmpleadosPendientes;
        }

    }
}
