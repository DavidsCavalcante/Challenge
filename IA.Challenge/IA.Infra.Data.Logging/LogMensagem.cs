/// <summary>
/// Log
/// </summary>

namespace IA.Infra.Data.Logging
{
    using System;
    using System.Text;
    using System.IO;

    /// <summary>
    /// Log do Sistema
    /// </summary>
    public class LogMensagem
    {
       
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