using Acelerador.Applications.Interfaces;
using Acelerador.DbContexts;
using Acelerador.DbContexts.Interfaces;
using Acelerador.Entities;
using Acelerador.Models;
using Microsoft.EntityFrameworkCore;

namespace Acelerador.Applications
{
    public class ClienteApplication : IClienteApplication
    {
        private readonly IDbContext _context;

        public ClienteApplication(IDbContext context)
        {
            _context = context;
        }

        public async Task<ClienteModel?> Atualizar(Guid id, ClientePatchModel patchModel, CancellationToken cancellationToken)
        {
            Console.WriteLine("Atualiza cliente.");
            var clienteASerAtualizado = await _context.Set<Cliente>().Where(c => c.Id == id).FirstOrDefaultAsync();
            if (clienteASerAtualizado is null)
            {
                // TODO: fazer exceção customizada
                throw new HttpRequestException("Cliente não encontrado");
            }

            clienteASerAtualizado.Atualizar(patchModel.Nome, patchModel.Email);

            // TODO: utilizar flunt notifications para verificar campos
            //if (!clienteASerAtualizado.IsValid)
            //{
            //    throw new BadHttpRequestException("Cliente não pode ser atualizado. Erros são: ");
            //}
             await _context.SaveChangesAsync();

            // TODO: utilizar automapper
            var model = new ClienteModel
            {
                Id = clienteASerAtualizado.Id,
                Nome = clienteASerAtualizado.Nome,
                Email = clienteASerAtualizado.Email
            };

            return model;
        }

        public async Task<IEnumerable<ClienteModel>?> Listar(CancellationToken cancellationToken)
        {
            Console.WriteLine("Lista cliente.");
            var clientes = await _context.Set<Cliente>().ToListAsync();

            // TODO: validar os campos (utilizar automapper e flunt notifications)
            var clientesModel = new List<ClienteModel>();
            if (clientes is not null)
            {
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
            }

            return clientesModel;
        }

        public Task<ClienteModel?> ObterPorId(Guid Id, CancellationToken cancellationToken)
        {
            Console.WriteLine("Obtém cliente por id.");
            throw new NotImplementedException();
        }

        public Task<bool> Remover(Guid id, CancellationToken cancellationToken)
        {
            Console.WriteLine("Remove cliente.");
            throw new NotImplementedException();
        }

        public async Task<ClienteModel?> Salvar(ClienteModel clienteModel, CancellationToken cancellationToken)
        {
            // TODO: validar os campos (utilizar automapper e flunt notifications)
            var cliente = new Cliente
            {
                Nome = clienteModel.Nome,
                Email = clienteModel.Email
            };

            var result = await _context.Set<Cliente>().AddAsync(cliente, cancellationToken);

            if (cliente.Id != Guid.Empty)
            {
                await _context.SaveChangesAsync();
                clienteModel.Id = result.Entity.Id;
                return clienteModel;
            }

            return null;
        }
    }
}
