using GerenciamentoDePessoas.Models;

namespace GerenciamentoDePessoas.Services
{
    public interface IPessoaService
    {
        public Task<List<Pessoa>> BuscarTodos();
        public Task<Pessoa> Criar(Pessoa pessoa);
        public Task<Pessoa> BuscarPorId(int id);
        public Task<Pessoa> Editar(Pessoa pessoa);
    }
}
