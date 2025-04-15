﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NicksSchoolDiary.DAL.DataContext;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NicksSchoolDiary.DAL.Migrations
{
    [DbContext(typeof(NicksSchoolDiaryDbContext))]
    partial class NicksSchoolDiaryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NicksSchoolDiary.Domain.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("character varying(45)");

                    b.Property<int>("StudentClassId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("StudentClassId");

                    b.HasIndex(new[] { "Name" }, "NameStudent");

                    b.ToTable("Student", (string)null);
                });

            modelBuilder.Entity("NicksSchoolDiary.Domain.Models.StudentClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "NameClass")
                        .IsUnique();

                    b.ToTable("StudentClass", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "1A"
                        },
                        new
                        {
                            Id = 2,
                            Name = "1B"
                        },
                        new
                        {
                            Id = 3,
                            Name = "2A"
                        },
                        new
                        {
                            Id = 4,
                            Name = "2B"
                        },
                        new
                        {
                            Id = 5,
                            Name = "3A"
                        },
                        new
                        {
                            Id = 6,
                            Name = "3B"
                        },
                        new
                        {
                            Id = 7,
                            Name = "4A"
                        },
                        new
                        {
                            Id = 8,
                            Name = "4B"
                        },
                        new
                        {
                            Id = 9,
                            Name = "5A"
                        });
                });

            modelBuilder.Entity("NicksSchoolDiary.Domain.Models.Student", b =>
                {
                    b.HasOne("NicksSchoolDiary.Domain.Models.StudentClass", "StudentClass")
                        .WithMany("Student")
                        .HasForeignKey("StudentClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StudentClass");
                });

            modelBuilder.Entity("NicksSchoolDiary.Domain.Models.StudentClass", b =>
                {
                    b.Navigation("Student");
                });
#pragma warning restore 612, 618
        }
    }
}
