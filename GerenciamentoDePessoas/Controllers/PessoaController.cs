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

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            try
            {
                if (id == 0)
                {
                    throw new Exception("Id inválido");
                }

                var pessoaDb = await _pessoaService.BuscarPorId(id);

                return View(pessoaDb);
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
                return RedirectToAction("Index", "Pessoa");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Editar(Pessoa pessoa)
        {
            try
            {
                if (pessoa.Id == 0)
                {
                    throw new Exception("Id inválido");
                }

                var pessoaDb = await _pessoaService.Editar(pessoa);

                TempData["Sucesso"] = $"Pessoa {pessoaDb.Nome} editado com sucesso!";

                return RedirectToAction("Index", "Pessoa");
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
                return View(pessoa);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                if (id == 0)
                {
                    throw new Exception("Id inválido");
                }

                await _pessoaService.Deletar(id);

                TempData["Sucesso"] = $"Pessoa deletada com sucesso!";

                return RedirectToAction("Index", "Pessoa");

            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
                return RedirectToAction("Index", "Pessoa");
            }
        }
    }
}
