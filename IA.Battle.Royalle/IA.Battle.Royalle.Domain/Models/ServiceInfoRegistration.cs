/// <summary>
/// IA.Battle.Royalle.Domain.Models
/// </summary>

namespace IA.Battle.Royalle.Domain.Models
{

    using System.Collections.Generic;

    /// <summary>
    /// ServiceInfoRegistration
    /// </summary>
    public class ServiceInfoRegistration
    {

        /// <summary>
        /// MachineName
        /// </summary>
        public string MachineName { get; set; }

        /// <summary>
        /// LocalAddress
        /// </summary>
        public string LocalAddress { get; set; }

        /// <summary>
        /// AntivirusInfo
        /// </summary>
        public AntivirusInfo AntivirusInfo { get; set; }

        /// <summary>
        /// WindowsVersion
        /// </summary>
        public string WindowsVersion { get; set; }

        /// <summary>
        /// RuntimeVersion
        /// </summary>
        public string RuntimeVersion { get; set; }

        /// <summary>
        /// HardDriveInfos
        /// </summary>
        public ICollection<HardDriveInfo> HardDriveInfos { get; set; }
    }
}