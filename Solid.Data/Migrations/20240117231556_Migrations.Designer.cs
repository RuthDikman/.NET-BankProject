﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Solid.Data;

#nullable disable

namespace Solid.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240117231556_Migrations")]
    partial class Migrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Solid.Core.Enteties.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tz")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Solid.Core.Enteties.Official", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Officials");
                });

            modelBuilder.Entity("Solid.Core.Enteties.Turn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("OfficialId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("OfficialId");

                    b.ToTable("Turns");
                });

            modelBuilder.Entity("Solid.Core.Enteties.Turn", b =>
                {
                    b.HasOne("Solid.Core.Enteties.Customer", "Cust")
                        .WithMany("TurnsList")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Solid.Core.Enteties.Official", "Official")
                        .WithMany("TurnsList")
                        .HasForeignKey("OfficialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cust");

                    b.Navigation("Official");
                });

            modelBuilder.Entity("Solid.Core.Enteties.Customer", b =>
                {
                    b.Navigation("TurnsList");
                });

            modelBuilder.Entity("Solid.Core.Enteties.Official", b =>
                {
                    b.Navigation("TurnsList");
                });
#pragma warning restore 612, 618
        }
    }
}