/// <summary>
/// IA.Domain.Interfaces.Services
/// </summary>
namespace IA.Domain.Interfaces.Services
{
    using IA.Domain.Entities;
    using IA.Domain.ValueObjects.Return;
    using System.Collections.Generic;

    /// <summary>
    /// ISubscriptionService
    /// </summary>
    public interface ISubscriptionService
    {
        /// <summary>
        /// CustomResponse
        /// </summary>
        /// <param name="serviceInfo">serviceInfo</param>
        /// <returns></returns>
        CustomResponse<Machine> Subscribe(Machine serviceInfo);

        /// <summary>
        /// CustomResponse
        /// </summary>
        /// <param name="serviceInfo">serviceInfo</param>
        /// <returns></returns>
        CustomResponse<Machine> Unsubscribe(Machine serviceInfo);

        /// <summary>
        /// CustomResponse
        /// </summary>
        /// <returns><List<Machine>></returns>
        CustomResponse<List<Machine>> GetRestisteredMachines();
    }
}