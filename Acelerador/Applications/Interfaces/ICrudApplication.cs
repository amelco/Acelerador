using Acelerador.Models;

namespace Acelerador.Applications.Interfaces
{
    public interface ICrudApplication<TModel, TPatchModel>
        where TModel : class
        where TPatchModel : class
    {
        Task<Resultado<TModel>?> ObterPorId(Guid id, CancellationToken cancellationToken);
        Task<Resultado<IEnumerable<TModel>>?> Listar(CancellationToken cancellationToken);
        Task<Resultado<TModel>?> Atualizar(Guid id, TPatchModel patchModel, CancellationToken cancellationToken);
        Task<Resultado<TModel>?> Salvar(TModel clienteModel, CancellationToken cancellationToken);
        Task<bool> Remover(Guid id, CancellationToken cancellationToken);
    }
}
