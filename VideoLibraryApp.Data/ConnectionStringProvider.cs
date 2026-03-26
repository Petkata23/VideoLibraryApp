using System.Reflection;
using System.Text.Json;

namespace VideoLibraryApp.Data;

/// <summary>
/// Чете connection string за SQL Server от конфигурация (добра практика за предаване и различни среди).
/// Ред на приоритет: променлива на средата → appsettings.json → подразбиране (LocalDB).
/// </summary>
public static class ConnectionStringProvider
{
    /// <summary>Променлива на средата: пълен connection string.</summary>
    public const string EnvironmentVariableName = "VIDEO_LIBRARY_CONNECTION";

    /// <summary>
    /// Подразбиране за локална разработка – SQL Server LocalDB (без инсталация на именуван инстанс).
    /// </summary>
    public const string DefaultConnectionString =
        "Server=(localdb)\\mssqllocaldb;Database=Videoteka;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true";

    public static string GetConnectionString()
    {
        var fromEnv = Environment.GetEnvironmentVariable(EnvironmentVariableName);
        if (!string.IsNullOrWhiteSpace(fromEnv))
            return fromEnv.Trim();

        foreach (var dir in GetSearchDirectories())
        {
            var path = Path.Combine(dir, "appsettings.json");
            if (!File.Exists(path))
                continue;
            var fromFile = TryReadConnectionString(path);
            if (!string.IsNullOrEmpty(fromFile))
                return fromFile;
        }

        return DefaultConnectionString;
    }

    private static IEnumerable<string> GetSearchDirectories()
    {
        yield return AppContext.BaseDirectory;
        yield return Directory.GetCurrentDirectory();

        var location = Assembly.GetExecutingAssembly().Location;
        if (!string.IsNullOrEmpty(location))
        {
            var dir = Path.GetDirectoryName(location);
            if (!string.IsNullOrEmpty(dir))
                yield return dir;
        }
    }

    private static string TryReadConnectionString(string jsonPath)
    {
        try
        {
            using var stream = File.OpenRead(jsonPath);
            using var doc = JsonDocument.Parse(stream);
            if (!doc.RootElement.TryGetProperty("ConnectionStrings", out var cs))
                return null;
            if (!cs.TryGetProperty("DefaultConnection", out var prop))
                return null;
            var s = prop.GetString();
            return string.IsNullOrWhiteSpace(s) ? null : s.Trim();
        }
        catch
        {
            return null;
        }
    }
}
