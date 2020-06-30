/// <summary>
/// IA.Infra.Data.Contexts
/// </summary>

namespace IA.Infra.Data.Contexts
{
    using IA.Domain.Entities;
    using IA.Domain.ValueObjects;
    using IA.Infra.Data.Mapping;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using System;

    /// <summary>
    /// SQLiteDbContext
    /// </summary>
    public class SQLiteDbContext : DbContext
    {
        /// <summary>
        /// Machines
        /// </summary>
        public DbSet<Machine> Machines { get; set; }

        /// <summary>
        /// AntivirusInfos
        /// </summary>
        public DbSet<AntivirusInfo> AntivirusInfos { get; set; }

        /// <summary>
        /// HardDriveInfos
        /// </summary>
        public DbSet<HardDriveInfo> HardDriveInfos { get; set; }

        /// <summary>
        /// OnConfiguring
        /// </summary>
        /// <param name="optionsBuilder">optionsBuilder</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            optionsBuilder.UseSqlite(config["SQLiteConnection"]);
        }

        /// <summary>
        /// OnModelCreating
        /// </summary>
        /// <param name="modelBuilder">modelBuilder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MachineMap());
            modelBuilder.ApplyConfiguration(new HardDriveInfoMap());
        }
    }
}
