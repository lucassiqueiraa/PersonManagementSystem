using GerenciamentoDePessoas.Data;
using GerenciamentoDePessoas.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDePessoas.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly GerenciamentoDePessoasContext _context;
        public PessoaRepository(GerenciamentoDePessoasContext context)
        {
            _context = context;
        }

        public Task<List<Pessoa>> BuscarPessoasNome(string termo)
        {
            var pessoasDb = _context.Pessoas
                .Where(p => EF.Functions.Like(p.Nome, $"%{termo}%") ||
                            EF.Functions.Like(p.Sobrenome, $"%{termo}%") ||
                            EF.Functions.Like(p.cpf, $"%{termo}%"))
                .ToListAsync();

            return pessoasDb;
        }

        public async Task<Pessoa> BuscarPorId(int id)
        {
            try
            {
                var pessoaDb = await _context.Pessoas.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

                if (pessoaDb == null)
                {
                    throw new Exception("Pessoa não encontrada");
                }

                return pessoaDb;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<List<Pessoa>> BuscarTodos()
        {
            var usuariosBanco = await _context.Pessoas.ToListAsync();
            return usuariosBanco;

        }

        public async Task<int> BuscarTotal()
        {
            return await _context.Pessoas.CountAsync();
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

        public async Task Deletar(Pessoa pessoa)
        {
            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();
        }

        public async Task<Pessoa> Editar(Pessoa pessoa)
        {
            try
            {
                _context.Pessoas.Update(pessoa);
                await _context.SaveChangesAsync();
                return pessoa;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao editar pessoa: " + ex.Message);
            }
        }

        public async Task<bool> VerificarSePessoaExiste(string cpf)
        {
            var pessoaExiste = await _context.Pessoas.AnyAsync(u => u.cpf == cpf);

            return pessoaExiste;
        }
    }
}
