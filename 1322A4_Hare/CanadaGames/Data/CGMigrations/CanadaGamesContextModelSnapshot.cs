﻿// <auto-generated />
using System;
using CanadaGames.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CanadaGames.Data.CGMigrations
{
    [DbContext(typeof(CanadaGamesContext))]
    partial class CanadaGamesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.20");

            modelBuilder.Entity("CanadaGames.Models.Athlete", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Affiliation")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(255);

                    b.Property<string>("AthleteCode")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(7);

                    b.Property<int?>("CoachID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContingentID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<int>("GenderID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Goals")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(255);

                    b.Property<int>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("HometownID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("MediaInfo")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(2000);

                    b.Property<string>("MiddleName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<int>("SportID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("TEXT");

                    b.Property<double>("Weight")
                        .HasColumnType("REAL");

                    b.Property<int>("YearsInSport")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("AthleteCode")
                        .IsUnique();

                    b.HasIndex("CoachID");

                    b.HasIndex("ContingentID");

                    b.HasIndex("GenderID");

                    b.HasIndex("HometownID");

                    b.HasIndex("SportID");

                    b.ToTable("Athletes");
                });

            modelBuilder.Entity("CanadaGames.Models.AthletePhoto", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AthleteID")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("Content")
                        .HasColumnType("BLOB");

                    b.Property<string>("MimeType")
                        .HasColumnType("TEXT")
                        .HasMaxLength(255);

                    b.HasKey("ID");

                    b.HasIndex("AthleteID")
                        .IsUnique();

                    b.ToTable("AthletePhotos");
                });

            modelBuilder.Entity("CanadaGames.Models.AthleteSport", b =>
                {
                    b.Property<int>("AthleteID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SportID")
                        .HasColumnType("INTEGER");

                    b.HasKey("AthleteID", "SportID");

                    b.HasIndex("SportID");

                    b.ToTable("AthleteSports");
                });

            modelBuilder.Entity("CanadaGames.Models.AthleteThumbnail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AthleteID")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("Content")
                        .HasColumnType("BLOB");

                    b.Property<string>("MimeType")
                        .HasColumnType("TEXT")
                        .HasMaxLength(255);

                    b.HasKey("ID");

                    b.HasIndex("AthleteID")
                        .IsUnique();

                    b.ToTable("AthleteThumbnails");
                });

            modelBuilder.Entity("CanadaGames.Models.Coach", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("MiddleName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Coaches");
                });

            modelBuilder.Entity("CanadaGames.Models.Contingent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(2);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Contingents");
                });

            modelBuilder.Entity("CanadaGames.Models.Event", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GenderID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<int>("SportID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(10);

                    b.HasKey("ID");

                    b.HasIndex("GenderID");

                    b.HasIndex("SportID");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("CanadaGames.Models.FileContent", b =>
                {
                    b.Property<int>("FileContentID")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("Content")
                        .HasColumnType("BLOB");

                    b.Property<string>("MimeType")
                        .HasColumnType("TEXT")
                        .HasMaxLength(255);

                    b.HasKey("FileContentID");

                    b.ToTable("FileContent");
                });

            modelBuilder.Entity("CanadaGames.Models.Gender", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("CanadaGames.Models.Hometown", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContingentID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.HasIndex("ContingentID");

                    b.HasIndex("Name", "ContingentID")
                        .IsUnique();

                    b.ToTable("Hometowns");
                });

            modelBuilder.Entity("CanadaGames.Models.Placement", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AthleteID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comments")
                        .HasColumnType("TEXT")
                        .HasMaxLength(2000);

                    b.Property<int>("EventID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Place")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("EventID");

                    b.HasIndex("AthleteID", "EventID")
                        .IsUnique();

                    b.ToTable("Placements");
                });

            modelBuilder.Entity("CanadaGames.Models.Sport", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(3);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Sports");
                });

            modelBuilder.Entity("CanadaGames.Models.UploadedFile", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FileName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(255);

                    b.HasKey("ID");

                    b.ToTable("UploadedFiles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("UploadedFile");
                });

            modelBuilder.Entity("CanadaGames.Models.AthleteDocument", b =>
                {
                    b.HasBaseType("CanadaGames.Models.UploadedFile");

                    b.Property<int>("AthleteID")
                        .HasColumnType("INTEGER");

                    b.HasIndex("AthleteID");

                    b.HasDiscriminator().HasValue("AthleteDocument");
                });

            modelBuilder.Entity("CanadaGames.Models.Athlete", b =>
                {
                    b.HasOne("CanadaGames.Models.Coach", "Coach")
                        .WithMany("Athletes")
                        .HasForeignKey("CoachID");

                    b.HasOne("CanadaGames.Models.Contingent", "Contingent")
                        .WithMany("Athletes")
                        .HasForeignKey("ContingentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CanadaGames.Models.Gender", "Gender")
                        .WithMany("Athletes")
                        .HasForeignKey("GenderID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CanadaGames.Models.Hometown", "Hometown")
                        .WithMany("Athletes")
                        .HasForeignKey("HometownID");

                    b.HasOne("CanadaGames.Models.Sport", "Sport")
                        .WithMany("Athletes")
                        .HasForeignKey("SportID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("CanadaGames.Models.AthletePhoto", b =>
                {
                    b.HasOne("CanadaGames.Models.Athlete", "Athlete")
                        .WithOne("AthletePhoto")
                        .HasForeignKey("CanadaGames.Models.AthletePhoto", "AthleteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CanadaGames.Models.AthleteSport", b =>
                {
                    b.HasOne("CanadaGames.Models.Athlete", "Athlete")
                        .WithMany("AthleteSports")
                        .HasForeignKey("AthleteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CanadaGames.Models.Sport", "Sport")
                        .WithMany("AthleteSports")
                        .HasForeignKey("SportID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("CanadaGames.Models.AthleteThumbnail", b =>
                {
                    b.HasOne("CanadaGames.Models.Athlete", "Athlete")
                        .WithOne("AthleteThumbnail")
                        .HasForeignKey("CanadaGames.Models.AthleteThumbnail", "AthleteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CanadaGames.Models.Event", b =>
                {
                    b.HasOne("CanadaGames.Models.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CanadaGames.Models.Sport", "Sport")
                        .WithMany("Events")
                        .HasForeignKey("SportID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CanadaGames.Models.FileContent", b =>
                {
                    b.HasOne("CanadaGames.Models.UploadedFile", "UploadedFile")
                        .WithOne("FileContent")
                        .HasForeignKey("CanadaGames.Models.FileContent", "FileContentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CanadaGames.Models.Hometown", b =>
                {
                    b.HasOne("CanadaGames.Models.Contingent", "Contingent")
                        .WithMany("Hometowns")
                        .HasForeignKey("ContingentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("CanadaGames.Models.Placement", b =>
                {
                    b.HasOne("CanadaGames.Models.Athlete", "Athlete")
                        .WithMany("Placements")
                        .HasForeignKey("AthleteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CanadaGames.Models.Event", "Event")
                        .WithMany("Placements")
                        .HasForeignKey("EventID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("CanadaGames.Models.AthleteDocument", b =>
                {
                    b.HasOne("CanadaGames.Models.Athlete", "Athlete")
                        .WithMany("AthleteDocuments")
                        .HasForeignKey("AthleteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
