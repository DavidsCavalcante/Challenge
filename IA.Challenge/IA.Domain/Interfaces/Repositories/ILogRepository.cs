/// <summary>
/// IA.Domain.Interfaces.Repositories
/// </summary>

namespace IA.Domain.Interfaces.Repositories
{
    using System;

    /// <summary>
    /// ILogRepository
    /// </summary>
    public interface ILogRepository
    {
        /// <summary>
        /// LogMessageAsync
        /// </summary>
        /// <param name="category">category</param>
        /// <param name="message">message</param>
        /// <param name="dateTime">dateTime</param>
        void LogMessageAsync(string category, string message, DateTime dateTime);
    }
}
