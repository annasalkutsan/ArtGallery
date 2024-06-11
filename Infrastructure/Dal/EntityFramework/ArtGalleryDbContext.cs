using System.Data.Common;
using Domain.Entities;
using Infrastructure.Dal.EntityFramework.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal.EntityFramework;

public class ArtGalleryDbContext:DbContext
{
    public ArtGalleryDbContext(DbContextOptions<ArtGalleryDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Painting> Paintings { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Image> Images { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("User ID=postgres;Password=12345;Host=localhost;Port=5432;Database=postgres;");
        }
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new AuthorConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new PaintingConfiguration());
        modelBuilder.ApplyConfiguration(new ImageConfiguration());
    }
}