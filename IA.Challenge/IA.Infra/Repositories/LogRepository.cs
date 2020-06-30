/// <summary>
/// IA.Infra.Repositories
/// </summary>

namespace IA.Infra.Repositories
{
    using IA.Domain.Interfaces.Repositories;
    using IA.Infra.Data.Contexts;
    using System;
    using System.IO;
    using System.Text;

    /// <summary>
    /// LogRepository
    /// </summary>
    public class LogRepository : ILogRepository
    {
        /// <summary>
        /// SQLiteDbContext
        /// </summary>
        private readonly SQLiteDbContext _context;

        /// <summary>
        /// LogRepository
        /// </summary>
        /// <param name="context">context</param>
        public LogRepository(SQLiteDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// LogMessageAsync
        /// </summary>
        /// <param name="category">string category</param>
        /// <param name="message">string message</param>
        /// <param name="dateTime">DateTime dateTime</param>
        public async void LogMessageAsync(string category, string message, DateTime dateTime)
        {
            string logFilePath = Path.Combine(AppContext.BaseDirectory, "logfile.txt");

            using (var stream = new FileStream(logFilePath, FileMode.Append, FileAccess.Write, FileShare.Write, 4096, useAsync: true))
            {
                var bytes = Encoding.UTF8.GetBytes($"{category} - {message} at {dateTime}" + Environment.NewLine);
                await stream.WriteAsync(bytes, 0, bytes.Length);
            }
        }
    }
}