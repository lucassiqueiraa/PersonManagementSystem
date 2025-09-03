using GerenciamentoDePessoas.Models;
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

        [HttpGet]
        public async Task<IActionResult> Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Pessoa pessoa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuario = await _pessoaService.Criar(pessoa);

                    TempData["Sucesso"] = $"Usuário {usuario.Nome} Criado com sucesso!";

                    return RedirectToAction("Index", "Pessoa");
                }

                return View(pessoa);
                
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
                return View(pessoa);
            }
            
        }
    }
}
