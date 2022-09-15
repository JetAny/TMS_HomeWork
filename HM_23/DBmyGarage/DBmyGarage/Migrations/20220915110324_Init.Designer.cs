﻿// <auto-generated />
using System;
using DBmyGarage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DBmyGarage.Migrations
{
    [DbContext(typeof(mygarageContext))]
    [Migration("20220915110324_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");

            modelBuilder.Entity("DBmyGarage.Garage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Sity")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("garages", (string)null);
                });

            modelBuilder.Entity("DBmyGarage.Transport", b =>
                {
                    b.Property<int>("IdTr")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("brand");

                    b.Property<int?>("FuelQuntity")
                        .HasColumnType("int")
                        .HasColumnName("fuelQuntity");

                    b.Property<string>("FuelType")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("fuelType");

                    b.Property<int?>("GarageId")
                        .HasColumnType("int")
                        .HasColumnName("garage_Id");

                    b.Property<int?>("MaxSpeed")
                        .HasColumnType("int")
                        .HasColumnName("maxSpeed");

                    b.Property<string>("Namber")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("namber");

                    b.Property<int?>("TypeId")
                        .HasColumnType("int")
                        .HasColumnName("type_Id");

                    b.HasKey("IdTr")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "GarageId" }, "transport_FK");

                    b.HasIndex(new[] { "TypeId" }, "transport_TP");

                    b.ToTable("transport", (string)null);
                });

            modelBuilder.Entity("DBmyGarage.Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Type1")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.ToTable("type", (string)null);
                });

            modelBuilder.Entity("DBmyGarage.Transport", b =>
                {
                    b.HasOne("DBmyGarage.Garage", "Garage")
                        .WithMany("Transports")
                        .HasForeignKey("GarageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("transport_FK");

                    b.HasOne("DBmyGarage.Type", "Type")
                        .WithMany("Transports")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("transport_TP");

                    b.Navigation("Garage");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("DBmyGarage.Garage", b =>
                {
                    b.Navigation("Transports");
                });

            modelBuilder.Entity("DBmyGarage.Type", b =>
                {
                    b.Navigation("Transports");
                });
#pragma warning restore 612, 618
        }
    }
}