using Acelerador.Applications.Interfaces;
using Acelerador.Models;
using Microsoft.AspNetCore.Mvc;

namespace Acelerador.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteApplication _application;

        public ClienteController(IClienteApplication application)
        {
            _application = application;
        }

        [HttpGet]
        public async Task<IActionResult> Listar(CancellationToken cancellationToken)
        {
            var resultado = await _application.Listar(cancellationToken);
            return Ok(resultado);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id, CancellationToken cancellationToken)
        {
            var resultado = await _application.ObterPorId(id, cancellationToken);
            return Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Salvar([FromBody] ClienteModel clienteModel, CancellationToken cancellationToken)
        {
            var resultado = await _application.Salvar(clienteModel, cancellationToken);
            return Ok(resultado);
        }

        [HttpPatch]
        [Route("{id}")]
        [ProducesResponseType(typeof(ClienteModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] ClientePatchModel patchModel, CancellationToken cancellationToken)
        {
            var resultado = await _application.Atualizar(id, patchModel, cancellationToken);
            return Ok(resultado);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Remover(Guid id, CancellationToken cancellationToken)
        {
            var resultado = await _application.Remover(id, cancellationToken);
            return Ok(resultado);
        }
    }
}
