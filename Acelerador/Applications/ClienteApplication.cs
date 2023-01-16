using Acelerador.Applications.Interfaces;
using Acelerador.DbContexts.Interfaces;
using Acelerador.Entities;
using Acelerador.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Acelerador.Applications
{
    public class ClienteApplication : IClienteApplication
    {
        private readonly IDbContext _context;
        private readonly ILogger<ClienteApplication> _logger;

        public ClienteApplication(IDbContext context, ILogger<ClienteApplication> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Resultado<ClienteModel>?> Atualizar(Guid id, ClientePatchModel patchModel, CancellationToken cancellationToken)
        {
            var clienteASerAtualizado = await _context.Set<Cliente>().Where(c => c.Id == id).FirstOrDefaultAsync();
            if (clienteASerAtualizado is null)
            {
                _logger.LogInformation($"Cliente de Id {id} não encontrado");
                return new Resultado<ClienteModel>("Cliente não encontrado", HttpStatusCode.NotFound);
            }

            clienteASerAtualizado.Atualizar(patchModel.Nome, patchModel.Email, patchModel.Cpf);

            if (!clienteASerAtualizado.EstaValido)
            {
                return new Resultado<ClienteModel>(clienteASerAtualizado.Erros, HttpStatusCode.NotFound);
            }

            await _context.SaveChangesAsync();

            // TODO: utilizar automapper
            var model = new ClienteModel
            {
                Id = clienteASerAtualizado.Id,
                Nome = clienteASerAtualizado.Nome,
                Email = clienteASerAtualizado.Email
            };

            return new Resultado<ClienteModel>(model);
        }

        public async Task<Resultado<IEnumerable<ClienteModel>>?> Listar(CancellationToken cancellationToken)
        {
            var clientes = await _context.Set<Cliente>().ToListAsync();
            var clientesModel = new List<ClienteModel>();
            if (clientes is null)
            {
                _logger.LogInformation("Sem usuários cadastrados");
                return new Resultado<IEnumerable<ClienteModel>>("Sem usuários cadastrados", HttpStatusCode.NotFound);
            }

            // TODO: automapper para Converter List<Cliente> para List<ClienteModel>
            foreach (var cliente in clientes)
            {
                clientesModel.Add(new ClienteModel
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    Email = cliente.Email
                });
            }

            return new Resultado<IEnumerable<ClienteModel>>(clientesModel);
        }

        public async Task<Resultado<ClienteModel>?> ObterPorId(Guid id, CancellationToken cancellationToken)
        {
            var cliente = await _context.Set<Cliente>().Where(c => c.Id == id).FirstOrDefaultAsync();
            if (cliente is null)
            {
                _logger.LogInformation($"Cliente de Id {id} não encontrado");
                return new Resultado<ClienteModel>("Cliente não encontrado", HttpStatusCode.NotFound);
            }
            var clienteModel = new ClienteModel
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email
            };
            return new Resultado<ClienteModel>(clienteModel);
        }

        public async Task<bool> Remover(Guid id, CancellationToken cancellationToken)
        {
            var cliente = await _context.Set<Cliente>().Where(c => c.Id == id).FirstOrDefaultAsync();
            if (cliente is null)
            {
                _logger.LogInformation($"Cliente de Id {id} não encontrado. Cliente não removido.");
                return false;
            }

            _context.Set<Cliente>().Remove(cliente);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Resultado<ClienteModel>?> Salvar(ClienteModel clienteModel, CancellationToken cancellationToken)
        {
            var cliente = new Cliente(clienteModel.Nome, clienteModel.Email, clienteModel.Cpf, clienteModel.Cnpj);

            if (!cliente.EstaValido)
            {
                return new Resultado<ClienteModel>(cliente.Erros, HttpStatusCode.BadRequest);
            }

            var result = await _context.Set<Cliente>().AddAsync(cliente, cancellationToken);

            if (cliente.Id != Guid.Empty)
            {
                await _context.SaveChangesAsync();
                clienteModel.Id = result.Entity.Id;
                return new Resultado<ClienteModel>(clienteModel);
            }

            return null;
        }
    }
}
