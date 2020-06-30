/// <summary>
/// IA.Domain.ValueObjects
/// </summary>

namespace IA.Domain.ValueObjects
{
    using IA.Domain.Entities;

    /// <summary>
    /// AntivirusInfo
    /// </summary>
    public class AntivirusInfo : Entity
    {
        /// <summary>
        /// HasAntivirusInstalled
        /// </summary>
        public bool HasAntivirusInstalled { get; set; }

        /// <summary>
        /// ApplicationName
        /// </summary>
        public string ApplicationName { get; set; }

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