using GerenciamentoDePessoas.Models;

namespace GerenciamentoDePessoas.Repository
{
    public interface IPessoaRepository
    {
        public Task<List<Pessoa>> BuscarTodos();
        public Task<bool> VerificarSePessoaExiste(string cpf);
        public Task<Pessoa> Criar(Pessoa pessoa); 
        public Task<Pessoa> BuscarPorId(int id);
        public Task<Pessoa> Editar(Pessoa pessoa);
        public Task Deletar(Pessoa pessoa);
    }
}
