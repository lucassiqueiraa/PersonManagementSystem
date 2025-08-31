using GerenciamentoDePessoas.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDePessoas.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        public async Task<IActionResult> Index()
        {

            var todosUsuarios = await _pessoaService.BuscarTodos();

            return View(todosUsuarios);
        }
    }
}
