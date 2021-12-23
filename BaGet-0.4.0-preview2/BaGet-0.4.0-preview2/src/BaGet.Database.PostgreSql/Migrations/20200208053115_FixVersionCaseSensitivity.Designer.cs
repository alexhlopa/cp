﻿// <auto-generated />
using System;
using BaGet.Database.PostgreSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BaGet.Database.PostgreSql.Migrations
{
    [DbContext(typeof(PostgreSqlContext))]
    [Migration("20200208053115_FixVersionCaseSensitivity")]
    partial class FixVersionCaseSensitivity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:PostgresExtension:citext", ",,")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("BaGet.Core.Package", b =>
                {
                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Authors")
                        .HasColumnType("character varying(4000)")
                        .HasMaxLength(4000);

                    b.Property<string>("Description")
                        .HasColumnType("character varying(4000)")
                        .HasMaxLength(4000);

                    b.Property<long>("Downloads")
                        .HasColumnType("bigint");

                    b.Property<bool>("HasReadme")
                        .HasColumnType("boolean");

                    b.Property<string>("IconUrl")
                        .HasColumnType("character varying(4000)")
                        .HasMaxLength(4000);

                    b.Property<string>("Id")
                        .IsRequired()
                        .HasColumnType("citext")
                        .HasMaxLength(128);

                    b.Property<bool>("IsPrerelease")
                        .HasColumnType("boolean");

                    b.Property<string>("Language")
                        .HasColumnType("character varying(20)")
                        .HasMaxLength(20);

                    b.Property<string>("LicenseUrl")
                        .HasColumnType("character varying(4000)")
                        .HasMaxLength(4000);

                    b.Property<bool>("Listed")
                        .HasColumnType("boolean");

                    b.Property<string>("MinClientVersion")
                        .HasColumnType("character varying(44)")
                        .HasMaxLength(44);

                    b.Property<string>("NormalizedVersionString")
                        .IsRequired()
                        .HasColumnName("Version")
                        .HasColumnType("citext")
                        .HasMaxLength(64);

                    b.Property<string>("OriginalVersionString")
                        .HasColumnName("OriginalVersion")
                        .HasColumnType("character varying(64)")
                        .HasMaxLength(64);

                    b.Property<string>("ProjectUrl")
                        .HasColumnType("character varying(4000)")
                        .HasMaxLength(4000);

                    b.Property<DateTime>("Published")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ReleaseNotes")
                        .HasColumnName("ReleaseNotes")
                        .HasColumnType("character varying(4000)")
                        .HasMaxLength(4000);

                    b.Property<string>("RepositoryType")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("RepositoryUrl")
                        .HasColumnType("character varying(4000)")
                        .HasMaxLength(4000);

                    b.Property<bool>("RequireLicenseAcceptance")
                        .HasColumnType("boolean");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea");

                    b.Property<int>("SemVerLevel")
                        .HasColumnType("integer");

                    b.Property<string>("Summary")
                        .HasColumnType("character varying(4000)")
                        .HasMaxLength(4000);

                    b.Property<string>("Tags")
                        .HasColumnType("character varying(4000)")
                        .HasMaxLength(4000);

                    b.Property<string>("Title")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Key");

                    b.HasIndex("Id");

                    b.HasIndex("Id", "NormalizedVersionString")
                        .IsUnique();

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("BaGet.Core.PackageDependency", b =>
                {
                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Id")
                        .HasColumnType("citext")
                        .HasMaxLength(128);

                    b.Property<int?>("PackageKey")
                        .HasColumnType("integer");

                    b.Property<string>("TargetFramework")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("VersionRange")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Key");

                    b.HasIndex("Id");

                    b.HasIndex("PackageKey");

                    b.ToTable("PackageDependencies");
                });

            modelBuilder.Entity("BaGet.Core.PackageType", b =>
                {
                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("citext")
                        .HasMaxLength(512);

                    b.Property<int>("PackageKey")
                        .HasColumnType("integer");

                    b.Property<string>("Version")
                        .HasColumnType("character varying(64)")
                        .HasMaxLength(64);

                    b.HasKey("Key");

                    b.HasIndex("Name");

                    b.HasIndex("PackageKey");

                    b.ToTable("PackageTypes");
                });

            modelBuilder.Entity("BaGet.Core.TargetFramework", b =>
                {
                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Moniker")
                        .HasColumnType("citext")
                        .HasMaxLength(256);

                    b.Property<int>("PackageKey")
                        .HasColumnType("integer");

                    b.HasKey("Key");

                    b.HasIndex("Moniker");

                    b.HasIndex("PackageKey");

                    b.ToTable("TargetFrameworks");
                });

            modelBuilder.Entity("BaGet.Core.PackageDependency", b =>
                {
                    b.HasOne("BaGet.Core.Package", "Package")
                        .WithMany("Dependencies")
                        .HasForeignKey("PackageKey");
                });

            modelBuilder.Entity("BaGet.Core.PackageType", b =>
                {
                    b.HasOne("BaGet.Core.Package", "Package")
                        .WithMany("PackageTypes")
                        .HasForeignKey("PackageKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BaGet.Core.TargetFramework", b =>
                {
                    b.HasOne("BaGet.Core.Package", "Package")
                        .WithMany("TargetFrameworks")
                        .HasForeignKey("PackageKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
