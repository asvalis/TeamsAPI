﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TeamsAPI.DAL;

#nullable disable

namespace TeamsAPI.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220524135313_migrationv1")]
    partial class migrationv1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TeamsAPI.Models.Players", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int?>("Teamid")
                        .HasColumnType("int");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Teamid");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("TeamsAPI.Models.Team", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("location")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("location")
                        .IsUnique();

                    b.HasIndex("name")
                        .IsUnique();

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("TeamsAPI.Models.Players", b =>
                {
                    b.HasOne("TeamsAPI.Models.Team", null)
                        .WithMany("players")
                        .HasForeignKey("Teamid");
                });

            modelBuilder.Entity("TeamsAPI.Models.Team", b =>
                {
                    b.Navigation("players");
                });
#pragma warning restore 612, 618
        }
    }
}
