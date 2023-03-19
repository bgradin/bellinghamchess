using Microsoft.EntityFrameworkCore;
using BellinghamChessClub.Models;

namespace BellinghamChessClub.DataAccess
{
  public class ClubDbContext : DbContext
  {
    public ClubDbContext(DbContextOptions<ClubDbContext> options)
        : base(options)
    {
    }

    public DbSet<Player> Players
    {
      get; set;
    }
    public DbSet<Game> Games
    {
      get; set;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Player>().ToTable("Players");
      modelBuilder.Entity<Game>().ToTable("Games");
    }
  }
}
