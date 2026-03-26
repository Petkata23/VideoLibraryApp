using Microsoft.EntityFrameworkCore;

namespace VideoLibraryApp.Data;

/// <summary>
/// Фабрика за създаване на VideoLibraryDbContext (SQL Server).
/// Connection string: <see cref="ConnectionStringProvider"/>.
/// </summary>
public static class DbContextFactory
{
    /// <summary>
    /// Създава нов DbContext с SQL Server база данни.
    /// </summary>
    public static VideoLibraryDbContext Create()
    {
        var options = new DbContextOptionsBuilder<VideoLibraryDbContext>()
            .UseSqlServer(ConnectionStringProvider.GetConnectionString())
            .Options;

        return new VideoLibraryDbContext(options);
    }
}
