﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Twitter.Data;

#nullable disable

namespace Twitter.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230519114003_comment_like_tbl")]
    partial class comment_like_tbl
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Twitter.Entities.Comment_entity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("comment_text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("created_on")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("modified_on")
                        .HasColumnType("datetime2");

                    b.Property<int>("tweet_id")
                        .HasColumnType("int");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("tweet_id");

                    b.HasIndex("user_id");

                    b.ToTable("Comment_entity");
                });

            modelBuilder.Entity("Twitter.Entities.Draft_entity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Tweet_text")
                        .IsRequired()
                        .HasMaxLength(280)
                        .HasColumnType("nvarchar(280)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Drafts");
                });

            modelBuilder.Entity("Twitter.Entities.Follower_entity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("created_on")
                        .HasColumnType("datetime2");

                    b.Property<int?>("follower_Id")
                        .HasColumnType("int");

                    b.Property<bool>("is_approved")
                        .HasColumnType("bit");

                    b.Property<int?>("user_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("follower_Id");

                    b.HasIndex("user_id");

                    b.ToTable("followers");
                });

            modelBuilder.Entity("Twitter.Entities.Like_Tweet_entity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("created_on")
                        .HasColumnType("datetime2");

                    b.Property<int>("tweet_id")
                        .HasColumnType("int");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("tweet_id");

                    b.HasIndex("user_id");

                    b.ToTable("like_Tweet");
                });

            modelBuilder.Entity("Twitter.Models.Comment_Like_entity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("Comment_entityId")
                        .HasColumnType("int");

                    b.Property<int?>("Tweet_entityId")
                        .HasColumnType("int");

                    b.Property<int>("comment_id")
                        .HasColumnType("int");

                    b.Property<int>("tweet_id")
                        .HasColumnType("int");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Comment_entityId");

                    b.HasIndex("Tweet_entityId");

                    b.HasIndex("user_id");

                    b.ToTable("Comment_Like_entity");
                });

            modelBuilder.Entity("Twitter.Models.Tweet_entity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("created_on")
                        .HasColumnType("datetime2");

                    b.Property<bool>("is_deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("modified_on")
                        .HasColumnType("datetime2");

                    b.Property<string>("tweet_text")
                        .IsRequired()
                        .HasMaxLength(280)
                        .HasColumnType("nvarchar(280)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tweets");
                });

            modelBuilder.Entity("Twitter.Models.UserProfile_entity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<bool>("account_type")
                        .HasColumnType("bit");

                    b.Property<string>("bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_profile_img")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserProfile");
                });

            modelBuilder.Entity("Twitter.Models.User_entity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("birthdate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("created_on")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(320)
                        .HasColumnType("nvarchar(320)");

                    b.Property<string>("firstname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("is_active")
                        .HasColumnType("bit");

                    b.Property<string>("lastname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("modified_on")
                        .HasColumnType("datetime2");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Twitter.Entities.Comment_entity", b =>
                {
                    b.HasOne("Twitter.Models.Tweet_entity", "tweets")
                        .WithMany("comments_tweettbl")
                        .HasForeignKey("tweet_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Twitter.Models.User_entity", "user")
                        .WithMany("comments_usertbl")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tweets");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Twitter.Entities.Draft_entity", b =>
                {
                    b.HasOne("Twitter.Models.User_entity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Twitter.Entities.Follower_entity", b =>
                {
                    b.HasOne("Twitter.Models.User_entity", "followed_by")
                        .WithMany("follower_in_users")
                        .HasForeignKey("follower_Id");

                    b.HasOne("Twitter.Models.User_entity", "User")
                        .WithMany("user_in_users")
                        .HasForeignKey("user_id");

                    b.Navigation("User");

                    b.Navigation("followed_by");
                });

            modelBuilder.Entity("Twitter.Entities.Like_Tweet_entity", b =>
                {
                    b.HasOne("Twitter.Models.Tweet_entity", "tweet_tbl")
                        .WithMany("likes_tweets_tweettbl")
                        .HasForeignKey("tweet_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Twitter.Models.User_entity", "User")
                        .WithMany("likes_tweets_usertbl")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("tweet_tbl");
                });

            modelBuilder.Entity("Twitter.Models.Comment_Like_entity", b =>
                {
                    b.HasOne("Twitter.Entities.Comment_entity", null)
                        .WithMany("comment_like_cmttbl")
                        .HasForeignKey("Comment_entityId");

                    b.HasOne("Twitter.Models.Tweet_entity", null)
                        .WithMany("comments_like_tweettbl")
                        .HasForeignKey("Tweet_entityId");

                    b.HasOne("Twitter.Models.User_entity", "user")
                        .WithMany("comment_likes_usertbl")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("Twitter.Models.Tweet_entity", b =>
                {
                    b.HasOne("Twitter.Models.User_entity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Twitter.Models.UserProfile_entity", b =>
                {
                    b.HasOne("Twitter.Models.User_entity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Twitter.Entities.Comment_entity", b =>
                {
                    b.Navigation("comment_like_cmttbl");
                });

            modelBuilder.Entity("Twitter.Models.Tweet_entity", b =>
                {
                    b.Navigation("comments_like_tweettbl");

                    b.Navigation("comments_tweettbl");

                    b.Navigation("likes_tweets_tweettbl");
                });

            modelBuilder.Entity("Twitter.Models.User_entity", b =>
                {
                    b.Navigation("comment_likes_usertbl");

                    b.Navigation("comments_usertbl");

                    b.Navigation("follower_in_users");

                    b.Navigation("likes_tweets_usertbl");

                    b.Navigation("user_in_users");
                });
#pragma warning restore 612, 618
        }
    }
}
