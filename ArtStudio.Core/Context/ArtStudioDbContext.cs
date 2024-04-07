using ArtStudio.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtStudio.Core.Context;

public class ArtStudioDbContext(DbContextOptions<ArtStudioDbContext> options) 
    : DbContext(options)
{
    public DbSet<ArtEntity> Arts { get; set; }
    //public DbSet<EArtEntity> EArts { get; set; }
    //public DbSet<SculptureEntity> Sculputres { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ArtEntity>()
            .Property(p => p.CreatedOn)
            .HasDefaultValue(DateTime.Now);
        modelBuilder.Entity<ArtEntity>()
            .HasIndex(a => a.Name)
            .IsUnique();
        
        modelBuilder.Entity<UserEntity>()
            .HasIndex(u => u.Email)
            .IsUnique();
        modelBuilder.Entity<UserEntity>()
            .HasIndex(u => u.Name)
            .IsUnique();
    }
}