using Microsoft.EntityFrameworkCore;

namespace SuperHeroApi.Data
{
    public class DataContext : DbContext
    {
       

        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        //here the superHeros is the name of the db table
        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}