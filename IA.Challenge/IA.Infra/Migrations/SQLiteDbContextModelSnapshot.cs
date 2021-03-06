﻿// <auto-generated />
namespace IA.Infra.Migrations
{
    using IA.Infra.Data.Contexts;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;

    [DbContext(typeof(SQLiteDbContext))]
    partial class SQLiteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("IA.Domain.Entities.Machine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("LocalAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("MachineName")
                        .HasColumnType("TEXT");

                    b.Property<string>("RuntimeVersion")
                        .HasColumnType("TEXT");

                    b.Property<string>("WindowsVersion")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("IA.Domain.ValueObjects.AntivirusInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ApplicationName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("HasAntivirusInstalled")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MachineId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MachineId")
                        .IsUnique();

                    b.ToTable("AntivirusInfos");
                });

            modelBuilder.Entity("IA.Domain.ValueObjects.HardDriveInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DiskName")
                        .HasColumnType("TEXT");

                    b.Property<string>("FreeSpace")
                        .HasColumnType("TEXT");

                    b.Property<int>("MachineId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TotalSize")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MachineId");

                    b.ToTable("HardDriveInfos");
                });

            modelBuilder.Entity("IA.Domain.ValueObjects.AntivirusInfo", b =>
                {
                    b.HasOne("IA.Domain.Entities.Machine", "Machine")
                        .WithOne("AntivirusInfo")
                        .HasForeignKey("IA.Domain.ValueObjects.AntivirusInfo", "MachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IA.Domain.ValueObjects.HardDriveInfo", b =>
                {
                    b.HasOne("IA.Domain.Entities.Machine", "Machine")
                        .WithMany("HardDriveInfos")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}