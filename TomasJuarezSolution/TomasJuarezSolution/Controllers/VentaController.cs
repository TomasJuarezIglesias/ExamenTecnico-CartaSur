using Business;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TomasJuarezSolution.Controllers
{
    public class VentaController : Controller
    {
        // GET: VentaController
        public ActionResult VerDiaMayoresVentas()
        {
            VentaBusiness ventaServices = new VentaBusiness();
            Venta venta = ventaServices.ObtenerDiaMayorVentas();
            return View("DiaMayorVenta",venta);
        }

    }
}
