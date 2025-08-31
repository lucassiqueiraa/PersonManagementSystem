using GerenciamentoDePessoas.Models;

namespace GerenciamentoDePessoas.Repository
{
    public interface IPessoaRepository
    {
        public Task<List<Pessoa>> BuscarTodos();
    }
}
