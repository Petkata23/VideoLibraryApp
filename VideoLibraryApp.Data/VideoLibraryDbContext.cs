using Microsoft.EntityFrameworkCore;
using VideoLibraryApp.Data.Entities;

namespace VideoLibraryApp.Data;

/// <summary>
/// DbContext за приложението на видеотеката.
/// </summary>
public class VideoLibraryDbContext : DbContext
{
    public VideoLibraryDbContext(DbContextOptions<VideoLibraryDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Cassette> Cassettes => Set<Cassette>();
    public DbSet<UserSavedFilm> UserSavedFilms => Set<UserSavedFilm>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Глобален филтър – по подразбиране не показваме изтрити записи
        modelBuilder.Entity<User>()
            .HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Cassette>()
            .HasQueryFilter(e => !e.IsDeleted);

        // User
        modelBuilder.Entity<User>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasIndex(x => x.Username).IsUnique();
            e.Property(x => x.Username).HasMaxLength(100).IsRequired();
            e.Property(x => x.PasswordHash).HasMaxLength(500).IsRequired();
        });

        // Cassette
        modelBuilder.Entity<Cassette>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Title).HasMaxLength(200).IsRequired();
            e.Property(x => x.Director).HasMaxLength(150);
            e.Property(x => x.Genre).HasMaxLength(100);
            e.Property(x => x.Description).HasMaxLength(2000);
            e.Property(x => x.ImageData).HasMaxLength(512 * 1024);
        });

        // UserSavedFilm – много-към-много
        modelBuilder.Entity<UserSavedFilm>(e =>
        {
            e.HasKey(x => new { x.UserId, x.CassetteId });

            e.HasOne(x => x.User)
                .WithMany(x => x.SavedFilms)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            e.HasOne(x => x.Cassette)
                .WithMany(x => x.SavedByUsers)
                .HasForeignKey(x => x.CassetteId)
                .OnDelete(DeleteBehavior.Cascade);

            e.HasIndex(x => new { x.UserId, x.CassetteId }).IsUnique();
        });
    }

    /// <summary>
    /// Презаписва SaveChanges за автоматично обновяване на UpdatedAt.
    /// </summary>
    public override int SaveChanges()
    {
        ApplyUpdatedAt();
        return base.SaveChanges();
    }

    /// <summary>
    /// Същата логика като при синхронно записване (добра практика при async код).
    /// </summary>
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ApplyUpdatedAt();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void ApplyUpdatedAt()
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            if (entry.State == EntityState.Modified)
                entry.Property(x => x.UpdatedAt).CurrentValue = DateTime.UtcNow;
        }
    }
}
