/// <summary>
/// IA.Infra.Data.Mapping
/// </summary>

namespace IA.Infra.Data.Mapping
{
    using IA.Domain.ValueObjects;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// AntivirusInfoMap
    /// </summary>
    public class AntivirusInfoMap : IEntityTypeConfiguration<AntivirusInfo>
    {
        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="builder">EntityTypeBuilder<AntivirusInfo> builder</param>
        public void Configure(EntityTypeBuilder<AntivirusInfo> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}