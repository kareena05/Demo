using Microsoft.EntityFrameworkCore;
using Twitter.Models;

namespace Twitter.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        
        public DbSet<User_tbl> Users { get; set; }
        public DbSet<UserProfile_tbl> UserProfile { get; set; }
    }
}
