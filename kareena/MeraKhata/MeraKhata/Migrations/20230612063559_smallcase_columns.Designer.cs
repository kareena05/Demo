﻿// <auto-generated />
using System;
using MeraKhata.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MeraKhata.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230612063559_smallcase_columns")]
    partial class smallcase_columns
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MeraKhata.Models.BackUpEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("filename")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("lastbackup")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("userid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("userid");

                    b.ToTable("backup");
                });

            modelBuilder.Entity("MeraKhata.Models.UserEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("fullname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("mobile")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("email")
                        .IsUnique();

                    b.ToTable("users");
                });

            modelBuilder.Entity("MeraKhata.Models.BackUpEntity", b =>
                {
                    b.HasOne("MeraKhata.Models.UserEntity", "user")
                        .WithMany()
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });
#pragma warning restore 612, 618
        }
    }
}