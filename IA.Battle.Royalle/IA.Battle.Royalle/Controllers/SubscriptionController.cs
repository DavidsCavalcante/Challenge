/// <summary>
/// IA.Battle.Royalle.Api.Controllers
/// </summary>

namespace IA.Battle.Royalle.Api.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using IA.Battle.Royalle.Domain.Interfaces.Services;

    /// <summary>
    /// SubscriptionController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {

        /// <summary>
        /// IServiceInformation
        /// </summary>
        private readonly IServiceInformation _serviceInformation;

        /// <summary>
        /// SubscriptionController
        /// </summary>
        /// <param name="serviceInformation"></param>
        public SubscriptionController(IServiceInformation serviceInformation)
        {
            _serviceInformation = serviceInformation;
        }

        /// <summary>
        /// Subscribe
        /// </summary>
        /// <returns>json</returns>
        [HttpPost]
        [Route("v1/subscribe")]
        public IActionResult Subscribe()
        {
            _serviceInformation.Subscribe();
            return Ok();
        }

        /// <summary>
        /// Unsubscribe
        /// </summary>
        /// <returns>json</returns>
        [HttpPost]
        [Route("v1/unsubscribe")]
        public IActionResult Unsubscribe()
        {
            _serviceInformation.Unsubscribe();
            return Ok();
        }
    }
}