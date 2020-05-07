using Microsoft.EntityFrameworkCore;
using web.Models;

namespace web.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
           
        }
        //Configure Technology and ExampleProject Foreign Keys for the ExampleProjectTechnology Table 
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=CensusContext.db");
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<HasherTrail>().HasKey(entity => new { entity.HasherId, entity.TrailId });
        }

        public DbSet<Hasher> Hashers {get; set;}
        public DbSet<Trail> Trails {get; set;}
       
    }
}