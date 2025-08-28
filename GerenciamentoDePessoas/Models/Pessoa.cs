using System.ComponentModel.DataAnnotations;
using GerenciamentoDePessoas.Models.Enum;

namespace GerenciamentoDePessoas.Models
{
    public class Pessoa
    {
        public Pessoa(int id, string nome, string sobrenome, DateTime dataNascimento)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
        }

        public Pessoa()
        {
        }

        public int Id { get; set;}
        //Com o ErrorMessage, podemos personalizar a mensagem de erro que será exibida caso o campo não seja preenchido.
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 10 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Sobrenome é obrigatório")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "O sobrenome deve ter entre 2 e 10 caracteres")]
        public string Sobrenome { get; set; }
        [CustomValidation(typeof(Pessoa), "ValidarDataNascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve conter 11 digitos sem caracteres especiais.")]
        public string cpf { get; set; }

        [Required(ErrorMessage = "O tipo sanguineo é obrigatório!")]
        public ETipoSanguineo TipoSanguineo { get; set; }

        public static ValidationResult ValidarDataNascimento(DateTime dataNascimento)
        {
            if (dataNascimento > DateTime.Now)
            {
                return new ValidationResult("A data de nascimento não pode ser futura");
            }

            return ValidationResult.Success;
        }

        
    }
}
