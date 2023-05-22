using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
using Twitter.Entities;
using Twitter.Models;

namespace Twitter.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Follower_entity>().
               HasOne(f => f.User)
               .WithMany(u => u.user_in_users)
               .HasForeignKey(x => x.user_id)
               .OnDelete(DeleteBehavior.ClientSetNull)
               ;

            modelBuilder.Entity<Follower_entity>().
               HasOne(f => f.followed_by)
               .WithMany(u => u.follower_in_users)
               .HasForeignKey(x => x.follower_Id)
               .OnDelete(DeleteBehavior.ClientSetNull)
               ;
        }

        public DbSet<User_entity> Users { get; set; }
        public DbSet<UserProfile_entity> UserProfile { get; set; }
        public DbSet<Tweet_entity> Tweets { get; set; }
        public DbSet<Draft_entity> Drafts { get; set; }
        public DbSet<Follower_entity> followers { get; set; }   
        public DbSet<Like_Tweet_entity> like_Tweet { get; set; }
        public DbSet<Comment_entity> comments { get; set; }
       
      
      
        
    }
}
