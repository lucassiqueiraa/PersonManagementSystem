using GerenciamentoDePessoas.Models;
using GerenciamentoDePessoas.Repository;
using System.Runtime.InteropServices;

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

        public async Task<Pessoa> Criar(Pessoa pessoa)
        {
            var usuarioExiste = await _pessoasRepository.VerificarSePessoaExiste(pessoa.cpf);

            if(usuarioExiste)
            {
                throw new Exception("Usuário já existe");
            }

            var usuarioCriado = await _pessoasRepository.Criar(pessoa);

            return usuarioCriado;
        }

     
    }
}
