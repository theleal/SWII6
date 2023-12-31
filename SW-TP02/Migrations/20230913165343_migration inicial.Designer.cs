﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TP02___SWII6.Data;

#nullable disable

namespace TP02___SWII6.Migrations
{
    [DbContext(typeof(ContextApplication))]
    [Migration("20230913165343_migration inicial")]
    partial class migrationinicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TP02___SWII6.Models.Conteiner", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("ID_DocumentoBL")
                        .HasColumnType("int");

                    b.Property<string>("NumeroConteiner")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("VARCHAR(11)");

                    b.Property<short>("Tamanho")
                        .HasColumnType("SMALLINT");

                    b.Property<short>("Tipo")
                        .HasColumnType("SMALLINT");

                    b.HasKey("ID");

                    b.HasIndex("ID_DocumentoBL");

                    b.ToTable("Conteiners");
                });

            modelBuilder.Entity("TP02___SWII6.Models.DocumentoBL", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Consignee")
                        .IsRequired()
                        .HasColumnType("VARCHAR(25)");

                    b.Property<string>("Navio")
                        .IsRequired()
                        .HasColumnType("VARCHAR(25)");

                    b.Property<string>("NumeroDocumento")
                        .IsRequired()
                        .HasColumnType("VARCHAR(25)");

                    b.HasKey("ID");

                    b.ToTable("DocumentosBL");
                });

            modelBuilder.Entity("TP02___SWII6.Models.Conteiner", b =>
                {
                    b.HasOne("TP02___SWII6.Models.DocumentoBL", "DocumentoBL")
                        .WithMany("Conteineres")
                        .HasForeignKey("ID_DocumentoBL")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocumentoBL");
                });

            modelBuilder.Entity("TP02___SWII6.Models.DocumentoBL", b =>
                {
                    b.Navigation("Conteineres");
                });
#pragma warning restore 612, 618
        }
    }
}
