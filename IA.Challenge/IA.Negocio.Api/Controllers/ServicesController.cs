/// <summary>
/// IA.Controllers
/// </summary>

namespace IA.Controllers
{
    using IA.Domain.Entities;
    using IA.Domain.Interfaces.Services;
    using IA.Hubs;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;

    /// <summary>
    /// ServicesController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private IHubContext<SubscriptionHub> _hub;
        private readonly ILogService _logService;
        private readonly ISubscriptionService _subscriptionService;

        /// <summary>
        /// ServicesController
        /// </summary>
        /// <param name="logService">ILogService logService</param>
        /// <param name="subscriptionService">ISubscriptionService subscriptionService</param>
        /// <param name="hub">IHubContext<SubscriptionHub> hu</param>
        public ServicesController(ILogService logService, ISubscriptionService subscriptionService, IHubContext<SubscriptionHub> hub)
        {
            _hub = hub;
            _logService = logService;
            _subscriptionService = subscriptionService;
        }

        /// <summary>
        /// ServiceSubscribe
        /// </summary>
        /// <param name="serviceInfo">[FromBody] Machine serviceInfo</param>
        /// <returns>json</returns>
        [HttpPost("v1/subscribe")]
        public IActionResult ServiceSubscribe([FromBody] Machine serviceInfo)
        {
            var result = _subscriptionService.Subscribe(serviceInfo);

            if (serviceInfo != null)
                return Ok(result);
            else
                return BadRequest("Erro ai consultar API.");
        }

        /// <summary>
        /// ServiceUnsubscribe
        /// </summary>
        /// <param name="serviceInfo">[FromBody] Machine serviceInfo</param>
        /// <returns>json</returns>
        [HttpPost("v1/unsubscribe")]
        public IActionResult ServiceUnsubscribe([FromBody] Machine serviceInfo)
        {
            var result = _subscriptionService.Unsubscribe(serviceInfo);

            if (serviceInfo != null)
                return Ok(result);
            else
                return BadRequest("Erro ai consultar API.");
        }

        /// <summary>
        /// SignalR
        /// </summary>
        /// <returns>SignalR</returns>
        [HttpGet("v1/subscription")]
        public IActionResult SignalR()
        {
            this._hub.Clients.All.SendAsync("transferchartdata", new { resp = "resposta SignalR" });
            return Ok("Retorno");
        }

        /// <summary>
        /// GetServiceList
        /// </summary>
        /// <returns>json</returns>
        [HttpGet("v1/listar")]
        public IActionResult GetServiceList()
        {
            var result = _subscriptionService.GetRestisteredMachines();
            return Ok(result);
        } 
    }
}