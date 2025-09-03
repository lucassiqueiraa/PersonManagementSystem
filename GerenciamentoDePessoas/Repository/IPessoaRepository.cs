using GerenciamentoDePessoas.Models;

namespace GerenciamentoDePessoas.Repository
{
    public interface IPessoaRepository
    {
        public Task<List<Pessoa>> BuscarTodos();
        public Task<bool> VerificarSePessoaExiste(string cpf);
        public Task<Pessoa> Criar(Pessoa pessoa); 
    }
}
