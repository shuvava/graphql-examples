using Microsoft.EntityFrameworkCore;

using StarWars.Models;


namespace StarWars.Repository.EF6
{
    public class StarWarsContext : DbContext
    {
        public StarWarsContext()
        {
        }


        public StarWarsContext(DbContextOptions<StarWarsContext> options) : base(options)
        {
        }


        public virtual DbSet<Human> Humans { get; set; }
        public virtual DbSet<Droid> Droids { get; set; }
    }
}
