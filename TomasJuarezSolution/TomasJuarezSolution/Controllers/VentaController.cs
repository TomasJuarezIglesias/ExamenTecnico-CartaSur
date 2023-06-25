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
            // Se obtiene la fecha de mayor cantidad de ventas y se envia a la view el objeto que contiene la fecha
            VentaBusiness ventaServices = new VentaBusiness();
            Venta venta = ventaServices.ObtenerDiaMayorVentas();
            return View("DiaMayorVenta",venta);
        }

    }
}
