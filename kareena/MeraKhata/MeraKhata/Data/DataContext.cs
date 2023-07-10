using MeraKhata.Models;
using Microsoft.EntityFrameworkCore;

namespace MeraKhata.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<UserEntity> users { get; set; }
        public DbSet<BackUpEntity> backup { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserEntity>()
                .HasIndex(u => u.email)
                .IsUnique();
        }
    }
}
