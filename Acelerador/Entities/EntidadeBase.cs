using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Acelerador.Entities
{
    public class EntidadeBase
    {
        [Key]
        public Guid Id { get; private set; }

        [NotMapped]
        public HashSet<string> Erros { get; set; } = new HashSet<string>();
        [NotMapped]
        public bool EstaValido => Erros.Count == 0;
    }
}
