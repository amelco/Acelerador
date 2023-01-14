namespace Acelerador.Applications.Interfaces
{
    public interface ICrudApplication<TModel, TPatchModel>
        where TModel : class
        where TPatchModel : class
    {
        Task<TModel?> ObterPorId(Guid Id, CancellationToken cancellationToken);
        Task<IEnumerable<TModel>?> Listar(CancellationToken cancellationToken);
        Task<TModel?> Atualizar(Guid id, TPatchModel patchModel, CancellationToken cancellationToken);
        Task<TModel?> Salvar(TModel clienteModel, CancellationToken cancellationToken);
        Task<bool> Remover(Guid id, CancellationToken cancellationToken);
    }
}
