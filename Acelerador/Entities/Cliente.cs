using Acelerador.Helpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace Acelerador.Entities
{
    [Table("clientes")]
    public class Cliente : EntidadeBase
    {
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Cpf { get; set; } = null!;

        public Cliente(string nome, string email, string cpf, string cnpj)
        {
            Nome = nome;
            Email = email;
            Cpf = cpf;

            Validador.ValidaEmail(this, email);
            Validador.ValidaCpf(this, cpf);
        }

        public void Atualizar(string? nome, string? email, string? cpf)
        {
            LimpaErros();

            if (nome is not null)
                Nome = nome;
            if (email is not null)
            {
                Validador.ValidaEmail(this, email);
                Email = email;
            }
            if (cpf is not null)
            {
                Validador.ValidaCpf(this, cpf);
                Email = cpf;
            }
        }

        private void LimpaErros()
        {
            Erros.Clear();
        }
    }
}
