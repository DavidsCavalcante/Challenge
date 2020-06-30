/// <summary>
/// IA.Battle.Royalle.Application.Settings
/// </summary>

namespace IA.Battle.Royalle.Application.Settings
{

    /// <summary>
    /// CoreApiSettings
    /// </summary>
    public class CoreApiSettings
    {
        /// <summary>
        /// CoreApiSettings
        /// </summary>
        /// <param name="host">string host</param>
        public CoreApiSettings(string host)
        {
            Host = host;
        }

        /// <summary>
        /// Host
        /// </summary>
        public string Host { get; set; }
    }
}