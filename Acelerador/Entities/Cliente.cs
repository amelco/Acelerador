using Acelerador.Helpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace Acelerador.Entities
{
    [Table("clientes")]
    public class Cliente : EntidadeBase
    {
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;

        public Cliente(string nome, string email)
        {
            Nome = nome;
            Email = email;

            Validador.ValidaEmail(this, email);
        }

        public void Atualizar(string? nome, string? email)
        {
            LimpaErros();

            if (nome is not null)
                Nome = nome;
            if (email is not null)
            {
                Validador.ValidaEmail(this, email);
                Email = email;
            }
        }

        private void LimpaErros()
        {
            Erros.Clear();
        }
    }
}
