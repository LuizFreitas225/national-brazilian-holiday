﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NationalBrazilianHolidays.Data;

#nullable disable

namespace NationalBrazilianHolidays.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FeriadoPais", b =>
                {
                    b.Property<long>("FeriadosId")
                        .HasColumnType("bigint");

                    b.Property<long>("PaisesId")
                        .HasColumnType("bigint");

                    b.HasKey("FeriadosId", "PaisesId");

                    b.HasIndex("PaisesId");

                    b.ToTable("FeriadoPais");
                });

            modelBuilder.Entity("NationalBrazilianHolidays.Model.Feriado", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long?>("Ano")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Feriados");
                });

            modelBuilder.Entity("NationalBrazilianHolidays.Model.Localidade", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("localidades");
                });

            modelBuilder.Entity("NationalBrazilianHolidays.Model.Continente", b =>
                {
                    b.HasBaseType("NationalBrazilianHolidays.Model.Localidade");

                    b.ToTable("Continente");
                });

            modelBuilder.Entity("NationalBrazilianHolidays.Model.Pais", b =>
                {
                    b.HasBaseType("NationalBrazilianHolidays.Model.Localidade");

                    b.Property<long?>("ContinenteId")
                        .HasColumnType("bigint");

                    b.Property<string>("Sigla")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("ContinenteId");

                    b.ToTable("Pais");
                });

            modelBuilder.Entity("FeriadoPais", b =>
                {
                    b.HasOne("NationalBrazilianHolidays.Model.Feriado", null)
                        .WithMany()
                        .HasForeignKey("FeriadosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NationalBrazilianHolidays.Model.Pais", null)
                        .WithMany()
                        .HasForeignKey("PaisesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NationalBrazilianHolidays.Model.Continente", b =>
                {
                    b.HasOne("NationalBrazilianHolidays.Model.Localidade", null)
                        .WithOne()
                        .HasForeignKey("NationalBrazilianHolidays.Model.Continente", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NationalBrazilianHolidays.Model.Pais", b =>
                {
                    b.HasOne("NationalBrazilianHolidays.Model.Continente", "Continente")
                        .WithMany()
                        .HasForeignKey("ContinenteId");

                    b.HasOne("NationalBrazilianHolidays.Model.Localidade", null)
                        .WithOne()
                        .HasForeignKey("NationalBrazilianHolidays.Model.Pais", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Continente");
                });
#pragma warning restore 612, 618
        }
    }
}
