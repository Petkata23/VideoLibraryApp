using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace VideoLibraryApp.Data;

/// <summary>
/// Фабрика за EF Core Design-time (миграции).
/// </summary>
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<VideoLibraryDbContext>
{
    public VideoLibraryDbContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<VideoLibraryDbContext>()
            .UseSqlServer(ConnectionStringProvider.GetConnectionString())
            .Options;

        return new VideoLibraryDbContext(options);
    }
}
