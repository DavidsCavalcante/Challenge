/// <summary>
/// IA.Battle.Royalle.Controllers
/// </summary>

namespace IA.Battle.Royalle.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using IA.Battle.Royalle.Domain.Interfaces.Services;

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
        /// 
        /// </summaryCommandsController>
        /// <param name="commandService">ICommandService commandService</param>
        public CommandsController(IComandoService comandoService)
        {
            _comandoService = comandoService;
        }

        /// <summary>
        /// ExecuteCommand
        /// </summary>
        /// <param name="command">[FromBody] string command</param>
        /// <returns>json</returns>
        [HttpPost("v1/execute")]
        public IActionResult ExecuteCommand([FromBody] string command)
        {
            var result = _comandoService.ExecutaComando(command);
            return Ok(result);
        }
    }
}