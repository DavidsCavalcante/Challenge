/// <summary>
/// IA.Infra.Data.Mapping
/// </summary>

namespace IA.Infra.Data.Mapping
{
    using IA.Domain.ValueObjects;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// HardDriveInfoMap
    /// </summary>
    public class HardDriveInfoMap : IEntityTypeConfiguration<HardDriveInfo>
    {
        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="builder">EntityTypeBuilder<HardDriveInfo> builder</param>
        public void Configure(EntityTypeBuilder<HardDriveInfo> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Machine)
                .WithMany(e => e.HardDriveInfos)
                .HasForeignKey(s => s.MachineId);
        }
    }
}