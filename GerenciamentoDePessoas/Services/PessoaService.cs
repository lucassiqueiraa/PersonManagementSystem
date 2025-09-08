using GerenciamentoDePessoas.Models;
using GerenciamentoDePessoas.Repository;
using System.Runtime.InteropServices;

namespace GerenciamentoDePessoas.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoasRepository;

        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoasRepository = pessoaRepository;
        }

        public async Task<Pessoa> BuscarPorId(int id)
        {
            return await _pessoasRepository.BuscarPorId(id);
        }

        public async Task<List<Pessoa>> BuscarTodos()
        {
            var pessoasBanco = await _pessoasRepository.BuscarTodos();
            return pessoasBanco;
        }

        public async Task<Pessoa> Criar(Pessoa pessoa)
        {
            var usuarioExiste = await _pessoasRepository.VerificarSePessoaExiste(pessoa.cpf);

            if (usuarioExiste)
            {
                throw new Exception("Pessoa já existe no sistema");
            }

            var pessoaCriada = await _pessoasRepository.Criar(pessoa);

            return pessoaCriada;
        }

        public async Task Deletar(int id)
        {
            var pessoaDb = await _pessoasRepository.BuscarPorId(id);

            await _pessoasRepository.Deletar(pessoaDb);
        }

        public async Task<Pessoa> Editar(Pessoa pessoa)
        {

            //Não precisa armazenar visto que ja temos a pessoa e o respectivo ID, apenas validação
            await _pessoasRepository.BuscarPorId(pessoa.Id);

            return await _pessoasRepository.Editar(pessoa);
        }
    }
}
