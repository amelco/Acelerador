using System.ComponentModel.DataAnnotations.Schema;

namespace Acelerador.Entities
{
    [Table("clientes")]
    public class Cliente : EntidadeBase
    {
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;


        public void Atualizar(string? nome, string? email)
        {
            if (nome is not null)
                Nome = nome;
            if (email is not null)
                Email = email;
        }
    }
}
