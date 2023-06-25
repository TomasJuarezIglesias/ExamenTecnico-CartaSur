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

            if (response.Status is not TaskStatus.WaitingForActivation)
            {

                return false;
                
            }

            // Ingresar en una DB al nuevo empleado
            EmpleadoPendienteDataAccess empleadoPendienteDataAccess = new();
            empleadoPendienteDataAccess.IngresarEmpleado(empleado);

            return true;
        }

        public List<Empleado> ObtenerPendientes()
        {
            EmpleadoPendienteDataAccess empleadoPendienteDataAccess = new();
            return empleadoPendienteDataAccess.ObtenerEmpleadosPendientes();
        }
        
    }
}
