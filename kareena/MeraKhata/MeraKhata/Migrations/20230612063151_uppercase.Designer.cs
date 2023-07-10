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
    [Migration("20230612063151_uppercase")]
    partial class uppercase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MeraKhata.Models.BackUpEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Filename")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Lastbackup")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Userid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Userid");

                    b.ToTable("backup");
                });

            modelBuilder.Entity("MeraKhata.Models.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("users");
                });

            modelBuilder.Entity("MeraKhata.Models.BackUpEntity", b =>
                {
                    b.HasOne("MeraKhata.Models.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
