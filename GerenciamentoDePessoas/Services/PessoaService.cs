using GerenciamentoDePessoas.Models;
using GerenciamentoDePessoas.Repository;

namespace GerenciamentoDePessoas.Services
{
    public class PessoaService:IPessoaService
    {
        private readonly IPessoaRepository _pessoasRepository;

        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoasRepository = pessoaRepository;
        }

        public async Task<List<Pessoa>> BuscarTodos()
        {
            var usuariosBanco = await _pessoasRepository.BuscarTodos();
            return usuariosBanco;
        }
    }
}
