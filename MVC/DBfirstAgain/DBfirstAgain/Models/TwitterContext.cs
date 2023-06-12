using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DBfirstAgain.Models;

public partial class TwitterContext : DbContext
{
    public TwitterContext()
    {
    }

    public TwitterContext(DbContextOptions<TwitterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Draft> Drafts { get; set; }

    public virtual DbSet<Follower> Followers { get; set; }

    public virtual DbSet<LikeTweet> LikeTweets { get; set; }

    public virtual DbSet<Tweet> Tweets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.ToTable("comments");

            entity.HasIndex(e => e.TweetId, "IX_comments_tweet_id");

            entity.HasIndex(e => e.UserId, "IX_comments_user_id");

            entity.Property(e => e.CommentText).HasColumnName("comment_text");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("('2023-05-19T14:59:59.3226804+05:30')")
                .HasColumnName("created_on");
            entity.Property(e => e.ModifiedOn).HasColumnName("modified_on");
            entity.Property(e => e.TweetId).HasColumnName("tweet_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Tweet).WithMany(p => p.Comments)
                .HasForeignKey(d => d.TweetId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.User).WithMany(p => p.Comments).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Draft>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_Drafts_UserId");

            entity.Property(e => e.TweetText)
                .HasMaxLength(280)
                .HasColumnName("Tweet_text");

            entity.HasOne(d => d.User).WithMany(p => p.Drafts).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Follower>(entity =>
        {
            entity.ToTable("followers");

            entity.HasIndex(e => e.FollowerId, "IX_followers_follower_Id");

            entity.HasIndex(e => e.UserId, "IX_followers_user_id");

            entity.Property(e => e.CreatedOn).HasColumnName("created_on");
            entity.Property(e => e.FollowerId).HasColumnName("follower_Id");
            entity.Property(e => e.IsApproved).HasColumnName("is_approved");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.FollowerNavigation).WithMany(p => p.FollowerFollowerNavigations)
                .HasForeignKey(d => d.FollowerId)
                .HasConstraintName("FK_follower_Id");

            entity.HasOne(d => d.User).WithMany(p => p.FollowerUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_user_id");
        });

        modelBuilder.Entity<LikeTweet>(entity =>
        {
            entity.ToTable("like_Tweet");

            entity.HasIndex(e => e.TweetId, "IX_like_Tweet_tweet_id");

            entity.HasIndex(e => e.UserId, "IX_like_Tweet_user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedOn).HasColumnName("created_on");
            entity.Property(e => e.TweetId).HasColumnName("tweet_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Tweet).WithMany(p => p.LikeTweets).HasForeignKey(d => d.TweetId);

            entity.HasOne(d => d.User).WithMany(p => p.LikeTweets).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Tweet>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_Tweets_UserId");

            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("('2023-05-17T18:09:21.0314164+05:30')")
                .HasColumnName("created_on");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("(CONVERT([bit],(0)))")
                .HasColumnName("is_deleted");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("('0001-01-01T00:00:00.0000000')")
                .HasColumnName("modified_on");
            entity.Property(e => e.TweetText)
                .HasMaxLength(280)
                .HasColumnName("tweet_text");

            entity.HasOne(d => d.User).WithMany(p => p.Tweets).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("('0001-01-01T00:00:00.0000000')")
                .HasColumnName("created_on");
            entity.Property(e => e.Email)
                .HasMaxLength(320)
                .HasDefaultValueSql("(N'')")
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(100)
                .HasColumnName("firstname");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(1)))")
                .HasColumnName("is_active");
            entity.Property(e => e.Lastname)
                .HasMaxLength(100)
                .HasColumnName("lastname");
            entity.Property(e => e.ModifiedOn).HasColumnName("modified_on");
            entity.Property(e => e.Password)
                .HasMaxLength(120)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.ToTable("UserProfile");

            entity.HasIndex(e => e.UserId, "IX_UserProfile_UserId");

            entity.Property(e => e.AccountType)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(1)))")
                .HasColumnName("account_type");
            entity.Property(e => e.Bio).HasColumnName("bio");
            entity.Property(e => e.UserProfileImg).HasColumnName("user_profile_img");

            entity.HasOne(d => d.User).WithMany(p => p.UserProfiles).HasForeignKey(d => d.UserId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
