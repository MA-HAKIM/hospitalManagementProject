﻿// <auto-generated />
using HospitalManagement_API.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HospitalManagement_API.Migrations
{
    [DbContext(typeof(HospitalDbContext))]
    partial class HospitalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HospitalManagement_API.Model.Allergies", b =>
                {
                    b.Property<int>("AllergiesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AllergiesID"), 1L, 1);

                    b.Property<string>("AllergiesName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AllergiesID");

                    b.ToTable("Allergies");
                });

            modelBuilder.Entity("HospitalManagement_API.Model.Allergies_Details", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("AllergiesID")
                        .HasColumnType("int");

                    b.Property<int>("PatientInformationID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PatientInformationID");

                    b.ToTable("AllergiesDetails");
                });

            modelBuilder.Entity("HospitalManagement_API.Model.DiseaseInformation", b =>
                {
                    b.Property<int>("DiseaseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiseaseID"), 1L, 1);

                    b.Property<string>("DiseaseName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DiseaseID");

                    b.ToTable("DiseaseInformation");
                });

            modelBuilder.Entity("HospitalManagement_API.Model.NCD", b =>
                {
                    b.Property<int>("NCDID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NCDID"), 1L, 1);

                    b.Property<string>("NCDName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("NCDID");

                    b.ToTable("NCD");
                });

            modelBuilder.Entity("HospitalManagement_API.Model.NCD_Details", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("NCDID")
                        .HasColumnType("int");

                    b.Property<int>("PatientInformationID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PatientInformationID");

                    b.ToTable("NCDDetails");
                });

            modelBuilder.Entity("HospitalManagement_API.Model.PatientInformation", b =>
                {
                    b.Property<int>("PatientInformationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientInformationID"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("ContactNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DiseaseId")
                        .HasColumnType("int");

                    b.Property<int>("Epilepsy")
                        .HasColumnType("int");

                    b.Property<string>("PatientName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("PatientInformationID");

                    b.HasIndex("DiseaseId");

                    b.ToTable("PatientInformation");
                });

            modelBuilder.Entity("HospitalManagement_API.Model.Allergies_Details", b =>
                {
                    b.HasOne("HospitalManagement_API.Model.PatientInformation", "PatientInformation")
                        .WithMany("Allergies_Details")
                        .HasForeignKey("PatientInformationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PatientInformation");
                });

            modelBuilder.Entity("HospitalManagement_API.Model.NCD_Details", b =>
                {
                    b.HasOne("HospitalManagement_API.Model.PatientInformation", "PatientInformation")
                        .WithMany("NCD_Details")
                        .HasForeignKey("PatientInformationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PatientInformation");
                });

            modelBuilder.Entity("HospitalManagement_API.Model.PatientInformation", b =>
                {
                    b.HasOne("HospitalManagement_API.Model.DiseaseInformation", "DiseaseInformation")
                        .WithMany("Patients")
                        .HasForeignKey("DiseaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DiseaseInformation");
                });

            modelBuilder.Entity("HospitalManagement_API.Model.DiseaseInformation", b =>
                {
                    b.Navigation("Patients");
                });

            modelBuilder.Entity("HospitalManagement_API.Model.PatientInformation", b =>
                {
                    b.Navigation("Allergies_Details");

                    b.Navigation("NCD_Details");
                });
#pragma warning restore 612, 618
        }
    }
}
