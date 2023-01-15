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

            var validador = new Validador<Cliente>(this);
            validador.ValidaEmail(this.Email);

            //if (!Auxiliadores.EmailValido(email))
            //    Erros.Add("Email inválido");
        }

        public void Atualizar(string? nome, string? email)
        {
            LimpaErros();

            if (nome is not null)
                Nome = nome;
            if (email is not null)
            {
                //if (!Auxiliadores.EmailValido(email))
                //    Erros.Add("Email inválido");
                var validador = new Validador<Cliente>(this);
                validador.ValidaEmail(email);
                Email = email;
            }
        }

        private void LimpaErros()
        {
            Erros.Clear();
        }
    }
}
