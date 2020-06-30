/// <summary>
/// IA.Domain.ValueObjects.Return
/// </summary>
namespace IA.Domain.ValueObjects.Return
{
    using System.Collections.Generic;

    /// <summary>
    /// CustomResponse
    /// </summary>
    /// <typeparam name="T">CustomResponse<T></typeparam>
    public class CustomResponse<T> where T : class
    {
        /// <summary>
        /// T Data
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Notifications
        /// </summary>
        public List<CustomNotificationResponse> Notifications { get; set; }
    }
}