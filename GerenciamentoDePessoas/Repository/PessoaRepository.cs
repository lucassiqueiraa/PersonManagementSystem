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

        public async Task<Pessoa> Criar(Pessoa pessoa)
        {
            try
            {
                await _context.Pessoas.AddAsync(pessoa);
                await _context.SaveChangesAsync();

                return pessoa;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar pessoa: " + ex.Message);
            }
        }

        public async Task<bool> VerificarSePessoaExiste(string cpf)
        {
            var usuarioExiste = await _context.Pessoas.AnyAsync(u => u.cpf == cpf);

            return usuarioExiste;
        }
    }
}
