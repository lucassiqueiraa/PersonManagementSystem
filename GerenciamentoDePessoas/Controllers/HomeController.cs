using System.Diagnostics;
using GerenciamentoDePessoas.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDePessoas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment; //Para acessar informa��es do ambiente de hospedagem
        }

        public IActionResult Index()
        {
            string caminhoPasta = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            var nomeImagens = Directory
                .EnumerateFiles(caminhoPasta)
                .Select(Path.GetFileName)
                .ToList();

            return View(nomeImagens);
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
