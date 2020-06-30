/// <summary>
/// IA.Application.Services
/// </summary>

namespace IA.Application.Services
{
    using IA.Domain.Entities;
    using IA.Domain.Interfaces.Repositories;
    using IA.Domain.Interfaces.Services;
    using IA.Domain.ValueObjects.Return;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// SubscriptionService
    /// </summary>
    public class SubscriptionService : ISubscriptionService
    {

        /// <summary>
        /// IServiceRepository
        /// </summary>
        private readonly IServiceRepository _serviceRepository;

        /// <summary>
        /// ILogRepository
        /// </summary>
        private readonly ILogRepository _logRepository;

        /// <summary>
        /// SubscriptionService
        /// </summary>
        /// <param name="serviceRepository">serviceRepository</param>
        /// <param name="logRepository">logRepository</param>
        public SubscriptionService(IServiceRepository serviceRepository, ILogRepository logRepository)
        {
            _serviceRepository = serviceRepository;
            _logRepository = logRepository;
        }

        /// <summary>
        /// CustomResponse
        /// </summary>
        /// <returns>CustomResponse<List<Machine>></returns>
        public CustomResponse<List<Machine>> GetRestisteredMachines()
        {
            var result = _serviceRepository.Get().ToList();
            return new CustomResponse<List<Machine>>()
            {
                Data = result,
                Message = "Machines list retrieved"
            };
        }

        /// <summary>
        /// CustomResponse
        /// </summary>
        /// <param name="serviceInfo">serviceInfo</param>
        /// <returns>CustomResponse<Machine></returns>
        public CustomResponse<Machine> Subscribe(Machine serviceInfo)
        {
            var result = _serviceRepository.Subscribe(serviceInfo);
            _logRepository.LogMessageAsync("Subscription", $"The machine {serviceInfo.MachineName} registered", DateTime.Now);
            return new CustomResponse<Machine>()
            {
                Data = result,
                Message = "Service registered"
            };
        }

        /// <summary>
        /// CustomResponse<Machine>
        /// </summary>
        /// <param name="serviceInfo">serviceInfo</param>
        /// <returns>CustomResponse<Machine></returns>
        public CustomResponse<Machine> Unsubscribe(Machine serviceInfo)
        {
            var result = _serviceRepository.Unsubscribe(serviceInfo);
            _logRepository.LogMessageAsync("Unsubscription", $"The machine {serviceInfo.MachineName} unregistered", DateTime.Now);
            return new CustomResponse<Machine>()
            {
                Data = result,
                Message = "Service unregistered"
            };
        }
    }
}