using Microsoft.AspNetCore.Mvc;
using PRUEBA.Models;
using PRUEBA.Services; // Asegúrate de importar el namespace correcto
using System.Diagnostics;

namespace PRUEBA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ConexionService _conexionService;

        public HomeController(ILogger<HomeController> logger, ConexionService conexionService)
        {
            _logger = logger;
            _conexionService = conexionService;
        }

        public IActionResult Index()
        {
            bool conectado = _conexionService.EstaConectado();
            TempData["EstadoConexion"] = conectado ? "Conectado a la base de datos." : "No se pudo conectar a la base de datos.";
            TempData["TipoAlerta"] = conectado ? "success" : "danger";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}