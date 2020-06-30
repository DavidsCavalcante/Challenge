/// <summary>
/// IA.Domain.Interfaces.Services
/// </summary>

namespace IA.Domain.Interfaces.Services
{
    using System;

    /// <summary>
    /// ILogService
    /// </summary>
    public interface ILogService
    {
        /// <summary>
        /// LogMessage
        /// </summary>
        /// <param name="category">category</param>
        /// <param name="message">message</param>
        /// <param name="dateTime">dateTime</param>
        void LogMessage(string category, string message, DateTime dateTime);
    }
}