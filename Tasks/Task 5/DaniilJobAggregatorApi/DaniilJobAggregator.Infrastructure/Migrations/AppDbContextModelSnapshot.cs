﻿// <auto-generated />
using System.Collections.Generic;
using DaniilJobAggregator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DaniilJobAggregator.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DaniilJobAggregator.Core.Entities.Organisation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Organisations");
                });

            modelBuilder.Entity("DaniilJobAggregator.Core.Entities.Vacancy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.PrimitiveCollection<List<string>>("Conditions")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("IdOrganisation")
                        .HasColumnType("integer");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("OrganisationId")
                        .HasColumnType("integer");

                    b.PrimitiveCollection<List<string>>("Requirements")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.PrimitiveCollection<List<string>>("Responsibilities")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<decimal?>("Salary")
                        .HasColumnType("numeric");

                    b.Property<int>("ScheduleType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrganisationId");

                    b.ToTable("Vacancies");
                });

            modelBuilder.Entity("DaniilJobAggregator.Core.Entities.Vacancy", b =>
                {
                    b.HasOne("DaniilJobAggregator.Core.Entities.Organisation", null)
                        .WithMany("Vacancies")
                        .HasForeignKey("OrganisationId");
                });

            modelBuilder.Entity("DaniilJobAggregator.Core.Entities.Organisation", b =>
                {
                    b.Navigation("Vacancies");
                });
#pragma warning restore 612, 618
        }
    }
}
