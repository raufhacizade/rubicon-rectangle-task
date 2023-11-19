using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RubiconTask.Models;

namespace RubiconTask.Data
{
  public class RubiconContext : DbContext
  {
    public RubiconContext(DbContextOptions<RubiconContext> options) : base(options) { }
    public DbSet<Rectangle> Rectangles { get; set; }
    public DbSet<RubiconUser> RubiconUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      List<Rectangle> seedRectangles = new List<Rectangle>();
      Random rnd = new Random();
      int rndStart = 0;
      int rndEnd = 200;
      for (int i = 1; i <= 200; i++)
      {
        seedRectangles.Add(new Rectangle { Id = i, X1 = rnd.Next(rndStart, rndEnd), Y1 = rnd.Next(rndStart, rndEnd), X2 = rnd.Next(rndStart, rndEnd), Y2 = rnd.Next(rndStart, rndEnd), CreatedOn = DateTime.Now });
      }

      RubiconUser rubiconUser = new RubiconUser
      {
        Id = 1,
        UserName = "testuser@gmail.com",
        Email = "testuser@gmail.com",
        EmailConfirmed = true,
        CreatedOn = DateTime.Now
      };

      PasswordHasher<RubiconUser> ph = new PasswordHasher<RubiconUser>();
      rubiconUser.PasswordHash = ph.HashPassword(rubiconUser, "test_user_pwd");

      modelBuilder.Entity<Rectangle>()
            .Property(r => r.Id)
            .ValueGeneratedOnAdd();
      modelBuilder.Entity<Rectangle>().HasData(seedRectangles);
      modelBuilder.Entity<RubiconUser>().HasData(rubiconUser);
    }
  }
}
