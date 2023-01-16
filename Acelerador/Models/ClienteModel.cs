namespace Acelerador.Models
{
    public class ClienteModel : ModelBase
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Cpf { get; internal set; }
    }

    public class ClientePatchModel : ModelBase
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Cpf { get; internal set; }
    }
}
