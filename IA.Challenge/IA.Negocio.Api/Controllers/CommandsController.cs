/// <summary>
///  IA.Controllers
/// </summary>

namespace IA.Controllers
{
    using IA.Domain.Interfaces.Services;
    using IA.Domain.ValueObjects;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// CommandsController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        /// <summary>
        /// ICommandService
        /// </summary>
        private readonly IComandoService _comandoService;

        /// <summary>
        /// CommandsController
        /// </summary>
        /// <param name="commandService">ICommandService commandService</param>
        public CommandsController(IComandoService comandoService)
        {
            _comandoService = comandoService;
        }
        
        /// <summary>
        /// ExecuteCommand
        /// </summary>
        /// <param name="command">[FromBody] Command command</param>
        /// <returns>return Ok(result)</returns>
        [HttpPost("executar")]
        public IActionResult ExecutaComando([FromBody] Comando comando)
        {
            var result = _comandoService.Executar(comando);
            return Ok(result);
        }
    }
}