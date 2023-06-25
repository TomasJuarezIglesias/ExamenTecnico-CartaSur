using Business;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TomasJuarezSolution.Controllers
{
    public class EmpleadoController : Controller
    {
        IApiBusiness<Empleado> apiBusiness;
        public EmpleadoController()
        {
            apiBusiness = new EmpleadoApiConnection();
        }

        // GET: EmpleadoController
        public async Task<ActionResult> VerEmpleadosTotales()
        {
            try
            {
                // Se obtienen todos los empleados
                IEnumerable<Empleado>? Empleados = await apiBusiness.GetColection();
                return View("ListaEmpleados",Empleados);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<ActionResult> VerEmpleadosActivos()
        {
            try
            {
                // Se obtienen todos los empleados y se filtran por activos
                IEnumerable<Empleado>? Empleados = await apiBusiness.GetColection();
                Empleados = Empleados?.Where(e => e.Activo == true);
                return View("EmpleadosActivos", Empleados);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<ActionResult> VerEmpleadosInactivos()
        {
            try
            {
                // Se obtienen todos los empleados y se filtran por inactivos
                IEnumerable<Empleado>? Empleados = await apiBusiness.GetColection();
                Empleados = Empleados?.Where(e => e.Activo == false);
                return View("EmpleadosInactivos", Empleados);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<ActionResult> VerEmpleadosPendientes()
        {
            try
            {
                // Se obtienen los empleados pendientes almacenados en la db
                EmpleadoBusiness empleadoBusiness = new();
                IEnumerable<Empleado>? Empleados = empleadoBusiness.ObtenerPendientes();
                return View("EmpleadosPendientes", Empleados);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // GET: EmpleadoController/Create
        public ActionResult IngresarEmpleado()
        {
            return View("IngresarEmpleado");
        }

        // POST: EmpleadoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                EmpleadoBusiness empleadoBusiness = new EmpleadoBusiness();
                bool Ok = empleadoBusiness.IngresarEmpleado(collection);

                // Si no se encuentra en estado pendiente de activacion
                if (!Ok)
                {
                    ViewBag.Error = "Ha ocurrido un problema con el registro. Llame al administrador";
                    return View("IngresarEmpleado");
                }

                return RedirectToAction("VerEmpleadosPendientes");
            }
            catch
            {
                return View("IngresarEmpleado");
            }
        }
    }
}
