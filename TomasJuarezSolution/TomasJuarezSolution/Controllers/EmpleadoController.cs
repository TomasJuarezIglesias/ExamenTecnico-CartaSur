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
                IEnumerable<Empleado>? Empleados = await apiBusiness.GetColection();
                return View("View",Empleados);
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
                IEnumerable<Empleado>? Empleados = await apiBusiness.GetColection();
                Empleados = Empleados?.Where(e => e.Activo == false);
                return View("EmpleadosInactivos", Empleados);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // GET: EmpleadoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpleadoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
