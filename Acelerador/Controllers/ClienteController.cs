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
            if (resultado is null)
            {
                return NotFound();
            }

            return Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Salvar([FromBody] ClienteModel clienteModel, CancellationToken cancellationToken)
        {
            var resultado = await _application.Salvar(clienteModel, cancellationToken);
            if (resultado is null)
            {
                return BadRequest();
            }

            return Ok(resultado);
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] ClientePatchModel patchModel, CancellationToken cancellationToken)
        {
            var resultado = await _application.Atualizar(id, patchModel, cancellationToken);
            if (resultado is null)
            {
                return BadRequest();
            }

            return Ok(resultado);
        }
    }
}
