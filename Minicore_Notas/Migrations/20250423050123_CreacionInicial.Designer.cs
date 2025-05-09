﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Minicore_Notas.Data;

#nullable disable

namespace Minicore_Notas.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250423050123_CreacionInicial")]
    partial class CreacionInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Minicore_Notas.Models.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<double>("GradeValue")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Grades");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateOnly(2023, 10, 1),
                            GradeValue = 8.5,
                            Name = "Deber 1",
                            StudentId = 1
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateOnly(2023, 10, 2),
                            GradeValue = 9.5,
                            Name = "Prueba 1",
                            StudentId = 1
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateOnly(2023, 10, 3),
                            GradeValue = 10.0,
                            Name = "Control 1",
                            StudentId = 1
                        });
                });

            modelBuilder.Entity("Minicore_Notas.Models.Period", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("End")
                        .HasColumnType("date");

                    b.Property<DateOnly>("Start")
                        .HasColumnType("date");

                    b.Property<int>("Weigh")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Periods");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            End = new DateOnly(2023, 11, 25),
                            Start = new DateOnly(2023, 9, 27),
                            Weigh = 25
                        },
                        new
                        {
                            Id = 2,
                            End = new DateOnly(2024, 1, 8),
                            Start = new DateOnly(2023, 11, 26),
                            Weigh = 35
                        },
                        new
                        {
                            Id = 3,
                            End = new DateOnly(2024, 9, 30),
                            Start = new DateOnly(2024, 1, 9),
                            Weigh = 40
                        });
                });

            modelBuilder.Entity("Minicore_Notas.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Juan"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Pedro"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Maria"
                        });
                });

            modelBuilder.Entity("Minicore_Notas.Models.Grade", b =>
                {
                    b.HasOne("Minicore_Notas.Models.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Minicore_Notas.Models.Student", b =>
                {
                    b.Navigation("Grades");
                });
#pragma warning restore 612, 618
        }
    }
}
