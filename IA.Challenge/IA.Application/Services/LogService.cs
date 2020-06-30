/// <summary>
/// IA.Application.Services
/// </summary>

namespace IA.Application.Services
{
    using IA.Domain.Interfaces.Repositories;
    using IA.Domain.Interfaces.Services;
    using System;

    /// <summary>
    /// LogService
    /// </summary>
    public class LogService : ILogService
    {

        /// <summary>
        /// ILogRepository
        /// </summary>
        private readonly ILogRepository _logRepository;

        /// <summary>
        /// LogService
        /// </summary>
        /// <param name="logRepository">logRepository</param>
        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        /// <summary>
        /// LogMessage
        /// </summary>
        /// <param name="category">category</param>
        /// <param name="message">message</param>
        /// <param name="dateTime">dateTime</param>
        public void LogMessage(string category, string message, DateTime dateTime)
        {
            _logRepository.LogMessageAsync(category, message, dateTime);
        }
    }
}