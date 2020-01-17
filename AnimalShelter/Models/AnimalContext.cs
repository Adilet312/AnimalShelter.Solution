using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Models
{
  public class AnimalContext : DbContext
  {
    public DbSet<Animal> Animals { get; set; }

    public AnimalContext(DbContextOptions options) : base(options) { }
  }
}