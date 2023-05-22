using Microsoft.EntityFrameworkCore;
using TestingMVC.Models;

namespace TestingMVC.Data
{
    public class DataContext: DbContext
    {

        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options):base(options) {
        }
        public DbSet<Category> Categories { get; set; }

    }
}
