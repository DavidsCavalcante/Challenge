/// <summary>
/// IA.Infra.Data.Mapping
/// </summary>

namespace IA.Infra.Data.Mapping
{
    using IA.Domain.Entities;
    using IA.Domain.ValueObjects;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// MachineMap
    /// </summary>
    public class MachineMap : IEntityTypeConfiguration<Machine>
    {
        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="builder">EntityTypeBuilder<Machine> builder</param>
        public void Configure(EntityTypeBuilder<Machine> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.AntivirusInfo)
                .WithOne(av => av.Machine)
                .HasForeignKey<AntivirusInfo>(av => av.MachineId);
        }
    }
}