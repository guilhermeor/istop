﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ParkingDbContext))]
    [Migration("20191224235837_changeLengthObservationAaddress")]
    partial class changeLengthObservationAaddress
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Parking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AvailableSpaces")
                        .HasColumnType("int");

                    b.Property<DateTime>("ClosingHour")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("OpeningHour")
                        .HasColumnType("datetime2");

                    b.Property<int>("Spaces")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Parkings");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c04eed3d-fb05-4f55-b550-33d3896b33dc"),
                            AvailableSpaces = 0,
                            ClosingHour = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "HappyParking",
                            OpeningHour = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Spaces = 120
                        });
                });

            modelBuilder.Entity("Domain.Entities.Parking", b =>
                {
                    b.OwnsOne("Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("ParkingId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnName("Number")
                                .HasColumnType("nvarchar(5)")
                                .HasMaxLength(5);

                            b1.Property<string>("Observation")
                                .IsRequired()
                                .HasColumnName("Observation")
                                .HasColumnType("nvarchar(150)")
                                .HasMaxLength(150);

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnName("Street")
                                .HasColumnType("nvarchar(50)")
                                .HasMaxLength(50);

                            b1.HasKey("ParkingId");

                            b1.ToTable("Parkings");

                            b1.WithOwner()
                                .HasForeignKey("ParkingId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
