using DataAccess;
using Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class EmpleadoBusiness
    {
        public bool IngresarEmpleado(IFormCollection collection)
        {
            var listaDatos = collection.ToList();

            Empleado empleado = new()
            {
                Legajo = listaDatos[0].Value,
                Apellido = listaDatos[1].Value,
                Nombre = listaDatos[2].Value,
                Dni = Int64.Parse(listaDatos[3].Value),
                Cuil = Int64.Parse(listaDatos[4].Value),
                FechaNacimiento = listaDatos[5].Value
            };

            EmpleadoApiConnection empleadoApiConnection = new();
            var response = empleadoApiConnection.PostEntity(empleado);

            // Se verifica si esta en estado pendiente de activacion
            if (response.Status is not TaskStatus.WaitingForActivation)
            {

                return false;
                
            }

            // Se ingresa al empleado en la tabla de empleados pendientes para no perder su informacion.
            EmpleadoPendienteDataAccess empleadoPendienteDataAccess = new();
            empleadoPendienteDataAccess.IngresarEmpleado(empleado);

            return true;
        }

        // Metodo utilizado como medio de transferencia del resultado obtenido
        public List<Empleado> ObtenerPendientes()
        {
            EmpleadoPendienteDataAccess empleadoPendienteDataAccess = new();
            return empleadoPendienteDataAccess.ObtenerEmpleadosPendientes();
        }
        
    }
}
