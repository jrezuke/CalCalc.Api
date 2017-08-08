﻿// <auto-generated />
using CalCalc.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace CalCalc.Api.Migrations
{
    [DbContext(typeof(CalCalcDbContext))]
    partial class CalCalcDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-preview1-24937")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CalCalc.Api.Models.Additive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdditiveListId");

                    b.Property<int>("CalEntryId");

                    b.Property<int>("Volume");

                    b.HasKey("Id");

                    b.HasIndex("AdditiveListId");

                    b.HasIndex("CalEntryId");

                    b.ToTable("Additive");
                });

            modelBuilder.Entity("CalCalc.Api.Models.AdditiveList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int?>("ChoOfKcal")
                        .HasColumnName("CHO % of kcal");

                    b.Property<decimal?>("KcalUnit")
                        .HasColumnName("Kcal/unit")
                        .HasColumnType("decimal");

                    b.Property<int?>("LipidOfKcal")
                        .HasColumnName("Lipid % of kcal");

                    b.Property<string>("Manufacturer")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.Property<int?>("ProteinOfKcal")
                        .HasColumnName("Protein % of kcal");

                    b.Property<int?>("Unit");

                    b.HasKey("Id");

                    b.ToTable("AdditiveList");
                });

            modelBuilder.Entity("CalCalc.Api.Models.CalEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Hours")
                        .HasColumnType("decimal");

                    b.Property<int>("SubjectId");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("CalEntry");
                });

            modelBuilder.Entity("CalCalc.Api.Models.DextroseConcentration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Concentration")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<decimal>("KcalMl")
                        .HasColumnType("decimal");

                    b.HasKey("Id");

                    b.ToTable("DextroseConcentration");
                });

            modelBuilder.Entity("CalCalc.Api.Models.Enteral", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int>("CalEntryId");

                    b.Property<int>("FormulaListId");

                    b.Property<int>("Volume");

                    b.HasKey("Id");

                    b.HasIndex("CalEntryId");

                    b.HasIndex("FormulaListId");

                    b.ToTable("Enteral");
                });

            modelBuilder.Entity("CalCalc.Api.Models.FluidInfusion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CalEntryId");

                    b.Property<int>("DextroseConcentrationId");

                    b.Property<int>("Volume");

                    b.HasKey("Id");

                    b.HasIndex("CalEntryId");

                    b.HasIndex("DextroseConcentrationId");

                    b.ToTable("FluidInfusion");
                });

            modelBuilder.Entity("CalCalc.Api.Models.FormulaList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Cho")
                        .HasColumnName("CHO");

                    b.Property<decimal>("KcalML")
                        .HasColumnName("Kcal_mL")
                        .HasColumnType("decimal");

                    b.Property<decimal?>("KcalOz")
                        .HasColumnName("Kcal_oz")
                        .HasColumnType("decimal");

                    b.Property<int>("Lipid");

                    b.Property<string>("Manufacturer")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("Protein");

                    b.HasKey("Id");

                    b.ToTable("FormulaList");
                });

            modelBuilder.Entity("CalCalc.Api.Models.Parenteral", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal?>("Amino")
                        .HasColumnType("decimal");

                    b.Property<int>("CalEntryId");

                    b.Property<decimal?>("Dextrose")
                        .HasColumnType("decimal");

                    b.Property<decimal?>("Lipid")
                        .HasColumnType("decimal");

                    b.Property<decimal>("Volume")
                        .HasColumnType("decimal");

                    b.HasKey("Id");

                    b.HasIndex("CalEntryId");

                    b.ToTable("Parenteral");
                });

            modelBuilder.Entity("CalCalc.Api.Models.Site", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LongName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Site");
                });

            modelBuilder.Entity("CalCalc.Api.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("SiteId");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.Property<string>("SubjectId")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("SiteId");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("CalCalc.Api.Models.Additive", b =>
                {
                    b.HasOne("CalCalc.Api.Models.AdditiveList", "AdditiveList")
                        .WithMany("Additive")
                        .HasForeignKey("AdditiveListId")
                        .HasConstraintName("FK_Additive_AdditiveList")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CalCalc.Api.Models.CalEntry", "CalEntry")
                        .WithMany("Additive")
                        .HasForeignKey("CalEntryId")
                        .HasConstraintName("FK_Additive_Entry");
                });

            modelBuilder.Entity("CalCalc.Api.Models.CalEntry", b =>
                {
                    b.HasOne("CalCalc.Api.Models.Subject", "Subject")
                        .WithMany("CalEntry")
                        .HasForeignKey("SubjectId")
                        .HasConstraintName("FK_CalEntries_Subjects");
                });

            modelBuilder.Entity("CalCalc.Api.Models.Enteral", b =>
                {
                    b.HasOne("CalCalc.Api.Models.CalEntry", "CalEntry")
                        .WithMany("Enteral")
                        .HasForeignKey("CalEntryId")
                        .HasConstraintName("FK_Enteral_CalEntry");

                    b.HasOne("CalCalc.Api.Models.FormulaList", "FormulaList")
                        .WithMany("Enteral")
                        .HasForeignKey("FormulaListId")
                        .HasConstraintName("FK_Enteral_FormulaList");
                });

            modelBuilder.Entity("CalCalc.Api.Models.FluidInfusion", b =>
                {
                    b.HasOne("CalCalc.Api.Models.CalEntry", "CalEntry")
                        .WithMany("FluidInfusion")
                        .HasForeignKey("CalEntryId")
                        .HasConstraintName("FK_FluidInfusions_CalEntries");

                    b.HasOne("CalCalc.Api.Models.DextroseConcentration", "DextroseConcentration")
                        .WithMany("FluidInfusion")
                        .HasForeignKey("DextroseConcentrationId")
                        .HasConstraintName("FK_FluidInfusions_DextroseConcentrations");
                });

            modelBuilder.Entity("CalCalc.Api.Models.Parenteral", b =>
                {
                    b.HasOne("CalCalc.Api.Models.CalEntry", "CalEntry")
                        .WithMany("Parenteral")
                        .HasForeignKey("CalEntryId")
                        .HasConstraintName("FK_Parenteral_CalEntry");
                });

            modelBuilder.Entity("CalCalc.Api.Models.Subject", b =>
                {
                    b.HasOne("CalCalc.Api.Models.Site", "Site")
                        .WithMany("Subject")
                        .HasForeignKey("SiteId")
                        .HasConstraintName("FK_Subjects_Sites");
                });
        }
    }
}
