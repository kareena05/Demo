using Microsoft.EntityFrameworkCore;
using Twitter.Models;

namespace Twitter.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        
        public DbSet<User_entity> Users { get; set; }
        public DbSet<UserProfile_entity> UserProfile { get; set; }
        public DbSet<Tweet_entity> Tweets { get; set; }
    }
}
