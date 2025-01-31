﻿// <auto-generated />
using Catalog.Host.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Catalog.Host.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230214154559_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.HasSequence("abnormal_type_hilo")
                .IncrementsBy(10);

            modelBuilder.HasSequence("anomaly_hilo")
                .IncrementsBy(10);

            modelBuilder.HasSequence("artefact_hilo")
                .IncrementsBy(10);

            modelBuilder.HasSequence("characteristic_hilo")
                .IncrementsBy(10);

            modelBuilder.HasSequence("frequency_hilo")
                .IncrementsBy(10);

            modelBuilder.HasSequence("location_hilo")
                .IncrementsBy(10);

            modelBuilder.Entity("Catalog.Host.Data.Entities.AbnormalTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "abnormal_type_hilo");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("AbnormalType", (string)null);
                });

            modelBuilder.Entity("Catalog.Host.Data.Entities.AnomalyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "anomaly_hilo");

                    b.Property<int>("AbnormalTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("FrequencyId")
                        .HasColumnType("integer");

                    b.Property<int>("LocationId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("AbnormalTypeId");

                    b.HasIndex("FrequencyId");

                    b.HasIndex("LocationId");

                    b.ToTable("Anomaly", (string)null);
                });

            modelBuilder.Entity("Catalog.Host.Data.Entities.ArtefactEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "artefact_hilo");

                    b.Property<int>("AbnormalTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("AnomalyId")
                        .HasColumnType("integer");

                    b.Property<int>("CharacteristicId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Cost")
                        .HasColumnType("numeric");

                    b.Property<int>("FrequencyId")
                        .HasColumnType("integer");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Nature")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("AbnormalTypeId");

                    b.HasIndex("AnomalyId");

                    b.HasIndex("CharacteristicId");

                    b.HasIndex("FrequencyId");

                    b.ToTable("Artefact", (string)null);
                });

            modelBuilder.Entity("Catalog.Host.Data.Entities.CharacteristicEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "characteristic_hilo");

                    b.Property<int>("ChemicalProtection")
                        .HasColumnType("integer");

                    b.Property<int>("ElectricalProtection")
                        .HasColumnType("integer");

                    b.Property<int>("MaximumWeight")
                        .HasColumnType("integer");

                    b.Property<int>("ProtectionDogs")
                        .HasColumnType("integer");

                    b.Property<int>("Radiation")
                        .HasColumnType("integer");

                    b.Property<int>("Restoration")
                        .HasColumnType("integer");

                    b.Property<int>("RestorationHealth")
                        .HasColumnType("integer");

                    b.Property<int>("Saturation")
                        .HasColumnType("integer");

                    b.Property<int>("ThermalProtection")
                        .HasColumnType("integer");

                    b.Property<int>("WoundHealing")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Characteristic", (string)null);
                });

            modelBuilder.Entity("Catalog.Host.Data.Entities.FrequencyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "frequency_hilo");

                    b.Property<string>("Meets")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Meets", (string)null);
                });

            modelBuilder.Entity("Catalog.Host.Data.Entities.LocationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "location_hilo");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Location", (string)null);
                });

            modelBuilder.Entity("Catalog.Host.Data.Entities.AnomalyEntity", b =>
                {
                    b.HasOne("Catalog.Host.Data.Entities.AbnormalTypeEntity", "Type")
                        .WithMany()
                        .HasForeignKey("AbnormalTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Catalog.Host.Data.Entities.FrequencyEntity", "Meets")
                        .WithMany()
                        .HasForeignKey("FrequencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Catalog.Host.Data.Entities.LocationEntity", "LocationPlace")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LocationPlace");

                    b.Navigation("Meets");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Catalog.Host.Data.Entities.ArtefactEntity", b =>
                {
                    b.HasOne("Catalog.Host.Data.Entities.AbnormalTypeEntity", "Type")
                        .WithMany()
                        .HasForeignKey("AbnormalTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Catalog.Host.Data.Entities.AnomalyEntity", "Anomaly")
                        .WithMany()
                        .HasForeignKey("AnomalyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Catalog.Host.Data.Entities.CharacteristicEntity", "Values")
                        .WithMany()
                        .HasForeignKey("CharacteristicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Catalog.Host.Data.Entities.FrequencyEntity", "Meets")
                        .WithMany()
                        .HasForeignKey("FrequencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Anomaly");

                    b.Navigation("Meets");

                    b.Navigation("Type");

                    b.Navigation("Values");
                });
#pragma warning restore 612, 618
        }
    }
}
