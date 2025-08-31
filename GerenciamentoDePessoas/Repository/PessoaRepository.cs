using GerenciamentoDePessoas.Data;
using GerenciamentoDePessoas.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDePessoas.Repository
{
    public class PessoaRepository:IPessoaRepository
    {
        private readonly GerenciamentoDePessoasContext _context;
        public PessoaRepository(GerenciamentoDePessoasContext context)
        {
            _context = context;
        }

        public async Task<List<Pessoa>> BuscarTodos()
        {
            var usuariosBanco = await _context.Pessoas.ToListAsync();
            return usuariosBanco;

        }
    }
}
