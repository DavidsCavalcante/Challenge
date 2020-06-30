/// <summary>
/// IA.Domain.Entities
/// </summary>

namespace IA.Domain.Entities
{
    using System.Collections.Generic;
    using IA.Domain.ValueObjects;

    /// <summary>
    /// Machine
    /// </summary>
    public class Machine : Entity
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
        /// ICollection<HardDriveInfo> HardDriveInfos
        /// </summary>
        public ICollection<HardDriveInfo> HardDriveInfos { get; set; }
    }
}
