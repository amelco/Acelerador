using System.ComponentModel.DataAnnotations;

namespace Acelerador.Entities
{
    public class EntidadeBase
    {
        [Key]
        public Guid Id { get; private set; }
    }
}
