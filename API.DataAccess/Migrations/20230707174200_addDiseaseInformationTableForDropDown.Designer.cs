﻿// <auto-generated />
using System;
using API.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230707174200_addDiseaseInformationTableForDropDown")]
    partial class addDiseaseInformationTableForDropDown
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Models.DiseaseInformation", b =>
                {
                    b.Property<Guid>("DiseaseInformationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DiseaseInformationName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DiseaseInformationId");

                    b.ToTable("DiseaseInformations");
                });

            modelBuilder.Entity("API.Models.Patient", b =>
                {
                    b.Property<Guid>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PatientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientId");

                    b.ToTable("Patients");
                });
#pragma warning restore 612, 618
        }
    }
}
