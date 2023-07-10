using MeraKhata.Models;
using Microsoft.EntityFrameworkCore;

namespace MeraKhata.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<BackUpEntity> Backup { get; set; }
    }
}
