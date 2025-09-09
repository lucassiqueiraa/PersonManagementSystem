using GerenciamentoDePessoas.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDePessoas.Services
{
    public interface IPessoaService
    {
        public Task<List<Pessoa>> BuscarTodos();
        public Task<int> BuscarTotal();
        public Task<List<string>> BuscarPessoasNome(string termo);
        public Task<Pessoa> Criar(Pessoa pessoa);
        public Task<Pessoa> BuscarPorId(int id);
        public Task<Pessoa> Editar(Pessoa pessoa);
        public Task Deletar(int id);

    }
}
