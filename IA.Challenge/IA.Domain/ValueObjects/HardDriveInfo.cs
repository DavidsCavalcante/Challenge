/// <summary>
/// IA.Domain.ValueObjects
/// </summary>

namespace IA.Domain.ValueObjects
{
    using IA.Domain.Entities;

    /// <summary>
    /// HardDriveInfo
    /// </summary>
    public class HardDriveInfo : Entity
    {

        /// <summary>
        /// DiskName
        /// </summary>
        public string DiskName { get; set; }

        /// <summary>
        /// FreeSpace
        /// </summary>
        public string FreeSpace { get; set; }

        /// <summary>
        /// TotalSize
        /// </summary>
        public string TotalSize { get; set; }

        /// <summary>
        /// MachineId
        /// </summary>
        public int MachineId { get; set; }

        /// <summary>
        /// Machine
        /// </summary>
        public Machine Machine { get; set; }
    }
}